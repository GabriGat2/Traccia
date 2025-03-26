namespace Traccia
{
    partial class FormNavigatore
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBoxTraccia = new System.Windows.Forms.GroupBox();
            this.butExplorerTraccia = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxPathTraccia = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.textBoxNomeTraccia = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBoxTraccia.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxTraccia);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 90;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBoxTraccia
            // 
            this.groupBoxTraccia.Controls.Add(this.butExplorerTraccia);
            this.groupBoxTraccia.Controls.Add(this.label10);
            this.groupBoxTraccia.Controls.Add(this.textBoxPathTraccia);
            this.groupBoxTraccia.Controls.Add(this.Label5);
            this.groupBoxTraccia.Controls.Add(this.textBoxNomeTraccia);
            this.groupBoxTraccia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTraccia.Location = new System.Drawing.Point(0, 0);
            this.groupBoxTraccia.Name = "groupBoxTraccia";
            this.groupBoxTraccia.Size = new System.Drawing.Size(800, 90);
            this.groupBoxTraccia.TabIndex = 0;
            this.groupBoxTraccia.TabStop = false;
            this.groupBoxTraccia.Text = "Traccia";
            // 
            // butExplorerTraccia
            // 
            this.butExplorerTraccia.Location = new System.Drawing.Point(762, 42);
            this.butExplorerTraccia.Name = "butExplorerTraccia";
            this.butExplorerTraccia.Size = new System.Drawing.Size(17, 23);
            this.butExplorerTraccia.TabIndex = 24;
            this.butExplorerTraccia.Text = "E";
            this.butExplorerTraccia.UseVisualStyleBackColor = true;
            this.butExplorerTraccia.Click += new System.EventHandler(this.butExplorerTraccia_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Path ";
            // 
            // textBoxPathTraccia
            // 
            this.textBoxPathTraccia.Location = new System.Drawing.Point(129, 45);
            this.textBoxPathTraccia.Name = "textBoxPathTraccia";
            this.textBoxPathTraccia.ReadOnly = true;
            this.textBoxPathTraccia.Size = new System.Drawing.Size(627, 20);
            this.textBoxPathTraccia.TabIndex = 23;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(9, 26);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(35, 13);
            this.Label5.TabIndex = 20;
            this.Label5.Text = "Nome";
            // 
            // textBoxNomeTraccia
            // 
            this.textBoxNomeTraccia.Location = new System.Drawing.Point(129, 19);
            this.textBoxNomeTraccia.Name = "textBoxNomeTraccia";
            this.textBoxNomeTraccia.ReadOnly = true;
            this.textBoxNomeTraccia.Size = new System.Drawing.Size(627, 20);
            this.textBoxNomeTraccia.TabIndex = 21;
            // 
            // FormNavigatore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormNavigatore";
            this.Text = "Navigatore";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBoxTraccia.ResumeLayout(false);
            this.groupBoxTraccia.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBoxTraccia;
        private System.Windows.Forms.Button butExplorerTraccia;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxPathTraccia;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.TextBox textBoxNomeTraccia;
    }
}