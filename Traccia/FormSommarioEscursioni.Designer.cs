namespace Traccia
{
    partial class FormSommarioEscursioni
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
            this.butAnnulla = new System.Windows.Forms.Button();
            this.butApri = new System.Windows.Forms.Button();
            this.textBoxPathEscursione = new System.Windows.Forms.TextBox();
            this.groupBoxSommarioDelleEscursioni = new System.Windows.Forms.GroupBox();
            this.treeViewSommarioEscursioni = new System.Windows.Forms.TreeView();
            this.groupBoxSommarioDelleEscursioni.SuspendLayout();
            this.SuspendLayout();
            // 
            // butAnnulla
            // 
            this.butAnnulla.Location = new System.Drawing.Point(17, 508);
            this.butAnnulla.Name = "butAnnulla";
            this.butAnnulla.Size = new System.Drawing.Size(75, 23);
            this.butAnnulla.TabIndex = 10;
            this.butAnnulla.Text = "Annulla";
            this.butAnnulla.UseVisualStyleBackColor = true;
            this.butAnnulla.Click += new System.EventHandler(this.butAnnulla_Click);
            // 
            // butApri
            // 
            this.butApri.Location = new System.Drawing.Point(17, 482);
            this.butApri.Name = "butApri";
            this.butApri.Size = new System.Drawing.Size(75, 23);
            this.butApri.TabIndex = 9;
            this.butApri.Text = "Apri";
            this.butApri.UseVisualStyleBackColor = true;
            this.butApri.Click += new System.EventHandler(this.butApri_Click);
            // 
            // textBoxPathEscursione
            // 
            this.textBoxPathEscursione.Location = new System.Drawing.Point(110, 484);
            this.textBoxPathEscursione.Name = "textBoxPathEscursione";
            this.textBoxPathEscursione.Size = new System.Drawing.Size(953, 20);
            this.textBoxPathEscursione.TabIndex = 8;
            // 
            // groupBoxSommarioDelleEscursioni
            // 
            this.groupBoxSommarioDelleEscursioni.Controls.Add(this.treeViewSommarioEscursioni);
            this.groupBoxSommarioDelleEscursioni.Location = new System.Drawing.Point(14, 14);
            this.groupBoxSommarioDelleEscursioni.Name = "groupBoxSommarioDelleEscursioni";
            this.groupBoxSommarioDelleEscursioni.Size = new System.Drawing.Size(1052, 461);
            this.groupBoxSommarioDelleEscursioni.TabIndex = 7;
            this.groupBoxSommarioDelleEscursioni.TabStop = false;
            this.groupBoxSommarioDelleEscursioni.Text = "Sommario delle escursioni";
            // 
            // treeViewSommarioEscursioni
            // 
            this.treeViewSommarioEscursioni.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewSommarioEscursioni.Location = new System.Drawing.Point(3, 16);
            this.treeViewSommarioEscursioni.Name = "treeViewSommarioEscursioni";
            this.treeViewSommarioEscursioni.Size = new System.Drawing.Size(1046, 442);
            this.treeViewSommarioEscursioni.TabIndex = 0;
            this.treeViewSommarioEscursioni.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewSommarioEscursioni_AfterSelect);
            // 
            // FormSommarioEscursioni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 544);
            this.Controls.Add(this.butAnnulla);
            this.Controls.Add(this.butApri);
            this.Controls.Add(this.textBoxPathEscursione);
            this.Controls.Add(this.groupBoxSommarioDelleEscursioni);
            this.Name = "FormSommarioEscursioni";
            this.Text = "Sommario Escursioni";
            this.groupBoxSommarioDelleEscursioni.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button butAnnulla;
        private System.Windows.Forms.Button butApri;
        private System.Windows.Forms.TextBox textBoxPathEscursione;
        private System.Windows.Forms.GroupBox groupBoxSommarioDelleEscursioni;
        private System.Windows.Forms.TreeView treeViewSommarioEscursioni;
    }
}