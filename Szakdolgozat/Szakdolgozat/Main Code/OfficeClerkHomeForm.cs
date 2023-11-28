using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Szakdolgozat.Model;

namespace Szakdolgozat
{
    public partial class OfficeClerkHomeForm : Form
    {
        StyleForms stilus = new StyleForms();

        public OfficeClerkHomeForm()
        {
            InitializeComponent();

            stilus.styleParentForm(this);
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

        private void OfficeClerkForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void BT_egyenleg_Click(object sender, EventArgs e)
        {
            openChildForm(new Szakdolgozat.Main_Code.OfficeClerkFormCheckBalance());
        }

        private void BT_jelszovaltoztat_Click(object sender, EventArgs e)
        {
            openChildForm(new Szakdolgozat.Main_Code.ChangePasswordForm());

        }

        private void BT_menu_rendeles_megtekint_Click(object sender, EventArgs e)
        {
            openChildForm(new Szakdolgozat.Main_Code.OfficeClerkFormCheckOrders());
        }

        private void BT_kijelentkezés_Click(object sender, EventArgs e)
        {
            LoginForm form = new LoginForm();
            form.Show();
            this.Hide();
        }

        private void BT_keves_termek_listazas_Click(object sender, EventArgs e)
        {
            openChildForm(new Szakdolgozat.Main_Code.OfficeClerkFormCheckLowProducts());
        }

        private void BT_keves_alkatresz_listazas_Click(object sender, EventArgs e)
        {
            openChildForm(new Szakdolgozat.Main_Code.OfficeClerkFormCheckLowParts());
        }
    }
}
