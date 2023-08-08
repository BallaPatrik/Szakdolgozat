
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.kilépésToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.legyártottTermékekFelviteleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maFelvittTermékekListázásaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DGV_products = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Torles = new System.Windows.Forms.DataGridViewButtonColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_products)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kilépésToolStripMenuItem,
            this.legyártottTermékekFelviteleToolStripMenuItem,
            this.maFelvittTermékekListázásaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // kilépésToolStripMenuItem
            // 
            this.kilépésToolStripMenuItem.Name = "kilépésToolStripMenuItem";
            this.kilépésToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.kilépésToolStripMenuItem.Text = "Kilépés";
            this.kilépésToolStripMenuItem.Click += new System.EventHandler(this.kilépésToolStripMenuItem_Click);
            // 
            // legyártottTermékekFelviteleToolStripMenuItem
            // 
            this.legyártottTermékekFelviteleToolStripMenuItem.Name = "legyártottTermékekFelviteleToolStripMenuItem";
            this.legyártottTermékekFelviteleToolStripMenuItem.Size = new System.Drawing.Size(169, 20);
            this.legyártottTermékekFelviteleToolStripMenuItem.Text = "Legyártott termékek felvitele";
            this.legyártottTermékekFelviteleToolStripMenuItem.Click += new System.EventHandler(this.legyártottTermékekFelviteleToolStripMenuItem_Click);
            // 
            // maFelvittTermékekListázásaToolStripMenuItem
            // 
            this.maFelvittTermékekListázásaToolStripMenuItem.Name = "maFelvittTermékekListázásaToolStripMenuItem";
            this.maFelvittTermékekListázásaToolStripMenuItem.Size = new System.Drawing.Size(167, 20);
            this.maFelvittTermékekListázásaToolStripMenuItem.Text = "Ma felvitt termékek listázása";
            this.maFelvittTermékekListázásaToolStripMenuItem.Click += new System.EventHandler(this.maFelvittTermékekListázásaToolStripMenuItem_Click);
            // 
            // DGV_products
            // 
            this.DGV_products.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_products.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGV_products.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_products.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Torles});
            this.DGV_products.Location = new System.Drawing.Point(124, 104);
            this.DGV_products.Name = "DGV_products";
            this.DGV_products.Size = new System.Drawing.Size(469, 261);
            this.DGV_products.TabIndex = 18;
            this.DGV_products.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_products_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "A mai nap folyamán felvitt termékek:";
            // 
            // Torles
            // 
            this.Torles.HeaderText = "Torles";
            this.Torles.Name = "Torles";
            this.Torles.Text = "X";
            this.Torles.UseColumnTextForButtonValue = true;
            // 
            // OperatorFormListDailyProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGV_products);
            this.Controls.Add(this.menuStrip1);
            this.Name = "OperatorFormListDailyProducts";
            this.Text = "OperatorFormListDailyProducts";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OperatorFormListDailyProducts_FormClosed);
            this.Load += new System.EventHandler(this.OperatorFormListDailyProducts_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_products)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kilépésToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem legyártottTermékekFelviteleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maFelvittTermékekListázásaToolStripMenuItem;
        private System.Windows.Forms.DataGridView DGV_products;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewButtonColumn Torles;
    }
}