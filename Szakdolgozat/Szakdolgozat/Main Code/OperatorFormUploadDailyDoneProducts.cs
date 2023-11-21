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
using System.Globalization;
using Szakdolgozat.Model;

namespace Szakdolgozat
{
    public partial class OperatorFormUploadDailyDoneProducts : Form
    {
        StyleForms stilus = new StyleForms();

        public OperatorFormUploadDailyDoneProducts()
        {
            InitializeComponent();

            stilus.styleChildForm(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getProductsFromDatabase();
        }

        private void getProductsFromDatabase()
        {

            Database db = new Database();

            MySqlConnection conn = db.getConnection();

            conn.Open();

            string sql = "select nev from termekek";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                LB_termekek.Items.Add(dr.GetString(0));
            }

            conn.Close();
        }

        private void OperatorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void LB_termekek_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BT_termekfelvitele_Click(object sender, EventArgs e)
        {
            string termek = LB_termekek.SelectedItem.ToString();
            int darabszam = Convert.ToInt32(TB_darabszam.Text);

            Database db = new Database();

            MySqlConnection conn = db.getConnection();

            conn.Open();

            string sql = "select termekid from termekek where nev='" + termek + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            MySqlDataReader dr = cmd.ExecuteReader();

            int termekid = 0;

            while (dr.Read())
            {
                termekid = dr.GetInt32(0);
            }

            conn.Close();

            conn.Open();

            //kiválogatni az alkatrészeket a darabszámokkal együtt

            Dictionary<int, int> alkarteszidkdarabszamokkal = new Dictionary<int, int>();

            cmd.CommandText = "SELECT alkatreszid, darabszam FROM termek_alkatreszek WHERE termekid=" + termekid;

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                alkarteszidkdarabszamokkal.Add(dr.GetInt32(0), dr.GetInt32(1));
            }

            conn.Close();

            //ezeket az értékeket felszorozni a termékek darabszámával

            Dictionary<int, int> alkarteszidkjodarabszamokkal = new Dictionary<int, int>();

            foreach (var elem in alkarteszidkdarabszamokkal)
            {
                alkarteszidkjodarabszamokkal[elem.Key] = elem.Value * darabszam;
            }

            //az összes alkatrészek értékeit kinyerni

            Dictionary<int, int> alkatreszidkdarabszammaladatbazisbol = new Dictionary<int, int>();

            foreach (var elem in alkarteszidkjodarabszamokkal)
            {
                conn.Open();

                cmd.CommandText = "SELECT alkatreszid, osszesdarab FROM alkatreszek WHERE alkatreszid=" + elem.Key;

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    alkatreszidkdarabszammaladatbazisbol.Add(dr.GetInt32(0), dr.GetInt32(1));
                }

                conn.Close();
            }

            //összes alkatrészből kivonni az elvileg legyártott termékek számát

            //ez jön

            //végigmenni az értékekeken, ha bármelyik negatív, akkor nem lehet az adott mennyiségű terméket legyártani

            //ellenkező esetben le lehet gyártani



            conn.Open();

            DateTime time = DateTime.Now;

            string format = "yyyy-MM-dd HH:mm:ss";

            string sql2 = "insert into gyartas(termekid, datum, db) values(" + termekid + ", '" + time.ToString(format) + "' , " + darabszam + ");";
            MySqlCommand cmd2 = new MySqlCommand(sql2, conn);

            try
            {
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Termék felvitele sikeres!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beszúras nem sikerült! Indoka: " + ex.Message);
            }

            conn.Close();
        }
    }
}
