using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TPARCHIPERCEPTRON.GUI
{
    public partial class frmSourceDonnees : Form
    {
        private int _resultat = 0;
        public frmSourceDonnees()
        {
            InitializeComponent();
        }

        private void btnConfirmer_Click(object sender, EventArgs e)
        {
            if (rdbFichier.Checked == true)
                _resultat = 0;
            if (rdbDatabase.Checked == true)
                _resultat = 1;
            this.Close();
        }

        public int SourceDonnees()
        {
            return _resultat;
        }
    }
}
