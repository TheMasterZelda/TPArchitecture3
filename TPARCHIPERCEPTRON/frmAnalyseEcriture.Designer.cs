namespace TPARCHIPERCEPTRON
{
    partial class frmAnalyseEcriture
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAnalyseEcriture));
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.grpEntrainement = new System.Windows.Forms.GroupBox();
            this.lblValeurEntraine = new System.Windows.Forms.Label();
            this.txtValeurEntrainee = new System.Windows.Forms.TextBox();
            this.btnEntrainement = new System.Windows.Forms.Button();
            this.grpDessinEntrainement = new System.Windows.Forms.GroupBox();
            this.btnEffacer = new System.Windows.Forms.Button();
            this.ucDessin = new TPARCHIPERCEPTRON.ucZoneDessin();
            this.grpTests = new System.Windows.Forms.GroupBox();
            this.lblValeurTestee = new System.Windows.Forms.Label();
            this.txtValeurTestee = new System.Windows.Forms.TextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.mnuPrincipal = new System.Windows.Forms.MenuStrip();
            this.tsmiLangue = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAfficherDessins = new System.Windows.Forms.ToolStripMenuItem();
            this.grpEntrainement.SuspendLayout();
            this.grpDessinEntrainement.SuspendLayout();
            this.grpTests.SuspendLayout();
            this.mnuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtConsole
            // 
            resources.ApplyResources(this.txtConsole, "txtConsole");
            this.txtConsole.Name = "txtConsole";
            // 
            // grpEntrainement
            // 
            resources.ApplyResources(this.grpEntrainement, "grpEntrainement");
            this.grpEntrainement.Controls.Add(this.lblValeurEntraine);
            this.grpEntrainement.Controls.Add(this.txtValeurEntrainee);
            this.grpEntrainement.Controls.Add(this.btnEntrainement);
            this.grpEntrainement.Name = "grpEntrainement";
            this.grpEntrainement.TabStop = false;
            // 
            // lblValeurEntraine
            // 
            resources.ApplyResources(this.lblValeurEntraine, "lblValeurEntraine");
            this.lblValeurEntraine.Name = "lblValeurEntraine";
            // 
            // txtValeurEntrainee
            // 
            resources.ApplyResources(this.txtValeurEntrainee, "txtValeurEntrainee");
            this.txtValeurEntrainee.Name = "txtValeurEntrainee";
            // 
            // btnEntrainement
            // 
            resources.ApplyResources(this.btnEntrainement, "btnEntrainement");
            this.btnEntrainement.Name = "btnEntrainement";
            this.btnEntrainement.UseVisualStyleBackColor = true;
            this.btnEntrainement.Click += new System.EventHandler(this.btnEntrainement_Click);
            // 
            // grpDessinEntrainement
            // 
            resources.ApplyResources(this.grpDessinEntrainement, "grpDessinEntrainement");
            this.grpDessinEntrainement.Controls.Add(this.btnEffacer);
            this.grpDessinEntrainement.Controls.Add(this.ucDessin);
            this.grpDessinEntrainement.Name = "grpDessinEntrainement";
            this.grpDessinEntrainement.TabStop = false;
            // 
            // btnEffacer
            // 
            resources.ApplyResources(this.btnEffacer, "btnEffacer");
            this.btnEffacer.Name = "btnEffacer";
            this.btnEffacer.UseVisualStyleBackColor = true;
            this.btnEffacer.Click += new System.EventHandler(this.btnEffacer_Click);
            // 
            // ucDessin
            // 
            resources.ApplyResources(this.ucDessin, "ucDessin");
            this.ucDessin.BackColor = System.Drawing.Color.White;
            this.ucDessin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucDessin.Name = "ucDessin";
            // 
            // grpTests
            // 
            resources.ApplyResources(this.grpTests, "grpTests");
            this.grpTests.Controls.Add(this.lblValeurTestee);
            this.grpTests.Controls.Add(this.txtValeurTestee);
            this.grpTests.Controls.Add(this.btnTest);
            this.grpTests.Name = "grpTests";
            this.grpTests.TabStop = false;
            // 
            // lblValeurTestee
            // 
            resources.ApplyResources(this.lblValeurTestee, "lblValeurTestee");
            this.lblValeurTestee.Name = "lblValeurTestee";
            // 
            // txtValeurTestee
            // 
            resources.ApplyResources(this.txtValeurTestee, "txtValeurTestee");
            this.txtValeurTestee.Name = "txtValeurTestee";
            this.txtValeurTestee.ReadOnly = true;
            // 
            // btnTest
            // 
            resources.ApplyResources(this.btnTest, "btnTest");
            this.btnTest.Name = "btnTest";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // mnuPrincipal
            // 
            resources.ApplyResources(this.mnuPrincipal, "mnuPrincipal");
            this.mnuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiLangue,
            this.tsmiAfficherDessins});
            this.mnuPrincipal.Name = "mnuPrincipal";
            // 
            // tsmiLangue
            // 
            resources.ApplyResources(this.tsmiLangue, "tsmiLangue");
            this.tsmiLangue.Name = "tsmiLangue";
            // 
            // tsmiAfficherDessins
            // 
            resources.ApplyResources(this.tsmiAfficherDessins, "tsmiAfficherDessins");
            this.tsmiAfficherDessins.Name = "tsmiAfficherDessins";
            this.tsmiAfficherDessins.Click += new System.EventHandler(this.tsmiAfficherDessins_Click);
            // 
            // frmAnalyseEcriture
            // 
            this.AcceptButton = this.btnEntrainement;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpTests);
            this.Controls.Add(this.grpEntrainement);
            this.Controls.Add(this.grpDessinEntrainement);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.mnuPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mnuPrincipal;
            this.MaximizeBox = false;
            this.Name = "frmAnalyseEcriture";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAnalyseEcriture_FormClosing);
            this.Load += new System.EventHandler(this.frmAnalyseEcriture_Load);
            this.grpEntrainement.ResumeLayout(false);
            this.grpEntrainement.PerformLayout();
            this.grpDessinEntrainement.ResumeLayout(false);
            this.grpTests.ResumeLayout(false);
            this.grpTests.PerformLayout();
            this.mnuPrincipal.ResumeLayout(false);
            this.mnuPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.GroupBox grpEntrainement;
        private System.Windows.Forms.Label lblValeurEntraine;
        private System.Windows.Forms.TextBox txtValeurEntrainee;
        private System.Windows.Forms.Button btnEntrainement;
        private System.Windows.Forms.GroupBox grpDessinEntrainement;
        private ucZoneDessin ucDessin;
        private System.Windows.Forms.GroupBox grpTests;
        private System.Windows.Forms.Label lblValeurTestee;
        private System.Windows.Forms.TextBox txtValeurTestee;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnEffacer;
        private System.Windows.Forms.MenuStrip mnuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem tsmiLangue;
        private System.Windows.Forms.ToolStripMenuItem tsmiAfficherDessins;
    }
}

