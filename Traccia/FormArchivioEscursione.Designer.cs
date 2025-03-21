namespace Traccia
{
    partial class FormArchivioEscursione
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
            this.textBoxDirectoryBase = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPrefisso = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextDescrizione = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.butExplorerArea = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBoxArchivio = new System.Windows.Forms.GroupBox();
            this.butExplorerEscursione = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxPathArchivio = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.Label5 = new System.Windows.Forms.Label();
            this.textBoxArchivio = new System.Windows.Forms.TextBox();
            this.groupBoxDescrizione = new System.Windows.Forms.GroupBox();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.groupBoxComandi = new System.Windows.Forms.GroupBox();
            this.butModificaTraccia = new System.Windows.Forms.Button();
            this.butArchiviaTraccia = new System.Windows.Forms.Button();
            this.butCrea = new System.Windows.Forms.Button();
            this.butAggiorna = new System.Windows.Forms.Button();
            this.groupBoxOutput = new System.Windows.Forms.GroupBox();
            this.richTextBoxOutput = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBoxArchivio.SuspendLayout();
            this.groupBoxDescrizione.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.groupBoxComandi.SuspendLayout();
            this.groupBoxOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxDirectoryBase
            // 
            this.textBoxDirectoryBase.Location = new System.Drawing.Point(141, 12);
            this.textBoxDirectoryBase.Name = "textBoxDirectoryBase";
            this.textBoxDirectoryBase.ReadOnly = true;
            this.textBoxDirectoryBase.Size = new System.Drawing.Size(627, 20);
            this.textBoxDirectoryBase.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Data";
            // 
            // textBoxPrefisso
            // 
            this.textBoxPrefisso.Location = new System.Drawing.Point(141, 44);
            this.textBoxPrefisso.Name = "textBoxPrefisso";
            this.textBoxPrefisso.Size = new System.Drawing.Size(627, 20);
            this.textBoxPrefisso.TabIndex = 5;
            this.textBoxPrefisso.TextChanged += new System.EventHandler(this.textBoxPrefisso_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Prefisso";
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(141, 70);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(627, 20);
            this.textBoxNome.TabIndex = 7;
            this.textBoxNome.TextChanged += new System.EventHandler(this.textBoxNome_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nome";
            // 
            // richTextDescrizione
            // 
            this.richTextDescrizione.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextDescrizione.Location = new System.Drawing.Point(3, 16);
            this.richTextDescrizione.Name = "richTextDescrizione";
            this.richTextDescrizione.Size = new System.Drawing.Size(790, 152);
            this.richTextDescrizione.TabIndex = 8;
            this.richTextDescrizione.Text = "";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.butExplorerArea);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxDirectoryBase);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(796, 681);
            this.splitContainer1.SplitterDistance = 60;
            this.splitContainer1.TabIndex = 9;
            // 
            // butExplorerArea
            // 
            this.butExplorerArea.Location = new System.Drawing.Point(774, 12);
            this.butExplorerArea.Name = "butExplorerArea";
            this.butExplorerArea.Size = new System.Drawing.Size(17, 23);
            this.butExplorerArea.TabIndex = 14;
            this.butExplorerArea.Text = "E";
            this.butExplorerArea.UseVisualStyleBackColor = true;
            this.butExplorerArea.Click += new System.EventHandler(this.butExplorerArea_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 16);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Area Archivio";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer2.Size = new System.Drawing.Size(796, 617);
            this.splitContainer2.SplitterDistance = 340;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupBoxArchivio);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.groupBoxDescrizione);
            this.splitContainer3.Size = new System.Drawing.Size(796, 340);
            this.splitContainer3.SplitterDistance = 166;
            this.splitContainer3.SplitterWidth = 3;
            this.splitContainer3.TabIndex = 11;
            // 
            // groupBoxArchivio
            // 
            this.groupBoxArchivio.Controls.Add(this.butExplorerEscursione);
            this.groupBoxArchivio.Controls.Add(this.label7);
            this.groupBoxArchivio.Controls.Add(this.textBoxPathArchivio);
            this.groupBoxArchivio.Controls.Add(this.dateTimePicker1);
            this.groupBoxArchivio.Controls.Add(this.Label5);
            this.groupBoxArchivio.Controls.Add(this.textBoxPrefisso);
            this.groupBoxArchivio.Controls.Add(this.label3);
            this.groupBoxArchivio.Controls.Add(this.textBoxArchivio);
            this.groupBoxArchivio.Controls.Add(this.label2);
            this.groupBoxArchivio.Controls.Add(this.textBoxNome);
            this.groupBoxArchivio.Controls.Add(this.label4);
            this.groupBoxArchivio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxArchivio.Location = new System.Drawing.Point(0, 0);
            this.groupBoxArchivio.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxArchivio.Name = "groupBoxArchivio";
            this.groupBoxArchivio.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxArchivio.Size = new System.Drawing.Size(796, 166);
            this.groupBoxArchivio.TabIndex = 0;
            this.groupBoxArchivio.TabStop = false;
            this.groupBoxArchivio.Text = "Archivio";
            // 
            // butExplorerEscursione
            // 
            this.butExplorerEscursione.Location = new System.Drawing.Point(774, 129);
            this.butExplorerEscursione.Name = "butExplorerEscursione";
            this.butExplorerEscursione.Size = new System.Drawing.Size(17, 23);
            this.butExplorerEscursione.TabIndex = 13;
            this.butExplorerEscursione.Text = "E";
            this.butExplorerEscursione.UseVisualStyleBackColor = true;
            this.butExplorerEscursione.Click += new System.EventHandler(this.butExplorerEscursione_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Path Archivio";
            // 
            // textBoxPathArchivio
            // 
            this.textBoxPathArchivio.Location = new System.Drawing.Point(141, 129);
            this.textBoxPathArchivio.Name = "textBoxPathArchivio";
            this.textBoxPathArchivio.ReadOnly = true;
            this.textBoxPathArchivio.Size = new System.Drawing.Size(627, 20);
            this.textBoxPathArchivio.TabIndex = 12;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(141, 18);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 8;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(21, 103);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(45, 13);
            this.Label5.TabIndex = 9;
            this.Label5.Text = "Archivio";
            // 
            // textBoxArchivio
            // 
            this.textBoxArchivio.Location = new System.Drawing.Point(141, 103);
            this.textBoxArchivio.Name = "textBoxArchivio";
            this.textBoxArchivio.ReadOnly = true;
            this.textBoxArchivio.Size = new System.Drawing.Size(627, 20);
            this.textBoxArchivio.TabIndex = 10;
            // 
            // groupBoxDescrizione
            // 
            this.groupBoxDescrizione.Controls.Add(this.richTextDescrizione);
            this.groupBoxDescrizione.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDescrizione.Location = new System.Drawing.Point(0, 0);
            this.groupBoxDescrizione.Name = "groupBoxDescrizione";
            this.groupBoxDescrizione.Size = new System.Drawing.Size(796, 171);
            this.groupBoxDescrizione.TabIndex = 0;
            this.groupBoxDescrizione.TabStop = false;
            this.groupBoxDescrizione.Text = "Descrizione";
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.groupBoxComandi);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.groupBoxOutput);
            this.splitContainer4.Size = new System.Drawing.Size(796, 273);
            this.splitContainer4.SplitterDistance = 60;
            this.splitContainer4.SplitterWidth = 3;
            this.splitContainer4.TabIndex = 0;
            // 
            // groupBoxComandi
            // 
            this.groupBoxComandi.Controls.Add(this.butModificaTraccia);
            this.groupBoxComandi.Controls.Add(this.butArchiviaTraccia);
            this.groupBoxComandi.Controls.Add(this.butCrea);
            this.groupBoxComandi.Controls.Add(this.butAggiorna);
            this.groupBoxComandi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxComandi.Location = new System.Drawing.Point(0, 0);
            this.groupBoxComandi.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxComandi.Name = "groupBoxComandi";
            this.groupBoxComandi.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxComandi.Size = new System.Drawing.Size(796, 60);
            this.groupBoxComandi.TabIndex = 0;
            this.groupBoxComandi.TabStop = false;
            this.groupBoxComandi.Text = "Comandi";
            // 
            // butModificaTraccia
            // 
            this.butModificaTraccia.Location = new System.Drawing.Point(343, 19);
            this.butModificaTraccia.Name = "butModificaTraccia";
            this.butModificaTraccia.Size = new System.Drawing.Size(111, 23);
            this.butModificaTraccia.TabIndex = 14;
            this.butModificaTraccia.Text = "Modifica Traccia";
            this.butModificaTraccia.UseVisualStyleBackColor = true;
            this.butModificaTraccia.Click += new System.EventHandler(this.butModificaTraccia_Click);
            // 
            // butArchiviaTraccia
            // 
            this.butArchiviaTraccia.Location = new System.Drawing.Point(564, 18);
            this.butArchiviaTraccia.Name = "butArchiviaTraccia";
            this.butArchiviaTraccia.Size = new System.Drawing.Size(111, 23);
            this.butArchiviaTraccia.TabIndex = 13;
            this.butArchiviaTraccia.Text = "Nuova Traccia";
            this.butArchiviaTraccia.UseVisualStyleBackColor = true;
            this.butArchiviaTraccia.Click += new System.EventHandler(this.butArchiviaTraccia_Click);
            // 
            // butCrea
            // 
            this.butCrea.Location = new System.Drawing.Point(10, 18);
            this.butCrea.Name = "butCrea";
            this.butCrea.Size = new System.Drawing.Size(138, 23);
            this.butCrea.TabIndex = 12;
            this.butCrea.Text = "Crea Archivio Escursione";
            this.butCrea.UseVisualStyleBackColor = true;
            this.butCrea.Click += new System.EventHandler(this.butCrea_Click);
            // 
            // butAggiorna
            // 
            this.butAggiorna.Location = new System.Drawing.Point(176, 18);
            this.butAggiorna.Name = "butAggiorna";
            this.butAggiorna.Size = new System.Drawing.Size(75, 23);
            this.butAggiorna.TabIndex = 11;
            this.butAggiorna.Text = "Aggiorna";
            this.butAggiorna.UseVisualStyleBackColor = true;
            this.butAggiorna.Click += new System.EventHandler(this.butAggiorna_Click);
            // 
            // groupBoxOutput
            // 
            this.groupBoxOutput.Controls.Add(this.richTextBoxOutput);
            this.groupBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxOutput.Location = new System.Drawing.Point(0, 0);
            this.groupBoxOutput.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxOutput.Name = "groupBoxOutput";
            this.groupBoxOutput.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxOutput.Size = new System.Drawing.Size(796, 210);
            this.groupBoxOutput.TabIndex = 0;
            this.groupBoxOutput.TabStop = false;
            this.groupBoxOutput.Text = "Output";
            // 
            // richTextBoxOutput
            // 
            this.richTextBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxOutput.Location = new System.Drawing.Point(2, 15);
            this.richTextBoxOutput.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBoxOutput.Name = "richTextBoxOutput";
            this.richTextBoxOutput.Size = new System.Drawing.Size(792, 193);
            this.richTextBoxOutput.TabIndex = 0;
            this.richTextBoxOutput.Text = "";
            // 
            // FormArchivioEscursione
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 681);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormArchivioEscursione";
            this.Text = "Archivio Escursione";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBoxArchivio.ResumeLayout(false);
            this.groupBoxArchivio.PerformLayout();
            this.groupBoxDescrizione.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.groupBoxComandi.ResumeLayout(false);
            this.groupBoxOutput.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxDirectoryBase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPrefisso;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextDescrizione;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBoxDescrizione;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.TextBox textBoxArchivio;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button butCrea;
        private System.Windows.Forms.Button butAggiorna;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox groupBoxArchivio;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.GroupBox groupBoxComandi;
        private System.Windows.Forms.GroupBox groupBoxOutput;
        private System.Windows.Forms.RichTextBox richTextBoxOutput;
        private System.Windows.Forms.Button butArchiviaTraccia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxPathArchivio;
        private System.Windows.Forms.Button butModificaTraccia;
        private System.Windows.Forms.Button butExplorerEscursione;
        private System.Windows.Forms.Button butExplorerArea;
    }
}