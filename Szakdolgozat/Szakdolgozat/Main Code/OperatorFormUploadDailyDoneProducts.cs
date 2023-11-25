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
            if (TB_darabszam.Text == "")
            {
                MessageBox.Show("Kérem adja meg a termék darabszámát!");
                return;
            }

            if (LB_termekek.SelectedItem == null)
            {
                MessageBox.Show("Kérem válassza ki, hogy milyen terméket gyártott le!");
                return;
            }

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

            int sordarab = 0;
                
            while (dr.Read())
            {
                alkarteszidkdarabszamokkal.Add(dr.GetInt32(0), dr.GetInt32(1));
                sordarab++;
            }

            if (sordarab == 0)
            {
                MessageBox.Show("Nincs hozzárendelve alkatrész a termékhez! Nem lehet legyártani!");
                return;
            }

            conn.Close();

            //ezeket az értékeket felszorozni a termékek darabszámával

            Dictionary<int, int> alkatreszidkjodarabszamokkal = new Dictionary<int, int>();

            foreach (var elem in alkarteszidkdarabszamokkal)
            {
                alkatreszidkjodarabszamokkal[elem.Key] = elem.Value * darabszam;
            }

            //az összes alkatrészek értékeit kinyerni

            Dictionary<int, int> alkatreszidkdarabszammaladatbazisbol = new Dictionary<int, int>();

            foreach (var elem in alkatreszidkjodarabszamokkal)
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

            Dictionary<int, int> tenylegesalkatreszidkdarabszammal = new Dictionary<int, int>();

            foreach(var elem in alkatreszidkdarabszammaladatbazisbol)
            {
                foreach (var elem2 in alkatreszidkjodarabszamokkal)
                {
                    if (elem.Key == elem2.Key) 
                    {
                        tenylegesalkatreszidkdarabszammal.Add(elem.Key, elem.Value - elem2.Value);
                    }
                }
            }

            //végigmenni az értékekeken, ha bármelyik negatív, akkor nem lehet az adott mennyiségű terméket legyártani

            bool error = false;

            foreach (var elem in tenylegesalkatreszidkdarabszammal)
            {
                if (elem.Value < 0)
                {
                    error = true;
                }
            }

            if (error)
            {
                MessageBox.Show("Hiba a terméket/termékeket nem lehet legyártani, mert nincs hozzá elég alkatrész!");
                return;
            }

            //ellenkező esetben le lehet gyártani

            //viszont az alkatrészeket le kell vonni (alkatreszidkjodarabszamokkal ebben a mapben megtalálhatóak az értékek)

            foreach (var elem in alkatreszidkjodarabszamokkal)
            {
                conn.Open();
                cmd.CommandText = "UPDATE alkatreszek SET osszesdarab=osszesdarab-" + elem.Value + " WHERE alkatreszid=" + elem.Key;
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            //termék darabszámát hozzáadni a termékek táblához (osszesdarabot növelni)
            conn.Open();

            cmd.CommandText = "UPDATE termekek SET osszesdarab=osszesdarab+" + darabszam + " WHERE termekid=" + termekid;
            cmd.ExecuteNonQuery();

            conn.Close();

            //terméket felvinni a gyartas táblába

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
