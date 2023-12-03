
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
            this.Col_Btn_Reszletek = new System.Windows.Forms.DataGridViewButtonColumn();
            this.But_Ellenajanlat = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_rendelesek)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(494, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 25);
            this.label2.TabIndex = 27;
            this.label2.Text = "Megrendelések";
            // 
            // DGV_rendelesek
            // 
            this.DGV_rendelesek.AllowUserToAddRows = false;
            this.DGV_rendelesek.AllowUserToDeleteRows = false;
            this.DGV_rendelesek.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV_rendelesek.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_rendelesek.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Col_Btn_Reszletek,
            this.But_Ellenajanlat});
            this.DGV_rendelesek.Location = new System.Drawing.Point(262, 129);
            this.DGV_rendelesek.Name = "DGV_rendelesek";
            this.DGV_rendelesek.Size = new System.Drawing.Size(482, 276);
            this.DGV_rendelesek.TabIndex = 28;
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
            // But_Ellenajanlat
            // 
            this.But_Ellenajanlat.HeaderText = "Ellenajánlat küldése";
            this.But_Ellenajanlat.Name = "But_Ellenajanlat";
            this.But_Ellenajanlat.Text = "Ellenajánlat";
            this.But_Ellenajanlat.UseColumnTextForButtonValue = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(260, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Szűrés:";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Minden",
            "Elfogadva",
            "Elutasítva",
            "Kezdeti elbírálás",
            "Elbírálás alatt",
            "Elbírálva"});
            this.comboBox1.Location = new System.Drawing.Point(308, 85);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(246, 21);
            this.comboBox1.TabIndex = 30;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // BuyerFormListOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.DataGridViewButtonColumn Col_Btn_Reszletek;
        private System.Windows.Forms.DataGridViewButtonColumn But_Ellenajanlat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}