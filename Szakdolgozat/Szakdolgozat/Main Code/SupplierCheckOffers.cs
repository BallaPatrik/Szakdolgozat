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
    public partial class SupplierCheckOffers : Form
    {
        StyleForms stilus = new StyleForms();

        public SupplierCheckOffers()
        {
            InitializeComponent();

            DGV_ajanlatok.Columns.Add("Col1", "Azonosító");
            DGV_ajanlatok.Columns.Add("Col2", "Dátum");
            DGV_ajanlatok.Columns.Add("Col3", "Név");
            DGV_ajanlatok.Columns.Add("Col3", "Állapot");
            DGV_ajanlatok.Columns.Add("Col4", "Végösszeg");


            DGV_ajanlatok.Columns[1].ReadOnly = true;
            DGV_ajanlatok.Columns[2].ReadOnly = true;
            DGV_ajanlatok.Columns[3].ReadOnly = true;
            DGV_ajanlatok.Columns[4].ReadOnly = true;

            stilus.styleChildForm(this);


            foreach (DataGridViewColumn elem in DGV_ajanlatok.Columns)
            {
                elem.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            getOffersFromDatabase();
        }

        private void getOffersFromDatabase()
        {
            DGV_ajanlatok.Rows.Clear();
            Database db = new Database();

            MySqlConnection conn = db.getConnection();

            int felhasznaloid = Transporter.getInstance().CurrentUser.Felhasznaloid;

            try
            {
                conn.Open();

                string sql = "select datum, cegnev, allapot, vegosszeg, ajanlatid from ajanlat join beszallitok on ajanlat.beszallitoid = beszallitok.beszallitoid where allapot IN ('Elbírálás alatt', 'Kezdeti elbírálás')";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    DGV_ajanlatok.Rows.Add(0, 0, dr.GetInt32(4), dr.GetString(0), dr.GetString(1), dr.GetString(2), dr.GetInt32(3));

                }

                DGV_ajanlatok.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Bold);

                //oszlop szélességek beállítása
                DGV_ajanlatok.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                DGV_ajanlatok.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                DGV_ajanlatok.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                DGV_ajanlatok.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                DGV_ajanlatok.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                for (int i = 0; i < DGV_ajanlatok.Columns.Count; i++)
                {
                    DGV_ajanlatok.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; //fejlécek középre igazítása
                    DGV_ajanlatok.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //a többi cella középre igazítása
                }

                DGV_ajanlatok.Refresh();

                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Nem sikerült csatlakozni az adatbázishoz!");
            }
        }

        private void SupplierCheckOffers_Load(object sender, EventArgs e)
        {

            DataGridViewButtonColumn buttonelfogad = new DataGridViewButtonColumn();
            {
                buttonelfogad.Name = "Elfogadás";
                buttonelfogad.HeaderText = "A rendelés elfogadása";
                buttonelfogad.Text = "Elfogadás";
                buttonelfogad.UseColumnTextForButtonValue = true;
                this.DGV_ajanlatok.Columns.Add(buttonelfogad);
            }

            DataGridViewButtonColumn buttonelutasit = new DataGridViewButtonColumn();
            {
                buttonelutasit.Name = "Elutasítás";
                buttonelutasit.HeaderText = "A rendelés elutasítása";
                buttonelutasit.Text = "Elutasítás";
                buttonelutasit.UseColumnTextForButtonValue = true;
                this.DGV_ajanlatok.Columns.Add(buttonelutasit);
            }
        }

        private string getLatestState(int ajanlatid)
        {
            string allapot = "Nem tudom";
            Database db = new Database();

            MySqlConnection conn = db.getConnection();
            string sql = "select datum, allapot from ajanlat WHERE datum IN (SELECT MAX(datum) FROM ajanlat) and ajanlatid = " + ajanlatid + " GROUP BY datum ";

            conn.Open();

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                allapot = dr.GetString(1);
            }

            conn.Close();

            return allapot;
        }

        private void DGV_ajanlatok_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Database db = new Database();

            MySqlConnection conn = db.getConnection();

            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0 && (e.ColumnIndex == 0 || e.ColumnIndex == 1 || e.ColumnIndex == 7 || e.ColumnIndex == 8))
            {
                if (e.ColumnIndex == 0)
                {
                    int rendelesid = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[2].Value);
                    Transporter.getInstance().setOrderId(rendelesid);
                    SupplierOfferDetails form = new SupplierOfferDetails();
                    form.ShowDialog();
                }
                else if (e.ColumnIndex == 1)
                {
                    int rendelesid = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[2].Value);
                    Transporter.getInstance().setOrderId(rendelesid);
                    OfficeClerkFormSendCounterOffer form = new OfficeClerkFormSendCounterOffer();
                    form.ShowDialog();
                }
                else if (e.ColumnIndex == 7)
                {
                    int rendelesid = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[2].Value);

                    string allapot = senderGrid.Rows[e.RowIndex].Cells[5].Value.ToString();
                    if (allapot == "Elfogadva" || allapot == "Elutasítva" || getLatestState(rendelesid) == "Nem tudom" || getLatestState(rendelesid) == "Elutasítva" || getLatestState(rendelesid) == "Elfogadva")
                    {
                        MessageBox.Show("A megrendelést ebben az állapotban (már) nem lehet módosítani, vagy létezik belőle aktuálisabb változat!");
                    }
                    else
                    {
                        conn.Open();
                        DateTime datum = DateTime.Now;
                        string format = "yyyy-MM-dd HH:mm:ss";
                        allapot = "Elfogadva";
                        string sql = "select felhasznaloid from felhasznalok where nev='" + senderGrid.Rows[e.RowIndex].Cells[4].Value.ToString() + "'";
                        int userid = 0;
                        MySqlCommand cmd = new MySqlCommand(sql, conn);

                        MySqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            userid = dr.GetInt32(0);
                        }
                        conn.Close();

                       

                        Balance.getInstance().addBalance(Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[6].Value));

                        conn.Open();

                        string sql3 = "SELECT rendeles_termekek.termekid, rendeles_termekek.db FROM rendeles_termekek WHERE rendelesid= " + rendelesid + "";

                        MySqlCommand cmd3 = new MySqlCommand(sql3, conn);

                        MySqlDataReader dr3 = cmd3.ExecuteReader();

                        Dictionary<int, int> termekidkdarabbal = new Dictionary<int, int>();

                        while (dr3.Read())
                        {
                            termekidkdarabbal.Add(dr3.GetInt32(0), dr3.GetInt32(1));
                        }

                        conn.Close();

                        conn.Open();

                        foreach (var elem in termekidkdarabbal)
                        {
                            string sql4 = "UPDATE termekek SET osszesdarab=osszesdarab-" + elem.Value + " WHERE termekid=" + elem.Key;

                            MySqlCommand cmd4 = new MySqlCommand(sql4, conn);

                            cmd4.ExecuteNonQuery();
                        }

                        conn.Close();

                        //getProductQuantity meghívása ezekre

                        //ha valamelyik nincs hibaüzenet


                        conn.Open();
                        string sql5 = "insert into rendelesek (rendelesid, userid, datum, allapot, bevetel) VALUES (" + rendelesid + ", " + userid + ", '" + datum.ToString(format) + "', '" + allapot + "', " + senderGrid.Rows[e.RowIndex].Cells[6].Value.ToString() + ")";
                        MySqlCommand cmd5 = new MySqlCommand(sql5, conn);
                        cmd5.ExecuteNonQuery();
                        MessageBox.Show("Megrendelés elfogadva!");
                        conn.Close();
                    }
                }
                else if (e.ColumnIndex == 8)
                {
                    int rendelesid = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[2].Value);

                    string allapot = senderGrid.Rows[e.RowIndex].Cells[5].Value.ToString();

                    if (allapot == "Elfogadva" || allapot == "Elutasítva" || getLatestState(rendelesid) == "Nem tudom" || getLatestState(rendelesid) == "Elutasítva" || getLatestState(rendelesid) == "Elfogadva")
                    {
                        MessageBox.Show("A megrendelést ebben az állapotban (már) nem lehet módosítani, vagy létezik belőle aktuálisabb változat!");
                    }
                    else
                    {
                        conn.Open();
                        DateTime datum = DateTime.Now;
                        string format = "yyyy-MM-dd HH:mm:ss";
                        allapot = "Elutasítva";
                        string sql = "select felhasznaloid from felhasznalok where nev='" + senderGrid.Rows[e.RowIndex].Cells[4].Value.ToString() + "'";
                        int userid = 0;
                        MySqlCommand cmd = new MySqlCommand(sql, conn);

                        MySqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            userid = dr.GetInt32(0);
                        }
                        conn.Close();

                        conn.Open();
                        string sql2 = "insert into rendelesek (rendelesid, userid, datum, allapot, bevetel) VALUES (" + rendelesid + ", " + userid + ", '" + datum.ToString(format) + "', '" + allapot + "', " + senderGrid.Rows[e.RowIndex].Cells[6].Value.ToString() + ")";
                        MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                        cmd2.ExecuteNonQuery();
                        MessageBox.Show("Megrendelés elutasítva!");
                        conn.Close();
                    }
                }
                getOffersFromDatabase();
            }
        }

        private void DGV_ajanlatok_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Database db = new Database();

            MySqlConnection conn = db.getConnection();

            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {

                int felhasznaloid = Transporter.getInstance().CurrentUser.Felhasznaloid;

                int ajanlatid = 0;

                conn.Open();

                string datumseged = DGV_ajanlatok.Rows[e.RowIndex].Cells[3].Value.ToString();

                string datumstr;

                datumstr = datumseged.Replace(". ", "-");
                StringBuilder sb = new StringBuilder(datumstr);
                sb[10] = ' ';
                datumstr = sb.ToString();

                string sql = "select ajanlatid from ajanlat where beszallitoid=" + felhasznaloid + " and datum='" + datumstr + "'";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ajanlatid = dr.GetInt32(0);
                }

                Transporter.getInstance().setOfferId(ajanlatid);

                conn.Close();
            }
        }
    }
}
