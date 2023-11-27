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
using QRCoder;
using Szakdolgozat.Model;

namespace Szakdolgozat
{
    public partial class BuyerFormOrder : Form
    {
        StyleForms stilus = new StyleForms();

        public BuyerFormOrder()
        {
            InitializeComponent(); 
            DGV_termekek.Columns.Add("Col1", "Termek");
            DGV_termekek.Columns.Add("Col2", "A gyarto altal kiirt ar (Ft/db)");
            DGV_termekek.Columns.Add("Col3", "Arajanlat (Ft/db)");
            DGV_termekek.Columns.Add("Col4", "Darab");

            stilus.styleChildForm(this);

            foreach(DataGridViewColumn elem in DGV_termekek.Columns)
            {
                elem.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void BuyerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void getProductsFromDatabase()
        {
            
            DGV_termekek.Columns[0].ReadOnly = true;
            DGV_termekek.Columns[1].ReadOnly = true;
            DGV_termekek.Columns[2].ReadOnly = false;
            DGV_termekek.Columns[3].ReadOnly = false;

            Database db = new Database();

            MySqlConnection conn = db.getConnection();

            try
            {
                conn.Open();

                string sql = "select nev, ar from termekek";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    DGV_termekek.Rows.Add(dr.GetString(0), dr.GetInt32(1), 0, 0);
                }

                DGV_termekek.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Bold);

                //oszlop szélességek beállítása
                DGV_termekek.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                DGV_termekek.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                DGV_termekek.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                DGV_termekek.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                for (int i = 0; i < DGV_termekek.Columns.Count; i++)
                {
                    DGV_termekek.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; //fejlécek középre igazítása
                    DGV_termekek.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //a többi cella középre igazítása
                }

                DGV_termekek.Refresh();

                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Nem sikerült csatlakozni az adatbázishoz!");
            }
        }


        private void BuyerForm_Load(object sender, EventArgs e)
        {
            getProductsFromDatabase();
        }

        private void Megrendelés_Click(object sender, EventArgs e)
        {
            
            Database db = new Database();

            MySqlConnection conn = db.getConnection();

            MySqlCommand cmd, cmd2;

            conn.Open();

            int userid = Transporter.getInstance().CurrentUser.Felhasznaloid;

            DateTime datum = DateTime.Now;

            string format = "yyyy-MM-dd HH:mm:ss";

            string allapot = "Elbírálás alatt";

            if (L_vegosszeg.Text == "Végösszeg: 0 Ft")
            {
                MessageBox.Show("Nem jelölt ki termékeket!");
                return;
            }

            int bevetel = Convert.ToInt32(L_vegosszeg.Text.Split(':')[1].Trim().Split(' ')[0].Trim());

            string sql = "insert into rendelesek(userid, datum, allapot, bevetel) values(" + userid + ", '" + datum.ToString(format) + "' , '" + allapot + "' , " + bevetel + ");";

            cmd = new MySqlCommand(sql, conn);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Megrendelés sikeres!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Megrendelés sikertelen! Indoka: " + ex.Message);
            }

            int rendelesid = 0;

            List<string> termekek = new List<string>();

            string sql2 = "select rendelesid FROM rendelesek GROUP BY rendelesid DESC LIMIT 1";
            cmd2 = new MySqlCommand(sql2, conn);

            MySqlDataReader dr = cmd2.ExecuteReader();

            while (dr.Read())
            {
                rendelesid = dr.GetInt32(0);
            }

            List<int> darabszamok = new List<int>();

            foreach (DataGridViewRow elem in DGV_termekek.Rows)
            {
                if (!elem.Cells[3].Value.ToString().Equals("0"))
                {
                    termekek.Add(elem.Cells[0].Value.ToString());
                    darabszamok.Add(Convert.ToInt32(elem.Cells[3].Value));
                }
            }

            conn.Close();

            List<int> termekidk = new List<int>();

            foreach (var elem in termekek)
            {
                conn.Open();
                string sql3 = "SELECT termekid FROM termekek WHERE nev='" + elem + "'";
                MySqlCommand cmd3 = new MySqlCommand(sql3, conn);
                MySqlDataReader dr3 = cmd3.ExecuteReader();

                while (dr3.Read())
                {
                    termekidk.Add(dr3.GetInt32(0));
                }

                conn.Close();
            }

            List<int> arajanlatok = new List<int>();
            foreach (DataGridViewRow elem in DGV_termekek.Rows)
            {
                if (!elem.Cells[3].Value.ToString().Equals("0"))
                {
                    arajanlatok.Add(Convert.ToInt32(elem.Cells[2].Value) * Convert.ToInt32(elem.Cells[3].Value));
                }
            }

       
            Dictionary<int, int> termekidkdarabszammal = new Dictionary<int, int>();

            for (int i = 0; i < termekidk.Count; i++)
            {
                termekidkdarabszammal.Add(termekidk[i], darabszamok[i]);
            }

            Dictionary<int, int> termekidkarajanlattal = new Dictionary<int, int>();
            for (int i = 0; i < termekidk.Count; i++)
            {
                termekidkarajanlattal.Add(termekidk[i], arajanlatok[i]);
            }


            foreach (var elem in termekidkdarabszammal) 
            {
               foreach(var elem2 in termekidkarajanlattal)
                {
                    if(elem.Key == elem2.Key)
                    {
                        conn.Open();
                        string sql4 = "INSERT INTO rendeles_termekek(rendelesid, termekid, db, datum, reszosszeg) VALUES(" + rendelesid + ", " + elem.Key + ", " + elem.Value + ", '" + datum.ToString(format) + "', " + elem2.Value + ")";
                        MySqlCommand cmd4 = new MySqlCommand(sql4, conn);
                        try
                        {
                            cmd4.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("A megrendelés nem sikerült! Indoka: " + ex.Message);
                        }
                        conn.Close();
                    }
                }
            }
        }

        private void DGV_termekek_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
            {
                int vegosszeg = 0;

                foreach (DataGridViewRow row in DGV_termekek.Rows)
                {
                    vegosszeg += Convert.ToInt32(row.Cells[2].Value) * Convert.ToInt32(row.Cells[3].Value);
                }

                L_vegosszeg.Text = "Végösszeg: " + vegosszeg + " Ft";
            }
        }

        private void DGV_termekek_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
