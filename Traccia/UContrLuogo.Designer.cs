namespace Traccia
{
    partial class UContrLuogo
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

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxLuogo = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDati = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDescrizione = new System.Windows.Forms.TextBox();
            this.textBoxSigla = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxLuogo.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxLuogo
            // 
            this.groupBoxLuogo.Controls.Add(this.textBoxID);
            this.groupBoxLuogo.Controls.Add(this.label5);
            this.groupBoxLuogo.Controls.Add(this.textBoxSigla);
            this.groupBoxLuogo.Controls.Add(this.label4);
            this.groupBoxLuogo.Controls.Add(this.textBoxDescrizione);
            this.groupBoxLuogo.Controls.Add(this.label3);
            this.groupBoxLuogo.Controls.Add(this.textBoxDati);
            this.groupBoxLuogo.Controls.Add(this.label2);
            this.groupBoxLuogo.Controls.Add(this.textBoxNome);
            this.groupBoxLuogo.Controls.Add(this.label1);
            this.groupBoxLuogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxLuogo.Location = new System.Drawing.Point(0, 0);
            this.groupBoxLuogo.Name = "groupBoxLuogo";
            this.groupBoxLuogo.Size = new System.Drawing.Size(764, 110);
            this.groupBoxLuogo.TabIndex = 0;
            this.groupBoxLuogo.TabStop = false;
            this.groupBoxLuogo.Text = "Luogo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome";
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(74, 19);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(194, 20);
            this.textBoxNome.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Dati";
            // 
            // textBoxDati
            // 
            this.textBoxDati.Location = new System.Drawing.Point(74, 46);
            this.textBoxDati.Name = "textBoxDati";
            this.textBoxDati.Size = new System.Drawing.Size(670, 20);
            this.textBoxDati.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Descrizione";
            // 
            // textBoxDescrizione
            // 
            this.textBoxDescrizione.Location = new System.Drawing.Point(74, 71);
            this.textBoxDescrizione.Name = "textBoxDescrizione";
            this.textBoxDescrizione.Size = new System.Drawing.Size(670, 20);
            this.textBoxDescrizione.TabIndex = 5;
            // 
            // textBoxSigla
            // 
            this.textBoxSigla.Location = new System.Drawing.Point(340, 19);
            this.textBoxSigla.Name = "textBoxSigla";
            this.textBoxSigla.Size = new System.Drawing.Size(127, 20);
            this.textBoxSigla.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(304, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Sigla";
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(537, 19);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(207, 20);
            this.textBoxID.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(513, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "ID";
            // 
            // UContrLuogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxLuogo);
            this.Name = "UContrLuogo";
            this.Size = new System.Drawing.Size(764, 110);
            this.groupBoxLuogo.ResumeLayout(false);
            this.groupBoxLuogo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxLuogo;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox textBoxDati;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox textBoxSigla;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox textBoxDescrizione;
    }
}
