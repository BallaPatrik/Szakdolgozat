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
    public partial class BuyerHomeForm : Form
    {
        public BuyerHomeForm()
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

        private void eddigiRendelésekMegtekintéseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new BuyerFormListOrders());
        }

        private void kilépésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            this.Hide();
        }

        private void megrendelésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new BuyerFormOrder());
        }

        private void BuyerHomeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void jelszóváltoztatásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new ChangePasswordForm());
        }
    }
}
