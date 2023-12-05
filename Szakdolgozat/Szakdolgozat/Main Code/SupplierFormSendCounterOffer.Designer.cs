
namespace Szakdolgozat.Main_Code
{
    partial class SupplierFormSendCounterOffer
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
            this.BT_ellenajanlat_kuldese = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.DGV_ajanlatok = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ajanlatok)).BeginInit();
            this.SuspendLayout();
            // 
            // BT_ellenajanlat_kuldese
            // 
            this.BT_ellenajanlat_kuldese.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BT_ellenajanlat_kuldese.Location = new System.Drawing.Point(678, 199);
            this.BT_ellenajanlat_kuldese.Name = "BT_ellenajanlat_kuldese";
            this.BT_ellenajanlat_kuldese.Size = new System.Drawing.Size(101, 52);
            this.BT_ellenajanlat_kuldese.TabIndex = 34;
            this.BT_ellenajanlat_kuldese.Text = "Küldés";
            this.BT_ellenajanlat_kuldese.UseVisualStyleBackColor = true;
            this.BT_ellenajanlat_kuldese.Click += new System.EventHandler(this.BT_ellenajanlat_kuldese_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(280, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 25);
            this.label2.TabIndex = 33;
            this.label2.Text = "Ajánlat részletek";
            // 
            // DGV_ajanlatok
            // 
            this.DGV_ajanlatok.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV_ajanlatok.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_ajanlatok.Location = new System.Drawing.Point(21, 106);
            this.DGV_ajanlatok.Name = "DGV_ajanlatok";
            this.DGV_ajanlatok.Size = new System.Drawing.Size(651, 298);
            this.DGV_ajanlatok.TabIndex = 32;
            // 
            // SupplierFormSendCounterOffer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BT_ellenajanlat_kuldese);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DGV_ajanlatok);
            this.Name = "SupplierFormSendCounterOffer";
            this.Text = "Ellenajanlat kuldese";
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ajanlatok)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BT_ellenajanlat_kuldese;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DGV_ajanlatok;
    }
}