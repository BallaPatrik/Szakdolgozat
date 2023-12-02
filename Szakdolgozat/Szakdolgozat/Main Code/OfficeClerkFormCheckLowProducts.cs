using MySql.Data.MySqlClient;
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
    public partial class OfficeClerkFormCheckLowProducts : Form
    {
        StyleForms stilus = new StyleForms();
        public OfficeClerkFormCheckLowProducts()
        {
            InitializeComponent();

            stilus.styleChildForm(this);

            DGV_termekek.Columns.Add("Col1", "Terméknév");
            DGV_termekek.Columns.Add("Col2", "Darabszám");
            DGV_termekek.Columns[0].ReadOnly = true;
            DGV_termekek.Columns[1].ReadOnly = true;

            DGV_termekek.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Bold);

            //oszlop szélességek beállítása
            DGV_termekek.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < DGV_termekek.Columns.Count; i++)
            {
                DGV_termekek.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; //fejlécek középre igazítása
                DGV_termekek.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //a többi cella középre igazítása
            }

            foreach (Button button in this.Controls.OfType<Button>())
            {
                stilus.styleButton(button);
            }
        }

        private void OfficeClerkFormCheckLowProducts_Load(object sender, EventArgs e)
        {

        }

        private void BT_listaz_Click(object sender, EventArgs e)
        {
            if (TB_darabszam.Text == "")
            {
                MessageBox.Show("Kérem adja meg a darabszámot!");
                return;
            }

            DGV_termekek.Rows.Clear();

            DGV_termekek.Refresh();

            int darabszam = Convert.ToInt32(TB_darabszam.Text);
            Database db = new Database();

            MySqlConnection conn = db.getConnection();

            MySqlCommand cmd;

            conn.Open();

            cmd = new MySqlCommand("SELECT nev, osszesdarab FROM termekek WHERE osszesdarab<=" + darabszam, conn);

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                DGV_termekek.Rows.Add(dr.GetString(0), dr.GetInt32(1));
            }
        }

        private void OfficeClerkFormCheckLowProducts_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
