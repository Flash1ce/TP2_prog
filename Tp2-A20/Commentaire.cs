using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Tp2_A20
{
    public class Commentaire : TreeNode
    {
        #region Attributs

        /// <summary>
        /// Attributs représente le contenu du commentaire.
        /// </summary>
        private string _contenu;

        /// <summary>
        /// Attributs représente le nombre de pouce en haut.
        /// </summary>
        private int _pouceEnHaut;

        /// <summary>
        /// Attributs représente le nombre de pouce en bas.
        /// </summary>
        private int _pouceEnBas;

        /// <summary>
        /// Attributs représente l'auteur du commentaire.
        /// </summary>
        private string _auteur;

        #endregion

        #region Get/Set

        /// <summary>
        /// Get/Set Permet de modifier ou d'obtenir l'auteur du commentaire.
        /// </summary>
        public string Auteur
        {
            get { return _auteur; }
            set { _auteur = value; }
        }

        /// <summary>
        /// Permet de modifier ou d'obtenir le Contenu du commentaire.
        /// </summary>
        public string Contenu
        {
            get { return _contenu; }
            set { _contenu = value; }
        }

        /// <summary>
        /// Permet de modifier ou d'obtenir le nombre de pouces en haut.
        /// </summary>
        public int PouceEnHaut
        {
            get { return _pouceEnHaut; }
            set { _pouceEnHaut = value; }
        }

        /// <summary>
        /// Permet de modifier ou d'obtenir le nombre de pouces en bas.
        /// </summary>
        public int PouceEnBas
        {
            get { return _pouceEnBas; }
            set { _pouceEnBas = value; }
        }

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur vide.
        /// </summary>
        public Commentaire()
        {
        }

        /// <summary>
        /// Constructeur avec paramètre.
        /// </summary>
        /// <param name="pContenu">String représente le contenu</param>
        /// <param name="pAuteur">String, représente l'auteur</param>
        public Commentaire(string pContenu, string pAuteur)
        {
            Contenu = pContenu;
            Auteur = pAuteur;
            PouceEnHaut = 0;
            PouceEnBas = 0;
            Text = ToString();
        }

        #endregion

        #region Methodes

        /// <summary>
        /// Permet d'ajouter un pouce en haut
        /// </summary>
        public void AjouterPouceEnHaut()
        {
            _pouceEnHaut++;
        }

        /// <summary>
        /// Permet d'ajouter un pouce en bas
        /// </summary>
        public void AjouterPouceEnBas()
        {
            _pouceEnBas++;
        }

        /// <summary>
        /// Méthode pour obtenir le score des pouces. pouceHaut - pouceBas
        /// </summary>
        /// <returns>int le "pointage" des pouce (Ration)</returns>
        public int pointagePouce()
        {
            return PouceEnHaut - PouceEnBas;
        }

        /// <summary>
        /// Override du tostring
        /// </summary>
        /// <returns>string "Contenu - auteur - ration pouces"</returns>
        public override string ToString()
        {
            string contenu = Contenu.Substring(0, Math.Min(25, Contenu.Length));

            int pouceMoyenne = pointagePouce();

            return String.Format("{0} - {1} - {2}", contenu, Auteur, pouceMoyenne);
        }

        /// <summary>
        /// Permet de d'acctualiser l'affichage du commentaire.
        /// </summary>
        public void RafraichirAffichage()
        {
            Text = ToString();
            foreach (Commentaire sousCategorie in Nodes)
            {
                sousCategorie.RafraichirAffichage();
            }
        }

        /// <summary>
        /// Permet de trier les commentaire dans le trewviews.
        /// </summary>
        public void TrierTreeView()
        {
            List<Commentaire> lstCommentaires = new List<Commentaire>();
            foreach (Commentaire sousCategorie in Nodes)
            {
                lstCommentaires.Add(sousCategorie);
                if (sousCategorie.Nodes.Count > 0)
                {
                    sousCategorie.TrierTreeView();
                }
            }
            lstCommentaires = Utilitaires.QuickSort(lstCommentaires);

            if (lstCommentaires.Count > 1)
            {
                for (int i = 0; i < lstCommentaires.Count; i++)
                {
                    Nodes.Remove(lstCommentaires[i]);
                    Nodes.Insert(i, lstCommentaires[i]);
                }
            }
        }

        /// <summary>
        /// Permet d'obtenir la liste des noeud des commentaire créé par un utilisateur.
        /// </summary>
        /// <param name="pAuteur">string, auteur du commentaire</param>
        /// <param name="plstElementFiltre">liste de type commentaire des élément filtre</param>
        public void TrouverListNoeud(string pAuteur, List<Commentaire> plstElementFiltre)
        {
            foreach (Commentaire sousCategorie in Nodes)
            {
                if (sousCategorie.Auteur == pAuteur)
                {
                    plstElementFiltre.Add(sousCategorie);
                }
                if (sousCategorie.Nodes.Count > 0)
                {
                    sousCategorie.TrouverListNoeud(pAuteur, plstElementFiltre);
                }
            }
        }

        //// Ce quil aurait fallut faire a la place de la méthode précédente, pour parcourire l'arbre dune meilleur facon.
        //public List<Commentaire> TrouverNoeudParAuteur(string pAuteur)
        //{
        //    List<Commentaire> listRetour = new List<Commentaire>();
        //    // si l'auteur du commentaire est == a l'auteur rechercher ont l'ajoute a la liste
        //    if (Auteur == pAuteur)
        //    {
        //        listRetour.Add(this);
        //    }

        //    // pour chauqe commentaire dans les enfant du commentaire ont rappelle la fonction
        //    foreach (Commentaire commentaire in Nodes)
        //    {
        //        listRetour.AddRange(commentaire.TrouverNoeudParAuteur(pAuteur));
        //    }
        //    return listRetour;
        //}

        /// <summary>
        /// Permet d'exporter les commentaire dans un fichier xml
        /// </summary>
        /// <param name="pSw"></param>
        public virtual void ExporterXML(StreamWriter pSw)
        {
            pSw.WriteLine("<commentaire>");
            pSw.WriteLine("<contenu>" + Contenu + "</contenu>");
            pSw.WriteLine("<auteur>" + Auteur + "</auteur>");
            pSw.WriteLine("<pouceHaut>" + PouceEnHaut + "</pouceHaut>");
            pSw.WriteLine("<pouceBas>" + PouceEnBas + "</pouceBas>");
            foreach (Commentaire elem in Nodes)
            {
                elem.ExporterXML(pSw);
            }
            pSw.WriteLine("</commentaire>");
        }

        #endregion
    }
}