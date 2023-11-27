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
using Szakdolgozat.Model;

namespace Szakdolgozat
{
    public partial class OperatorFormListDailyProducts : Form
    {
        StyleForms stilus = new StyleForms();
        private int elozodarabszam = 0;

        public OperatorFormListDailyProducts()
        {
            InitializeComponent();
            DGV_products.Columns.Add("Col2", "Termek");
            DGV_products.Columns.Add("Col3", "Datum");
            DGV_products.Columns.Add("Col4", "Darabszam");

            stilus.styleChildForm(this);

            foreach (DataGridViewColumn elem in DGV_products.Columns)
            {
                elem.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void OperatorFormListDailyProducts_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void selectDailyProductsFromDatabase()
        {

            DGV_products.Rows.Clear();

            DGV_products.Refresh();

            Database db = new Database();

            MySqlConnection conn = db.getConnection();

            MySqlCommand cmd;

            MySqlDataAdapter sda;

            DataTable dt;

            conn.Open();

            //SELECT * FROM `gyartas` WHERE datum LIKE '2023-04-13%';

            DateTime time = DateTime.Now;

            string format = "yyyy. MM. dd";

            cmd = new MySqlCommand("select termekek.nev, gyartas.datum, gyartas.db from gyartas join termekek on termekek.termekid=gyartas.termekid", conn);

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (dr.GetString(1).Contains(time.ToString(format)) == true)
                {
                    DGV_products.Rows.Add("", dr.GetString(0), dr.GetString(1), dr.GetInt32(2));
                }
            }

            DGV_products.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Bold);

            //oszlop szélességek beállítása
            DGV_products.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DGV_products.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DGV_products.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DGV_products.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            for (int i = 0; i < DGV_products.Columns.Count; i++)
            {
                DGV_products.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; //fejlécek középre igazítása
                DGV_products.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //a többi cella középre igazítása
            }

            conn.Close();
        }

        private void OperatorFormListDailyProducts_Load(object sender, EventArgs e)
        {
            selectDailyProductsFromDatabase();
        }

        private void DGV_products_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            elozodarabszam = Convert.ToInt32(DGV_products.Rows[e.RowIndex].Cells[3].Value);

            senderGrid.Columns[1].ReadOnly = true;
            senderGrid.Columns[2].ReadOnly = true;
            senderGrid.Columns[3].ReadOnly = true;

            //kivédeni a törlés gomb előtti területre való kattintást
            if (e.ColumnIndex < 0)
            {
                MessageBox.Show("Kérem a táblázat belsejébe kattintson!");
                return;
            }

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0 && DGV_products.Rows[e.RowIndex].Cells[1].Value != null)
            {
                string termeknev = DGV_products.Rows[e.RowIndex].Cells[1].Value.ToString();
                string datum = DGV_products.Rows[e.RowIndex].Cells[2].Value.ToString();
                datum = datum.Replace(". ", "-");
                int darabszam = Convert.ToInt32(DGV_products.Rows[e.RowIndex].Cells[3].Value.ToString());

                Database db = new Database();

                MySqlConnection conn = db.getConnection();

                MySqlDataReader dr;

                //TÖRLÉSNÉL ALKATRÉSZEK HOZZÁADÁSA AZ ADATBÁZISHOZ

                //termék id-jának, és darabszámának meghatározása

                conn.Open();

                int termekid = 0;

                string sql = "SELECT termekid FROM termekek WHERE nev='" + termeknev + "'";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    termekid = dr.GetInt32(0);
                }

                conn.Close();

                //termékid-val kiválasztjuk az alkatrészeket a termek_alkatreszek táblából

                conn.Open();

                Dictionary<int, int> alkatresziddarabszamkezdetlegeslista = new Dictionary<int, int>();

                cmd.CommandText = "SELECT alkatreszid, darabszam FROM termek_alkatreszek WHERE termekid=" + termekid;

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    alkatresziddarabszamkezdetlegeslista.Add(dr.GetInt32(0), dr.GetInt32(1));
                }

                conn.Close();

                //felszorozzuk a darabszámmal

                Dictionary<int, int> alkatresziddarabszamveglegeslista = new Dictionary<int, int>();

                foreach (var elem in alkatresziddarabszamkezdetlegeslista)
                {
                    alkatresziddarabszamveglegeslista.Add(elem.Key, elem.Value * darabszam);
                }

                //hozzáadjuk az alkatreszek osszesdarab-jához

                foreach (var elem in alkatresziddarabszamveglegeslista)
                {
                    conn.Open();

                    cmd.CommandText = "UPDATE alkatreszek SET osszesdarab=osszesdarab+" + elem.Value + " WHERE alkatreszid=" + elem.Key;

                    cmd.ExecuteNonQuery();

                    conn.Close();
                }

                //gyartas táblából való törlés

                conn.Open();

                cmd.CommandText = "delete from gyartas where datum='" + datum + "' and db=" + darabszam + " and termekid = (SELECT termekid FROM termekek WHERE nev = '" + termeknev + "')";

                cmd.ExecuteNonQuery();

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Termék törlése sikeres!");
                    DGV_products.Rows.RemoveAt(e.RowIndex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Törlés nem sikerült! Indoka: " + ex.Message);
                }

                conn.Close();
            }
            else if (e.RowIndex >= 0 && DGV_products.Rows[e.RowIndex].Cells[1].Value != null)
            {
                TB_termeknev.Text = DGV_products.Rows[e.RowIndex].Cells[1].Value.ToString();
                TB_datum.Text = DGV_products.Rows[e.RowIndex].Cells[2].Value.ToString();
                TB_darabszam.Text = DGV_products.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }

        private void BT_modosit_Click(object sender, EventArgs e)
        {
            Database db = new Database();

            MySqlConnection conn = db.getConnection();

            if (TB_darabszam.Text == "" || TB_termeknev.Text == "" || TB_datum.Text == "")
            {
                MessageBox.Show("Kérem kattintson a táblázaton belüli elemre, ha módosítani szeretne elemet!");
                return;
            }

            int eredetidb = Convert.ToInt32(TB_darabszam.Text);
            string termek = TB_termeknev.Text;
            string datumseged = TB_datum.Text;
            string datum;
            datum = datumseged.Replace(". ", "-");
            StringBuilder sb = new StringBuilder(datum);
            sb[10] = ' ';
            datum = sb.ToString();
            int darabszam = -1;

            foreach (DataGridViewRow row in DGV_products.Rows)
            {
                if (row.Cells[2].Value.ToString().Equals(datumseged))
                {
                    darabszam = Convert.ToInt32(row.Cells[3].Value.ToString());
                    break;
                }
            }

            if (darabszam == -1)
            {
                MessageBox.Show("Ki kell választani terméket!");
                return;
            }





            //MÓDOSÍTÁSNÁL AZ ALKATRÉSZEKET IS KEZELNI KELL

            //Az eredeti darabszámból kivonni a módosítottat

            int ujdarabszam = Convert.ToInt32(TB_darabszam.Text.ToString());
            int keresettdarab = darabszam;
            darabszam = Math.Abs(ujdarabszam - darabszam);


            MySqlDataReader dr;

            //termék id-jának, és darabszámának meghatározása

            conn.Open();

            int termekid = 0;
            string termeknev = TB_termeknev.Text;

            string sql = "SELECT termekid FROM termekek WHERE nev='" + termeknev + "'";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                termekid = dr.GetInt32(0);
            }

            conn.Close();


            conn.Open();

            Dictionary<int, int> alkatresziddarabszamkezdetlegeslista = new Dictionary<int, int>();

            cmd.CommandText = "SELECT alkatreszid, darabszam FROM termek_alkatreszek WHERE termekid=" + termekid;

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                alkatresziddarabszamkezdetlegeslista.Add(dr.GetInt32(0), dr.GetInt32(1));
            }

            conn.Close();

            //felszorozzuk a darabszámmal

            Dictionary<int, int> alkatresziddarabszamveglegeslista = new Dictionary<int, int>();

            foreach (var elem in alkatresziddarabszamkezdetlegeslista)
            {
                alkatresziddarabszamveglegeslista.Add(elem.Key, elem.Value * darabszam);
            }

            if (ujdarabszam > elozodarabszam)
            {
                //LE KELL VONNI AZ ALKATRÉSZT

                Dictionary<int, int> alkatreszidkdarabszammaladatbazisbol = new Dictionary<int, int>();

                foreach (var elem in alkatresziddarabszamveglegeslista)
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

                foreach (var elem in alkatreszidkdarabszammaladatbazisbol)
                {
                    foreach (var elem2 in alkatresziddarabszamveglegeslista)
                    {
                        if (elem.Key == elem2.Key)
                        {
                            tenylegesalkatreszidkdarabszammal.Add(elem.Key, elem.Value - elem2.Value);
                        }
                    }
                }

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

                foreach (var elem in alkatresziddarabszamveglegeslista)
                {
                    conn.Open();

                    cmd.CommandText = "UPDATE alkatreszek SET osszesdarab=osszesdarab-" + elem.Value + " WHERE alkatreszid=" + elem.Key;

                    cmd.ExecuteNonQuery();

                    conn.Close();
                }

            }
            else if (ujdarabszam < elozodarabszam)
            {
                //HOZZÁ KELL ADNI AZ ALKATRÉSZT

                Dictionary<int, int> alkatreszidkdarabszammaladatbazisbol = new Dictionary<int, int>();

                foreach (var elem in alkatresziddarabszamveglegeslista)
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

                Dictionary<int, int> tenylegesalkatreszidkdarabszammal = new Dictionary<int, int>();

                foreach (var elem in alkatreszidkdarabszammaladatbazisbol)
                {
                    foreach (var elem2 in alkatresziddarabszamveglegeslista)
                    {
                        if (elem.Key == elem2.Key)
                        {
                            tenylegesalkatreszidkdarabszammal.Add(elem.Key, elem.Value - elem2.Value);
                        }
                    }
                }

                foreach (var elem in alkatresziddarabszamveglegeslista)
                {
                    conn.Open();

                    cmd.CommandText = "UPDATE alkatreszek SET osszesdarab=osszesdarab+" + elem.Value + " WHERE alkatreszid=" + elem.Key;

                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("Nem történt módosítás!");
                return;
            }

            sql = "update gyartas set db=" + ujdarabszam + " where datum='" + datum + "' and db=" + keresettdarab + " and termekid = (SELECT termekid FROM termekek WHERE nev = '" + termek + "')";

            cmd = new MySqlCommand(sql, conn);

            conn.Open();

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Termék módosítása sikeres!");

                selectDailyProductsFromDatabase();
                //TB_darabszam.Text = darabszam.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Módosítás nem sikerült! Indoka: " + ex.Message);
            }
            conn.Close();

            selectDailyProductsFromDatabase();
        }
    }
}
