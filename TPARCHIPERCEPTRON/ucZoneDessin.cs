using System;
using System.Drawing;
using System.Windows.Forms;

namespace TPARCHIPERCEPTRON
{
    /// <summary>
    /// Contrôle utilisateur qui permet de créer une petite interface pour dessiner un caractère. 
    /// </summary>
    public partial class ucZoneDessin : UserControl
    {
        private CoordDessin _coordonnees;
        private Graphics _objGraphics;

        private bool _doitDessiner = false; // determines whether to paint
        private int _largeur;
        private int _hauteur;


        public CoordDessin Coordonnees
        {
            get { return _coordonnees; }
        }

        /// <summary>
        /// Constructeur. Initialise la zone de dessin.
        /// </summary>
        public ucZoneDessin()
        {
            InitializeComponent();

            _largeur = CstApplication.TAILLEDESSINY;
            _hauteur = CstApplication.TAILLEDESSINX;
            pZoneDessin.Image = new Bitmap(_largeur, _hauteur);
            _objGraphics = Graphics.FromImage(pZoneDessin.Image);
            _coordonnees = new CoordDessin(_largeur, _hauteur);
        }

        /// <summary>
        /// Si l'utilisateur à cliqué, enclenché le processus de dessin pour le MouseMove.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pZoneDessin_MouseDown(object sender, MouseEventArgs e)
        {
            
            _doitDessiner = true;
        }

        /// <summary>
        /// Si l'utilisateur a préalablement cliqué, alors dessiner à la position de la souris.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pZoneDessin_MouseMove(object sender, MouseEventArgs e)
        {
            if (_doitDessiner)
            {
                int coordCorrigeX = e.X - (e.X % CstApplication.LARGEURTRAIT);
                int coordCorrigeY = e.Y - (e.Y % CstApplication.HAUTEURTRAIT);
                _objGraphics.FillRectangle(new SolidBrush(Color.Black), coordCorrigeX, coordCorrigeY, CstApplication.LARGEURTRAIT, CstApplication.HAUTEURTRAIT);
                _objGraphics.Save();
                pZoneDessin.Refresh();
                _coordonnees.AjouterCoordonnees(coordCorrigeX, coordCorrigeY, CstApplication.LARGEURTRAIT, CstApplication.HAUTEURTRAIT);
            }
        }

        /// <summary>
        /// Ré-initialise le dessin et les composants.
        /// </summary>
        public void EffacerDessin()
        {
            _coordonnees = new CoordDessin(_largeur, _hauteur);
            _objGraphics.Clear(pZoneDessin.BackColor);
            pZoneDessin.Refresh();
            _coordonnees = new CoordDessin(_largeur, _hauteur);

        }

        /// <summary>
        /// Cette méthode permet d'arrêter le dessin lorsque l'utilisateur à lâché le bouton de la souris.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pZoneDessin_MouseUp(object sender, MouseEventArgs e)
        {
            _doitDessiner = false;
        }
    }
}

