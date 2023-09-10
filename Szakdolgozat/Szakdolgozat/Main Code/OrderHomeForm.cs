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
    public partial class OrderHomeForm : Form
    {
        public OrderHomeForm()
        {
            InitializeComponent();
            openChildForm(new BuyerForm());
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
            panel1.Controls.Add(childForm);
            panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void megrendelésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new BuyerForm());
        }

        private void OrderHomeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void kilépésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
