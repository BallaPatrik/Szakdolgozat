﻿
namespace Szakdolgozat
{
    partial class OfficeClerkHomeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OfficeClerkHomeForm));
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.BT_alkatresz_ajanlatok = new System.Windows.Forms.Button();
            this.BT_menu_rendeles_megtekint = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.BT_kijelentkezés = new System.Windows.Forms.Button();
            this.BT_jelszovaltoztat = new System.Windows.Forms.Button();
            this.BT_keves_alkatresz_listazas = new System.Windows.Forms.Button();
            this.BT_keves_termek_listazas = new System.Windows.Forms.Button();
            this.BT_egyenleg = new System.Windows.Forms.Button();
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
            this.panelContent.TabIndex = 19;
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.AutoScroll = true;
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.panelSideMenu.Controls.Add(this.BT_kijelentkezés);
            this.panelSideMenu.Controls.Add(this.BT_jelszovaltoztat);
            this.panelSideMenu.Controls.Add(this.BT_keves_alkatresz_listazas);
            this.panelSideMenu.Controls.Add(this.BT_keves_termek_listazas);
            this.panelSideMenu.Controls.Add(this.BT_egyenleg);
            this.panelSideMenu.Controls.Add(this.BT_alkatresz_ajanlatok);
            this.panelSideMenu.Controls.Add(this.BT_menu_rendeles_megtekint);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(250, 554);
            this.panelSideMenu.TabIndex = 35;
            // 
            // BT_alkatresz_ajanlatok
            // 
            this.BT_alkatresz_ajanlatok.Dock = System.Windows.Forms.DockStyle.Top;
            this.BT_alkatresz_ajanlatok.FlatAppearance.BorderSize = 0;
            this.BT_alkatresz_ajanlatok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_alkatresz_ajanlatok.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_alkatresz_ajanlatok.Image = ((System.Drawing.Image)(resources.GetObject("BT_alkatresz_ajanlatok.Image")));
            this.BT_alkatresz_ajanlatok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BT_alkatresz_ajanlatok.Location = new System.Drawing.Point(0, 145);
            this.BT_alkatresz_ajanlatok.Name = "BT_alkatresz_ajanlatok";
            this.BT_alkatresz_ajanlatok.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BT_alkatresz_ajanlatok.Size = new System.Drawing.Size(250, 45);
            this.BT_alkatresz_ajanlatok.TabIndex = 4;
            this.BT_alkatresz_ajanlatok.Text = "Alkatrész ajánlatok";
            this.BT_alkatresz_ajanlatok.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BT_alkatresz_ajanlatok.UseVisualStyleBackColor = true;
            this.BT_alkatresz_ajanlatok.Click += new System.EventHandler(this.BT_keves_termek_listazas_Click);
            // 
            // BT_menu_rendeles_megtekint
            // 
            this.BT_menu_rendeles_megtekint.Dock = System.Windows.Forms.DockStyle.Top;
            this.BT_menu_rendeles_megtekint.FlatAppearance.BorderSize = 0;
            this.BT_menu_rendeles_megtekint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_menu_rendeles_megtekint.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_menu_rendeles_megtekint.Image = ((System.Drawing.Image)(resources.GetObject("BT_menu_rendeles_megtekint.Image")));
            this.BT_menu_rendeles_megtekint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BT_menu_rendeles_megtekint.Location = new System.Drawing.Point(0, 100);
            this.BT_menu_rendeles_megtekint.Name = "BT_menu_rendeles_megtekint";
            this.BT_menu_rendeles_megtekint.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BT_menu_rendeles_megtekint.Size = new System.Drawing.Size(250, 45);
            this.BT_menu_rendeles_megtekint.TabIndex = 2;
            this.BT_menu_rendeles_megtekint.Text = "Megrendelések megtekintése";
            this.BT_menu_rendeles_megtekint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BT_menu_rendeles_megtekint.UseVisualStyleBackColor = true;
            this.BT_menu_rendeles_megtekint.Click += new System.EventHandler(this.BT_menu_rendeles_megtekint_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(250, 100);
            this.panelLogo.TabIndex = 1;
            // 
            // BT_kijelentkezés
            // 
            this.BT_kijelentkezés.Dock = System.Windows.Forms.DockStyle.Top;
            this.BT_kijelentkezés.FlatAppearance.BorderSize = 0;
            this.BT_kijelentkezés.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_kijelentkezés.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_kijelentkezés.Image = global::Szakdolgozat.Properties.Resources._1486505366_exit_export_out_send_sending_archive_outside_81436;
            this.BT_kijelentkezés.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BT_kijelentkezés.Location = new System.Drawing.Point(0, 370);
            this.BT_kijelentkezés.Name = "BT_kijelentkezés";
            this.BT_kijelentkezés.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BT_kijelentkezés.Size = new System.Drawing.Size(250, 45);
            this.BT_kijelentkezés.TabIndex = 13;
            this.BT_kijelentkezés.Text = "Kijelentkezés";
            this.BT_kijelentkezés.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BT_kijelentkezés.UseVisualStyleBackColor = true;
            this.BT_kijelentkezés.Click += new System.EventHandler(this.BT_kijelentkezés_Click);
            // 
            // BT_jelszovaltoztat
            // 
            this.BT_jelszovaltoztat.Dock = System.Windows.Forms.DockStyle.Top;
            this.BT_jelszovaltoztat.FlatAppearance.BorderSize = 0;
            this.BT_jelszovaltoztat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_jelszovaltoztat.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_jelszovaltoztat.Image = global::Szakdolgozat.Properties.Resources._40_104848;
            this.BT_jelszovaltoztat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BT_jelszovaltoztat.Location = new System.Drawing.Point(0, 325);
            this.BT_jelszovaltoztat.Name = "BT_jelszovaltoztat";
            this.BT_jelszovaltoztat.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BT_jelszovaltoztat.Size = new System.Drawing.Size(250, 45);
            this.BT_jelszovaltoztat.TabIndex = 12;
            this.BT_jelszovaltoztat.Text = "Jelszóváltoztatás";
            this.BT_jelszovaltoztat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BT_jelszovaltoztat.UseVisualStyleBackColor = true;
            this.BT_jelszovaltoztat.Click += new System.EventHandler(this.BT_jelszovaltoztat_Click);
            // 
            // BT_keves_alkatresz_listazas
            // 
            this.BT_keves_alkatresz_listazas.Dock = System.Windows.Forms.DockStyle.Top;
            this.BT_keves_alkatresz_listazas.FlatAppearance.BorderSize = 0;
            this.BT_keves_alkatresz_listazas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_keves_alkatresz_listazas.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_keves_alkatresz_listazas.Image = ((System.Drawing.Image)(resources.GetObject("BT_keves_alkatresz_listazas.Image")));
            this.BT_keves_alkatresz_listazas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BT_keves_alkatresz_listazas.Location = new System.Drawing.Point(0, 280);
            this.BT_keves_alkatresz_listazas.Name = "BT_keves_alkatresz_listazas";
            this.BT_keves_alkatresz_listazas.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BT_keves_alkatresz_listazas.Size = new System.Drawing.Size(250, 45);
            this.BT_keves_alkatresz_listazas.TabIndex = 11;
            this.BT_keves_alkatresz_listazas.Text = "Kevés alkatrész listázás";
            this.BT_keves_alkatresz_listazas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BT_keves_alkatresz_listazas.UseVisualStyleBackColor = true;
            this.BT_keves_alkatresz_listazas.Click += new System.EventHandler(this.BT_keves_alkatresz_listazas_Click);
            // 
            // BT_keves_termek_listazas
            // 
            this.BT_keves_termek_listazas.Dock = System.Windows.Forms.DockStyle.Top;
            this.BT_keves_termek_listazas.FlatAppearance.BorderSize = 0;
            this.BT_keves_termek_listazas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_keves_termek_listazas.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_keves_termek_listazas.Image = ((System.Drawing.Image)(resources.GetObject("BT_keves_termek_listazas.Image")));
            this.BT_keves_termek_listazas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BT_keves_termek_listazas.Location = new System.Drawing.Point(0, 235);
            this.BT_keves_termek_listazas.Name = "BT_keves_termek_listazas";
            this.BT_keves_termek_listazas.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BT_keves_termek_listazas.Size = new System.Drawing.Size(250, 45);
            this.BT_keves_termek_listazas.TabIndex = 10;
            this.BT_keves_termek_listazas.Text = "Kevés termék listázás";
            this.BT_keves_termek_listazas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BT_keves_termek_listazas.UseVisualStyleBackColor = true;
            this.BT_keves_termek_listazas.Click += new System.EventHandler(this.BT_keves_termek_listazas_Click);
            // 
            // BT_egyenleg
            // 
            this.BT_egyenleg.Dock = System.Windows.Forms.DockStyle.Top;
            this.BT_egyenleg.FlatAppearance.BorderSize = 0;
            this.BT_egyenleg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_egyenleg.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_egyenleg.Image = ((System.Drawing.Image)(resources.GetObject("BT_egyenleg.Image")));
            this.BT_egyenleg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BT_egyenleg.Location = new System.Drawing.Point(0, 190);
            this.BT_egyenleg.Name = "BT_egyenleg";
            this.BT_egyenleg.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BT_egyenleg.Size = new System.Drawing.Size(250, 45);
            this.BT_egyenleg.TabIndex = 9;
            this.BT_egyenleg.Text = "Egyenleg lekérdezése";
            this.BT_egyenleg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BT_egyenleg.UseVisualStyleBackColor = true;
            this.BT_egyenleg.Click += new System.EventHandler(this.BT_egyenleg_Click);
            // 
            // OfficeClerkHomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.panelSideMenu);
            this.Controls.Add(this.panelContent);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OfficeClerkHomeForm";
            this.Text = "Irodista felulet";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OfficeClerkForm_FormClosed);
            this.panelSideMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button BT_menu_rendeles_megtekint;
        private System.Windows.Forms.Button BT_alkatresz_ajanlatok;
        private System.Windows.Forms.Button BT_kijelentkezés;
        private System.Windows.Forms.Button BT_jelszovaltoztat;
        private System.Windows.Forms.Button BT_keves_alkatresz_listazas;
        private System.Windows.Forms.Button BT_keves_termek_listazas;
        private System.Windows.Forms.Button BT_egyenleg;
    }
}