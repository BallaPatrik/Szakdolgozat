
namespace Szakdolgozat.Main_Code
{
    partial class BuyerHomeForm
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
            this.BT_kijelentkezes = new System.Windows.Forms.Button();
            this.BT_jelszovaltoztat = new System.Windows.Forms.Button();
            this.BT_menu_rendeles_megtekint = new System.Windows.Forms.Button();
            this.BT_menu_rendeles = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panelSideMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Margin = new System.Windows.Forms.Padding(4);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1067, 554);
            this.panelContent.TabIndex = 32;
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.AutoScroll = true;
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.panelSideMenu.Controls.Add(this.BT_kijelentkezes);
            this.panelSideMenu.Controls.Add(this.BT_jelszovaltoztat);
            this.panelSideMenu.Controls.Add(this.BT_menu_rendeles_megtekint);
            this.panelSideMenu.Controls.Add(this.BT_menu_rendeles);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(250, 554);
            this.panelSideMenu.TabIndex = 34;
            // 
            // BT_kijelentkezes
            // 
            this.BT_kijelentkezes.Dock = System.Windows.Forms.DockStyle.Top;
            this.BT_kijelentkezes.FlatAppearance.BorderSize = 0;
            this.BT_kijelentkezes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_kijelentkezes.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_kijelentkezes.Location = new System.Drawing.Point(0, 235);
            this.BT_kijelentkezes.Name = "BT_kijelentkezes";
            this.BT_kijelentkezes.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BT_kijelentkezes.Size = new System.Drawing.Size(250, 45);
            this.BT_kijelentkezes.TabIndex = 6;
            this.BT_kijelentkezes.Text = "Kijelentkezés";
            this.BT_kijelentkezes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BT_kijelentkezes.UseVisualStyleBackColor = true;
            this.BT_kijelentkezes.Click += new System.EventHandler(this.BT_kijelentkezes_Click);
            // 
            // BT_jelszovaltoztat
            // 
            this.BT_jelszovaltoztat.Dock = System.Windows.Forms.DockStyle.Top;
            this.BT_jelszovaltoztat.FlatAppearance.BorderSize = 0;
            this.BT_jelszovaltoztat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_jelszovaltoztat.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_jelszovaltoztat.Location = new System.Drawing.Point(0, 190);
            this.BT_jelszovaltoztat.Name = "BT_jelszovaltoztat";
            this.BT_jelszovaltoztat.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BT_jelszovaltoztat.Size = new System.Drawing.Size(250, 45);
            this.BT_jelszovaltoztat.TabIndex = 5;
            this.BT_jelszovaltoztat.Text = "Jelszóváltoztatás";
            this.BT_jelszovaltoztat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BT_jelszovaltoztat.UseVisualStyleBackColor = true;
            this.BT_jelszovaltoztat.Click += new System.EventHandler(this.BT_jelszovaltoztat_Click);
            // 
            // BT_menu_rendeles_megtekint
            // 
            this.BT_menu_rendeles_megtekint.Dock = System.Windows.Forms.DockStyle.Top;
            this.BT_menu_rendeles_megtekint.FlatAppearance.BorderSize = 0;
            this.BT_menu_rendeles_megtekint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_menu_rendeles_megtekint.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_menu_rendeles_megtekint.Location = new System.Drawing.Point(0, 145);
            this.BT_menu_rendeles_megtekint.Name = "BT_menu_rendeles_megtekint";
            this.BT_menu_rendeles_megtekint.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BT_menu_rendeles_megtekint.Size = new System.Drawing.Size(250, 45);
            this.BT_menu_rendeles_megtekint.TabIndex = 4;
            this.BT_menu_rendeles_megtekint.Text = "Megrendelések megtekintése";
            this.BT_menu_rendeles_megtekint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BT_menu_rendeles_megtekint.UseVisualStyleBackColor = true;
            this.BT_menu_rendeles_megtekint.Click += new System.EventHandler(this.BT_menu_rendeles_megtekint_Click);
            // 
            // BT_menu_rendeles
            // 
            this.BT_menu_rendeles.Dock = System.Windows.Forms.DockStyle.Top;
            this.BT_menu_rendeles.FlatAppearance.BorderSize = 0;
            this.BT_menu_rendeles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_menu_rendeles.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_menu_rendeles.Location = new System.Drawing.Point(0, 100);
            this.BT_menu_rendeles.Name = "BT_menu_rendeles";
            this.BT_menu_rendeles.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BT_menu_rendeles.Size = new System.Drawing.Size(250, 45);
            this.BT_menu_rendeles.TabIndex = 3;
            this.BT_menu_rendeles.Text = "Rendelés";
            this.BT_menu_rendeles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BT_menu_rendeles.UseVisualStyleBackColor = true;
            this.BT_menu_rendeles.Click += new System.EventHandler(this.BT_menu_rendeles_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(250, 100);
            this.panelLogo.TabIndex = 0;
            // 
            // BuyerHomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.panelSideMenu);
            this.Controls.Add(this.panelContent);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BuyerHomeForm";
            this.Text = "Megrendeloi felulet";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BuyerHomeForm_FormClosed);
            this.panelSideMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button BT_menu_rendeles;
        private System.Windows.Forms.Button BT_kijelentkezes;
        private System.Windows.Forms.Button BT_jelszovaltoztat;
        private System.Windows.Forms.Button BT_menu_rendeles_megtekint;
    }
}