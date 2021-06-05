using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tp2_A20
{
    public partial class frmAjoutDiscussion : Form
    {
        #region Attributs

        private Discussion _discussion;
        private Commentaire _commentaire;
        private bool _bAjoutCommentaire;
        private string _auteur;

        #endregion

        #region Get/Set

        /// <summary>
        /// Get/Set représente l'auteur
        /// </summary>
        public string Auteur
        {
            get { return _auteur; }
            set { _auteur = value; }
        }

        /// <summary>
        /// Get représente le commentaire
        /// </summary>
        public Commentaire Commentaire
        {
            get { return _commentaire; }
        }

        /// <summary>
        /// Get représente la discution
        /// </summary>
        public Discussion Discussion
        {
            get { return _discussion; }
        }

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur qui prend en paramètre l'auteur
        /// </summary>
        /// <param name="pAuteur">Représente l'auteur</param>
        public frmAjoutDiscussion(string pAuteur)
        {
            InitializeComponent();
            _bAjoutCommentaire = false;
            Auteur = pAuteur;
        }

        /// <summary>
        /// Constructeur qui prend en paramètre le contenu et l'auteur.
        /// </summary>
        /// <param name="pContenu">Représente le contenu</param>
        /// <param name="pAuteur">Représente l'auteur</param>
        public frmAjoutDiscussion(string pContenu, string pAuteur)
        {
            InitializeComponent();
            txtTitre.Text = pContenu.Substring(0, Math.Min(50, pContenu.Length));
            txtTitre.Enabled = false;
            txtCatégorie.Enabled = false;
            _bAjoutCommentaire = true;
            this.btnSauvegarder.Text = "Ajouter le commentarie";

            Auteur = pAuteur;
        }

        #endregion

        #region Évènement

        /// <summary>
        /// Evènement quand le bouton Sauvegarder est clicker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSauvegarder_Click(object sender, EventArgs e)
        {
            bool bValide = true;

            if (txtTitre.Text.Trim().Length < 3)
            {
                errorProvider1.SetError(txtTitre, "Votre titre doit comporter au moins 3 caractères");
                bValide = false;
            }

            if (!_bAjoutCommentaire && txtCatégorie.Text.Trim().Length < 3)
            {
                errorProvider1.SetError(txtCatégorie, "Votre catégorie doit comporter au moins 3 caractères");
                bValide = false;
            }

            if (txtContenu.Text.Trim().Length < 3)
            {
                errorProvider1.SetError(txtContenu, "Votre contenu doit comporter au moins 3 caractères");
                bValide = false;
            }

            if (bValide)
            {
                if (_bAjoutCommentaire)
                {
                    _commentaire = new Commentaire( txtContenu.Text, Auteur);
                }
                else
                {
                    _discussion = new Discussion( txtContenu.Text, txtTitre.Text, txtCatégorie.Text, Auteur);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        #endregion
    }
}