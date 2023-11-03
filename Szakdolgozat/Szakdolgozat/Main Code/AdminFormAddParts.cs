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

namespace Szakdolgozat
{
    public partial class AdminFormAddParts : Form
    {
        public AdminFormAddParts()
        {
            InitializeComponent();
            DGV_parts.Columns.Add("Col2", "Nev");
            DGV_parts.Columns[0].ReadOnly = true;
            loadCombobox();
            updateParts(1);
        }

        private void loadCombobox()
        {

            Database db = new Database();

            MySqlConnection conn = db.getConnection();

            MySqlCommand cmd;

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

            cmd = new MySqlCommand("SELECT nev FROM termek_alkatreszek JOIN alkatreszek on alkatreszek.alkatreszid=termek_alkatreszek.alkatreszid WHERE termekid=" + id, conn);

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                DGV_parts.Rows.Add(dr.GetString(0));
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateParts(Convert.ToInt32(comboBox1.SelectedItem.ToString().Split(':')[0]));
        }

        private void insertPartIntoDataBase()
        {
            string alkatresznev = TB_name.Text;
            int kezdodarabszam = Convert.ToInt32(TB_startingQuantity.Text);
            int darabszam = Convert.ToInt32(TB_quantity.Text);

            Database db = new Database();

            MySqlConnection conn = db.getConnection();

            MySqlCommand cmd;

            conn.Open();

            cmd = new MySqlCommand("INSERT INTO alkatreszek (nev,osszesdarab) VALUES ('" + alkatresznev + "', " + kezdodarabszam + ")", conn);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sikeres alkatrészbeszúrás!");
            } catch(Exception ex)
            {
                MessageBox.Show("Hiba történt a beszúrás közben!");
            }
        }

        private void showNewPartInDGV()
        {

        }

        private void BT_confirm_Click(object sender, EventArgs e)
        {
            insertPartIntoDataBase();
        }
    }
}
