using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using TPARCHIPERCEPTRON.BLL;
using TPARCHIPERCEPTRON;

namespace TPARCHIPERCEPTRON.DAL
{
    public class IdxReader
    {
        public IdxReader()
        {

        }

        public List<CoordDessin> Extract()
        {
            List<CoordDessin> lstCoord = new List<CoordDessin>();
            try
            {
                FileStream ifsLabels = new FileStream("..\\..\\Data\\t10k-labels.idx1-ubyte",FileMode.Open); // test labels
                FileStream ifsImages = new FileStream("..\\..\\Data\\t10k-images.idx3-ubyte",FileMode.Open); // test images

                BinaryReader brLabels = new BinaryReader(ifsLabels);
                BinaryReader brImages = new BinaryReader(ifsImages);

                int magic1 = brImages.ReadInt32(); // discard
                int numImages = brImages.ReadInt32();
                int numRows = brImages.ReadInt32();
                int numCols = brImages.ReadInt32();

                int magic2 = brLabels.ReadInt32();
                int numLabels = brLabels.ReadInt32();

                byte[][] pixels = new byte[28][];
                for (int i = 0; i < pixels.Length; ++i)
                    pixels[i] = new byte[28];

                // each test image
                for (int di = 0; di < 10000; ++di)
                {
                    for (int i = 0; i < 28; ++i)
                    {
                        for (int j = 0; j < 28; ++j)
                        {
                            byte b = brImages.ReadByte();
                            pixels[i][j] = b;
                        }
                    }

                    byte lbl = brLabels.ReadByte();

                    DigitImage dImage = new DigitImage(pixels, lbl);

                    // Partie modifier
                    string coordonner =  dImage.ToString();

                    CoordDessin cd = new CoordDessin(CstApplication.TAILLEDESSINY, CstApplication.TAILLEDESSINX);

                    string[] sTabElement = new string[coordonner.Length];

                    for (int i = 0; i < coordonner.Length; i++)
                    {
                        sTabElement[i] = coordonner[i].ToString();
                    }

                    for (int x = 0; x < 28; x++)
                    {
                        for (int y = 0; y < 28; y++)
                        {
                            if (Convert.ToInt32(sTabElement[x + (28 * y)]) == 0)
                                cd.AjouterCoordonnees(x * (CstApplication.TAILLEDESSINX / 28), y * (CstApplication.TAILLEDESSINY / 28), CstApplication.LARGEURTRAIT, CstApplication.HAUTEURTRAIT);
                        }
                    }
                    cd.Reponse = dImage.label.ToString();
                    lstCoord.Add(cd);
                } // each image

                ifsImages.Close();
                brImages.Close();
                ifsLabels.Close();
                brLabels.Close();

                return lstCoord;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return lstCoord;
            }
        } // Main
    } // Program

    public class DigitImage
    {
        public byte[][] pixels;
        public byte label;

        public DigitImage(byte[][] pixels,
          byte label)
        {
            this.pixels = new byte[28][];
            for (int i = 0; i < this.pixels.Length; ++i)
                this.pixels[i] = new byte[28];

            for (int i = 0; i < 28; ++i)
                for (int j = 0; j < 28; ++j)
                    this.pixels[i][j] = pixels[i][j];

            this.label = label;
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < 28; ++i)
            {
                for (int j = 0; j < 28; ++j)
                {
                    if (this.pixels[i][j] == 0)
                        s += "1"; // white
                    else if (this.pixels[i][j] == 255)
                        s += "0"; // black
                    else
                        s += "0"; // gray
                }
            }
            return s;
        } // ToString

    }
} // ns




