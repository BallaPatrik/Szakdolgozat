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

namespace Szakdolgozat.Main_Code
{
    public partial class OperatorHomeForm : Form
    {
        StyleForms stilus = new StyleForms();

        public OperatorHomeForm()
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

        private void HomeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void jelszóváltoztatásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new ChangePasswordForm());
        }

        private void BT_menu_legyartott_termekek_felvitele_Click(object sender, EventArgs e)
        {
            openChildForm(new OperatorFormUploadDailyDoneProducts());
        }

        private void BT_menu_legyartott_termekek_listazasa_Click(object sender, EventArgs e)
        {
            openChildForm(new OperatorFormListDailyProducts());
        }

        private void BT_menu_jelszovaltoztat_Click(object sender, EventArgs e)
        {
            openChildForm(new ChangePasswordForm());
        }

        private void BT_menu_kijelentkezes_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            this.Hide();
        }
    }
}
