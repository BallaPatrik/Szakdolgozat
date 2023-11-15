using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szakdolgozat.Main_Code
{
    public partial class AdminHomeForm : Form
    {
        public AdminHomeForm()
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

        private void AdminHomeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        
        private void BT_menu_felhasz_hozzaad_Click(object sender, EventArgs e)
        {
            openChildForm(new Szakdolgozat.Main_Code.AdminFormAddUser());
        }

        private void BT_menu_felhasz_torol_Click(object sender, EventArgs e)
        {
            openChildForm(new AdminFormDeleteUser());
        }

        private void BT_alkatresz_hozzarendel_termek_Click(object sender, EventArgs e)
        {
            openChildForm(new AdminFormAddParts());
        }

        private void BT_alkatresz_hozzarendel_termek_darab_Click(object sender, EventArgs e)
        {
            openChildForm(new AdminFormAddPartsQuantity());
        }

        private void BT_jelszovaltoztat_Click(object sender, EventArgs e)
        {
            openChildForm(new ChangePasswordForm());
        }

        private void BT_kijelentkezés_Click(object sender, EventArgs e)
        {
            LoginForm form = new LoginForm();
            form.Show();
            this.Hide();
        }
    }
}
