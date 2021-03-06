﻿using System.Collections.Generic;
using TPARCHIPERCEPTRON.DAL;

namespace TPARCHIPERCEPTRON.BLL
{
    /// <summary>
    /// Gère les fonctionnalités de l'application. Entre autre, permet de :
    /// - Charger les échantillons d'apprentissage,
    /// - Sauvegarder les échantillons d'apprentissage,
    /// - Tester le perceptron
    /// - Entrainer le perceptron
    /// </summary>
    public class GestionClassesPerceptrons
    {
        private Dictionary<string, Perceptron> _lstPerceptrons;
        private GestionFichiersSorties _gestionSortie;

        /// <summary>
        /// Constructeur
        /// </summary>
        public GestionClassesPerceptrons(int source)
        {
            _lstPerceptrons = new Dictionary<string, Perceptron>();
            _gestionSortie = new GestionFichiersSorties(source);

            //À COMPLÉTER
            ChargerCoordonnees();
        }

        /// <summary>
        /// Charge les échantillons d'apprentissage sauvegardé sur le disque.
        /// </summary>
        public void ChargerCoordonnees()
        {
            _gestionSortie.ChargerCoordonnees();
            List<CoordDessin> lstCoord = ObtenirCoordonnees() as List<CoordDessin>;
            foreach (CoordDessin cd in lstCoord)
            {
                if (!_lstPerceptrons.ContainsKey(cd.Reponse))
                {
                    _lstPerceptrons.Add(cd.Reponse, new Perceptron(cd.Reponse));
                }
            }
        }

        /// <summary>
        /// Sauvegarde les échantillons d'apprentissage sauvegardé sur le disque.
        /// </summary>
        /// <returns>En cas d'erreur retourne le code d'erreur</returns>
        public int SauvegarderCoordonnees()
        {
            //À COMPLÉTER
            List<CoordDessin> lstCoord = _gestionSortie.ObtenirCoordonneesOriginale() as List<CoordDessin>;
            int erreur = _gestionSortie.SauvegarderCoordonnees(lstCoord);
            return erreur;
        }

        /// <summary>
        /// Entraine les perceptrons avec un nouveau caractère
        /// </summary>
        /// <param name="coordo">Les nouvelles coordonnées</param>
        /// <param name="reponse">La réponse associé(caractère) aux coordonnées</param>
        /// <returns>Le résultat de la console</returns>
        public string Entrainement(CoordDessin coordo, string reponse)
        {
            string sConsole = "";
            if (!_lstPerceptrons.ContainsKey(reponse))
            {
                _lstPerceptrons.Add(reponse, new Perceptron(reponse));
            }
            coordo.Reponse = reponse;
            List<CoordDessin> lstCoord = ObtenirCoordonnees() as List<CoordDessin>;//new List<CoordDessin>();
            lstCoord.Add(coordo);
            foreach (var c in _lstPerceptrons)
            {
                sConsole += c.Value.Entrainement(lstCoord);
            }
            // Pour ne pas enregistrer la base de donnée de Yann
            List<CoordDessin> lst = _gestionSortie.ObtenirCoordonneesOriginale() as List<CoordDessin>;
            lst.Add(coordo);
            _gestionSortie.SauvegarderCoordonnees(lst);
            return sConsole;
        }


        /// <summary>
        /// Test le perceptron avec de nouvelles coordonnées.
        /// </summary>
        /// <param name="coord">Les nouvelles coordonnées</param>
        /// <returns>Retourne la liste des valeurs possibles du perceptron</returns>
        public string TesterPerceptron(CoordDessin coord)
        {
            string resultat = "";

            foreach (var p in _lstPerceptrons)
            {
                if (p.Value.TesterNeurone(coord))
                    resultat += p.Key + ' ';
            }

            if (resultat == "")
                resultat = "?";

            return resultat;
        }

        /// <summary>
        /// Obtient une liste des coordonées.
        /// </summary>
        /// <returns>Une liste des coordonées.</returns>
        public IList<CoordDessin> ObtenirCoordonnees()
        {
            return _gestionSortie.ObtenirCoordonnees();
        }

        public void SetYann(bool state)
        {
            _gestionSortie.SetYann(state);
        }
    }
}
