
namespace Szakdolgozat.Main_Code
{
    partial class OfficeClerkFormCheckLowParts
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
            this.BT_listaz = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_darabszam = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DGV_alkatreszek = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_alkatreszek)).BeginInit();
            this.SuspendLayout();
            // 
            // BT_listaz
            // 
            this.BT_listaz.Location = new System.Drawing.Point(594, 99);
            this.BT_listaz.Name = "BT_listaz";
            this.BT_listaz.Size = new System.Drawing.Size(91, 23);
            this.BT_listaz.TabIndex = 41;
            this.BT_listaz.Text = "Listáz";
            this.BT_listaz.UseVisualStyleBackColor = true;
            this.BT_listaz.Click += new System.EventHandler(this.BT_listaz_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(271, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Ennyi darabszám alattiak legyenek listázva:";
            // 
            // TB_darabszam
            // 
            this.TB_darabszam.Location = new System.Drawing.Point(488, 101);
            this.TB_darabszam.Name = "TB_darabszam";
            this.TB_darabszam.Size = new System.Drawing.Size(100, 20);
            this.TB_darabszam.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(364, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(340, 25);
            this.label2.TabIndex = 38;
            this.label2.Text = "Alacsony darabszámú alkatrészek";
            // 
            // DGV_alkatreszek
            // 
            this.DGV_alkatreszek.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV_alkatreszek.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_alkatreszek.Location = new System.Drawing.Point(264, 154);
            this.DGV_alkatreszek.Name = "DGV_alkatreszek";
            this.DGV_alkatreszek.Size = new System.Drawing.Size(492, 238);
            this.DGV_alkatreszek.TabIndex = 37;
            // 
            // OfficeClerkFormCheckLowParts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BT_listaz);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_darabszam);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DGV_alkatreszek);
            this.Name = "OfficeClerkFormCheckLowParts";
            this.Text = "OfficeClerkFormCheckLowParts";
            this.Load += new System.EventHandler(this.OfficeClerkFormCheckLowParts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_alkatreszek)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BT_listaz;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_darabszam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DGV_alkatreszek;
    }
}