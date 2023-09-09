
namespace Szakdolgozat
{
    partial class BuyerForm
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
            this.Megrendelés = new System.Windows.Forms.Button();
            this.DGV_termekek = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_termekek)).BeginInit();
            this.SuspendLayout();
            // 
            // Megrendelés
            // 
            this.Megrendelés.Location = new System.Drawing.Point(328, 377);
            this.Megrendelés.Name = "Megrendelés";
            this.Megrendelés.Size = new System.Drawing.Size(82, 23);
            this.Megrendelés.TabIndex = 28;
            this.Megrendelés.Text = "Megrendelés";
            this.Megrendelés.UseVisualStyleBackColor = true;
            // 
            // DGV_termekek
            // 
            this.DGV_termekek.AllowUserToAddRows = false;
            this.DGV_termekek.AllowUserToDeleteRows = false;
            this.DGV_termekek.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_termekek.Location = new System.Drawing.Point(173, 106);
            this.DGV_termekek.Name = "DGV_termekek";
            this.DGV_termekek.Size = new System.Drawing.Size(408, 232);
            this.DGV_termekek.TabIndex = 27;
            this.DGV_termekek.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_termekek_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(286, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 25);
            this.label2.TabIndex = 26;
            this.label2.Text = "Megrendelői felület";
            // 
            // BuyerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Megrendelés);
            this.Controls.Add(this.DGV_termekek);
            this.Controls.Add(this.label2);
            this.Name = "BuyerForm";
            this.Text = "Megrendeloi felulet";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BuyerForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_termekek)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Megrendelés;
        private System.Windows.Forms.DataGridView DGV_termekek;
        private System.Windows.Forms.Label label2;
    }
}