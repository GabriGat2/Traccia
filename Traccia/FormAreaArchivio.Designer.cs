namespace Traccia
{
    partial class FormAreaArchivio
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
            this.groupBoxDirecoryAreaArchivio = new System.Windows.Forms.GroupBox();
            this.butDirectoryBaseAreaArchivio = new System.Windows.Forms.Button();
            this.textBoxDirectoryBaseAreaArchivio = new System.Windows.Forms.TextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupNomeAreaArchivio = new System.Windows.Forms.GroupBox();
            this.butDefault = new System.Windows.Forms.Button();
            this.butCrea = new System.Windows.Forms.Button();
            this.butAggiorna = new System.Windows.Forms.Button();
            this.Label5 = new System.Windows.Forms.Label();
            this.textBoxArchivio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPostfisso = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBoxDirecoryAreaArchivio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupNomeAreaArchivio.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxDirecoryAreaArchivio);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(796, 570);
            this.splitContainer1.SplitterDistance = 94;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBoxDirecoryAreaArchivio
            // 
            this.groupBoxDirecoryAreaArchivio.Controls.Add(this.butDirectoryBaseAreaArchivio);
            this.groupBoxDirecoryAreaArchivio.Controls.Add(this.textBoxDirectoryBaseAreaArchivio);
            this.groupBoxDirecoryAreaArchivio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDirecoryAreaArchivio.Location = new System.Drawing.Point(0, 0);
            this.groupBoxDirecoryAreaArchivio.Name = "groupBoxDirecoryAreaArchivio";
            this.groupBoxDirecoryAreaArchivio.Size = new System.Drawing.Size(796, 94);
            this.groupBoxDirecoryAreaArchivio.TabIndex = 0;
            this.groupBoxDirecoryAreaArchivio.TabStop = false;
            this.groupBoxDirecoryAreaArchivio.Text = "Selezione directory che contiene Area Archivio";
            // 
            // butDirectoryBaseAreaArchivio
            // 
            this.butDirectoryBaseAreaArchivio.Location = new System.Drawing.Point(12, 30);
            this.butDirectoryBaseAreaArchivio.Name = "butDirectoryBaseAreaArchivio";
            this.butDirectoryBaseAreaArchivio.Size = new System.Drawing.Size(168, 23);
            this.butDirectoryBaseAreaArchivio.TabIndex = 4;
            this.butDirectoryBaseAreaArchivio.Text = "Directory Base Area Archivio";
            this.butDirectoryBaseAreaArchivio.UseVisualStyleBackColor = true;
            this.butDirectoryBaseAreaArchivio.Click += new System.EventHandler(this.butDirectoryBaseAreaArchivio_Click);
            // 
            // textBoxDirectoryBaseAreaArchivio
            // 
            this.textBoxDirectoryBaseAreaArchivio.Location = new System.Drawing.Point(204, 30);
            this.textBoxDirectoryBaseAreaArchivio.Name = "textBoxDirectoryBaseAreaArchivio";
            this.textBoxDirectoryBaseAreaArchivio.Size = new System.Drawing.Size(552, 20);
            this.textBoxDirectoryBaseAreaArchivio.TabIndex = 3;
            this.textBoxDirectoryBaseAreaArchivio.TextChanged += new System.EventHandler(this.textBoxDirectoryBaseAreaArchivio_TextChanged);
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
            this.splitContainer2.Panel1.Controls.Add(this.groupNomeAreaArchivio);
            this.splitContainer2.Size = new System.Drawing.Size(796, 472);
            this.splitContainer2.SplitterDistance = 395;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupNomeAreaArchivio
            // 
            this.groupNomeAreaArchivio.Controls.Add(this.butDefault);
            this.groupNomeAreaArchivio.Controls.Add(this.butCrea);
            this.groupNomeAreaArchivio.Controls.Add(this.butAggiorna);
            this.groupNomeAreaArchivio.Controls.Add(this.Label5);
            this.groupNomeAreaArchivio.Controls.Add(this.textBoxArchivio);
            this.groupNomeAreaArchivio.Controls.Add(this.label4);
            this.groupNomeAreaArchivio.Controls.Add(this.textBoxPostfisso);
            this.groupNomeAreaArchivio.Controls.Add(this.label3);
            this.groupNomeAreaArchivio.Controls.Add(this.textBoxNome);
            this.groupNomeAreaArchivio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupNomeAreaArchivio.Location = new System.Drawing.Point(0, 0);
            this.groupNomeAreaArchivio.Name = "groupNomeAreaArchivio";
            this.groupNomeAreaArchivio.Size = new System.Drawing.Size(796, 395);
            this.groupNomeAreaArchivio.TabIndex = 0;
            this.groupNomeAreaArchivio.TabStop = false;
            this.groupNomeAreaArchivio.Text = "Imposta nome Area Archivio";
            // 
            // butDefault
            // 
            this.butDefault.Location = new System.Drawing.Point(654, 133);
            this.butDefault.Name = "butDefault";
            this.butDefault.Size = new System.Drawing.Size(102, 23);
            this.butDefault.TabIndex = 21;
            this.butDefault.Text = "Imposta Default";
            this.butDefault.UseVisualStyleBackColor = true;
            this.butDefault.Click += new System.EventHandler(this.butDefault_Click);
            // 
            // butCrea
            // 
            this.butCrea.Location = new System.Drawing.Point(172, 133);
            this.butCrea.Name = "butCrea";
            this.butCrea.Size = new System.Drawing.Size(75, 23);
            this.butCrea.TabIndex = 20;
            this.butCrea.Text = "Crea";
            this.butCrea.UseVisualStyleBackColor = true;
            this.butCrea.Click += new System.EventHandler(this.butCrea_Click);
            // 
            // butAggiorna
            // 
            this.butAggiorna.Location = new System.Drawing.Point(12, 133);
            this.butAggiorna.Name = "butAggiorna";
            this.butAggiorna.Size = new System.Drawing.Size(75, 23);
            this.butAggiorna.TabIndex = 19;
            this.butAggiorna.Text = "Aggiorna";
            this.butAggiorna.UseVisualStyleBackColor = true;
            this.butAggiorna.Click += new System.EventHandler(this.butAggiorna_Click);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(9, 99);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(70, 13);
            this.Label5.TabIndex = 17;
            this.Label5.Text = "Area Archivio";
            // 
            // textBoxArchivio
            // 
            this.textBoxArchivio.Location = new System.Drawing.Point(204, 92);
            this.textBoxArchivio.Name = "textBoxArchivio";
            this.textBoxArchivio.ReadOnly = true;
            this.textBoxArchivio.Size = new System.Drawing.Size(552, 20);
            this.textBoxArchivio.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Nome";
            // 
            // textBoxPostfisso
            // 
            this.textBoxPostfisso.Location = new System.Drawing.Point(204, 54);
            this.textBoxPostfisso.Name = "textBoxPostfisso";
            this.textBoxPostfisso.Size = new System.Drawing.Size(552, 20);
            this.textBoxPostfisso.TabIndex = 14;
            this.textBoxPostfisso.TextChanged += new System.EventHandler(this.textBoxPostfisso_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Postfisso";
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(204, 19);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(552, 20);
            this.textBoxNome.TabIndex = 16;
            this.textBoxNome.TextChanged += new System.EventHandler(this.textBoxNome_TextChanged);
            // 
            // FormAreaArchivio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 570);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormAreaArchivio";
            this.Text = "Crea Area Archivio";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBoxDirecoryAreaArchivio.ResumeLayout(false);
            this.groupBoxDirecoryAreaArchivio.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupNomeAreaArchivio.ResumeLayout(false);
            this.groupNomeAreaArchivio.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBoxDirecoryAreaArchivio;
        private System.Windows.Forms.Button butDirectoryBaseAreaArchivio;
        private System.Windows.Forms.TextBox textBoxDirectoryBaseAreaArchivio;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupNomeAreaArchivio;
        private System.Windows.Forms.Button butCrea;
        private System.Windows.Forms.Button butAggiorna;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.TextBox textBoxArchivio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPostfisso;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.Button butDefault;
    }
}