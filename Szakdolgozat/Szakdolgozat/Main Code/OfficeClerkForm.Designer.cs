
namespace Szakdolgozat
{
    partial class OfficeClerkForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.kilépésToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelContent = new System.Windows.Forms.Panel();
            this.alkatrészTermékhezRendeléseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kilépésToolStripMenuItem,
            this.alkatrészTermékhezRendeléseToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // kilépésToolStripMenuItem
            // 
            this.kilépésToolStripMenuItem.Name = "kilépésToolStripMenuItem";
            this.kilépésToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.kilépésToolStripMenuItem.Text = "Kilépés";
            this.kilépésToolStripMenuItem.Click += new System.EventHandler(this.kilépésToolStripMenuItem_Click);
            // 
            // panelContent
            // 
            this.panelContent.Location = new System.Drawing.Point(13, 41);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(775, 397);
            this.panelContent.TabIndex = 19;
            // 
            // alkatrészTermékhezRendeléseToolStripMenuItem
            // 
            this.alkatrészTermékhezRendeléseToolStripMenuItem.Name = "alkatrészTermékhezRendeléseToolStripMenuItem";
            this.alkatrészTermékhezRendeléseToolStripMenuItem.Size = new System.Drawing.Size(177, 20);
            this.alkatrészTermékhezRendeléseToolStripMenuItem.Text = "Alkatrész termékhez rendelése";
            // 
            // OfficeClerkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.menuStrip1);
            this.Name = "OfficeClerkForm";
            this.Text = "Irodista felulet";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OfficeClerkForm_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kilépésToolStripMenuItem;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.ToolStripMenuItem alkatrészTermékhezRendeléseToolStripMenuItem;
    }
}