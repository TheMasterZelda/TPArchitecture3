using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using TPARCHIPERCEPTRON.BLL;

namespace TPARCHIPERCEPTRON
{
    /// <summary>
    /// Auteur:      Michael Tran
    /// Date:        06-04-2014
    /// Description: Cette Form permet de voir les dessins dans le gestionnaire des perceptrons. 
    /// </summary>
    public partial class frmAffichageDessins : Form
    {
        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public frmAffichageDessins()
        {
            InitializeComponent();

            listeImage.ImageSize = new Size(CstApplication.TAILLEDESSINX, CstApplication.TAILLEDESSINY);
            listeImage.ColorDepth = ColorDepth.Depth8Bit;
        }

        /// <summary>
        /// Contient le gestionnaire des perceptrons.
        /// </summary>
        public GestionClassesPerceptrons GestionnairePerceptron { get; set; }

        /// <summary>
        /// Crée une image représentant le BitArray passé en paramètre.
        /// </summary>
        /// <param name="bitArray">Le BitArray à partir duqel générer une image.</param>
        /// <returns>Un Bitmap représentant le BitArray.</returns>
        Bitmap CreerImageBitArray(BitArray bitArray)
        {
            Bitmap bitmap = new Bitmap(listeImage.ImageSize.Width, listeImage.ImageSize.Height, PixelFormat.Format8bppIndexed);

            // Préparer une "palette" de gris.
            ColorPalette palette = bitmap.Palette;
            for (int i = 0; i < 256; i++)
            {
                int valeur = 256 - i - 1;
                palette.Entries[i] = Color.FromArgb(valeur, valeur, valeur);
            }
            bitmap.Palette = palette;

            // Verrouiller le bitmap en mémoire pour pouvoir accéder aux pixels.
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
            // Allouer un buffer ayant la bonne stride pour être aligné sur un DWORD(4 octets), ce qui est demandé par le format bitmap.
            byte[] buffer = new byte[bitmapData.Stride * bitmapData.Height];

            for (int y = 0; y < CstApplication.NOMBRE_BITS_Y; y++)
            {
                for (int x = 0; x < CstApplication.NOMBRE_BITS_X; x++)
                {
                    byte valeur = bitArray[x * CstApplication.NOMBRE_BITS_X + y] ? (byte)255 : (byte)0;

                    // Setter tous les pixels correspondant à la position dans le BitArray sur le bitmap.
                    // (16 * 16 pour le BitArray vers 64 * 64 pour le bitmap)
                    for (int py = 0; py < CstApplication.LARGEURTRAIT; py++)
                    {
                        for (int px = 0; px < CstApplication.HAUTEURTRAIT; px++)
                        {
                            buffer[((y * CstApplication.HAUTEURTRAIT) + py) * bitmapData.Stride + x * CstApplication.LARGEURTRAIT + px] = valeur;
                        }
                    }
                }
            }

            // Copier les pixels dans le buffer et déverrouiller le bitmap
            // pour appliquer les changements.
            Marshal.Copy(buffer, 0, bitmapData.Scan0, buffer.Length);
            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }

        /// <summary>
        /// Remplit le ListView des dessins du perceptron.
        /// </summary>
        void RemplirListView()
        {
            listeImage.Images.Clear();
            lvDessins.Items.Clear();
            int count = 0;
            List<Bitmap> images = new List<Bitmap>();
            foreach (CoordDessin item in GestionnairePerceptron.ObtenirCoordonnees())
            {
                // Pour éviter de freeze si trop grand nombre
                if (++count >= 1000)
                    break;
                
                Bitmap bitmap = CreerImageBitArray(item.BitArrayDessin);
                images.Add(bitmap);
                listeImage.Images.Add(bitmap);
                lvDessins.Items.Add(new ListViewItem(item.Reponse)
                {
                    ImageIndex = listeImage.Images.Count - 1,
                });
            }

            // Forcer la copie immédiate des images.
            IntPtr dummy = listeImage.Handle;
            // Disposer des copies.
            foreach (Bitmap image in images)
            {
                image.Dispose();
            }
            images.Clear();
        }

        /// <summary>
        /// Appelé lors de l'appui du bouton "Actualiser".
        /// Regnère les dessins dans la ListView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnActualiser_Click(object sender, EventArgs e)
        {
            RemplirListView();
        }

        /// <summary>
        /// Appelé lors du chargement de la Form.
        /// Genère les dessins dans la ListView.
        /// </summary>
        /// <param name="sender">L'objet qui à envoyé cet événement.</param>
        /// <param name="e">Les arguments de cet événement.</param>
        private void frmAffichageDessins_Load(object sender, EventArgs e)
        {
            RemplirListView();
        }

        /// <summary>
        /// Appelé lors de l'appui du bouton "Fermer".
        /// Ferme cette Form.
        /// </summary>
        /// <param name="sender">L'objet qui à envoyé cet événement.</param>
        /// <param name="e">Les arguments de cet événement.</param>
        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
