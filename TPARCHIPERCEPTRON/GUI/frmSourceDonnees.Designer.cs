namespace TPARCHIPERCEPTRON.GUI
{
    partial class frmSourceDonnees
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
            this.rdbDatabase = new System.Windows.Forms.RadioButton();
            this.rdbFichier = new System.Windows.Forms.RadioButton();
            this.btnConfirmer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rdbDatabase
            // 
            this.rdbDatabase.AutoSize = true;
            this.rdbDatabase.Location = new System.Drawing.Point(91, 35);
            this.rdbDatabase.Name = "rdbDatabase";
            this.rdbDatabase.Size = new System.Drawing.Size(71, 17);
            this.rdbDatabase.TabIndex = 0;
            this.rdbDatabase.Text = "Database";
            this.rdbDatabase.UseVisualStyleBackColor = true;
            // 
            // rdbFichier
            // 
            this.rdbFichier.AutoSize = true;
            this.rdbFichier.Checked = true;
            this.rdbFichier.Location = new System.Drawing.Point(91, 12);
            this.rdbFichier.Name = "rdbFichier";
            this.rdbFichier.Size = new System.Drawing.Size(81, 17);
            this.rdbFichier.TabIndex = 0;
            this.rdbFichier.TabStop = true;
            this.rdbFichier.Text = "Fichier local";
            this.rdbFichier.UseVisualStyleBackColor = true;
            // 
            // btnConfirmer
            // 
            this.btnConfirmer.Location = new System.Drawing.Point(91, 71);
            this.btnConfirmer.Name = "btnConfirmer";
            this.btnConfirmer.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmer.TabIndex = 1;
            this.btnConfirmer.Text = "Confimer";
            this.btnConfirmer.UseVisualStyleBackColor = true;
            this.btnConfirmer.Click += new System.EventHandler(this.btnConfirmer_Click);
            // 
            // frmSourceDonnees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 115);
            this.Controls.Add(this.btnConfirmer);
            this.Controls.Add(this.rdbFichier);
            this.Controls.Add(this.rdbDatabase);
            this.Name = "frmSourceDonnees";
            this.Text = "Source de données";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbDatabase;
        private System.Windows.Forms.RadioButton rdbFichier;
        private System.Windows.Forms.Button btnConfirmer;
    }
}