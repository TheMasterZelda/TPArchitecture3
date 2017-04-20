using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using TPARCHIPERCEPTRON.BLL;

namespace TPARCHIPERCEPTRON.DAL
{
    /// <summary>
    /// Cette classe gère l'accès aux disques pour le fichiers d'apprentissages. 
    /// Permet de charger ou décharger dans la matrice d'apprentissage.
    /// </summary>
    public class GestionFichiersSorties
    {
        private List<CoordDessin> _lstCoord;
        /// <summary>
        /// Permet d'extraire un fichier texte dans une matrice pour l'apprentissage automatique.
        /// </summary>
        public List<CoordDessin> ChargerCoordonnees()
        {
            _lstCoord = new List<CoordDessin>();
            string sFichier = ConfigurationManager.AppSettings["FichierApprentissage"];
            StreamReader sr = new StreamReader(new FileStream(sFichier, FileMode.Open, FileAccess.Read));
            string sLigne = "";
            string[] sTabElement;
            int iTailleArray = 0;
            int iNbCoord = 0;

            if (!sr.EndOfStream)
            {
                sLigne = sr.ReadLine();
                iTailleArray = Convert.ToInt32(sLigne);
                sLigne = sr.ReadLine();
                iNbCoord = Convert.ToInt32(sLigne);
            }

            if (iTailleArray != CstApplication.NOMBRE_BITS_X * CstApplication.NOMBRE_BITS_Y)
            {
                return _lstCoord;
            }

            if (!sr.EndOfStream)
            {
                for (int i = 0; i < iNbCoord; i++)
                {
                    sLigne = sr.ReadLine();
                    sTabElement = sLigne.Split('\t');
                    CoordDessin cd = new CoordDessin(CstApplication.LARGEURTRAIT, CstApplication.HAUTEURTRAIT);
                    for (int x = 0; x < CstApplication.NOMBRE_BITS_X; x++)
                    {
                        for (int y = 0; y < CstApplication.NOMBRE_BITS_Y; y++)
                        {
                            if (Convert.ToInt32(sTabElement[x + (CstApplication.NOMBRE_BITS_X * y)]) == CstApplication.VRAI)
                                cd.AjouterCoordonnees(x, y, CstApplication.LARGEURTRAIT, CstApplication.HAUTEURTRAIT);
                        }
                    }
                    cd.Reponse = sTabElement[sTabElement.Length - 1];
                    _lstCoord.Add(cd);
                }
            }
            //À COMPLÉTER
            return _lstCoord;
        }

        /// <summary>
        /// Permet de sauvegarder dans fichier texte dans une matrice pour l'apprentissage automatique
        /// </summary>
        public int SauvegarderCoordonnees(List<CoordDessin> lstCoord)
        {
            try
            {
                string sFichier = ConfigurationManager.AppSettings["FichierApprentissage"];
                StreamWriter sw = new StreamWriter(new FileStream(sFichier, FileMode.Open, FileAccess.Write));

                sw.WriteLine(CstApplication.NOMBRE_BITS_X * CstApplication.NOMBRE_BITS_Y);
                sw.WriteLine(lstCoord.Count);

                foreach (CoordDessin cd in lstCoord)
                {
                    string sLigne = "";

                    foreach (bool bit in cd.BitArrayDessin)
                    {
                        sLigne += bit ? CstApplication.VRAI : CstApplication.FAUX;
                        sLigne += "\t";
                    }
                    sLigne += cd.Reponse;
                    sw.WriteLine(sLigne);
                }

                return CstApplication.OK;
            }
            catch (Exception ex)
            {
                return CstApplication.ERREUR;
            }
        }

        /// <summary>
        /// Permet d'extraire un fichier texte dans une matrice pour l'apprentissage automatique.
        /// </summary>
        public IList<CoordDessin> ObtenirCoordonnees()
        {

            return _lstCoord;
        }


        /// <summary>
        /// Permet de mélanger aléatoirement les échantillons d'apprentissages(coordonnées) dans le but d'améliorer l'apprentissage.
        /// </summary>
        /// <param name="lstCoord">Les coordonnées à mélanger</param>
        private void MelangerEchantillon(List<CoordDessin> lstCoord)
        {
            Random r1 = new Random();
            Random r2 = new Random();
            int index1;
            int index2;
            CoordDessin coordTemp;

            for (int i = 0; i < CstApplication.MAXITERATION; i++)
            {
                index1 = r1.Next(lstCoord.Count);
                index2 = r2.Next(lstCoord.Count);

                coordTemp = lstCoord[index1];
                lstCoord[index1] = lstCoord[index2];
                lstCoord[index2] = coordTemp;
            }
        }

    }

}
