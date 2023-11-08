
namespace Szakdolgozat.Main_Code
{
    partial class OfficeClerkFormCheckBalance
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
            this.label3 = new System.Windows.Forms.Label();
            this.TB_egyenleg = new System.Windows.Forms.TextBox();
            this.L_jelenlegi_egyenleg = new System.Windows.Forms.Label();
            this.BT_egyenleg_lekerdezese = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(265, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mennyi a rendelkezésre álló egyenleg?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(264, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 24);
            this.label3.TabIndex = 12;
            this.label3.Text = "Egyenleg lekérdezése";
            // 
            // TB_egyenleg
            // 
            this.TB_egyenleg.Location = new System.Drawing.Point(289, 159);
            this.TB_egyenleg.Name = "TB_egyenleg";
            this.TB_egyenleg.Size = new System.Drawing.Size(144, 20);
            this.TB_egyenleg.TabIndex = 13;
            // 
            // L_jelenlegi_egyenleg
            // 
            this.L_jelenlegi_egyenleg.AutoSize = true;
            this.L_jelenlegi_egyenleg.Location = new System.Drawing.Point(301, 239);
            this.L_jelenlegi_egyenleg.Name = "L_jelenlegi_egyenleg";
            this.L_jelenlegi_egyenleg.Size = new System.Drawing.Size(118, 13);
            this.L_jelenlegi_egyenleg.TabIndex = 14;
            this.L_jelenlegi_egyenleg.Text = "Jelenlegi egyenleg: 0 Ft";
            // 
            // BT_egyenleg_lekerdezese
            // 
            this.BT_egyenleg_lekerdezese.Location = new System.Drawing.Point(289, 202);
            this.BT_egyenleg_lekerdezese.Name = "BT_egyenleg_lekerdezese";
            this.BT_egyenleg_lekerdezese.Size = new System.Drawing.Size(144, 23);
            this.BT_egyenleg_lekerdezese.TabIndex = 15;
            this.BT_egyenleg_lekerdezese.Text = "Egyenleg lekérdezése";
            this.BT_egyenleg_lekerdezese.UseVisualStyleBackColor = true;
            this.BT_egyenleg_lekerdezese.Click += new System.EventHandler(this.BT_egyenleg_lekerdezese_Click);
            // 
            // OfficeClerkFormCheckBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BT_egyenleg_lekerdezese);
            this.Controls.Add(this.L_jelenlegi_egyenleg);
            this.Controls.Add(this.TB_egyenleg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "OfficeClerkFormCheckBalance";
            this.Text = "OfficeClerkFormCheckBalance";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_egyenleg;
        private System.Windows.Forms.Label L_jelenlegi_egyenleg;
        private System.Windows.Forms.Button BT_egyenleg_lekerdezese;
    }
}