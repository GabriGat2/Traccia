namespace Traccia
{
    partial class FormSommario
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
            this.groupBoxSommarioTracce = new System.Windows.Forms.GroupBox();
            this.richTextBoxSommarioTracce = new System.Windows.Forms.RichTextBox();
            this.butAggiorna = new System.Windows.Forms.Button();
            this.groupBoxSommarioTracce.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSommarioTracce
            // 
            this.groupBoxSommarioTracce.Controls.Add(this.richTextBoxSommarioTracce);
            this.groupBoxSommarioTracce.Location = new System.Drawing.Point(259, 85);
            this.groupBoxSommarioTracce.Name = "groupBoxSommarioTracce";
            this.groupBoxSommarioTracce.Size = new System.Drawing.Size(644, 330);
            this.groupBoxSommarioTracce.TabIndex = 0;
            this.groupBoxSommarioTracce.TabStop = false;
            this.groupBoxSommarioTracce.Text = "Sommario delle tracce";
            // 
            // richTextBoxSommarioTracce
            // 
            this.richTextBoxSommarioTracce.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxSommarioTracce.Location = new System.Drawing.Point(3, 16);
            this.richTextBoxSommarioTracce.Name = "richTextBoxSommarioTracce";
            this.richTextBoxSommarioTracce.Size = new System.Drawing.Size(638, 311);
            this.richTextBoxSommarioTracce.TabIndex = 0;
            this.richTextBoxSommarioTracce.Text = "";
            // 
            // butAggiorna
            // 
            this.butAggiorna.Location = new System.Drawing.Point(12, 50);
            this.butAggiorna.Name = "butAggiorna";
            this.butAggiorna.Size = new System.Drawing.Size(75, 23);
            this.butAggiorna.TabIndex = 1;
            this.butAggiorna.Text = "Aggiorna";
            this.butAggiorna.UseVisualStyleBackColor = true;
            this.butAggiorna.Click += new System.EventHandler(this.butAggiorna_Click);
            // 
            // FormSommario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 544);
            this.Controls.Add(this.butAggiorna);
            this.Controls.Add(this.groupBoxSommarioTracce);
            this.Name = "FormSommario";
            this.Text = "FormSommario";
            this.groupBoxSommarioTracce.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSommarioTracce;
        private System.Windows.Forms.RichTextBox richTextBoxSommarioTracce;
        private System.Windows.Forms.Button butAggiorna;
    }
}