
namespace Szakdolgozat.Main_Code
{
    partial class OperatorHomeForm
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
            this.panelContent = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.legyártottTermékekFelviteleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maFelvittTermékekListázásaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kilépésToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.Location = new System.Drawing.Point(12, 48);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(776, 390);
            this.panelContent.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.legyártottTermékekFelviteleToolStripMenuItem,
            this.maFelvittTermékekListázásaToolStripMenuItem,
            this.kilépésToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // legyártottTermékekFelviteleToolStripMenuItem
            // 
            this.legyártottTermékekFelviteleToolStripMenuItem.Name = "legyártottTermékekFelviteleToolStripMenuItem";
            this.legyártottTermékekFelviteleToolStripMenuItem.Size = new System.Drawing.Size(169, 20);
            this.legyártottTermékekFelviteleToolStripMenuItem.Text = "Legyártott termékek felvitele";
            this.legyártottTermékekFelviteleToolStripMenuItem.Click += new System.EventHandler(this.legyártottTermékekFelviteleToolStripMenuItem_Click);
            // 
            // maFelvittTermékekListázásaToolStripMenuItem
            // 
            this.maFelvittTermékekListázásaToolStripMenuItem.Name = "maFelvittTermékekListázásaToolStripMenuItem";
            this.maFelvittTermékekListázásaToolStripMenuItem.Size = new System.Drawing.Size(167, 20);
            this.maFelvittTermékekListázásaToolStripMenuItem.Text = "Ma felvitt termékek listázása";
            this.maFelvittTermékekListázásaToolStripMenuItem.Click += new System.EventHandler(this.maFelvittTermékekListázásaToolStripMenuItem_Click);
            // 
            // kilépésToolStripMenuItem
            // 
            this.kilépésToolStripMenuItem.Name = "kilépésToolStripMenuItem";
            this.kilépésToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.kilépésToolStripMenuItem.Text = "Kilépés";
            this.kilépésToolStripMenuItem.Click += new System.EventHandler(this.kilépésToolStripMenuItem_Click);
            // 
            // OperatorHomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "OperatorHomeForm";
            this.Text = "Operatori felulet";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HomeForm_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem legyártottTermékekFelviteleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maFelvittTermékekListázásaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kilépésToolStripMenuItem;
    }
}