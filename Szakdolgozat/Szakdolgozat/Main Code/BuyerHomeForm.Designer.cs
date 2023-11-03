
namespace Szakdolgozat.Main_Code
{
    partial class BuyerHomeForm
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
            this.kilépésToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.megrendelésToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eddigiRendelésekMegtekintéseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.Location = new System.Drawing.Point(12, 37);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(776, 377);
            this.panelContent.TabIndex = 32;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kilépésToolStripMenuItem,
            this.megrendelésToolStripMenuItem,
            this.eddigiRendelésekMegtekintéseToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 33;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // kilépésToolStripMenuItem
            // 
            this.kilépésToolStripMenuItem.Name = "kilépésToolStripMenuItem";
            this.kilépésToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.kilépésToolStripMenuItem.Text = "Kilépés";
            this.kilépésToolStripMenuItem.Click += new System.EventHandler(this.kilépésToolStripMenuItem_Click);
            // 
            // megrendelésToolStripMenuItem
            // 
            this.megrendelésToolStripMenuItem.Name = "megrendelésToolStripMenuItem";
            this.megrendelésToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.megrendelésToolStripMenuItem.Text = "Rendelés";
            this.megrendelésToolStripMenuItem.Click += new System.EventHandler(this.megrendelésToolStripMenuItem_Click);
            // 
            // eddigiRendelésekMegtekintéseToolStripMenuItem
            // 
            this.eddigiRendelésekMegtekintéseToolStripMenuItem.Name = "eddigiRendelésekMegtekintéseToolStripMenuItem";
            this.eddigiRendelésekMegtekintéseToolStripMenuItem.Size = new System.Drawing.Size(185, 20);
            this.eddigiRendelésekMegtekintéseToolStripMenuItem.Text = "Eddigi rendelések megtekintése";
            this.eddigiRendelésekMegtekintéseToolStripMenuItem.Click += new System.EventHandler(this.eddigiRendelésekMegtekintéseToolStripMenuItem_Click);
            // 
            // BuyerHomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panelContent);
            this.Name = "BuyerHomeForm";
            this.Text = "Megrendeloi felulet";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BuyerHomeForm_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kilépésToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem megrendelésToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eddigiRendelésekMegtekintéseToolStripMenuItem;
    }
}