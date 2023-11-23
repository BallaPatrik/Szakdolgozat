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

namespace Szakdolgozat
{
    public partial class AdminFormAddParts : Form
    {
        StyleForms stilus = new StyleForms();

        public AdminFormAddParts()
        {
            InitializeComponent();
            DGV_parts.Columns.Add("Col2", "Nev");
            DGV_parts.Columns[0].ReadOnly = true;
            loadCombobox();
            updateParts(1);

            stilus.styleChildForm(this);

            foreach (DataGridViewColumn elem in DGV_parts.Columns)
            {
                elem.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
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
            if(TB_name.Text=="" || TB_startingQuantity.Text=="" || TB_quantity.Text == "")
            {
                MessageBox.Show("Kérem töltse ki az összes beviteli mezőt!");
                return;
            }

            string alkatresznev = TB_name.Text;
            int kezdodarabszam = Convert.ToInt32(TB_startingQuantity.Text);
            int darabszam = Convert.ToInt32(TB_quantity.Text);

            Database db = new Database();

            MySqlConnection conn = db.getConnection();

            MySqlCommand cmd, cmd2, cmd3, cmd4;

            conn.Open();

            int termekid = 0;

            string sql = "SELECT termekid FROM termekek WHERE nev='" + comboBox1.SelectedItem.ToString().Split(':')[1].Trim() + "'";
            
            cmd=new MySqlCommand(sql, conn);

            MySqlDataReader dr=cmd.ExecuteReader();

            while (dr.Read())
            {
                termekid=dr.GetInt32(0);
            }

            conn.Close();

            conn.Open();

            cmd3 = new MySqlCommand("INSERT INTO alkatreszek (nev,osszesdarab) VALUES ('" + alkatresznev + "', " + kezdodarabszam + ")", conn);

            try
            {
                cmd3.ExecuteNonQuery();

                int alkatreszid = 0;

                string sql2 = "SELECT alkatreszid FROM alkatreszek WHERE nev='" + alkatresznev + "'";

                cmd2 = new MySqlCommand(sql2, conn);

                MySqlDataReader dr2 = cmd2.ExecuteReader();

                while (dr2.Read())
                {
                    alkatreszid = dr2.GetInt32(0);
                }

                conn.Close();

                conn.Open();

                string sql4 = "INSERT INTO termek_alkatreszek (termekid, alkatreszid, darabszam) VALUES(" + termekid + ", " + alkatreszid + ", " + darabszam + ")";
                cmd4=new MySqlCommand(sql4, conn);

                cmd4.ExecuteNonQuery();

                MessageBox.Show("Sikeres alkatrészbeszúrás!");

                updateParts(Convert.ToInt32(comboBox1.SelectedItem.ToString().Split(':')[0]));

            } catch(Exception ex)
            {
                MessageBox.Show("Hiba történt a beszúrás közben!");
            }

            conn.Close();
        }

        private void BT_confirm_Click(object sender, EventArgs e)
        {
            insertPartIntoDataBase();
        }

        private void AdminFormAddParts_Load(object sender, EventArgs e)
        {

        }
    }
}
