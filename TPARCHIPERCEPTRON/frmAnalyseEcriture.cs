using System;
using System.Configuration;
using System.Windows.Forms;

using System.Globalization;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;

namespace TPARCHIPERCEPTRON
{
    /// <summary>
    /// Permet d'afficher l'interface pour la reconnaissance de caractères. 
    /// Cet interface fera appel au Perceptron pour identifier le caractère dessiné.
    /// </summary>
    public partial class frmAnalyseEcriture : Form
    {
        // Le gestionnaire des perceptrons.
        private GestionClassesPerceptrons _gcpAnalyseEcriture;

        // La liste contenant les items de menu correspodant aux langues.
        private List<ToolStripMenuItem> _langues = new List<ToolStripMenuItem>();
        // Si un changement de langue est en cours.
        // Évite le changement récursif de la propriété Checked.
        private bool _changementLangueCourante = false;
        // La langue cochée.
        private ToolStripMenuItem _langueCourante = null;

        // Représente une instance de la fenêtre des dessins.
        // Sert à autoriser une instance de la boîte de dialogue.
        private frmAffichageDessins _instanceDessinsForm = null;

        /// <summary>
        /// Constructeur de la form. Initialise les composants
        /// </summary>
        public frmAnalyseEcriture()
        {
            InitializeComponent();

            ucDessin.Width = CstApplication.TAILLEDESSINX;
            ucDessin.Height = CstApplication.TAILLEDESSINY;

            _gcpAnalyseEcriture = new GestionClassesPerceptrons();
            //À COMPLÉTER   
        }


        /// <summary>
        /// Entraine le bon Perceptron avec la valeur entrée dans le TextBox txtValeurEntrainee et le caractère dessiné.
        /// </summary>
        /// <param name="sender">L'objet qui à envoyé cet événement.</param>
        /// <param name="e">Les arguments de cet événement.</param>
        private void btnEntrainement_Click(object sender, EventArgs e)
        {
            //À COMPLÉTER
        }

        /// <summary>
        /// Appel le perceptron pour vérifier quel neuronne identifie le mieux le caractère dessiné.
        /// </summary>
        /// <param name="sender">L'objet qui à envoyé cet événement.</param>
        /// <param name="e">Les arguments de cet événement.</param>
        private void btnTest_Click(object sender, EventArgs e)
        {
            //À COMPLÉTER
        }

        /// <summary>
        /// Efface le caractère dessiné et sa matrice.
        /// </summary>
        /// <param name="sender">L'objet qui à envoyé cet événement.</param>
        /// <param name="e">Les arguments de cet événement.</param>
        private void btnEffacer_Click(object sender, EventArgs e)
        {
            ucDessin.EffacerDessin();
        }

        /// <summary>
        /// Lors de la fermeture de la form, enregistré les données des perceptrons.
        /// </summary>
        /// <param name="sender">L'objet qui à envoyé cet événement.</param>
        /// <param name="e">Les arguments de cet événement.</param>
        private void frmAnalyseEcriture_FormClosing(object sender, FormClosingEventArgs e)
        {
            //À COMPLÉTER
        }

        /// <summary>
        /// Ajoute une langue au menu des langues.
        /// </summary>
        /// <param name="culture">La culture correspondant à la langue à ajouter.</param>
        private void AjouterLangue(CultureInfo culture)
        {
            ToolStripMenuItem itemMenu = new ToolStripMenuItem(culture.NativeName)
            {
                Tag = culture
            };
            tsmiLangue.DropDownItems.Add(itemMenu);
            _langues.Add(itemMenu);
        }

        /// <summary>
        /// Appelé lors du chargement de la Form.
        /// Sert à ajouter les langues dans le menu de la langue.
        /// </summary>
        /// <param name="sender">L'objet qui à envoyé cet événement.</param>
        /// <param name="e">Les arguments de cet événement.</param>
        private void frmAnalyseEcriture_Load(object sender, EventArgs e)
        {
            AjouterLangue(CultureInfo.GetCultureInfo("fr"));
            AjouterLangue(CultureInfo.GetCultureInfo("en"));
            _langues[0].Checked = true;
        }

        /// <summary>
        /// Appelé lors de l'appui du bouton "Afficher les dessins".
        /// Affiche la fenêtre des dessins.
        /// </summary>
        /// <param name="sender">L'objet qui à envoyé cet événement.</param>
        /// <param name="e">Les arguments de cet événement.</param>
        private void tsmiAfficherDessins_Click(object sender, EventArgs e)
        {
            // Si la fenêtre n'est pas encore ouverte, la créer.
            if (_instanceDessinsForm == null)
            {
                frmAffichageDessins nouvelleForm = new frmAffichageDessins();
                nouvelleForm.GestionnairePerceptron = _gcpAnalyseEcriture;

                // Ajouter un événement qui met _instanceDessinsForm à null lorsque
                // cette fenêtre se ferme.
                _instanceDessinsForm = nouvelleForm;
                nouvelleForm.FormClosed += (s, ea) => _instanceDessinsForm = null;

                nouvelleForm.Show();
            }

            // Amener la fenêtre existante ou nouvellement crée
            // en avant-plan.
            _instanceDessinsForm.BringToFront();
        }
    }
}
