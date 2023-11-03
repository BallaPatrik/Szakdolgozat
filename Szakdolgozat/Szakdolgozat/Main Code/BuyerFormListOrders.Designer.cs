
namespace Szakdolgozat.Main_Code
{
    partial class BuyerFormListOrders
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
            this.DGV_rendelesek = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_rendelesek)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(297, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 25);
            this.label2.TabIndex = 27;
            this.label2.Text = "Megrendelések";
            // 
            // DGV_rendelesek
            // 
            this.DGV_rendelesek.AllowUserToAddRows = false;
            this.DGV_rendelesek.AllowUserToDeleteRows = false;
            this.DGV_rendelesek.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_rendelesek.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4});
            this.DGV_rendelesek.Location = new System.Drawing.Point(67, 109);
            this.DGV_rendelesek.Name = "DGV_rendelesek";
            this.DGV_rendelesek.Size = new System.Drawing.Size(677, 276);
            this.DGV_rendelesek.TabIndex = 28;
            this.DGV_rendelesek.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_rendelesek_CellClick);
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Rendelés részletek";
            this.Column4.Name = "Column4";
            this.Column4.Text = "Részletek";
            this.Column4.UseColumnTextForButtonValue = true;
            // 
            // BuyerFormListOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DGV_rendelesek);
            this.Controls.Add(this.label2);
            this.Name = "BuyerFormListOrders";
            this.Text = "BuyerFormListOrders";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BuyerFormListOrders_FormClosed);
            this.Load += new System.EventHandler(this.BuyerFormListOrders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_rendelesek)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DGV_rendelesek;
        private System.Windows.Forms.DataGridViewButtonColumn Column4;
    }
}