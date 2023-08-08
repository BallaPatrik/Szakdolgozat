
namespace Szakdolgozat
{
    partial class OperatorForm
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
            this.LB_termekek = new System.Windows.Forms.ListBox();
            this.TB_darabszam = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BT_termekfelvitele = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LB_termekek
            // 
            this.LB_termekek.FormattingEnabled = true;
            this.LB_termekek.Location = new System.Drawing.Point(217, 84);
            this.LB_termekek.Name = "LB_termekek";
            this.LB_termekek.Size = new System.Drawing.Size(314, 186);
            this.LB_termekek.TabIndex = 0;
            this.LB_termekek.SelectedIndexChanged += new System.EventHandler(this.LB_termekek_SelectedIndexChanged);
            // 
            // TB_darabszam
            // 
            this.TB_darabszam.Location = new System.Drawing.Point(301, 302);
            this.TB_darabszam.Name = "TB_darabszam";
            this.TB_darabszam.Size = new System.Drawing.Size(138, 20);
            this.TB_darabszam.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(223, 305);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Darabszám:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(214, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Termékek:";
            // 
            // BT_termekfelvitele
            // 
            this.BT_termekfelvitele.Location = new System.Drawing.Point(301, 349);
            this.BT_termekfelvitele.Name = "BT_termekfelvitele";
            this.BT_termekfelvitele.Size = new System.Drawing.Size(119, 23);
            this.BT_termekfelvitele.TabIndex = 17;
            this.BT_termekfelvitele.Text = "Termék felvitele";
            this.BT_termekfelvitele.UseVisualStyleBackColor = true;
            this.BT_termekfelvitele.Click += new System.EventHandler(this.BT_termekfelvitele_Click);
            // 
            // OperatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BT_termekfelvitele);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_darabszam);
            this.Controls.Add(this.LB_termekek);
            this.Name = "OperatorForm";
            this.Text = "Operatori felulet";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OperatorForm_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LB_termekek;
        private System.Windows.Forms.TextBox TB_darabszam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BT_termekfelvitele;
    }
}

