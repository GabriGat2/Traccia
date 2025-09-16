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
            this.groupBoxSommarioDelleTracce2 = new System.Windows.Forms.GroupBox();
            this.treeViewSommarioTracce = new System.Windows.Forms.TreeView();
            this.textBoxPathTraccia = new System.Windows.Forms.TextBox();
            this.butApri = new System.Windows.Forms.Button();
            this.butAnnulla = new System.Windows.Forms.Button();
            this.groupBoxSommarioDelleTracce2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSommarioDelleTracce2
            // 
            this.groupBoxSommarioDelleTracce2.Controls.Add(this.treeViewSommarioTracce);
            this.groupBoxSommarioDelleTracce2.Location = new System.Drawing.Point(12, 15);
            this.groupBoxSommarioDelleTracce2.Name = "groupBoxSommarioDelleTracce2";
            this.groupBoxSommarioDelleTracce2.Size = new System.Drawing.Size(1052, 461);
            this.groupBoxSommarioDelleTracce2.TabIndex = 2;
            this.groupBoxSommarioDelleTracce2.TabStop = false;
            this.groupBoxSommarioDelleTracce2.Text = "Sommario dell tracce";
            // 
            // treeViewSommarioTracce
            // 
            this.treeViewSommarioTracce.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewSommarioTracce.Location = new System.Drawing.Point(3, 16);
            this.treeViewSommarioTracce.Name = "treeViewSommarioTracce";
            this.treeViewSommarioTracce.Size = new System.Drawing.Size(1046, 442);
            this.treeViewSommarioTracce.TabIndex = 0;
            this.treeViewSommarioTracce.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeViewSommarioTracce_MouseClick);
            this.treeViewSommarioTracce.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeViewSommarioTracce_MouseDoubleClick);
            // 
            // textBoxPathTraccia
            // 
            this.textBoxPathTraccia.Location = new System.Drawing.Point(108, 485);
            this.textBoxPathTraccia.Name = "textBoxPathTraccia";
            this.textBoxPathTraccia.Size = new System.Drawing.Size(953, 20);
            this.textBoxPathTraccia.TabIndex = 3;
            // 
            // butApri
            // 
            this.butApri.Location = new System.Drawing.Point(15, 483);
            this.butApri.Name = "butApri";
            this.butApri.Size = new System.Drawing.Size(75, 23);
            this.butApri.TabIndex = 4;
            this.butApri.Text = "Apri";
            this.butApri.UseVisualStyleBackColor = true;
            this.butApri.Click += new System.EventHandler(this.butApri_Click);
            // 
            // butAnnulla
            // 
            this.butAnnulla.Location = new System.Drawing.Point(15, 509);
            this.butAnnulla.Name = "butAnnulla";
            this.butAnnulla.Size = new System.Drawing.Size(75, 23);
            this.butAnnulla.TabIndex = 5;
            this.butAnnulla.Text = "Annulla";
            this.butAnnulla.UseVisualStyleBackColor = true;
            this.butAnnulla.Click += new System.EventHandler(this.butAnnulla_Click);
            // 
            // FormSommario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 544);
            this.Controls.Add(this.butAnnulla);
            this.Controls.Add(this.butApri);
            this.Controls.Add(this.textBoxPathTraccia);
            this.Controls.Add(this.groupBoxSommarioDelleTracce2);
            this.Name = "FormSommario";
            this.Text = "Sommario delle tracce";
            this.groupBoxSommarioDelleTracce2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxSommarioDelleTracce2;
        private System.Windows.Forms.TreeView treeViewSommarioTracce;
        private System.Windows.Forms.TextBox textBoxPathTraccia;
        private System.Windows.Forms.Button butApri;
        private System.Windows.Forms.Button butAnnulla;
    }
}