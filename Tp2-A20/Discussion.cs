using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Tp2_A20
{
    public class Discussion : Commentaire
    {
        #region Attributs

        /// <summary>
        /// Attributs représente le titre de la discution.
        /// </summary>
        private string _titre;

        /// <summary>
        /// Attributs représente la catégorie de la discution.
        /// </summary>
        private string _categorie;

        #endregion

        #region Get/Set

        /// <summary>
        /// Get/Set permet de modifier ou d'obtenir la Categorie.
        /// </summary>
        public string Categorie
        {
            get { return _categorie; }
            set { _categorie = value; }
        }

        /// <summary>
        /// Permet de modifier ou d'obtenir le Titre.
        /// </summary>
        public string Titre
        {
            get { return _titre; }
            set { _titre = value; }
        }

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur par défault
        /// </summary>
        public Discussion()
        {
        }

        /// <summary>
        /// Constructeur avec paramètre.
        /// </summary>
        /// <param name="pContenu">String contenue de la disscussion.</param>
        /// <param name="pTitre">String titre de la disscussion.</param>
        /// <param name="pCategorie">String categorie de la disscussion.</param>
        /// <param name="pAuteur">String auteur de la disscussion.</param>
        public Discussion(string pContenu, string pTitre, string pCategorie, string pAuteur) : base(pContenu, pAuteur)
        {
            Titre = pTitre;
            Categorie = pCategorie;
        }

        #endregion

        #region Methodes

        /// <summary>
        /// Permet d'exporter les discution dans un fichier xml
        /// </summary>
        /// <param name="pSw"></param>
        public override void ExporterXML(StreamWriter pSw)
        {
            pSw.WriteLine("<discussion>");
            pSw.WriteLine("<titre>" + Titre +"</titre>");
            pSw.WriteLine("<categorie>" + Categorie + "</categorie>");
            pSw.WriteLine("<contenu>" + Contenu + "</contenu>");
            pSw.WriteLine("<auteur>" + Auteur + "</auteur>");
            pSw.WriteLine("<pouceHaut>" + PouceEnHaut + "</pouceHaut>");
            pSw.WriteLine("<pouceBas>" + PouceEnBas + "</pouceBas>");
            foreach (Commentaire elem in Nodes)
            {
                elem.ExporterXML(pSw);
            }
            pSw.WriteLine("</discussion>");
        }

        #endregion
    }
}