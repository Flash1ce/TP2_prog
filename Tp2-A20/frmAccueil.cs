using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json.Serialization;
using System.IO;
using System.Text.Json;

namespace Tp2_A20
{
    public partial class frmAccueil : Form
    {
        #region Attributs

        /// <summary>
        /// Dictionaire pour les utilisateur
        /// </summary>
        private Dictionary<string, Utilisateur> _dicoUser;

        /// <summary>
        /// Dictionaire pour le Salts
        /// </summary>
        private Dictionary<string, byte[]> _dicoSalts;

        /// <summary>
        /// Attributs qui représente si l'utilisateur est connecter ou non.
        /// </summary>
        private bool _estConnecter;

        /// <summary>
        /// Attributs qui représente le nom de l'utilisateur connecter.
        /// </summary>
        private string _nomUtilisateurConnecter;

        #endregion

        #region Get/Set

        /// <summary>
        /// Get/Set permet de savoir si l'utilisateur est connecter.
        /// </summary>
        public bool EstConnecter
        {
            get { return _estConnecter; }
            set { _estConnecter = value; }
        }

        /// <summary>
        /// Get/Set permet de modifier ou d'obtenir le nom de l'utilisateur connecter.
        /// </summary>
        public string NomUtilisateurConnecter
        {
            get { return _nomUtilisateurConnecter; }
            set { _nomUtilisateurConnecter = value; }
        }

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur du formulaire Acceuil
        /// </summary>
        public frmAccueil()
        {
            InitializeComponent();
            EstConnecter = false;
            this.gbAuthentifie.Visible = false;

            if (File.Exists("user.dat"))
            {
                using (StreamReader sr = new StreamReader("user.dat"))
                {
                    _dicoUser = (Dictionary<string, Utilisateur>)JsonSerializer.Deserialize(sr.ReadToEnd(), typeof(Dictionary<string, Utilisateur>));
                }
            }
            else
            {
                _dicoUser = new Dictionary<string, Utilisateur>();
            }

            if (File.Exists("user.slt"))
            {
                using (StreamReader sr = new StreamReader("user.slt"))
                {
                    _dicoSalts = (Dictionary<string, byte[]>)JsonSerializer.Deserialize(sr.ReadToEnd(), typeof(Dictionary<string, byte[]>));
                }
            }
            else
            {
                _dicoSalts = new Dictionary<string, byte[]>();
            }

            if (File.Exists("publication.xml"))
            {
                Utilitaires.ImportationXML("publication.xml", tvPublications.Nodes);
            }

            ClasserTreeView();
        }

        #endregion

        #region Evenement

        /// <summary>
        /// Permet de créé un compte.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreeCompte_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (this.txtUtilisateur.Text is null || this.txtUtilisateur.Text == "")
            {
                errorProvider1.SetError(txtUtilisateur, "L'utilisateur ne doit pas être vide.");
            }
            else if (this.txtMotDePasse.Text is null || this.txtMotDePasse.Text == "")
            {
                errorProvider1.SetError(txtMotDePasse, "Le mot de passe ne doit pas être vide.");
            }
            else
            {
                if (_dicoUser.ContainsKey(txtUtilisateur.Text))
                {
                    errorProvider1.SetError(txtUtilisateur, "Ce nom d'utilisateur est déja exsistant!");
                }
                else
                {
                    _dicoSalts.Add(txtUtilisateur.Text, Utilitaires.SaltMotDePasse());

                    Utilisateur user = new Utilisateur(txtUtilisateur.Text, Utilitaires.HashMotDePasse(txtMotDePasse.Text, _dicoSalts[txtUtilisateur.Text]));

                    _dicoUser.Add(txtUtilisateur.Text, user);
                }
            }

        }

        /// <summary>
        /// Permet de ce connecter.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (this.txtUtilisateur.Text is null || this.txtUtilisateur.Text == "")
            {
                errorProvider1.SetError(txtUtilisateur, "L'utilisateur ne doit pas être vide.");
            }
            else if (this.txtMotDePasse.Text is null || this.txtMotDePasse.Text == "")
            {
                errorProvider1.SetError(txtMotDePasse, "Le mot de passe ne doit pas être vide.");
            }
            else
            {
                if (_dicoUser.ContainsKey(txtUtilisateur.Text))
                {
                    if (Utilitaires.VerifierMdp(txtMotDePasse.Text, _dicoSalts[txtUtilisateur.Text], _dicoUser[txtUtilisateur.Text].MotDePasse))
                    {
                        this.gbAuthentification.Visible = false;
                        this.gbAuthentifie.Visible = true;

                        EstConnecter = true;
                        NomUtilisateurConnecter = txtUtilisateur.Text;

                        this.gbAuthentifie.Text = "Bonjour " + NomUtilisateurConnecter;
                    }
                    else
                    {
                        errorProvider1.SetError(txtUtilisateur, "Erreur d'authentification");
                        errorProvider1.SetError(txtMotDePasse, "Erreur d'authentification");
                    }
                }
                else
                {
                    errorProvider1.SetError(txtUtilisateur, "Erreur d'authentification");
                    errorProvider1.SetError(txtMotDePasse, "Erreur d'authentification");
                }
            }
        }

        /// <summary>
        /// Permet d'ajouter un pouce vers le haut.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPouceEnHaut_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (EstConnecter == true)
            {
                if (tvPublications.SelectedNode is null)
                {
                    errorProvider1.SetError(btnPouceEnHaut, "Vous devez sélectionner une discusion ou un commentaire.");
                }
                else
                {
                    Commentaire unCommentaire = (Commentaire)tvPublications.SelectedNode;
                    unCommentaire.AjouterPouceEnHaut();
                    ClasserTreeView();
                    tvPublications.SelectedNode = unCommentaire;
                }
            }
            else
            {
                errorProvider1.SetError(btnPouceEnHaut, "Vous devez être connecter.");
            }
        }

        /// <summary>
        /// Permet d'ajouter un pouce vers le bas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPouceEnBas_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (EstConnecter == true)
            {
                if (tvPublications.SelectedNode is null)
                {
                    errorProvider1.SetError(btnPouceEnBas, "Vous devez sélectionner une discusion ou un commentaire.");
                }
                else
                {
                    Commentaire unCommentaire = (Commentaire)tvPublications.SelectedNode;
                    unCommentaire.AjouterPouceEnBas();
                    ClasserTreeView();
                    tvPublications.SelectedNode = unCommentaire;
                }
            }
            else
            {
                errorProvider1.SetError(btnPouceEnBas, "Vous devez être connecter.");
            }
        }

        /// <summary>
        /// Permet d'ajouter une discussion quand le bouton est cliker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDiscussion_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (EstConnecter == true)
            {
                frmAjoutDiscussion formulaireAjout = new frmAjoutDiscussion(NomUtilisateurConnecter);
                if (formulaireAjout.ShowDialog() == DialogResult.OK)
                {
                    Discussion uneDiscussion = formulaireAjout.Discussion;
                    tvPublications.Nodes.Add(uneDiscussion);
                    ClasserTreeView();
                    tvPublications.SelectedNode = uneDiscussion;
                }
            }
            else
            {
                errorProvider1.SetError(btnDiscussion, "Vous devez être connecter.");
            }
        }

        /// <summary>
        /// Permet d'ajouter un commentaire quand le bouton est clicker.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAjoutCommentaire_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (EstConnecter == true)
            {
                if (tvPublications.SelectedNode != null)
                {
                    frmAjoutDiscussion formulaireAjout =
                        new frmAjoutDiscussion(((Commentaire)tvPublications.SelectedNode).Contenu, NomUtilisateurConnecter);
                    if (formulaireAjout.ShowDialog() == DialogResult.OK)
                    {
                        Commentaire unCommentaire = formulaireAjout.Commentaire;
                        tvPublications.SelectedNode.Nodes.Add(unCommentaire);
                        ClasserTreeView();
                        tvPublications.SelectedNode = unCommentaire;
                    }
                }
                else
                {
                    errorProvider1.SetError(btnAjoutCommentaire, "Veuillez sélectionner un commentaire ou une discussion");
                }
            }
            else
            {
                errorProvider1.SetError(btnAjoutCommentaire, "Vous devez être connecter.");
            }
        }

        /// <summary>
        /// Méthode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvPublications_AfterSelect(object sender, TreeViewEventArgs e)
        {
            txtContenu.Text = ((Commentaire)tvPublications.SelectedNode).Contenu;
        }

        /// <summary>
        /// Évènement quand l'élément sélectionner dans lstFiltre change.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstFiltre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstFiltre.SelectedItem != null)
            {
                Commentaire commentaireSelectioner = (Commentaire)this.lstFiltre.SelectedItem;
                RafraichirTreeView();
                tvPublications.SelectedNode = commentaireSelectioner;
            }
        }

        /// <summary>
        /// Évènement quand le bouton FiltrerParCategories est clicker. Permet
        /// de filtrer par les categories.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFiltrerParCategories_Click(object sender, EventArgs e)
        {
            this.lstFiltre.Items.Clear();
            errorProvider1.Clear();
            if (!string.IsNullOrEmpty(this.txtFiltre.Text))
            {
                List<Commentaire> lstElementFiltre = new List<Commentaire>();
                foreach (Commentaire noeudRacine in tvPublications.Nodes)
                {
                    if (((Discussion)noeudRacine).Categorie.ToLower() == this.txtFiltre.Text.ToLower())
                    {
                        lstElementFiltre.Add(noeudRacine);
                    }
                }
                AfficherLstFiltrer(lstElementFiltre);
            }
            else
            {
                errorProvider1.SetError(txtFiltre, "Il doit avoir une catégorie dans le champs.");
            }
        }

        /// <summary>
        /// Évènement quand le bouton FiltrerParUtilisateur est clicker. Permet de
        /// filtrer par l'utilisateur.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFilterParUtilisateur_Click(object sender, EventArgs e)
        {
            this.lstFiltre.Items.Clear();
            errorProvider1.Clear();
            if (!string.IsNullOrEmpty(this.txtFiltre.Text))
            {
                List<Commentaire> lstElementFiltre = new List<Commentaire>();
                foreach (Commentaire noeudRacine in tvPublications.Nodes)
                {
                    if (noeudRacine.Auteur == this.txtFiltre.Text)
                    {
                        lstElementFiltre.Add(noeudRacine);
                    }
                    noeudRacine.TrouverListNoeud(this.txtFiltre.Text, lstElementFiltre);
                }
                AfficherLstFiltrer(lstElementFiltre);
            }
            else
            {
                errorProvider1.SetError(txtFiltre, "Il doit avoir un utilisateur dans le champs.");
            }

        }

        /// <summary>
        /// Méthode qui permet a l'utilisateur de ce déconnecter de l'application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeconnection_Click(object sender, EventArgs e)
        {
            EstConnecter = false;
            NomUtilisateurConnecter = "";
            this.gbAuthentifie.Visible = false;
            this.gbAuthentification.Visible = true;
            this.txtFiltre.Text = "";
            this.lstFiltre.Items.Clear();
            this.txtUtilisateur.Clear();
            this.txtMotDePasse.Clear();
        }

        /// <summary>
        /// Évènement quand l'application ce ferme. Enregistre les données.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAccueil_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("user.dat"))
            {
                sw.Write(JsonSerializer.Serialize(_dicoUser, typeof(Dictionary<string, Utilisateur>)));
            }

            using (StreamWriter sw = new StreamWriter("user.slt"))
            {
                sw.Write(JsonSerializer.Serialize(_dicoSalts, typeof(Dictionary<string, byte[]>)));
            }

            Utilitaires.ExportationXML("publication.xml", tvPublications.Nodes);
        }

        #endregion

        #region Méthode

        /// <summary>
        /// Permet d'acctualiser l'affichage du treeView (le nombre  pouce ect...)
        /// </summary>
        private void RafraichirTreeView()
        {
            foreach (Commentaire noeudRacine in tvPublications.Nodes)
            {
                noeudRacine.RafraichirAffichage();
            }
            tvPublications.Refresh();
            tvPublications.Focus();
        }

        /// <summary>
        /// Permet de classer en ordre les commentaire et les discusion.
        /// </summary>
        private void ClasserTreeView()
        {
            //if (tvPublications.SelectedNode is Discussion)
            //{
            //    // trie des discution tv.nodes
            //}
            //else
            //{
            //    // appelle a un trie dans la class comentaire.
            //    // récupère le parent ou il y a la modification puis trie c'est enfent donc le bon niveau est tié.
            //    // tvPublications.SelectedNode.Parent.MethodeDeTrieDeClass();
            //}

            List<Commentaire> lstDiscustion = new List<Commentaire>();
            foreach (Commentaire noeudRacine in tvPublications.Nodes)
            {
                noeudRacine.TrierTreeView();
                lstDiscustion.Add(noeudRacine);
            }

            lstDiscustion = Utilitaires.QuickSort(lstDiscustion);
            for (int j = 0; j < lstDiscustion.Count; j++)
            {
                int index = tvPublications.Nodes.IndexOf(lstDiscustion[j]);
                tvPublications.Nodes.RemoveAt(index);
                tvPublications.Nodes.Insert(j, lstDiscustion[j]);
            }
            RafraichirTreeView();
        }

        /// <summary>
        /// Permmet d'afficher le résultat du filtre dans la liste.
        /// </summary>
        private void AfficherLstFiltrer(List<Commentaire> plstElementFiltre)
        {
            for (int i = 0; i < plstElementFiltre.Count; i++)
            {
                this.lstFiltre.Items.Add(plstElementFiltre[i]);
            }
        }

        #endregion
    }
}