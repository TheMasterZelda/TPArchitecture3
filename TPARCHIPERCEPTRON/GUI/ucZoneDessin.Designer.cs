namespace TPARCHIPERCEPTRON
{
    partial class ucZoneDessin
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.pZoneDessin = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pZoneDessin)).BeginInit();
            this.SuspendLayout();
            // 
            // pZoneDessin
            // 
            this.pZoneDessin.Location = new System.Drawing.Point(0, 0);
            this.pZoneDessin.Name = "pZoneDessin";
            this.pZoneDessin.Size = new System.Drawing.Size(CstApplication.TAILLEDESSINX, CstApplication.TAILLEDESSINY);
            this.pZoneDessin.TabIndex = 0;
            this.pZoneDessin.TabStop = false;
            this.pZoneDessin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pZoneDessin_MouseDown);
            this.pZoneDessin.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pZoneDessin_MouseMove);
            this.pZoneDessin.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pZoneDessin_MouseUp);
            // 
            // ucZoneDessin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pZoneDessin);
            this.Name = "ucZoneDessin";
            this.Size = new System.Drawing.Size(64, 64);
            ((System.ComponentModel.ISupportInitialize)(this.pZoneDessin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pZoneDessin;


    }
}
