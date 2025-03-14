namespace Traccia
{
    partial class FormCreaArchivio
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
            this.butDirectoryBase = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.butCrea = new System.Windows.Forms.Button();
            this.butAggiorna = new System.Windows.Forms.Button();
            this.Label5 = new System.Windows.Forms.Label();
            this.textBoxArchivio = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBoxDescrizione = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBoxDescrizione.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxDirectoryBase
            // 
            this.textBoxDirectoryBase.Location = new System.Drawing.Point(141, 12);
            this.textBoxDirectoryBase.Name = "textBoxDirectoryBase";
            this.textBoxDirectoryBase.Size = new System.Drawing.Size(627, 20);
            this.textBoxDirectoryBase.TabIndex = 1;
            this.textBoxDirectoryBase.TextChanged += new System.EventHandler(this.textBoxDirectoryBase_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Data";
            // 
            // textBoxPrefisso
            // 
            this.textBoxPrefisso.Location = new System.Drawing.Point(141, 42);
            this.textBoxPrefisso.Name = "textBoxPrefisso";
            this.textBoxPrefisso.Size = new System.Drawing.Size(627, 20);
            this.textBoxPrefisso.TabIndex = 5;
            this.textBoxPrefisso.TextChanged += new System.EventHandler(this.textBoxPrefisso_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Prefisso";
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(141, 68);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(627, 20);
            this.textBoxNome.TabIndex = 7;
            this.textBoxNome.TextChanged += new System.EventHandler(this.textBoxNome_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 75);
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
            this.richTextDescrizione.Size = new System.Drawing.Size(794, 148);
            this.richTextDescrizione.TabIndex = 8;
            this.richTextDescrizione.Text = "";
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
            this.splitContainer1.Panel1.Controls.Add(this.butDirectoryBase);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxDirectoryBase);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 75;
            this.splitContainer1.TabIndex = 9;
            // 
            // butDirectoryBase
            // 
            this.butDirectoryBase.Location = new System.Drawing.Point(24, 12);
            this.butDirectoryBase.Name = "butDirectoryBase";
            this.butDirectoryBase.Size = new System.Drawing.Size(95, 23);
            this.butDirectoryBase.TabIndex = 2;
            this.butDirectoryBase.Text = "Directory Base";
            this.butDirectoryBase.UseVisualStyleBackColor = true;
            this.butDirectoryBase.Click += new System.EventHandler(this.butDirectoryBase_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.butCrea);
            this.splitContainer2.Panel1.Controls.Add(this.butAggiorna);
            this.splitContainer2.Panel1.Controls.Add(this.Label5);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxArchivio);
            this.splitContainer2.Panel1.Controls.Add(this.dateTimePicker1);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxPrefisso);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxNome);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBoxDescrizione);
            this.splitContainer2.Size = new System.Drawing.Size(800, 371);
            this.splitContainer2.SplitterDistance = 200;
            this.splitContainer2.TabIndex = 0;
            // 
            // butCrea
            // 
            this.butCrea.Location = new System.Drawing.Point(141, 156);
            this.butCrea.Name = "butCrea";
            this.butCrea.Size = new System.Drawing.Size(75, 23);
            this.butCrea.TabIndex = 12;
            this.butCrea.Text = "Crea";
            this.butCrea.UseVisualStyleBackColor = true;
            this.butCrea.Click += new System.EventHandler(this.butCrea_Click);
            // 
            // butAggiorna
            // 
            this.butAggiorna.Location = new System.Drawing.Point(24, 156);
            this.butAggiorna.Name = "butAggiorna";
            this.butAggiorna.Size = new System.Drawing.Size(75, 23);
            this.butAggiorna.TabIndex = 11;
            this.butAggiorna.Text = "Aggiorna";
            this.butAggiorna.UseVisualStyleBackColor = true;
            this.butAggiorna.Click += new System.EventHandler(this.butAggiorna_Click);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(21, 122);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(45, 13);
            this.Label5.TabIndex = 9;
            this.Label5.Text = "Archivio";
            // 
            // textBoxArchivio
            // 
            this.textBoxArchivio.Location = new System.Drawing.Point(141, 115);
            this.textBoxArchivio.Name = "textBoxArchivio";
            this.textBoxArchivio.ReadOnly = true;
            this.textBoxArchivio.Size = new System.Drawing.Size(627, 20);
            this.textBoxArchivio.TabIndex = 10;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(141, 16);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 8;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // groupBoxDescrizione
            // 
            this.groupBoxDescrizione.Controls.Add(this.richTextDescrizione);
            this.groupBoxDescrizione.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDescrizione.Location = new System.Drawing.Point(0, 0);
            this.groupBoxDescrizione.Name = "groupBoxDescrizione";
            this.groupBoxDescrizione.Size = new System.Drawing.Size(800, 167);
            this.groupBoxDescrizione.TabIndex = 0;
            this.groupBoxDescrizione.TabStop = false;
            this.groupBoxDescrizione.Text = "Descrizione";
            // 
            // FormCreaArchivio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormCreaArchivio";
            this.Text = "Crea Archivio";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBoxDescrizione.ResumeLayout(false);
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
        private System.Windows.Forms.Button butDirectoryBase;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.TextBox textBoxArchivio;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button butCrea;
        private System.Windows.Forms.Button butAggiorna;
    }
}