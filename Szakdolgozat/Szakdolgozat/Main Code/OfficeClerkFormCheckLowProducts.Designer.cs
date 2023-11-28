
namespace Szakdolgozat.Main_Code
{
    partial class OfficeClerkFormCheckLowProducts
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
            this.label2 = new System.Windows.Forms.Label();
            this.DGV_termekek = new System.Windows.Forms.DataGridView();
            this.TB_darabszam = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BT_listaz = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_termekek)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(358, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(318, 25);
            this.label2.TabIndex = 33;
            this.label2.Text = "Alacsony darabszámú termékek";
            // 
            // DGV_termekek
            // 
            this.DGV_termekek.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV_termekek.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_termekek.Location = new System.Drawing.Point(258, 153);
            this.DGV_termekek.Name = "DGV_termekek";
            this.DGV_termekek.Size = new System.Drawing.Size(492, 238);
            this.DGV_termekek.TabIndex = 32;
            // 
            // TB_darabszam
            // 
            this.TB_darabszam.Location = new System.Drawing.Point(482, 100);
            this.TB_darabszam.Name = "TB_darabszam";
            this.TB_darabszam.Size = new System.Drawing.Size(100, 20);
            this.TB_darabszam.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(265, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Ennyi darabszám alattiak legyenek listázva:";
            // 
            // BT_listaz
            // 
            this.BT_listaz.Location = new System.Drawing.Point(607, 98);
            this.BT_listaz.Name = "BT_listaz";
            this.BT_listaz.Size = new System.Drawing.Size(91, 23);
            this.BT_listaz.TabIndex = 36;
            this.BT_listaz.Text = "Listáz";
            this.BT_listaz.UseVisualStyleBackColor = true;
            this.BT_listaz.Click += new System.EventHandler(this.BT_listaz_Click);
            // 
            // OfficeClerkFormCheckLowProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BT_listaz);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_darabszam);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DGV_termekek);
            this.Name = "OfficeClerkFormCheckLowProducts";
            this.Text = "OfficeClerkFormCheckLowProducts";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OfficeClerkFormCheckLowProducts_FormClosed);
            this.Load += new System.EventHandler(this.OfficeClerkFormCheckLowProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_termekek)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DGV_termekek;
        private System.Windows.Forms.TextBox TB_darabszam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BT_listaz;
    }
}