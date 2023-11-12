
namespace Szakdolgozat.Main_Code
{
    partial class OfficeClerkFormCheckOrders
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
            this.DGV_rendelesek = new System.Windows.Forms.DataGridView();
            this.Col_Btn_Reszletek = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Col_Btn_Ajanlat = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_rendelesek)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_rendelesek
            // 
            this.DGV_rendelesek.AllowUserToAddRows = false;
            this.DGV_rendelesek.AllowUserToDeleteRows = false;
            this.DGV_rendelesek.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_rendelesek.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Col_Btn_Reszletek,
            this.Col_Btn_Ajanlat});
            this.DGV_rendelesek.Location = new System.Drawing.Point(26, 119);
            this.DGV_rendelesek.Name = "DGV_rendelesek";
            this.DGV_rendelesek.Size = new System.Drawing.Size(742, 276);
            this.DGV_rendelesek.TabIndex = 30;
            this.DGV_rendelesek.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_rendelesek_CellClick);
            this.DGV_rendelesek.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_rendelesek_CellContentClick);
            // 
            // Col_Btn_Reszletek
            // 
            this.Col_Btn_Reszletek.HeaderText = "Rendelés részletek";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(292, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 25);
            this.label2.TabIndex = 29;
            this.label2.Text = "Megrendelések";
            // 
            // OfficeClerkFormCheckOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DGV_rendelesek);
            this.Controls.Add(this.label2);
            this.Name = "OfficeClerkFormCheckOrders";
            this.Text = "Függőben lévő megrendelések";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OfficeClerkFormCheckOrders_FormClosed);
            this.Load += new System.EventHandler(this.OfficeClerkFormCheckOrders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_rendelesek)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_rendelesek;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewButtonColumn Col_Btn_Reszletek;
        private System.Windows.Forms.DataGridViewButtonColumn Col_Btn_Ajanlat;
    }
}