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
            this.SuspendLayout();
            // 
            // butArchiviaEscursione
            // 
            this.butArchiviaEscursione.Location = new System.Drawing.Point(49, 97);
            this.butArchiviaEscursione.Name = "butArchiviaEscursione";
            this.butArchiviaEscursione.Size = new System.Drawing.Size(147, 23);
            this.butArchiviaEscursione.TabIndex = 0;
            this.butArchiviaEscursione.Text = "Archivia Escursione";
            this.butArchiviaEscursione.UseVisualStyleBackColor = true;
            this.butArchiviaEscursione.Click += new System.EventHandler(this.butArchiviaEscursione_Click);
            // 
            // butCreaArchivio
            // 
            this.butCreaArchivio.Location = new System.Drawing.Point(49, 54);
            this.butCreaArchivio.Name = "butCreaArchivio";
            this.butCreaArchivio.Size = new System.Drawing.Size(147, 23);
            this.butCreaArchivio.TabIndex = 1;
            this.butCreaArchivio.Text = "Crea Archivio";
            this.butCreaArchivio.UseVisualStyleBackColor = true;
            this.butCreaArchivio.Click += new System.EventHandler(this.butCreaArchivio_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.butCreaArchivio);
            this.Controls.Add(this.butArchiviaEscursione);
            this.Name = "Form1";
            this.Text = "Traccia";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butArchiviaEscursione;
        private System.Windows.Forms.Button butCreaArchivio;
    }
}

