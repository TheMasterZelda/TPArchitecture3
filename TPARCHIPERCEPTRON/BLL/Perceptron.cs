using System;
using System.Collections;
using System.Collections.Generic;

namespace TPARCHIPERCEPTRON.BLL
{
    /// <summary>
    /// Classe du perceptron. Permet de faire l'apprentissage automatique sur un échantillon d'apprentissage. 
    /// </summary>
    public class Perceptron
    {
        private double _cstApprentissage;
        private double[] _poidsSyn;
        private string _reponse = "?";

        public string Reponse
        {
            get { return _reponse; }
        }

        /// <summary>
        /// Constructeur de la classe. Crée un perceptron pour une réponse(caractère) qu'on veut identifier le pattern(modèle)
        /// </summary>
        /// <param name="reponse">La classe que défini le perceptron</param>
        public Perceptron(string reponse)
        {
            _cstApprentissage = CstApplication.CONSTANTEAPPRENTISSAGE;
            _reponse = reponse;
        }

        /// <summary>
        /// Faire l'apprentissage sur un ensemble de coordonnées. Ces coordonnées sont les coordonnées de tous les caractères analysés. 
        /// </summary>
        /// <param name="lstCoord">La liste de coordonnées pour les caractères à analysés.</param>
        /// <returns>Les paramètres de la console</returns>
        public string Entrainement(List<CoordDessin> lstCoord)
        {
            Random r = new Random();
            string resultat = "";
            int iNbIterration = 0;
            int iNbErreur = 0;
            int iTaillePoid = (CstApplication.NOMBRE_BITS_X * CstApplication.NOMBRE_BITS_Y) + 1;
            _poidsSyn = new double[iTaillePoid];

            for (int i = 0; i < iTaillePoid; i++)
            {
                _poidsSyn[i] = r.NextDouble();
            }

            do
            {
                iNbErreur = 0;
                foreach (var c in lstCoord)
                {
                    int iValeurEstime = ValeurEstime(_poidsSyn, c.BitArrayDessin);
                    int iVraieValeur = c.Reponse == _reponse ? CstApplication.FAUX : CstApplication.VRAI;

                    if (iValeurEstime != iVraieValeur)
                    {
                        iNbErreur++;
                        _poidsSyn[0] += _cstApprentissage * (iVraieValeur - iValeurEstime);
                        for (int j = 1; j < _poidsSyn.Length; j++)
                        {
                            _poidsSyn[j] += _cstApprentissage * (iVraieValeur - iValeurEstime) * (c.BitArrayDessin[j - 1] ? CstApplication.FAUX : CstApplication.VRAI);
                        }
                    }
                }

                iNbIterration++;
            } while (iNbErreur != 0 && iNbIterration < CstApplication.MAXITERATION && ((((double)(lstCoord.Count - iNbErreur) / (double)(lstCoord.Count * 100.0d)) * 10000.0d)) < CstApplication.POURCENTCONVERGENCE) ;

           resultat += $"Le pourcentage de réussite est de {((double)(lstCoord.Count - iNbErreur) / (double)(lstCoord.Count * 100.0d)) * 10000.0d} pour {Reponse} avec {iNbIterration} iterration et {iNbErreur} erreur\r\n";

            return resultat;
        }

        /// <summary>
        /// Calcul la valeur(vrai ou faux) pour un les coordonnées d'un caractère. Permet au perceptron d'évaluer la valeur de vérité.
        /// </summary>
        /// <param name="vecteurSyn">Les poids synaptiques du perceptron</param>
        /// <param name="entree">Le vecteur de bit correspondant aux couleurs du caractère</param>
        /// <returns>Vrai ou faux</returns>
        public int ValeurEstime(double[] vecteurSyn, BitArray entree)
        {
            double sum = vecteurSyn[0];

            for (int i = 1; i < vecteurSyn.Length; i++)
            {
                sum += vecteurSyn[i] * (entree[i - 1] ? CstApplication.FAUX : CstApplication.VRAI);
            }
            return (sum >= 0) ? CstApplication.VRAI : CstApplication.FAUX;
        }

        /// <summary>
        /// Interroge la neuronnes pour un ensembles des coordonnées(d'un caractère).
        /// </summary>
        /// <param name="coord"></param>
        /// <returns></returns>
        public bool TesterNeurone(CoordDessin coord)
        {
            double sum = _poidsSyn[0];

            for (int i = 1; i < _poidsSyn.Length; i++)
            {
                sum += _poidsSyn[i] * (coord.BitArrayDessin[i - 1] ? CstApplication.FAUX : CstApplication.VRAI);
            }

            return (sum >= 0) ? false : true;
        }

    }
}
