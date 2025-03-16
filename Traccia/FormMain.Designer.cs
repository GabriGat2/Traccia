namespace Traccia
{
    partial class FormMain
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.butArchiviaEscursione = new System.Windows.Forms.Button();
            this.butCreaArchivio = new System.Windows.Forms.Button();
            this.butCreaAreaArchivio = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBoxAreaArchivio = new System.Windows.Forms.GroupBox();
            this.textBoxPathAreaArchivio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNomeAreaArchivio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butSelezionaAreaArchivio = new System.Windows.Forms.Button();
            this.groupBoxArchivio = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBoxAreaArchivio.SuspendLayout();
            this.groupBoxArchivio.SuspendLayout();
            this.SuspendLayout();
            // 
            // butArchiviaEscursione
            // 
            this.butArchiviaEscursione.Location = new System.Drawing.Point(16, 59);
            this.butArchiviaEscursione.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.butArchiviaEscursione.Name = "butArchiviaEscursione";
            this.butArchiviaEscursione.Size = new System.Drawing.Size(196, 28);
            this.butArchiviaEscursione.TabIndex = 0;
            this.butArchiviaEscursione.Text = "Archivia Escursione";
            this.butArchiviaEscursione.UseVisualStyleBackColor = true;
            this.butArchiviaEscursione.Click += new System.EventHandler(this.butArchiviaEscursione_Click);
            // 
            // butCreaArchivio
            // 
            this.butCreaArchivio.Location = new System.Drawing.Point(16, 23);
            this.butCreaArchivio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.butCreaArchivio.Name = "butCreaArchivio";
            this.butCreaArchivio.Size = new System.Drawing.Size(196, 28);
            this.butCreaArchivio.TabIndex = 1;
            this.butCreaArchivio.Text = "Crea Archivio";
            this.butCreaArchivio.UseVisualStyleBackColor = true;
            this.butCreaArchivio.Click += new System.EventHandler(this.butCreaArchivio_Click);
            // 
            // butCreaAreaArchivio
            // 
            this.butCreaAreaArchivio.Location = new System.Drawing.Point(16, 23);
            this.butCreaAreaArchivio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.butCreaAreaArchivio.Name = "butCreaAreaArchivio";
            this.butCreaAreaArchivio.Size = new System.Drawing.Size(196, 28);
            this.butCreaAreaArchivio.TabIndex = 2;
            this.butCreaAreaArchivio.Text = "Crea Area Archivio";
            this.butCreaAreaArchivio.UseVisualStyleBackColor = true;
            this.butCreaAreaArchivio.Click += new System.EventHandler(this.butCreaAreaArchivio_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxAreaArchivio);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBoxArchivio);
            this.splitContainer1.Size = new System.Drawing.Size(1062, 701);
            this.splitContainer1.SplitterDistance = 350;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 3;
            // 
            // groupBoxAreaArchivio
            // 
            this.groupBoxAreaArchivio.Controls.Add(this.textBoxPathAreaArchivio);
            this.groupBoxAreaArchivio.Controls.Add(this.label2);
            this.groupBoxAreaArchivio.Controls.Add(this.textBoxNomeAreaArchivio);
            this.groupBoxAreaArchivio.Controls.Add(this.label1);
            this.groupBoxAreaArchivio.Controls.Add(this.butSelezionaAreaArchivio);
            this.groupBoxAreaArchivio.Controls.Add(this.butCreaAreaArchivio);
            this.groupBoxAreaArchivio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxAreaArchivio.Location = new System.Drawing.Point(0, 0);
            this.groupBoxAreaArchivio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxAreaArchivio.Name = "groupBoxAreaArchivio";
            this.groupBoxAreaArchivio.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxAreaArchivio.Size = new System.Drawing.Size(1062, 350);
            this.groupBoxAreaArchivio.TabIndex = 0;
            this.groupBoxAreaArchivio.TabStop = false;
            this.groupBoxAreaArchivio.Text = "Area Archivio";
            // 
            // textBoxPathAreaArchivio
            // 
            this.textBoxPathAreaArchivio.Location = new System.Drawing.Point(229, 133);
            this.textBoxPathAreaArchivio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPathAreaArchivio.Name = "textBoxPathAreaArchivio";
            this.textBoxPathAreaArchivio.ReadOnly = true;
            this.textBoxPathAreaArchivio.Size = new System.Drawing.Size(820, 22);
            this.textBoxPathAreaArchivio.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 142);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Percorso Area Archivio";
            // 
            // textBoxNomeAreaArchivio
            // 
            this.textBoxNomeAreaArchivio.Location = new System.Drawing.Point(229, 101);
            this.textBoxNomeAreaArchivio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxNomeAreaArchivio.Name = "textBoxNomeAreaArchivio";
            this.textBoxNomeAreaArchivio.ReadOnly = true;
            this.textBoxNomeAreaArchivio.Size = new System.Drawing.Size(820, 22);
            this.textBoxNomeAreaArchivio.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 110);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Area Archivio";
            // 
            // butSelezionaAreaArchivio
            // 
            this.butSelezionaAreaArchivio.Location = new System.Drawing.Point(16, 59);
            this.butSelezionaAreaArchivio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.butSelezionaAreaArchivio.Name = "butSelezionaAreaArchivio";
            this.butSelezionaAreaArchivio.Size = new System.Drawing.Size(196, 28);
            this.butSelezionaAreaArchivio.TabIndex = 3;
            this.butSelezionaAreaArchivio.Text = "Seleziona Area Archivio";
            this.butSelezionaAreaArchivio.UseVisualStyleBackColor = true;
            this.butSelezionaAreaArchivio.Click += new System.EventHandler(this.butSelezionaAreaArchivio_Click);
            // 
            // groupBoxArchivio
            // 
            this.groupBoxArchivio.Controls.Add(this.butArchiviaEscursione);
            this.groupBoxArchivio.Controls.Add(this.butCreaArchivio);
            this.groupBoxArchivio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxArchivio.Location = new System.Drawing.Point(0, 0);
            this.groupBoxArchivio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxArchivio.Name = "groupBoxArchivio";
            this.groupBoxArchivio.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxArchivio.Size = new System.Drawing.Size(1062, 346);
            this.groupBoxArchivio.TabIndex = 0;
            this.groupBoxArchivio.TabStop = false;
            this.groupBoxArchivio.Text = "Archivio";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 701);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormMain";
            this.Text = "Traccia";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBoxAreaArchivio.ResumeLayout(false);
            this.groupBoxAreaArchivio.PerformLayout();
            this.groupBoxArchivio.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butArchiviaEscursione;
        private System.Windows.Forms.Button butCreaArchivio;
        private System.Windows.Forms.Button butCreaAreaArchivio;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBoxAreaArchivio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butSelezionaAreaArchivio;
        private System.Windows.Forms.GroupBox groupBoxArchivio;
        private System.Windows.Forms.TextBox textBoxPathAreaArchivio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNomeAreaArchivio;
    }
}

