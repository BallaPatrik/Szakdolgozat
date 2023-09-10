
namespace Szakdolgozat
{
    partial class LoginForm
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
            this.TB_jelszo = new System.Windows.Forms.TextBox();
            this.TB_felhnev = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BT_bejelentkezes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TB_jelszo
            // 
            this.TB_jelszo.Location = new System.Drawing.Point(333, 152);
            this.TB_jelszo.Name = "TB_jelszo";
            this.TB_jelszo.PasswordChar = '*';
            this.TB_jelszo.Size = new System.Drawing.Size(100, 20);
            this.TB_jelszo.TabIndex = 10;
            // 
            // TB_felhnev
            // 
            this.TB_felhnev.Location = new System.Drawing.Point(333, 123);
            this.TB_felhnev.Name = "TB_felhnev";
            this.TB_felhnev.Size = new System.Drawing.Size(100, 20);
            this.TB_felhnev.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(288, 159);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Jelszó:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(238, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Felhasználói név:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(310, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "LOGIN felület";
            // 
            // BT_bejelentkezes
            // 
            this.BT_bejelentkezes.Location = new System.Drawing.Point(333, 189);
            this.BT_bejelentkezes.Name = "BT_bejelentkezes";
            this.BT_bejelentkezes.Size = new System.Drawing.Size(87, 23);
            this.BT_bejelentkezes.TabIndex = 12;
            this.BT_bejelentkezes.Text = "Bejelentkezés";
            this.BT_bejelentkezes.UseVisualStyleBackColor = true;
            this.BT_bejelentkezes.Click += new System.EventHandler(this.BT_bejelentkezes_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BT_bejelentkezes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_jelszo);
            this.Controls.Add(this.TB_felhnev);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "LoginForm";
            this.Text = "Bejelentkezes";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginForm_FormClosed);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB_jelszo;
        private System.Windows.Forms.TextBox TB_felhnev;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BT_bejelentkezes;
    }
}