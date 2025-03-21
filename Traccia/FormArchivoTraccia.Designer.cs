namespace Traccia
{
    partial class FormArchivoTraccia
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
            this.textBoxPathEscursione = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPrefisso = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextDescrizione = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBoxEscursione = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxNomeEscursione = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPathInputDati = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBoxTraccia = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxPathArchivio = new System.Windows.Forms.TextBox();
            this.checkBoxSingola = new System.Windows.Forms.CheckBox();
            this.checkBoxGiorno = new System.Windows.Forms.CheckBox();
            this.comboBoxMezzo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxLettera = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.Label5 = new System.Windows.Forms.Label();
            this.textBoxArchivio = new System.Windows.Forms.TextBox();
            this.groupBoxDescrizione = new System.Windows.Forms.GroupBox();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.groupBoxComandi = new System.Windows.Forms.GroupBox();
            this.butCreaTraccia = new System.Windows.Forms.Button();
            this.butNuovaTraccia = new System.Windows.Forms.Button();
            this.butAggiorna = new System.Windows.Forms.Button();
            this.groupBoxOutput = new System.Windows.Forms.GroupBox();
            this.richTextBoxOutput = new System.Windows.Forms.RichTextBox();
            this.butCopiaFoto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBoxEscursione.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBoxTraccia.SuspendLayout();
            this.groupBoxDescrizione.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.groupBoxComandi.SuspendLayout();
            this.groupBoxOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxPathEscursione
            // 
            this.textBoxPathEscursione.Location = new System.Drawing.Point(141, 38);
            this.textBoxPathEscursione.Name = "textBoxPathEscursione";
            this.textBoxPathEscursione.ReadOnly = true;
            this.textBoxPathEscursione.Size = new System.Drawing.Size(627, 20);
            this.textBoxPathEscursione.TabIndex = 1;
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
            this.richTextDescrizione.Size = new System.Drawing.Size(790, 108);
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
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxEscursione);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(796, 570);
            this.splitContainer1.SplitterDistance = 90;
            this.splitContainer1.TabIndex = 9;
            // 
            // groupBoxEscursione
            // 
            this.groupBoxEscursione.Controls.Add(this.label7);
            this.groupBoxEscursione.Controls.Add(this.textBoxNomeEscursione);
            this.groupBoxEscursione.Controls.Add(this.label6);
            this.groupBoxEscursione.Controls.Add(this.textBoxPathInputDati);
            this.groupBoxEscursione.Controls.Add(this.label1);
            this.groupBoxEscursione.Controls.Add(this.textBoxPathEscursione);
            this.groupBoxEscursione.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxEscursione.Location = new System.Drawing.Point(0, 0);
            this.groupBoxEscursione.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxEscursione.Name = "groupBoxEscursione";
            this.groupBoxEscursione.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxEscursione.Size = new System.Drawing.Size(796, 90);
            this.groupBoxEscursione.TabIndex = 0;
            this.groupBoxEscursione.TabStop = false;
            this.groupBoxEscursione.Text = "Escursione";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 20);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Nome Escursione";
            // 
            // textBoxNomeEscursione
            // 
            this.textBoxNomeEscursione.Location = new System.Drawing.Point(141, 18);
            this.textBoxNomeEscursione.Name = "textBoxNomeEscursione";
            this.textBoxNomeEscursione.ReadOnly = true;
            this.textBoxNomeEscursione.Size = new System.Drawing.Size(627, 20);
            this.textBoxNomeEscursione.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 65);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Path Input Dati";
            // 
            // textBoxPathInputDati
            // 
            this.textBoxPathInputDati.Location = new System.Drawing.Point(141, 63);
            this.textBoxPathInputDati.Name = "textBoxPathInputDati";
            this.textBoxPathInputDati.ReadOnly = true;
            this.textBoxPathInputDati.Size = new System.Drawing.Size(627, 20);
            this.textBoxPathInputDati.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Path Escursione";
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
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            this.splitContainer2.Panel1MinSize = 50;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer2.Size = new System.Drawing.Size(796, 476);
            this.splitContainer2.SplitterDistance = 290;
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
            this.splitContainer3.Panel1.Controls.Add(this.groupBoxTraccia);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.groupBoxDescrizione);
            this.splitContainer3.Size = new System.Drawing.Size(796, 290);
            this.splitContainer3.SplitterDistance = 160;
            this.splitContainer3.SplitterWidth = 3;
            this.splitContainer3.TabIndex = 11;
            // 
            // groupBoxTraccia
            // 
            this.groupBoxTraccia.Controls.Add(this.label10);
            this.groupBoxTraccia.Controls.Add(this.textBoxPathArchivio);
            this.groupBoxTraccia.Controls.Add(this.checkBoxSingola);
            this.groupBoxTraccia.Controls.Add(this.checkBoxGiorno);
            this.groupBoxTraccia.Controls.Add(this.comboBoxMezzo);
            this.groupBoxTraccia.Controls.Add(this.label9);
            this.groupBoxTraccia.Controls.Add(this.comboBoxLettera);
            this.groupBoxTraccia.Controls.Add(this.label8);
            this.groupBoxTraccia.Controls.Add(this.dateTimePicker1);
            this.groupBoxTraccia.Controls.Add(this.Label5);
            this.groupBoxTraccia.Controls.Add(this.textBoxPrefisso);
            this.groupBoxTraccia.Controls.Add(this.label3);
            this.groupBoxTraccia.Controls.Add(this.textBoxArchivio);
            this.groupBoxTraccia.Controls.Add(this.label2);
            this.groupBoxTraccia.Controls.Add(this.textBoxNome);
            this.groupBoxTraccia.Controls.Add(this.label4);
            this.groupBoxTraccia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTraccia.Location = new System.Drawing.Point(0, 0);
            this.groupBoxTraccia.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxTraccia.Name = "groupBoxTraccia";
            this.groupBoxTraccia.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxTraccia.Size = new System.Drawing.Size(796, 160);
            this.groupBoxTraccia.TabIndex = 0;
            this.groupBoxTraccia.TabStop = false;
            this.groupBoxTraccia.Text = "Traccia";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 129);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Path Archivio";
            // 
            // textBoxPathArchivio
            // 
            this.textBoxPathArchivio.Location = new System.Drawing.Point(141, 122);
            this.textBoxPathArchivio.Name = "textBoxPathArchivio";
            this.textBoxPathArchivio.ReadOnly = true;
            this.textBoxPathArchivio.Size = new System.Drawing.Size(627, 20);
            this.textBoxPathArchivio.TabIndex = 18;
            // 
            // checkBoxSingola
            // 
            this.checkBoxSingola.AutoSize = true;
            this.checkBoxSingola.Location = new System.Drawing.Point(707, 20);
            this.checkBoxSingola.Name = "checkBoxSingola";
            this.checkBoxSingola.Size = new System.Drawing.Size(61, 17);
            this.checkBoxSingola.TabIndex = 16;
            this.checkBoxSingola.Text = "Singola";
            this.checkBoxSingola.UseVisualStyleBackColor = true;
            this.checkBoxSingola.CheckedChanged += new System.EventHandler(this.checkBoxSingola_CheckedChanged);
            // 
            // checkBoxGiorno
            // 
            this.checkBoxGiorno.AutoSize = true;
            this.checkBoxGiorno.Location = new System.Drawing.Point(633, 20);
            this.checkBoxGiorno.Name = "checkBoxGiorno";
            this.checkBoxGiorno.Size = new System.Drawing.Size(57, 17);
            this.checkBoxGiorno.TabIndex = 15;
            this.checkBoxGiorno.Text = "Giorno";
            this.checkBoxGiorno.UseVisualStyleBackColor = true;
            this.checkBoxGiorno.CheckedChanged += new System.EventHandler(this.checkBoxGiorno_CheckedChanged);
            // 
            // comboBoxMezzo
            // 
            this.comboBoxMezzo.FormattingEnabled = true;
            this.comboBoxMezzo.Location = new System.Drawing.Point(431, 16);
            this.comboBoxMezzo.Name = "comboBoxMezzo";
            this.comboBoxMezzo.Size = new System.Drawing.Size(187, 21);
            this.comboBoxMezzo.TabIndex = 14;
            this.comboBoxMezzo.SelectedValueChanged += new System.EventHandler(this.comboBoxMezzo_SelectedValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(387, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Mezzo";
            // 
            // comboBoxLettera
            // 
            this.comboBoxLettera.FormattingEnabled = true;
            this.comboBoxLettera.Location = new System.Drawing.Point(321, 18);
            this.comboBoxLettera.Name = "comboBoxLettera";
            this.comboBoxLettera.Size = new System.Drawing.Size(46, 21);
            this.comboBoxLettera.TabIndex = 12;
            this.comboBoxLettera.SelectedIndexChanged += new System.EventHandler(this.comboBoxLettera_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(275, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Lettera";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(141, 18);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(115, 20);
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
            this.textBoxArchivio.Location = new System.Drawing.Point(141, 96);
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
            this.groupBoxDescrizione.Size = new System.Drawing.Size(796, 127);
            this.groupBoxDescrizione.TabIndex = 0;
            this.groupBoxDescrizione.TabStop = false;
            this.groupBoxDescrizione.Text = "Descrizione";
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.splitContainer4.Size = new System.Drawing.Size(796, 182);
            this.splitContainer4.SplitterDistance = 60;
            this.splitContainer4.SplitterWidth = 3;
            this.splitContainer4.TabIndex = 0;
            // 
            // groupBoxComandi
            // 
            this.groupBoxComandi.Controls.Add(this.butCopiaFoto);
            this.groupBoxComandi.Controls.Add(this.butCreaTraccia);
            this.groupBoxComandi.Controls.Add(this.butNuovaTraccia);
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
            // butCreaTraccia
            // 
            this.butCreaTraccia.Location = new System.Drawing.Point(10, 18);
            this.butCreaTraccia.Name = "butCreaTraccia";
            this.butCreaTraccia.Size = new System.Drawing.Size(145, 23);
            this.butCreaTraccia.TabIndex = 13;
            this.butCreaTraccia.Text = "Crea Archivio Traccia";
            this.butCreaTraccia.UseVisualStyleBackColor = true;
            this.butCreaTraccia.Click += new System.EventHandler(this.butCreaTraccia_Click);
            // 
            // butNuovaTraccia
            // 
            this.butNuovaTraccia.Location = new System.Drawing.Point(214, 18);
            this.butNuovaTraccia.Name = "butNuovaTraccia";
            this.butNuovaTraccia.Size = new System.Drawing.Size(101, 23);
            this.butNuovaTraccia.TabIndex = 12;
            this.butNuovaTraccia.Text = "Nuova Traccia";
            this.butNuovaTraccia.UseVisualStyleBackColor = true;
            this.butNuovaTraccia.Click += new System.EventHandler(this.butNuovaTraccia_Click);
            // 
            // butAggiorna
            // 
            this.butAggiorna.Location = new System.Drawing.Point(712, 26);
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
            this.groupBoxOutput.Size = new System.Drawing.Size(796, 119);
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
            this.richTextBoxOutput.Size = new System.Drawing.Size(792, 102);
            this.richTextBoxOutput.TabIndex = 0;
            this.richTextBoxOutput.Text = "";
            // 
            // butCopiaFoto
            // 
            this.butCopiaFoto.Location = new System.Drawing.Point(505, 18);
            this.butCopiaFoto.Name = "butCopiaFoto";
            this.butCopiaFoto.Size = new System.Drawing.Size(101, 23);
            this.butCopiaFoto.TabIndex = 14;
            this.butCopiaFoto.Text = "Copia Foto";
            this.butCopiaFoto.UseVisualStyleBackColor = true;
            this.butCopiaFoto.Click += new System.EventHandler(this.butCopiaFoto_Click);
            // 
            // FormArchivoTraccia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 570);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormArchivoTraccia";
            this.Text = "Archivio Traccia";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBoxEscursione.ResumeLayout(false);
            this.groupBoxEscursione.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBoxTraccia.ResumeLayout(false);
            this.groupBoxTraccia.PerformLayout();
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
        private System.Windows.Forms.TextBox textBoxPathEscursione;
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
        private System.Windows.Forms.Button butNuovaTraccia;
        private System.Windows.Forms.Button butAggiorna;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox groupBoxTraccia;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.GroupBox groupBoxComandi;
        private System.Windows.Forms.GroupBox groupBoxOutput;
        private System.Windows.Forms.RichTextBox richTextBoxOutput;
        private System.Windows.Forms.GroupBox groupBoxEscursione;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxPathInputDati;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxNomeEscursione;
        private System.Windows.Forms.Button butCreaTraccia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxLettera;
        private System.Windows.Forms.ComboBox comboBoxMezzo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBoxGiorno;
        private System.Windows.Forms.CheckBox checkBoxSingola;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxPathArchivio;
        private System.Windows.Forms.Button butCopiaFoto;
    }
}