
namespace Szakdolgozat.Main_Code
{
    partial class SupplierCheckOffers
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
            this.DGV_ajanlatok = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.Col_Btn_Reszletek = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Col_Btn_Ajanlat = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ajanlatok)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_ajanlatok
            // 
            this.DGV_ajanlatok.AllowUserToAddRows = false;
            this.DGV_ajanlatok.AllowUserToDeleteRows = false;
            this.DGV_ajanlatok.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV_ajanlatok.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_ajanlatok.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Col_Btn_Reszletek,
            this.Col_Btn_Ajanlat});
            this.DGV_ajanlatok.Location = new System.Drawing.Point(232, 138);
            this.DGV_ajanlatok.Name = "DGV_ajanlatok";
            this.DGV_ajanlatok.Size = new System.Drawing.Size(536, 276);
            this.DGV_ajanlatok.TabIndex = 32;
            this.DGV_ajanlatok.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_ajanlatok_CellClick);
            this.DGV_ajanlatok.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_ajanlatok_CellContentClick);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(295, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 25);
            this.label2.TabIndex = 31;
            this.label2.Text = "Ajánlatok";
            // 
            // Col_Btn_Reszletek
            // 
            this.Col_Btn_Reszletek.HeaderText = "Ajánlat részletek";
            this.Col_Btn_Reszletek.Name = "Col_Btn_Reszletek";
            this.Col_Btn_Reszletek.Text = "Részletek";
            this.Col_Btn_Reszletek.UseColumnTextForButtonValue = true;
            // 
            // Col_Btn_Ajanlat
            // 
            this.Col_Btn_Ajanlat.HeaderText = "Ellenajánlat küldése";
            this.Col_Btn_Ajanlat.Name = "Col_Btn_Ajanlat";
            this.Col_Btn_Ajanlat.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Col_Btn_Ajanlat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Col_Btn_Ajanlat.Text = "Ellenajánlat";
            this.Col_Btn_Ajanlat.UseColumnTextForButtonValue = true;
            // 
            // SupplierCheckOffers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DGV_ajanlatok);
            this.Controls.Add(this.label2);
            this.Name = "SupplierCheckOffers";
            this.Text = "Ajánlatok megtekintése";
            this.Load += new System.EventHandler(this.SupplierCheckOffers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ajanlatok)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_ajanlatok;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewButtonColumn Col_Btn_Reszletek;
        private System.Windows.Forms.DataGridViewButtonColumn Col_Btn_Ajanlat;
    }
}