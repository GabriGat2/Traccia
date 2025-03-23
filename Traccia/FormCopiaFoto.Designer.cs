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
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker_DataInizio = new System.Windows.Forms.DateTimePicker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBoxData = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker_DataFine = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_OraFine = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBoxData.SuspendLayout();
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
            this.dateTimePicker_OraInizio.ValueChanged += new System.EventHandler(this.dateTimePicker_OraInizio_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(589, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker_DataInizio
            // 
            this.dateTimePicker_DataInizio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_DataInizio.Location = new System.Drawing.Point(49, 27);
            this.dateTimePicker_DataInizio.Name = "dateTimePicker_DataInizio";
            this.dateTimePicker_DataInizio.Size = new System.Drawing.Size(98, 20);
            this.dateTimePicker_DataInizio.TabIndex = 3;
            this.dateTimePicker_DataInizio.ValueChanged += new System.EventHandler(this.dateTimePicker_DataInizio_ValueChanged);
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
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 225;
            this.splitContainer1.TabIndex = 4;
            // 
            // groupBoxData
            // 
            this.groupBoxData.Controls.Add(this.textBox2);
            this.groupBoxData.Controls.Add(this.textBox1);
            this.groupBoxData.Controls.Add(this.label2);
            this.groupBoxData.Controls.Add(this.dateTimePicker_DataFine);
            this.groupBoxData.Controls.Add(this.dateTimePicker_OraFine);
            this.groupBoxData.Controls.Add(this.label1);
            this.groupBoxData.Controls.Add(this.dateTimePicker_DataInizio);
            this.groupBoxData.Controls.Add(this.button1);
            this.groupBoxData.Controls.Add(this.dateTimePicker_OraInizio);
            this.groupBoxData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxData.Location = new System.Drawing.Point(0, 0);
            this.groupBoxData.Name = "groupBoxData";
            this.groupBoxData.Size = new System.Drawing.Size(800, 225);
            this.groupBoxData.TabIndex = 0;
            this.groupBoxData.TabStop = false;
            this.groupBoxData.Text = "Selezione data e ora";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(307, 95);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(175, 20);
            this.textBox2.TabIndex = 9;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(49, 95);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(175, 20);
            this.textBox1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(270, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Fine";
            // 
            // dateTimePicker_DataFine
            // 
            this.dateTimePicker_DataFine.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_DataFine.Location = new System.Drawing.Point(307, 26);
            this.dateTimePicker_DataFine.Name = "dateTimePicker_DataFine";
            this.dateTimePicker_DataFine.Size = new System.Drawing.Size(98, 20);
            this.dateTimePicker_DataFine.TabIndex = 6;
            this.dateTimePicker_DataFine.ValueChanged += new System.EventHandler(this.dateTimePicker_DataFine_ValueChanged);
            // 
            // dateTimePicker_OraFine
            // 
            this.dateTimePicker_OraFine.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker_OraFine.Location = new System.Drawing.Point(411, 26);
            this.dateTimePicker_OraFine.Name = "dateTimePicker_OraFine";
            this.dateTimePicker_OraFine.ShowUpDown = true;
            this.dateTimePicker_OraFine.Size = new System.Drawing.Size(71, 20);
            this.dateTimePicker_OraFine.TabIndex = 5;
            this.dateTimePicker_OraFine.ValueChanged += new System.EventHandler(this.dateTimePicker_OraFine_ValueChanged);
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
            // FormCopiaFoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormCopiaFoto";
            this.Text = "Copia Foto";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBoxData.ResumeLayout(false);
            this.groupBoxData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker_OraInizio;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_DataInizio;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBoxData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker_DataFine;
        private System.Windows.Forms.DateTimePicker dateTimePicker_OraFine;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}