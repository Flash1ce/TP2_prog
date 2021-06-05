using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Konscious.Security.Cryptography;
using System.Security.Cryptography;
using System.Linq;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.Json;
using System.Windows.Forms;

namespace Tp2_A20
{
    public static class Utilitaires
    {
        #region Salt et Hash

        /// <summary>
        /// Salt du mot de passe
        /// </summary>
        /// <returns></returns>
        public static byte[] SaltMotDePasse()
        {
            var buffer = new byte[16];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buffer);
            return buffer;
        }

        /// <summary>
        /// Hash du mot de passe
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static byte[] HashMotDePasse(string password, byte[] salt)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = 8,
                Iterations = 4,
                MemorySize = 1024 * 1024
            };

            return argon2.GetBytes(16);
        }

        /// <summary>
        /// Permet de vérifier le mot de passe
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static bool VerifierMdp(string password, byte[] salt, byte[] hash)
        {
            return hash.SequenceEqual(HashMotDePasse(password, salt));
        }

        #endregion

        #region QuicSortCommentaire

        /// <summary>
        /// Permet de classer la liste de commentaire recus en paramètre.
        /// </summary>
        /// <param name="plstCommentaires">liste de commentaire a classer</param>
        /// <returns>List<Commentaire> la liste une fois trier</returns>
        public static List<Commentaire> QuickSort(List<Commentaire> plstCommentaires)
        {
            if (plstCommentaires.Count < 2)
            {
                return plstCommentaires;
            }
            else
            {
                List<Commentaire> lstCommentairesRetour = new List<Commentaire>();
                List<Commentaire> lstCommentairesTempo = new List<Commentaire>();
                List<Commentaire> lstCommentairesPetite = new List<Commentaire>();
                List<Commentaire> lstCommentairesGrande = new List<Commentaire>();
                Commentaire pivot = plstCommentaires[0];

                for (int i = 1; i < plstCommentaires.Count; i++)
                {
                    int plstCommPointage = plstCommentaires[i].pointagePouce();
                    int pivotPointage = pivot.pointagePouce();
                    if (plstCommPointage > pivotPointage)
                    {
                        lstCommentairesGrande.Add(plstCommentaires[i]);
                    }
                    else
                    {
                        if (plstCommPointage <= pivotPointage)
                        {
                            lstCommentairesPetite.Add(plstCommentaires[i]);
                        }
                    }
                }

                lstCommentairesTempo.AddRange(QuickSort(lstCommentairesGrande));
                lstCommentairesTempo.Add(pivot);
                lstCommentairesTempo.AddRange(QuickSort(lstCommentairesPetite));

                for (int i = 0; i < lstCommentairesTempo.Count; i++)
                {
                    lstCommentairesRetour.Add(lstCommentairesTempo[i]);
                }

                return lstCommentairesRetour;
            }
        }

        #endregion

        #region XML

        /// <summary>
        /// Permet d'exporter un fichier XML pour sauvegardé les publications (Disscutions/Commentaires)
        /// </summary>
        /// <param name="pPath">Chemin d'accès</param>
        /// <param name="pPublication">TreeNodeCollection des publications</param>
        public static void ExportationXML(string pPath, TreeNodeCollection pPublication)
        {
            using StreamWriter sw = new StreamWriter(pPath);
            {
                foreach (Discussion noeudRacine in pPublication)
                {
                    noeudRacine.ExporterXML(sw);
                }
            }
        }

        /// <summary>
        /// Permet d'importer un fichier xml ou les publications ont été sauvegardé.
        /// </summary>
        /// <param name="pPath">Chemin d'accès</param>
        /// <param name="pPublication">TreeNodeCollection des publications</param>
        /// <returns></returns>
        public static TreeNodeCollection ImportationXML(string pPath, TreeNodeCollection pPublication)
        {
            Queue<string> maFIle = new Queue<string>();

            using StreamReader sr = new StreamReader(pPath);
            {
                foreach (string elem in sr.ReadToEnd().Split("<"))
                {
                    maFIle.Enqueue(elem.Trim());
                }
            }

            maFIle.Dequeue();

            while (maFIle.Count > 1)
            {
                // ont aurait fait pPublication.Add(ImportationDisscussion(maFIle, pPublication);
                ImportationDiscussion(maFIle, pPublication);
            }

            return pPublication;
        }

        /// <summary>
        /// Méthode qui permet d'importer les discussions du fichier xml
        /// </summary>
        /// <param name="pFile">la file</param>
        /// <param name="pPublication">TreeNodeCollection des publications</param>
        private static void ImportationDiscussion(Queue<string> pFile, TreeNodeCollection pPublication)
        {
            // il aurait fallu return une discussion
            // 174 a 189 ont aurais pus mettre ca dans un autre méthode.
            pFile.Dequeue();
            string titre = pFile.Dequeue().Substring(6);
            pFile.Dequeue();
            string categorie = pFile.Dequeue().Substring(10);
            pFile.Dequeue();
            string contenu = pFile.Dequeue().Substring(8);
            pFile.Dequeue();
            string auteur = pFile.Dequeue().Substring(7);
            pFile.Dequeue();

            Discussion uneDiscussion = new Discussion(contenu, titre, categorie, auteur);

            uneDiscussion.PouceEnHaut = Convert.ToInt32(pFile.Dequeue().Substring(10));
            pFile.Dequeue();
            uneDiscussion.PouceEnBas = Convert.ToInt32(pFile.Dequeue().Substring(9));
            pFile.Dequeue();

            pPublication.Add(uneDiscussion);

            bool commPresent = true;
            while (commPresent)
            {
                if (pFile.Peek() == "commentaire>")
                {
                    // et faire a place
                    //uneDiscussion.Nodes.Add(ImportationCommentaire(pFile, pPublication));
                    ImportationCommentaire(pFile, pPublication);
                }
                else
                {
                    commPresent = false;
                }
            }

            pFile.Dequeue();
        }

        /// <summary>
        /// Permet d'importer les commenraires du fichier xml
        /// </summary>
        /// <param name="pFile">la file</param>
        /// <param name="pPublication">TreeNodeCollection des publications</param>
        private static void ImportationCommentaire(Queue<string> pFile, TreeNodeCollection pPublication)
        {
            // il aurait fallut return un commentaire

            // ligne 221 a 233 ont aurait pus mettre ca dans un autre methode
            Commentaire unCommentaire;
            pFile.Dequeue();
            string contenu = pFile.Dequeue().Substring(8);
            pFile.Dequeue();
            string auteur = pFile.Dequeue().Substring(7);
            pFile.Dequeue();

            unCommentaire = new Commentaire(contenu, auteur);

            unCommentaire.PouceEnHaut = Convert.ToInt32(pFile.Dequeue().Substring(10));
            pFile.Dequeue();
            unCommentaire.PouceEnBas = Convert.ToInt32(pFile.Dequeue().Substring(9));
            pFile.Dequeue();

            // ont aurait pus enlever ca, grace au autre modification.
            int index = pPublication.Count;
            pPublication[index - 1].Nodes.Add(unCommentaire);
            bool commPresent = true;
            while (commPresent)
            {
                if (pFile.Peek() == "commentaire>")
                {
                    ImportationCommentaire(pFile, pPublication[index - 1].Nodes);
                }
                else
                {
                    commPresent = false;
                }
            }

            pFile.Dequeue();
        }

        #endregion
    }
}