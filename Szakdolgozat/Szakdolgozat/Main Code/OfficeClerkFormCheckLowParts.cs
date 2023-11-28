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
    public partial class OfficeClerkFormCheckLowParts : Form
    {
        StyleForms stilus = new StyleForms();

        public OfficeClerkFormCheckLowParts()
        {
            InitializeComponent();

            stilus.styleChildForm(this);

            DGV_alkatreszek.Columns.Add("Col1", "Alkatrésznév");
            DGV_alkatreszek.Columns.Add("Col2", "Darabszám");
            DGV_alkatreszek.Columns[0].ReadOnly = true;
            DGV_alkatreszek.Columns[1].ReadOnly = true;

            DGV_alkatreszek.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Bold);

            //oszlop szélességek beállítása
            DGV_alkatreszek.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < DGV_alkatreszek.Columns.Count; i++)
            {
                DGV_alkatreszek.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; //fejlécek középre igazítása
                DGV_alkatreszek.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //a többi cella középre igazítása
            }
        }

        private void BT_listaz_Click(object sender, EventArgs e)
        {
            if (TB_darabszam.Text == "")
            {
                MessageBox.Show("Kérem adja meg a darabszámot!");
                return;
            }

            DGV_alkatreszek.Rows.Clear();

            DGV_alkatreszek.Refresh();

            int darabszam = Convert.ToInt32(TB_darabszam.Text);
            Database db = new Database();

            MySqlConnection conn = db.getConnection();

            MySqlCommand cmd;

            conn.Open();

            cmd = new MySqlCommand("SELECT nev, osszesdarab FROM alkatreszek WHERE osszesdarab<" + darabszam, conn);

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                DGV_alkatreszek.Rows.Add(dr.GetString(0), dr.GetInt32(1));
            }
        }
    }
}
