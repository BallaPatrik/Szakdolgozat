﻿
namespace Szakdolgozat
{
    partial class OperatorFormListDailyProducts
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
            this.DGV_products = new System.Windows.Forms.DataGridView();
            this.Torles = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TB_darabszam = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_datum = new System.Windows.Forms.TextBox();
            this.TB_termeknev = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BT_modosit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_products)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_products
            // 
            this.DGV_products.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV_products.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_products.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGV_products.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_products.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Torles});
            this.DGV_products.Location = new System.Drawing.Point(237, 98);
            this.DGV_products.Name = "DGV_products";
            this.DGV_products.Size = new System.Drawing.Size(469, 261);
            this.DGV_products.TabIndex = 18;
            this.DGV_products.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_products_CellClick);
            // 
            // Torles
            // 
            this.Torles.HeaderText = "Torles";
            this.Torles.Name = "Torles";
            this.Torles.Text = "X";
            this.Torles.UseColumnTextForButtonValue = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(234, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "A mai nap folyamán felvitt termékek:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(530, 470);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Darabszám:";
            // 
            // TB_darabszam
            // 
            this.TB_darabszam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_darabszam.Location = new System.Drawing.Point(599, 467);
            this.TB_darabszam.Name = "TB_darabszam";
            this.TB_darabszam.Size = new System.Drawing.Size(107, 20);
            this.TB_darabszam.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(341, 503);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Dátum:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(311, 474);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Terméknév:";
            // 
            // TB_datum
            // 
            this.TB_datum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_datum.Location = new System.Drawing.Point(388, 500);
            this.TB_datum.Name = "TB_datum";
            this.TB_datum.ReadOnly = true;
            this.TB_datum.Size = new System.Drawing.Size(100, 20);
            this.TB_datum.TabIndex = 29;
            // 
            // TB_termeknev
            // 
            this.TB_termeknev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_termeknev.Location = new System.Drawing.Point(388, 471);
            this.TB_termeknev.Name = "TB_termeknev";
            this.TB_termeknev.ReadOnly = true;
            this.TB_termeknev.Size = new System.Drawing.Size(100, 20);
            this.TB_termeknev.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(418, 444);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Módosítás (csak darabszámra működik):";
            // 
            // BT_modosit
            // 
            this.BT_modosit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_modosit.Location = new System.Drawing.Point(599, 497);
            this.BT_modosit.Name = "BT_modosit";
            this.BT_modosit.Size = new System.Drawing.Size(107, 23);
            this.BT_modosit.TabIndex = 34;
            this.BT_modosit.Text = "Módosítás";
            this.BT_modosit.UseVisualStyleBackColor = true;
            this.BT_modosit.Click += new System.EventHandler(this.BT_modosit_Click);
            // 
            // OperatorFormListDailyProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 532);
            this.Controls.Add(this.BT_modosit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TB_darabszam);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TB_datum);
            this.Controls.Add(this.TB_termeknev);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGV_products);
            this.Name = "OperatorFormListDailyProducts";
            this.Text = "OperatorFormListDailyProducts";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OperatorFormListDailyProducts_FormClosed);
            this.Load += new System.EventHandler(this.OperatorFormListDailyProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_products)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView DGV_products;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewButtonColumn Torles;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TB_darabszam;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_datum;
        private System.Windows.Forms.TextBox TB_termeknev;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BT_modosit;
    }
}