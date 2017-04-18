namespace TPARCHIPERCEPTRON
{
    partial class frmAffichageDessins
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAffichageDessins));
            this.lvDessins = new System.Windows.Forms.ListView();
            this.listeImage = new System.Windows.Forms.ImageList(this.components);
            this.btnActualiser = new System.Windows.Forms.Button();
            this.btnFermer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvDessins
            // 
            resources.ApplyResources(this.lvDessins, "lvDessins");
            this.lvDessins.LargeImageList = this.listeImage;
            this.lvDessins.Name = "lvDessins";
            this.lvDessins.UseCompatibleStateImageBehavior = false;
            // 
            // listeImage
            // 
            this.listeImage.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            resources.ApplyResources(this.listeImage, "listeImage");
            this.listeImage.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnActualiser
            // 
            resources.ApplyResources(this.btnActualiser, "btnActualiser");
            this.btnActualiser.Name = "btnActualiser";
            this.btnActualiser.UseVisualStyleBackColor = true;
            this.btnActualiser.Click += new System.EventHandler(this.btnActualiser_Click);
            // 
            // btnFermer
            // 
            resources.ApplyResources(this.btnFermer, "btnFermer");
            this.btnFermer.Name = "btnFermer";
            this.btnFermer.UseVisualStyleBackColor = true;
            this.btnFermer.Click += new System.EventHandler(this.btnFermer_Click);
            // 
            // frmAffichageDessins
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnFermer);
            this.Controls.Add(this.btnActualiser);
            this.Controls.Add(this.lvDessins);
            this.Name = "frmAffichageDessins";
            this.Load += new System.EventHandler(this.frmAffichageDessins_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvDessins;
        private System.Windows.Forms.Button btnActualiser;
        private System.Windows.Forms.Button btnFermer;
        private System.Windows.Forms.ImageList listeImage;
    }
}