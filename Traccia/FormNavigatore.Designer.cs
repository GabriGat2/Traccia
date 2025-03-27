namespace Traccia
{
    partial class FormNavigatore
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBoxTraccia = new System.Windows.Forms.GroupBox();
            this.butExplorerTraccia = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxPathTraccia = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.textBoxNomeTraccia = new System.Windows.Forms.TextBox();
            this.splitContainer1B2 = new System.Windows.Forms.SplitContainer();
            this.groupBoxNaviagtore = new System.Windows.Forms.GroupBox();
            this.richTextBoxDescrizione = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buInternetNavigatore = new System.Windows.Forms.Button();
            this.textBoxLink = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxNavigatore = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1B2B3 = new System.Windows.Forms.SplitContainer();
            this.ucFiles = new Traccia.UContrFiles();
            this.splitContainer1B2B3B4 = new System.Windows.Forms.SplitContainer();
            this.groupBoxComandi = new System.Windows.Forms.GroupBox();
            this.butAssegna = new System.Windows.Forms.Button();
            this.groupBoxOutput = new System.Windows.Forms.GroupBox();
            this.richTextBoxOutput = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBoxTraccia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1B2)).BeginInit();
            this.splitContainer1B2.Panel1.SuspendLayout();
            this.splitContainer1B2.Panel2.SuspendLayout();
            this.splitContainer1B2.SuspendLayout();
            this.groupBoxNaviagtore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1B2B3)).BeginInit();
            this.splitContainer1B2B3.Panel1.SuspendLayout();
            this.splitContainer1B2B3.Panel2.SuspendLayout();
            this.splitContainer1B2B3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1B2B3B4)).BeginInit();
            this.splitContainer1B2B3B4.Panel1.SuspendLayout();
            this.splitContainer1B2B3B4.Panel2.SuspendLayout();
            this.splitContainer1B2B3B4.SuspendLayout();
            this.groupBoxComandi.SuspendLayout();
            this.groupBoxOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxTraccia);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer1B2);
            this.splitContainer1.Size = new System.Drawing.Size(800, 561);
            this.splitContainer1.SplitterDistance = 80;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBoxTraccia
            // 
            this.groupBoxTraccia.Controls.Add(this.butExplorerTraccia);
            this.groupBoxTraccia.Controls.Add(this.label10);
            this.groupBoxTraccia.Controls.Add(this.textBoxPathTraccia);
            this.groupBoxTraccia.Controls.Add(this.Label5);
            this.groupBoxTraccia.Controls.Add(this.textBoxNomeTraccia);
            this.groupBoxTraccia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTraccia.Location = new System.Drawing.Point(0, 0);
            this.groupBoxTraccia.Name = "groupBoxTraccia";
            this.groupBoxTraccia.Size = new System.Drawing.Size(800, 80);
            this.groupBoxTraccia.TabIndex = 0;
            this.groupBoxTraccia.TabStop = false;
            this.groupBoxTraccia.Text = "Traccia";
            // 
            // butExplorerTraccia
            // 
            this.butExplorerTraccia.Location = new System.Drawing.Point(762, 42);
            this.butExplorerTraccia.Name = "butExplorerTraccia";
            this.butExplorerTraccia.Size = new System.Drawing.Size(17, 23);
            this.butExplorerTraccia.TabIndex = 24;
            this.butExplorerTraccia.Text = "E";
            this.butExplorerTraccia.UseVisualStyleBackColor = true;
            this.butExplorerTraccia.Click += new System.EventHandler(this.butExplorerTraccia_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Path ";
            // 
            // textBoxPathTraccia
            // 
            this.textBoxPathTraccia.Location = new System.Drawing.Point(129, 45);
            this.textBoxPathTraccia.Name = "textBoxPathTraccia";
            this.textBoxPathTraccia.ReadOnly = true;
            this.textBoxPathTraccia.Size = new System.Drawing.Size(627, 20);
            this.textBoxPathTraccia.TabIndex = 23;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(9, 26);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(35, 13);
            this.Label5.TabIndex = 20;
            this.Label5.Text = "Nome";
            // 
            // textBoxNomeTraccia
            // 
            this.textBoxNomeTraccia.Location = new System.Drawing.Point(129, 19);
            this.textBoxNomeTraccia.Name = "textBoxNomeTraccia";
            this.textBoxNomeTraccia.ReadOnly = true;
            this.textBoxNomeTraccia.Size = new System.Drawing.Size(627, 20);
            this.textBoxNomeTraccia.TabIndex = 21;
            // 
            // splitContainer1B2
            // 
            this.splitContainer1B2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1B2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1B2.Name = "splitContainer1B2";
            this.splitContainer1B2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1B2.Panel1
            // 
            this.splitContainer1B2.Panel1.Controls.Add(this.groupBoxNaviagtore);
            // 
            // splitContainer1B2.Panel2
            // 
            this.splitContainer1B2.Panel2.Controls.Add(this.splitContainer1B2B3);
            this.splitContainer1B2.Size = new System.Drawing.Size(800, 477);
            this.splitContainer1B2.SplitterDistance = 140;
            this.splitContainer1B2.TabIndex = 0;
            // 
            // groupBoxNaviagtore
            // 
            this.groupBoxNaviagtore.Controls.Add(this.richTextBoxDescrizione);
            this.groupBoxNaviagtore.Controls.Add(this.label3);
            this.groupBoxNaviagtore.Controls.Add(this.buInternetNavigatore);
            this.groupBoxNaviagtore.Controls.Add(this.textBoxLink);
            this.groupBoxNaviagtore.Controls.Add(this.label2);
            this.groupBoxNaviagtore.Controls.Add(this.comboBoxNavigatore);
            this.groupBoxNaviagtore.Controls.Add(this.label1);
            this.groupBoxNaviagtore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxNaviagtore.Location = new System.Drawing.Point(0, 0);
            this.groupBoxNaviagtore.Name = "groupBoxNaviagtore";
            this.groupBoxNaviagtore.Size = new System.Drawing.Size(800, 140);
            this.groupBoxNaviagtore.TabIndex = 0;
            this.groupBoxNaviagtore.TabStop = false;
            this.groupBoxNaviagtore.Text = "Navigatore";
            // 
            // richTextBoxDescrizione
            // 
            this.richTextBoxDescrizione.Location = new System.Drawing.Point(129, 83);
            this.richTextBoxDescrizione.Name = "richTextBoxDescrizione";
            this.richTextBoxDescrizione.Size = new System.Drawing.Size(627, 40);
            this.richTextBoxDescrizione.TabIndex = 27;
            this.richTextBoxDescrizione.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Descrizione";
            // 
            // buInternetNavigatore
            // 
            this.buInternetNavigatore.Location = new System.Drawing.Point(762, 54);
            this.buInternetNavigatore.Name = "buInternetNavigatore";
            this.buInternetNavigatore.Size = new System.Drawing.Size(17, 23);
            this.buInternetNavigatore.TabIndex = 25;
            this.buInternetNavigatore.Text = "E";
            this.buInternetNavigatore.UseVisualStyleBackColor = true;
            // 
            // textBoxLink
            // 
            this.textBoxLink.Location = new System.Drawing.Point(129, 54);
            this.textBoxLink.Name = "textBoxLink";
            this.textBoxLink.Size = new System.Drawing.Size(627, 20);
            this.textBoxLink.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Link";
            // 
            // comboBoxNavigatore
            // 
            this.comboBoxNavigatore.FormattingEnabled = true;
            this.comboBoxNavigatore.Location = new System.Drawing.Point(129, 27);
            this.comboBoxNavigatore.Name = "comboBoxNavigatore";
            this.comboBoxNavigatore.Size = new System.Drawing.Size(627, 21);
            this.comboBoxNavigatore.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo";
            // 
            // splitContainer1B2B3
            // 
            this.splitContainer1B2B3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1B2B3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1B2B3.Name = "splitContainer1B2B3";
            this.splitContainer1B2B3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1B2B3.Panel1
            // 
            this.splitContainer1B2B3.Panel1.Controls.Add(this.ucFiles);
            // 
            // splitContainer1B2B3.Panel2
            // 
            this.splitContainer1B2B3.Panel2.Controls.Add(this.splitContainer1B2B3B4);
            this.splitContainer1B2B3.Size = new System.Drawing.Size(800, 333);
            this.splitContainer1B2B3.SplitterDistance = 60;
            this.splitContainer1B2B3.TabIndex = 0;
            // 
            // ucFiles
            // 
            this.ucFiles.Abilita = false;
            this.ucFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucFiles.Location = new System.Drawing.Point(0, 0);
            this.ucFiles.Name = "ucFiles";
            this.ucFiles.Nome = "Files navigatore";
            this.ucFiles.PathDisponibili = "";
            this.ucFiles.PathResoconto = "";
            this.ucFiles.PathStampe = "";
            this.ucFiles.PathTracce = "";
            this.ucFiles.Size = new System.Drawing.Size(800, 60);
            this.ucFiles.TabIndex = 0;
            // 
            // splitContainer1B2B3B4
            // 
            this.splitContainer1B2B3B4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1B2B3B4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1B2B3B4.Name = "splitContainer1B2B3B4";
            this.splitContainer1B2B3B4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1B2B3B4.Panel1
            // 
            this.splitContainer1B2B3B4.Panel1.Controls.Add(this.groupBoxComandi);
            // 
            // splitContainer1B2B3B4.Panel2
            // 
            this.splitContainer1B2B3B4.Panel2.Controls.Add(this.groupBoxOutput);
            this.splitContainer1B2B3B4.Size = new System.Drawing.Size(800, 269);
            this.splitContainer1B2B3B4.SplitterDistance = 60;
            this.splitContainer1B2B3B4.TabIndex = 0;
            // 
            // groupBoxComandi
            // 
            this.groupBoxComandi.Controls.Add(this.butAssegna);
            this.groupBoxComandi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxComandi.Location = new System.Drawing.Point(0, 0);
            this.groupBoxComandi.Name = "groupBoxComandi";
            this.groupBoxComandi.Size = new System.Drawing.Size(800, 60);
            this.groupBoxComandi.TabIndex = 0;
            this.groupBoxComandi.TabStop = false;
            this.groupBoxComandi.Text = "Comandi";
            // 
            // butAssegna
            // 
            this.butAssegna.Location = new System.Drawing.Point(6, 19);
            this.butAssegna.Name = "butAssegna";
            this.butAssegna.Size = new System.Drawing.Size(75, 23);
            this.butAssegna.TabIndex = 0;
            this.butAssegna.Text = "Assegna";
            this.butAssegna.UseVisualStyleBackColor = true;
            this.butAssegna.Click += new System.EventHandler(this.butAssegna_Click);
            // 
            // groupBoxOutput
            // 
            this.groupBoxOutput.Controls.Add(this.richTextBoxOutput);
            this.groupBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxOutput.Location = new System.Drawing.Point(0, 0);
            this.groupBoxOutput.Name = "groupBoxOutput";
            this.groupBoxOutput.Size = new System.Drawing.Size(800, 205);
            this.groupBoxOutput.TabIndex = 0;
            this.groupBoxOutput.TabStop = false;
            this.groupBoxOutput.Text = "Output";
            // 
            // richTextBoxOutput
            // 
            this.richTextBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxOutput.Location = new System.Drawing.Point(3, 16);
            this.richTextBoxOutput.Name = "richTextBoxOutput";
            this.richTextBoxOutput.Size = new System.Drawing.Size(794, 186);
            this.richTextBoxOutput.TabIndex = 0;
            this.richTextBoxOutput.Text = "";
            // 
            // FormNavigatore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 561);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormNavigatore";
            this.Text = "Navigatore";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBoxTraccia.ResumeLayout(false);
            this.groupBoxTraccia.PerformLayout();
            this.splitContainer1B2.Panel1.ResumeLayout(false);
            this.splitContainer1B2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1B2)).EndInit();
            this.splitContainer1B2.ResumeLayout(false);
            this.groupBoxNaviagtore.ResumeLayout(false);
            this.groupBoxNaviagtore.PerformLayout();
            this.splitContainer1B2B3.Panel1.ResumeLayout(false);
            this.splitContainer1B2B3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1B2B3)).EndInit();
            this.splitContainer1B2B3.ResumeLayout(false);
            this.splitContainer1B2B3B4.Panel1.ResumeLayout(false);
            this.splitContainer1B2B3B4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1B2B3B4)).EndInit();
            this.splitContainer1B2B3B4.ResumeLayout(false);
            this.groupBoxComandi.ResumeLayout(false);
            this.groupBoxOutput.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBoxTraccia;
        private System.Windows.Forms.Button butExplorerTraccia;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxPathTraccia;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.TextBox textBoxNomeTraccia;
        private System.Windows.Forms.SplitContainer splitContainer1B2;
        private System.Windows.Forms.GroupBox groupBoxNaviagtore;
        private System.Windows.Forms.TextBox textBoxLink;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxNavigatore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buInternetNavigatore;
        private System.Windows.Forms.RichTextBox richTextBoxDescrizione;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainer1B2B3;
        private System.Windows.Forms.SplitContainer splitContainer1B2B3B4;
        private System.Windows.Forms.GroupBox groupBoxComandi;
        private System.Windows.Forms.Button butAssegna;
        private System.Windows.Forms.GroupBox groupBoxOutput;
        private System.Windows.Forms.RichTextBox richTextBoxOutput;
        private UContrFiles ucFiles;
    }
}