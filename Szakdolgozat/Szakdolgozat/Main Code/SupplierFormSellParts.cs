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

namespace Szakdolgozat.Main_Code
{
    public partial class SupplierFormSellParts : Form
    {
        public SupplierFormSellParts()
        {
            InitializeComponent();
            DGV_parts.Columns.Add("Col1", "Alkatresz neve");
            DGV_parts.Columns.Add("Col2", "Darabszama");
            DGV_parts.Columns.Add("Col3", "Erteke");
            DGV_parts.Columns[0].ReadOnly = true;
            updateParts();
        }

        private void updateParts()
        {
            Database db = new Database();

            MySqlConnection conn = db.getConnection();

            MySqlCommand cmd;

            conn.Open();

            cmd = new MySqlCommand("select nev from alkatreszek", conn);

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                DGV_parts.Rows.Add(dr.GetString(0),0,0);
            }

            DGV_parts.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Bold);

            //oszlop szélességek beállítása
            DGV_parts.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < DGV_parts.Columns.Count; i++)
            {
                DGV_parts.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; //fejlécek középre igazítása
                DGV_parts.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //a többi cella középre igazítása
            }

            conn.Close();
        }
    }
}
