
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
            this.label3 = new System.Windows.Forms.Label();
            this.BT_confirm = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DGV_parts = new System.Windows.Forms.DataGridView();
            this.TB_name = new System.Windows.Forms.TextBox();
            this.TB_startingQuantity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.TB_quantity = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_parts)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(226, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(333, 24);
            this.label3.TabIndex = 11;
            this.label3.Text = "Alkatrész hozzárendelése a termékhez";
            // 
            // BT_confirm
            // 
            this.BT_confirm.Location = new System.Drawing.Point(484, 317);
            this.BT_confirm.Name = "BT_confirm";
            this.BT_confirm.Size = new System.Drawing.Size(75, 23);
            this.BT_confirm.TabIndex = 10;
            this.BT_confirm.Text = "Megerősítés";
            this.BT_confirm.UseVisualStyleBackColor = true;
            this.BT_confirm.Click += new System.EventHandler(this.BT_confirm_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(302, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Termék alkatrészei:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Alkatrész neve:";
            // 
            // DGV_parts
            // 
            this.DGV_parts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_parts.Location = new System.Drawing.Point(305, 161);
            this.DGV_parts.Name = "DGV_parts";
            this.DGV_parts.Size = new System.Drawing.Size(409, 150);
            this.DGV_parts.TabIndex = 6;
            // 
            // TB_name
            // 
            this.TB_name.Location = new System.Drawing.Point(118, 219);
            this.TB_name.Name = "TB_name";
            this.TB_name.Size = new System.Drawing.Size(129, 20);
            this.TB_name.TabIndex = 12;
            // 
            // TB_startingQuantity
            // 
            this.TB_startingQuantity.Location = new System.Drawing.Point(118, 266);
            this.TB_startingQuantity.Name = "TB_startingQuantity";
            this.TB_startingQuantity.Size = new System.Drawing.Size(129, 20);
            this.TB_startingQuantity.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Kezdő darabszám:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Termék:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(118, 177);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(129, 21);
            this.comboBox1.TabIndex = 15;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // TB_quantity
            // 
            this.TB_quantity.Location = new System.Drawing.Point(118, 336);
            this.TB_quantity.Name = "TB_quantity";
            this.TB_quantity.Size = new System.Drawing.Size(129, 20);
            this.TB_quantity.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 307);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(213, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "1 termék megcsinálásához hány darab kell?";
            // 
            // OfficeClerkFormAddParts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TB_quantity);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.TB_startingQuantity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TB_name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BT_confirm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGV_parts);
            this.Name = "OfficeClerkFormAddParts";
            this.Text = "OfficeClerkFormAddParts";
            ((System.ComponentModel.ISupportInitialize)(this.DGV_parts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BT_confirm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGV_parts;
        private System.Windows.Forms.TextBox TB_name;
        private System.Windows.Forms.TextBox TB_startingQuantity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox TB_quantity;
        private System.Windows.Forms.Label label6;
    }
}