using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Tp2_A20
{
    [Serializable]
    public class Utilisateur
    {
        #region Attributs

        /// <summary>
        /// Attributs représente le nom
        /// </summary>
        private string _nom;

        /// <summary>
        /// Attributs représente le mot de passe
        /// </summary>
        private byte[] _MotDePasse;

        #endregion

        #region Get/Set

        /// <summary>
        /// Get/Set permet de modifier ou d'obtenir le nom de l'utilisateur
        /// </summary>
        public string NomUtilisateur
        {
            get { return _nom; }
            set { _nom = value; }
        }

        /// <summary>
        /// Get/Set permet de modifier ou d'obtenir le mot de passe.
        /// </summary>
        public byte[] MotDePasse
        {
            get { return _MotDePasse; }
            set { _MotDePasse = value; }
        }

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur par défault
        /// </summary>
        public Utilisateur()
        {
        }

        /// <summary>
        /// Constructeur avec paramètre
        /// </summary>
        /// <param name="pNomUtilisateur">string nom de l'utilisateur</param>
        /// <param name="pMotDePasse">byte[] mot de passe</param>
        public Utilisateur(string pNomUtilisateur, byte[] pMotDePasse)
        {
            NomUtilisateur = pNomUtilisateur;
            MotDePasse = pMotDePasse;
        }

        #endregion
    }
}