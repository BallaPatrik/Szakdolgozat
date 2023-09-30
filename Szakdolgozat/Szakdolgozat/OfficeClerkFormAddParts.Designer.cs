
namespace Szakdolgozat
{
    partial class OfficeClerkFormAddParts
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
            this.DGV_parts = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BT_confirm = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_parts)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_parts
            // 
            this.DGV_parts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_parts.Location = new System.Drawing.Point(301, 145);
            this.DGV_parts.Name = "DGV_parts";
            this.DGV_parts.Size = new System.Drawing.Size(409, 150);
            this.DGV_parts.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(80, 188);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Termék:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(298, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Termék alkatrészei:";
            // 
            // BT_confirm
            // 
            this.BT_confirm.Location = new System.Drawing.Point(480, 301);
            this.BT_confirm.Name = "BT_confirm";
            this.BT_confirm.Size = new System.Drawing.Size(75, 23);
            this.BT_confirm.TabIndex = 4;
            this.BT_confirm.Text = "Megerősítés";
            this.BT_confirm.UseVisualStyleBackColor = true;
            this.BT_confirm.Click += new System.EventHandler(this.BT_confirm_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(222, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(333, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Alkatrész hozzárendelése a termékhez";
            // 
            // OfficeClerkFormAddParts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BT_confirm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.DGV_parts);
            this.Name = "OfficeClerkFormAddParts";
            this.Text = "OfficeClerkFormAddParts";
            ((System.ComponentModel.ISupportInitialize)(this.DGV_parts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_parts;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BT_confirm;
        private System.Windows.Forms.Label label3;
    }
}