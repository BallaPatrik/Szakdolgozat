
namespace Szakdolgozat.Main_Code
{
    partial class ChangePasswordForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_regi_jelszo = new System.Windows.Forms.TextBox();
            this.TB_uj_jelszo_1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_uj_jelszo_2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BT_jelszavak_elrejtese_mutatasa = new System.Windows.Forms.Button();
            this.BT_jelszovaltoztat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label1.Location = new System.Drawing.Point(394, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Jelszóváltoztatás";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(370, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Eredeti jelszó:";
            // 
            // TB_regi_jelszo
            // 
            this.TB_regi_jelszo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_regi_jelszo.Location = new System.Drawing.Point(448, 152);
            this.TB_regi_jelszo.Name = "TB_regi_jelszo";
            this.TB_regi_jelszo.PasswordChar = '*';
            this.TB_regi_jelszo.Size = new System.Drawing.Size(132, 20);
            this.TB_regi_jelszo.TabIndex = 5;
            // 
            // TB_uj_jelszo_1
            // 
            this.TB_uj_jelszo_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_uj_jelszo_1.Location = new System.Drawing.Point(448, 191);
            this.TB_uj_jelszo_1.Name = "TB_uj_jelszo_1";
            this.TB_uj_jelszo_1.PasswordChar = '*';
            this.TB_uj_jelszo_1.Size = new System.Drawing.Size(132, 20);
            this.TB_uj_jelszo_1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(393, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Új jelszó:";
            // 
            // TB_uj_jelszo_2
            // 
            this.TB_uj_jelszo_2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_uj_jelszo_2.Location = new System.Drawing.Point(448, 227);
            this.TB_uj_jelszo_2.Name = "TB_uj_jelszo_2";
            this.TB_uj_jelszo_2.PasswordChar = '*';
            this.TB_uj_jelszo_2.Size = new System.Drawing.Size(132, 20);
            this.TB_uj_jelszo_2.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(331, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Új jelszó még egyszer:";
            // 
            // BT_jelszavak_elrejtese_mutatasa
            // 
            this.BT_jelszavak_elrejtese_mutatasa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_jelszavak_elrejtese_mutatasa.Location = new System.Drawing.Point(448, 272);
            this.BT_jelszavak_elrejtese_mutatasa.Name = "BT_jelszavak_elrejtese_mutatasa";
            this.BT_jelszavak_elrejtese_mutatasa.Size = new System.Drawing.Size(185, 23);
            this.BT_jelszavak_elrejtese_mutatasa.TabIndex = 10;
            this.BT_jelszavak_elrejtese_mutatasa.Text = "Jelszavak mutatása/elrejtése";
            this.BT_jelszavak_elrejtese_mutatasa.UseVisualStyleBackColor = true;
            this.BT_jelszavak_elrejtese_mutatasa.Click += new System.EventHandler(this.BT_jelszavak_elrejtese_mutatasa_Click);
            // 
            // BT_jelszovaltoztat
            // 
            this.BT_jelszovaltoztat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_jelszovaltoztat.Location = new System.Drawing.Point(459, 318);
            this.BT_jelszovaltoztat.Name = "BT_jelszovaltoztat";
            this.BT_jelszovaltoztat.Size = new System.Drawing.Size(152, 23);
            this.BT_jelszovaltoztat.TabIndex = 11;
            this.BT_jelszovaltoztat.Text = "Jelszó megváltoztatása";
            this.BT_jelszovaltoztat.UseVisualStyleBackColor = true;
            this.BT_jelszovaltoztat.Click += new System.EventHandler(this.BT_jelszovaltoztat_Click);
            // 
            // ChangePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BT_jelszovaltoztat);
            this.Controls.Add(this.BT_jelszavak_elrejtese_mutatasa);
            this.Controls.Add(this.TB_uj_jelszo_2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TB_uj_jelszo_1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TB_regi_jelszo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ChangePasswordForm";
            this.Text = "Jelszovaltoztatas";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ChangePasswordForm_FormClosed);
            this.Load += new System.EventHandler(this.ChangePasswordForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_regi_jelszo;
        private System.Windows.Forms.TextBox TB_uj_jelszo_1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_uj_jelszo_2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BT_jelszavak_elrejtese_mutatasa;
        private System.Windows.Forms.Button BT_jelszovaltoztat;
    }
}