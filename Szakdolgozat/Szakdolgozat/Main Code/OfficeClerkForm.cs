﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szakdolgozat
{
    public partial class OfficeClerkForm : Form
    {
        public OfficeClerkForm()
        {
            InitializeComponent();
        }

        private static Form activeForm = null;

        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Hide();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelContent.Controls.Add(childForm);
            panelContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void kilépésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm form = new LoginForm();
            form.Show();
            this.Hide();
        }

        private void OfficeClerkForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void alkatrészTermékhezRendeléseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new OfficeClerkFormAddParts());
        }

        private void alkatrészekDarabszámánakBeállításaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new OfficeClerkFormAddPartsQuantity());
        }
    }
}
