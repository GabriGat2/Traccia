namespace Traccia
{
    partial class FormFoto
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
            this.dateTimePicker_OraInizio = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_DataInizio = new System.Windows.Forms.DateTimePicker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBoxData = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker_DataFine = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_OraFine = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1B2 = new System.Windows.Forms.SplitContainer();
            this.groupBoxTipoFoto = new System.Windows.Forms.GroupBox();
            this.ucFotoRaw = new Traccia.UserControlFoto();
            this.ucFotoHeic = new Traccia.UserControlFoto();
            this.ucFotoJpeg = new Traccia.UserControlFoto();
            this.splitContainer1B2B3 = new System.Windows.Forms.SplitContainer();
            this.groupBoxComandi = new System.Windows.Forms.GroupBox();
            this.butAggiorna = new System.Windows.Forms.Button();
            this.butAnnullaCopia = new System.Windows.Forms.Button();
            this.butCopia = new System.Windows.Forms.Button();
            this.butAnnullaAssegna = new System.Windows.Forms.Button();
            this.ButAssegna = new System.Windows.Forms.Button();
            this.butAnnulaSelezione = new System.Windows.Forms.Button();
            this.butSelezione = new System.Windows.Forms.Button();
            this.groupBoxOutput = new System.Windows.Forms.GroupBox();
            this.richTextBoxOutput = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBoxData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1B2)).BeginInit();
            this.splitContainer1B2.Panel1.SuspendLayout();
            this.splitContainer1B2.Panel2.SuspendLayout();
            this.splitContainer1B2.SuspendLayout();
            this.groupBoxTipoFoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1B2B3)).BeginInit();
            this.splitContainer1B2B3.Panel1.SuspendLayout();
            this.splitContainer1B2B3.Panel2.SuspendLayout();
            this.splitContainer1B2B3.SuspendLayout();
            this.groupBoxComandi.SuspendLayout();
            this.groupBoxOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker_OraInizio
            // 
            this.dateTimePicker_OraInizio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker_OraInizio.Location = new System.Drawing.Point(153, 27);
            this.dateTimePicker_OraInizio.Name = "dateTimePicker_OraInizio";
            this.dateTimePicker_OraInizio.ShowUpDown = true;
            this.dateTimePicker_OraInizio.Size = new System.Drawing.Size(71, 20);
            this.dateTimePicker_OraInizio.TabIndex = 0;
            // 
            // dateTimePicker_DataInizio
            // 
            this.dateTimePicker_DataInizio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_DataInizio.Location = new System.Drawing.Point(49, 27);
            this.dateTimePicker_DataInizio.Name = "dateTimePicker_DataInizio";
            this.dateTimePicker_DataInizio.Size = new System.Drawing.Size(98, 20);
            this.dateTimePicker_DataInizio.TabIndex = 3;
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
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxData);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer1B2);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 70;
            this.splitContainer1.TabIndex = 4;
            // 
            // groupBoxData
            // 
            this.groupBoxData.Controls.Add(this.label2);
            this.groupBoxData.Controls.Add(this.dateTimePicker_DataFine);
            this.groupBoxData.Controls.Add(this.dateTimePicker_OraFine);
            this.groupBoxData.Controls.Add(this.label1);
            this.groupBoxData.Controls.Add(this.dateTimePicker_DataInizio);
            this.groupBoxData.Controls.Add(this.dateTimePicker_OraInizio);
            this.groupBoxData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxData.Location = new System.Drawing.Point(0, 0);
            this.groupBoxData.Name = "groupBoxData";
            this.groupBoxData.Size = new System.Drawing.Size(800, 70);
            this.groupBoxData.TabIndex = 0;
            this.groupBoxData.TabStop = false;
            this.groupBoxData.Text = "Data e ora ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(265, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Fine";
            // 
            // dateTimePicker_DataFine
            // 
            this.dateTimePicker_DataFine.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_DataFine.Location = new System.Drawing.Point(307, 27);
            this.dateTimePicker_DataFine.Name = "dateTimePicker_DataFine";
            this.dateTimePicker_DataFine.Size = new System.Drawing.Size(98, 20);
            this.dateTimePicker_DataFine.TabIndex = 6;
            // 
            // dateTimePicker_OraFine
            // 
            this.dateTimePicker_OraFine.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker_OraFine.Location = new System.Drawing.Point(411, 27);
            this.dateTimePicker_OraFine.Name = "dateTimePicker_OraFine";
            this.dateTimePicker_OraFine.ShowUpDown = true;
            this.dateTimePicker_OraFine.Size = new System.Drawing.Size(71, 20);
            this.dateTimePicker_OraFine.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Inizio";
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
            this.splitContainer1B2.Panel1.Controls.Add(this.groupBoxTipoFoto);
            // 
            // splitContainer1B2.Panel2
            // 
            this.splitContainer1B2.Panel2.Controls.Add(this.splitContainer1B2B3);
            this.splitContainer1B2.Size = new System.Drawing.Size(800, 376);
            this.splitContainer1B2.SplitterDistance = 200;
            this.splitContainer1B2.TabIndex = 0;
            // 
            // groupBoxTipoFoto
            // 
            this.groupBoxTipoFoto.Controls.Add(this.ucFotoRaw);
            this.groupBoxTipoFoto.Controls.Add(this.ucFotoHeic);
            this.groupBoxTipoFoto.Controls.Add(this.ucFotoJpeg);
            this.groupBoxTipoFoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTipoFoto.Location = new System.Drawing.Point(0, 0);
            this.groupBoxTipoFoto.Name = "groupBoxTipoFoto";
            this.groupBoxTipoFoto.Size = new System.Drawing.Size(800, 200);
            this.groupBoxTipoFoto.TabIndex = 0;
            this.groupBoxTipoFoto.TabStop = false;
            this.groupBoxTipoFoto.Text = "Tipo foto";
            // 
            // ucFotoRaw
            // 
            this.ucFotoRaw.Abilita = false;
            this.ucFotoRaw.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucFotoRaw.Location = new System.Drawing.Point(3, 146);
            this.ucFotoRaw.Name = "ucFotoRaw";
            this.ucFotoRaw.Nome = "TipoFoto";
            this.ucFotoRaw.PathAssegnati = "";
            this.ucFotoRaw.PathCopiati = "";
            this.ucFotoRaw.PathDisponibili = "";
            this.ucFotoRaw.PathSelezionati = "";
            this.ucFotoRaw.Size = new System.Drawing.Size(794, 65);
            this.ucFotoRaw.TabIndex = 8;
            // 
            // ucFotoHeic
            // 
            this.ucFotoHeic.Abilita = false;
            this.ucFotoHeic.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucFotoHeic.Location = new System.Drawing.Point(3, 81);
            this.ucFotoHeic.Name = "ucFotoHeic";
            this.ucFotoHeic.Nome = "TipoFoto";
            this.ucFotoHeic.PathAssegnati = "";
            this.ucFotoHeic.PathCopiati = "";
            this.ucFotoHeic.PathDisponibili = "";
            this.ucFotoHeic.PathSelezionati = "";
            this.ucFotoHeic.Size = new System.Drawing.Size(794, 65);
            this.ucFotoHeic.TabIndex = 7;
            // 
            // ucFotoJpeg
            // 
            this.ucFotoJpeg.Abilita = false;
            this.ucFotoJpeg.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucFotoJpeg.Location = new System.Drawing.Point(3, 16);
            this.ucFotoJpeg.Name = "ucFotoJpeg";
            this.ucFotoJpeg.Nome = "TipoFoto";
            this.ucFotoJpeg.PathAssegnati = "";
            this.ucFotoJpeg.PathCopiati = "";
            this.ucFotoJpeg.PathDisponibili = "";
            this.ucFotoJpeg.PathSelezionati = "";
            this.ucFotoJpeg.Size = new System.Drawing.Size(794, 65);
            this.ucFotoJpeg.TabIndex = 6;
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
            this.splitContainer1B2B3.Panel1.Controls.Add(this.groupBoxComandi);
            // 
            // splitContainer1B2B3.Panel2
            // 
            this.splitContainer1B2B3.Panel2.Controls.Add(this.groupBoxOutput);
            this.splitContainer1B2B3.Size = new System.Drawing.Size(800, 172);
            this.splitContainer1B2B3.SplitterDistance = 60;
            this.splitContainer1B2B3.TabIndex = 0;
            // 
            // groupBoxComandi
            // 
            this.groupBoxComandi.Controls.Add(this.butAggiorna);
            this.groupBoxComandi.Controls.Add(this.butAnnullaCopia);
            this.groupBoxComandi.Controls.Add(this.butCopia);
            this.groupBoxComandi.Controls.Add(this.butAnnullaAssegna);
            this.groupBoxComandi.Controls.Add(this.ButAssegna);
            this.groupBoxComandi.Controls.Add(this.butAnnulaSelezione);
            this.groupBoxComandi.Controls.Add(this.butSelezione);
            this.groupBoxComandi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxComandi.Location = new System.Drawing.Point(0, 0);
            this.groupBoxComandi.Name = "groupBoxComandi";
            this.groupBoxComandi.Size = new System.Drawing.Size(800, 60);
            this.groupBoxComandi.TabIndex = 0;
            this.groupBoxComandi.TabStop = false;
            this.groupBoxComandi.Text = "Comandi";
            // 
            // butAggiorna
            // 
            this.butAggiorna.Location = new System.Drawing.Point(483, 29);
            this.butAggiorna.Name = "butAggiorna";
            this.butAggiorna.Size = new System.Drawing.Size(75, 23);
            this.butAggiorna.TabIndex = 6;
            this.butAggiorna.Text = "Aggiorna";
            this.butAggiorna.UseVisualStyleBackColor = true;
            this.butAggiorna.Click += new System.EventHandler(this.butAggiorna_Click);
            // 
            // butAnnullaCopia
            // 
            this.butAnnullaCopia.Location = new System.Drawing.Point(688, 29);
            this.butAnnullaCopia.Name = "butAnnullaCopia";
            this.butAnnullaCopia.Size = new System.Drawing.Size(100, 23);
            this.butAnnullaCopia.TabIndex = 5;
            this.butAnnullaCopia.Text = "Annulla Copia";
            this.butAnnullaCopia.UseVisualStyleBackColor = true;
            this.butAnnullaCopia.Click += new System.EventHandler(this.butAnnullaCopia_Click);
            // 
            // butCopia
            // 
            this.butCopia.Location = new System.Drawing.Point(582, 29);
            this.butCopia.Name = "butCopia";
            this.butCopia.Size = new System.Drawing.Size(100, 23);
            this.butCopia.TabIndex = 4;
            this.butCopia.Text = "Copia";
            this.butCopia.UseVisualStyleBackColor = true;
            this.butCopia.Visible = false;
            this.butCopia.Click += new System.EventHandler(this.butCopia_Click);
            // 
            // butAnnullaAssegna
            // 
            this.butAnnullaAssegna.Location = new System.Drawing.Point(355, 29);
            this.butAnnullaAssegna.Name = "butAnnullaAssegna";
            this.butAnnullaAssegna.Size = new System.Drawing.Size(100, 23);
            this.butAnnullaAssegna.TabIndex = 3;
            this.butAnnullaAssegna.Text = "Annulla Assegna";
            this.butAnnullaAssegna.UseVisualStyleBackColor = true;
            this.butAnnullaAssegna.Click += new System.EventHandler(this.butAnnullaAssegna_Click);
            // 
            // ButAssegna
            // 
            this.ButAssegna.Location = new System.Drawing.Point(249, 29);
            this.ButAssegna.Name = "ButAssegna";
            this.ButAssegna.Size = new System.Drawing.Size(100, 23);
            this.ButAssegna.TabIndex = 2;
            this.ButAssegna.Text = "Assegna";
            this.ButAssegna.UseVisualStyleBackColor = true;
            this.ButAssegna.Click += new System.EventHandler(this.ButAssegna_Click);
            // 
            // butAnnulaSelezione
            // 
            this.butAnnulaSelezione.Location = new System.Drawing.Point(121, 29);
            this.butAnnulaSelezione.Name = "butAnnulaSelezione";
            this.butAnnulaSelezione.Size = new System.Drawing.Size(100, 23);
            this.butAnnulaSelezione.TabIndex = 1;
            this.butAnnulaSelezione.Text = "Annulla Selezione";
            this.butAnnulaSelezione.UseVisualStyleBackColor = true;
            this.butAnnulaSelezione.Click += new System.EventHandler(this.butAnnulaSelezione_Click);
            // 
            // butSelezione
            // 
            this.butSelezione.Location = new System.Drawing.Point(15, 29);
            this.butSelezione.Name = "butSelezione";
            this.butSelezione.Size = new System.Drawing.Size(100, 23);
            this.butSelezione.TabIndex = 0;
            this.butSelezione.Text = "Selezione";
            this.butSelezione.UseVisualStyleBackColor = true;
            this.butSelezione.Click += new System.EventHandler(this.butSelezione_Click);
            // 
            // groupBoxOutput
            // 
            this.groupBoxOutput.Controls.Add(this.richTextBoxOutput);
            this.groupBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxOutput.Location = new System.Drawing.Point(0, 0);
            this.groupBoxOutput.Name = "groupBoxOutput";
            this.groupBoxOutput.Size = new System.Drawing.Size(800, 108);
            this.groupBoxOutput.TabIndex = 0;
            this.groupBoxOutput.TabStop = false;
            this.groupBoxOutput.Text = "Output";
            // 
            // richTextBoxOutput
            // 
            this.richTextBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxOutput.Location = new System.Drawing.Point(3, 16);
            this.richTextBoxOutput.Name = "richTextBoxOutput";
            this.richTextBoxOutput.Size = new System.Drawing.Size(794, 89);
            this.richTextBoxOutput.TabIndex = 0;
            this.richTextBoxOutput.Text = "";
            // 
            // FormFoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormFoto";
            this.Text = "Copia Foto";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBoxData.ResumeLayout(false);
            this.groupBoxData.PerformLayout();
            this.splitContainer1B2.Panel1.ResumeLayout(false);
            this.splitContainer1B2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1B2)).EndInit();
            this.splitContainer1B2.ResumeLayout(false);
            this.groupBoxTipoFoto.ResumeLayout(false);
            this.splitContainer1B2B3.Panel1.ResumeLayout(false);
            this.splitContainer1B2B3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1B2B3)).EndInit();
            this.splitContainer1B2B3.ResumeLayout(false);
            this.groupBoxComandi.ResumeLayout(false);
            this.groupBoxOutput.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker_OraInizio;
        private System.Windows.Forms.DateTimePicker dateTimePicker_DataInizio;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBoxData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker_DataFine;
        private System.Windows.Forms.DateTimePicker dateTimePicker_OraFine;
        private System.Windows.Forms.SplitContainer splitContainer1B2;
        private System.Windows.Forms.GroupBox groupBoxTipoFoto;
        private System.Windows.Forms.SplitContainer splitContainer1B2B3;
        private System.Windows.Forms.GroupBox groupBoxComandi;
        private System.Windows.Forms.Button butSelezione;
        private System.Windows.Forms.GroupBox groupBoxOutput;
        private System.Windows.Forms.RichTextBox richTextBoxOutput;
        private UserControlFoto ucFotoJpeg;
        private UserControlFoto ucFotoRaw;
        private UserControlFoto ucFotoHeic;
        private System.Windows.Forms.Button butAnnulaSelezione;
        private System.Windows.Forms.Button ButAssegna;
        private System.Windows.Forms.Button butAnnullaAssegna;
        private System.Windows.Forms.Button butCopia;
        private System.Windows.Forms.Button butAnnullaCopia;
        private System.Windows.Forms.Button butAggiorna;
    }
}