
namespace Szakdolgozat.Main_Code
{
    partial class SupplierHomeForm
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
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.BT_menu_alkatresz_eladas = new System.Windows.Forms.Button();
            this.BT_menu_jelszovaltoztat = new System.Windows.Forms.Button();
            this.BT_menu_kijelentkezes = new System.Windows.Forms.Button();
            this.panelSideMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1067, 554);
            this.panelContent.TabIndex = 1;
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.AutoScroll = true;
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.panelSideMenu.Controls.Add(this.BT_menu_kijelentkezes);
            this.panelSideMenu.Controls.Add(this.BT_menu_jelszovaltoztat);
            this.panelSideMenu.Controls.Add(this.BT_menu_alkatresz_eladas);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(250, 554);
            this.panelSideMenu.TabIndex = 36;
            // 
            // panelLogo
            // 
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(250, 100);
            this.panelLogo.TabIndex = 1;
            // 
            // BT_menu_alkatresz_eladas
            // 
            this.BT_menu_alkatresz_eladas.Dock = System.Windows.Forms.DockStyle.Top;
            this.BT_menu_alkatresz_eladas.FlatAppearance.BorderSize = 0;
            this.BT_menu_alkatresz_eladas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_menu_alkatresz_eladas.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_menu_alkatresz_eladas.Location = new System.Drawing.Point(0, 100);
            this.BT_menu_alkatresz_eladas.Name = "BT_menu_alkatresz_eladas";
            this.BT_menu_alkatresz_eladas.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BT_menu_alkatresz_eladas.Size = new System.Drawing.Size(250, 45);
            this.BT_menu_alkatresz_eladas.TabIndex = 6;
            this.BT_menu_alkatresz_eladas.Text = "Alkatrészek eladása";
            this.BT_menu_alkatresz_eladas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BT_menu_alkatresz_eladas.UseVisualStyleBackColor = true;
            this.BT_menu_alkatresz_eladas.Click += new System.EventHandler(this.BT_menu_alkatresz_eladas_Click);
            // 
            // BT_menu_jelszovaltoztat
            // 
            this.BT_menu_jelszovaltoztat.Dock = System.Windows.Forms.DockStyle.Top;
            this.BT_menu_jelszovaltoztat.FlatAppearance.BorderSize = 0;
            this.BT_menu_jelszovaltoztat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_menu_jelszovaltoztat.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_menu_jelszovaltoztat.Location = new System.Drawing.Point(0, 145);
            this.BT_menu_jelszovaltoztat.Name = "BT_menu_jelszovaltoztat";
            this.BT_menu_jelszovaltoztat.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BT_menu_jelszovaltoztat.Size = new System.Drawing.Size(250, 45);
            this.BT_menu_jelszovaltoztat.TabIndex = 7;
            this.BT_menu_jelszovaltoztat.Text = "Jelszóváltoztatás";
            this.BT_menu_jelszovaltoztat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BT_menu_jelszovaltoztat.UseVisualStyleBackColor = true;
            this.BT_menu_jelszovaltoztat.Click += new System.EventHandler(this.BT_menu_jelszovaltoztat_Click);
            // 
            // BT_menu_kijelentkezes
            // 
            this.BT_menu_kijelentkezes.Dock = System.Windows.Forms.DockStyle.Top;
            this.BT_menu_kijelentkezes.FlatAppearance.BorderSize = 0;
            this.BT_menu_kijelentkezes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_menu_kijelentkezes.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_menu_kijelentkezes.Location = new System.Drawing.Point(0, 190);
            this.BT_menu_kijelentkezes.Name = "BT_menu_kijelentkezes";
            this.BT_menu_kijelentkezes.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BT_menu_kijelentkezes.Size = new System.Drawing.Size(250, 45);
            this.BT_menu_kijelentkezes.TabIndex = 8;
            this.BT_menu_kijelentkezes.Text = "Kijelentkezés";
            this.BT_menu_kijelentkezes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BT_menu_kijelentkezes.UseVisualStyleBackColor = true;
            this.BT_menu_kijelentkezes.Click += new System.EventHandler(this.BT_menu_kijelentkezes_Click);
            // 
            // SupplierHomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.panelSideMenu);
            this.Controls.Add(this.panelContent);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SupplierHomeForm";
            this.Text = "Beszallitoi felulet";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SupplierHomeForm_FormClosed);
            this.panelSideMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button BT_menu_jelszovaltoztat;
        private System.Windows.Forms.Button BT_menu_alkatresz_eladas;
        private System.Windows.Forms.Button BT_menu_kijelentkezes;
    }
}