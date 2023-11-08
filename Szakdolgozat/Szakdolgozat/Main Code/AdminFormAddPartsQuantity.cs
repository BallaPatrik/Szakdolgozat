using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Szakdolgozat
{
    public partial class AdminFormAddPartsQuantity : Form
    {
        public AdminFormAddPartsQuantity()
        {
            InitializeComponent();
            DGV_parts.Columns.Add("Col2", "Nev");
            DGV_parts.Columns.Add("Col3", "Darabszam");
            DGV_parts.Columns[0].ReadOnly = true;
            loadCombobox();
            updateParts(1);
        }

        //Combobox feltöltés

        private void loadCombobox()
        {

            Database db = new Database();

            MySqlConnection conn = db.getConnection();

            MySqlCommand cmd;

            MySqlDataAdapter sda;

            DataTable dt;

            conn.Open();

            cmd = new MySqlCommand("select * from termekek", conn);

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string comboboxitem = dr.GetInt32(0) + ": " + dr.GetString(1);
                comboBox1.Items.Add(comboboxitem);
            }

            comboBox1.SelectedIndex = 0;

            conn.Close();
        }

        //Datagridview frissítés

        private void updateParts(int id)
        {
            DGV_parts.Rows.Clear();

            DGV_parts.Refresh();

            Database db = new Database();

            MySqlConnection conn = db.getConnection();

            MySqlCommand cmd;

            MySqlDataAdapter sda;

            DataTable dt;

            conn.Open();

            cmd = new MySqlCommand("SELECT nev, darabszam FROM termek_alkatreszek JOIN alkatreszek on alkatreszek.alkatreszid=termek_alkatreszek.alkatreszid WHERE termekid=" + id, conn);

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                DGV_parts.Rows.Add(dr.GetString(0), dr.GetInt32(1));
            }

            DGV_parts.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Bold);

            //oszlop szélességek beállítása
            DGV_parts.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DGV_parts.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            for (int i = 0; i < DGV_parts.Columns.Count; i++)
            {
                DGV_parts.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; //fejlécek középre igazítása
                DGV_parts.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //a többi cella középre igazítása
            }

            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateParts(Convert.ToInt32(comboBox1.SelectedItem.ToString().Split(':')[0]));
        }

        //Confirm gomb funkció

        private void BT_confirm_Click(object sender, EventArgs e)
        {
            Database db = new Database();

            MySqlConnection conn = db.getConnection();
            bool worked = false;

            conn.Open();

            for (int i = 0; i < DGV_parts.Rows.Count; i++)
            {
                if (Convert.ToInt32(DGV_parts.Rows[i].Cells[1].Value) > 0)
                {
                    if (Convert.ToInt32(DGV_parts.Rows[i].Cells[1].Value) > getPartSum(Convert.ToString(DGV_parts.Rows[i].Cells[0].Value))) {
                        MessageBox.Show("Hiba: Nincs elég alkatrész! " + getPartSum(Convert.ToString(DGV_parts.Rows[i].Cells[0].Value)));
                    }
                    else
                    {
                        MySqlCommand cmd = new MySqlCommand("UPDATE termek_alkatreszek SET darabszam = " + Convert.ToInt32(DGV_parts.Rows[i].Cells[1].Value) + " WHERE alkatreszid = (SELECT alkatreszid FROM alkatreszek WHERE nev = '" + Convert.ToString(DGV_parts.Rows[i].Cells[0].Value) + "')", conn);
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "UPDATE alkatreszek SET osszesdarab = osszesdarab - " + Convert.ToInt32(DGV_parts.Rows[i].Cells[1].Value) + " WHERE nev = '" + Convert.ToString(DGV_parts.Rows[i].Cells[0].Value) + "'";
                        cmd.ExecuteNonQuery();
                        worked = true;
                    }
                }
            }

            if (worked) { MessageBox.Show("Sikeres módosítás!"); }


            updateParts(Convert.ToInt32(comboBox1.SelectedItem.ToString().Split(':')[0]));


            conn.Close();
        }

        private int getPartSum(string name)
        {
            Database db = new Database();

            MySqlConnection conn = db.getConnection();

            conn.Open();

            int sum = 0;

            MySqlCommand cmd = new MySqlCommand("SELECT osszesdarab FROM alkatreszek WHERE nev='" + name + "'", conn);

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                sum = dr.GetInt32(0);
                break;
            }

            conn.Close();

            return sum;
        }

    }
}
