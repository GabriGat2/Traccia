namespace Traccia
{
    partial class FormCopiaFoto
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
            this.checkBoxRAW = new System.Windows.Forms.CheckBox();
            this.checkBoxHEIC = new System.Windows.Forms.CheckBox();
            this.checkBoxJPEG = new System.Windows.Forms.CheckBox();
            this.splitContainer1B2B3 = new System.Windows.Forms.SplitContainer();
            this.groupBoxComandi = new System.Windows.Forms.GroupBox();
            this.butAnalizza = new System.Windows.Forms.Button();
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
            this.splitContainer1B2.SplitterDistance = 110;
            this.splitContainer1B2.TabIndex = 0;
            // 
            // groupBoxTipoFoto
            // 
            this.groupBoxTipoFoto.Controls.Add(this.checkBoxRAW);
            this.groupBoxTipoFoto.Controls.Add(this.checkBoxHEIC);
            this.groupBoxTipoFoto.Controls.Add(this.checkBoxJPEG);
            this.groupBoxTipoFoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTipoFoto.Location = new System.Drawing.Point(0, 0);
            this.groupBoxTipoFoto.Name = "groupBoxTipoFoto";
            this.groupBoxTipoFoto.Size = new System.Drawing.Size(800, 110);
            this.groupBoxTipoFoto.TabIndex = 0;
            this.groupBoxTipoFoto.TabStop = false;
            this.groupBoxTipoFoto.Text = "Tipo foto";
            // 
            // checkBoxRAW
            // 
            this.checkBoxRAW.AutoSize = true;
            this.checkBoxRAW.Location = new System.Drawing.Point(49, 76);
            this.checkBoxRAW.Name = "checkBoxRAW";
            this.checkBoxRAW.Size = new System.Drawing.Size(48, 17);
            this.checkBoxRAW.TabIndex = 3;
            this.checkBoxRAW.Text = "RAV";
            this.checkBoxRAW.UseVisualStyleBackColor = true;
            // 
            // checkBoxHEIC
            // 
            this.checkBoxHEIC.AutoSize = true;
            this.checkBoxHEIC.Location = new System.Drawing.Point(49, 53);
            this.checkBoxHEIC.Name = "checkBoxHEIC";
            this.checkBoxHEIC.Size = new System.Drawing.Size(51, 17);
            this.checkBoxHEIC.TabIndex = 2;
            this.checkBoxHEIC.Text = "HEIC";
            this.checkBoxHEIC.UseVisualStyleBackColor = true;
            // 
            // checkBoxJPEG
            // 
            this.checkBoxJPEG.AutoSize = true;
            this.checkBoxJPEG.Location = new System.Drawing.Point(49, 30);
            this.checkBoxJPEG.Name = "checkBoxJPEG";
            this.checkBoxJPEG.Size = new System.Drawing.Size(53, 17);
            this.checkBoxJPEG.TabIndex = 1;
            this.checkBoxJPEG.Text = "JPEG";
            this.checkBoxJPEG.UseVisualStyleBackColor = true;
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
            this.splitContainer1B2B3.Size = new System.Drawing.Size(800, 262);
            this.splitContainer1B2B3.SplitterDistance = 70;
            this.splitContainer1B2B3.TabIndex = 0;
            // 
            // groupBoxComandi
            // 
            this.groupBoxComandi.Controls.Add(this.butAnalizza);
            this.groupBoxComandi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxComandi.Location = new System.Drawing.Point(0, 0);
            this.groupBoxComandi.Name = "groupBoxComandi";
            this.groupBoxComandi.Size = new System.Drawing.Size(800, 70);
            this.groupBoxComandi.TabIndex = 0;
            this.groupBoxComandi.TabStop = false;
            this.groupBoxComandi.Text = "Comandi";
            // 
            // butAnalizza
            // 
            this.butAnalizza.Location = new System.Drawing.Point(27, 29);
            this.butAnalizza.Name = "butAnalizza";
            this.butAnalizza.Size = new System.Drawing.Size(75, 23);
            this.butAnalizza.TabIndex = 0;
            this.butAnalizza.Text = "Analizza";
            this.butAnalizza.UseVisualStyleBackColor = true;
            this.butAnalizza.Click += new System.EventHandler(this.butAnalizza_Click);
            // 
            // groupBoxOutput
            // 
            this.groupBoxOutput.Controls.Add(this.richTextBoxOutput);
            this.groupBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxOutput.Location = new System.Drawing.Point(0, 0);
            this.groupBoxOutput.Name = "groupBoxOutput";
            this.groupBoxOutput.Size = new System.Drawing.Size(800, 188);
            this.groupBoxOutput.TabIndex = 0;
            this.groupBoxOutput.TabStop = false;
            this.groupBoxOutput.Text = "Output";
            // 
            // richTextBoxOutput
            // 
            this.richTextBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxOutput.Location = new System.Drawing.Point(3, 16);
            this.richTextBoxOutput.Name = "richTextBoxOutput";
            this.richTextBoxOutput.Size = new System.Drawing.Size(794, 169);
            this.richTextBoxOutput.TabIndex = 0;
            this.richTextBoxOutput.Text = "";
            // 
            // FormCopiaFoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormCopiaFoto";
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
            this.groupBoxTipoFoto.PerformLayout();
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
        private System.Windows.Forms.CheckBox checkBoxHEIC;
        private System.Windows.Forms.CheckBox checkBoxJPEG;
        private System.Windows.Forms.CheckBox checkBoxRAW;
        private System.Windows.Forms.SplitContainer splitContainer1B2B3;
        private System.Windows.Forms.GroupBox groupBoxComandi;
        private System.Windows.Forms.Button butAnalizza;
        private System.Windows.Forms.GroupBox groupBoxOutput;
        private System.Windows.Forms.RichTextBox richTextBoxOutput;
    }
}