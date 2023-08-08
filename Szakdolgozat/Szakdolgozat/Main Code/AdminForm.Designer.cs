
namespace Szakdolgozat
{
    partial class AdminForm
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
            this.LB_szerepkorok = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_nev = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_jelszo = new System.Windows.Forms.TextBox();
            this.BT_felhasznalofelvitel = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.kilépésToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LB_szerepkorok
            // 
            this.LB_szerepkorok.FormattingEnabled = true;
            this.LB_szerepkorok.Location = new System.Drawing.Point(190, 190);
            this.LB_szerepkorok.Name = "LB_szerepkorok";
            this.LB_szerepkorok.Size = new System.Drawing.Size(314, 186);
            this.LB_szerepkorok.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(190, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Szerepkörök:";
            // 
            // TB_nev
            // 
            this.TB_nev.Location = new System.Drawing.Point(274, 81);
            this.TB_nev.Name = "TB_nev";
            this.TB_nev.Size = new System.Drawing.Size(100, 20);
            this.TB_nev.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Név:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Jelszó:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(269, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(209, 25);
            this.label4.TabIndex = 12;
            this.label4.Text = "Felhasználó felvitele";
            // 
            // TB_jelszo
            // 
            this.TB_jelszo.Location = new System.Drawing.Point(274, 127);
            this.TB_jelszo.Name = "TB_jelszo";
            this.TB_jelszo.Size = new System.Drawing.Size(100, 20);
            this.TB_jelszo.TabIndex = 13;
            // 
            // BT_felhasznalofelvitel
            // 
            this.BT_felhasznalofelvitel.Location = new System.Drawing.Point(291, 392);
            this.BT_felhasznalofelvitel.Name = "BT_felhasznalofelvitel";
            this.BT_felhasznalofelvitel.Size = new System.Drawing.Size(119, 23);
            this.BT_felhasznalofelvitel.TabIndex = 14;
            this.BT_felhasznalofelvitel.Text = "Felhasználó felvitele";
            this.BT_felhasznalofelvitel.UseVisualStyleBackColor = true;
            this.BT_felhasznalofelvitel.Click += new System.EventHandler(this.BT_felhasznalofelvitel_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kilépésToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // kilépésToolStripMenuItem
            // 
            this.kilépésToolStripMenuItem.Name = "kilépésToolStripMenuItem";
            this.kilépésToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.kilépésToolStripMenuItem.Text = "Kilépés";
            this.kilépésToolStripMenuItem.Click += new System.EventHandler(this.kilépésToolStripMenuItem_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BT_felhasznalofelvitel);
            this.Controls.Add(this.TB_jelszo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TB_nev);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LB_szerepkorok);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AdminForm";
            this.Text = "Adminisztratori felulet";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminForm_FormClosed);
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LB_szerepkorok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_nev;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TB_jelszo;
        private System.Windows.Forms.Button BT_felhasznalofelvitel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kilépésToolStripMenuItem;
    }
}