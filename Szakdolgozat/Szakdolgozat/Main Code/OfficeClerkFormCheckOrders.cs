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
    public partial class OfficeClerkFormCheckOrders : Form
    {
        public OfficeClerkFormCheckOrders()
        {
            InitializeComponent();
            DGV_rendelesek.Columns.Add("Col1", "Azonosító");
            DGV_rendelesek.Columns.Add("Col2", "Dátum");
            DGV_rendelesek.Columns.Add("Col3", "Név");
            DGV_rendelesek.Columns.Add("Col3", "Állapot");
            DGV_rendelesek.Columns.Add("Col4", "Végösszeg");


            DGV_rendelesek.Columns[1].ReadOnly = true;
            DGV_rendelesek.Columns[2].ReadOnly = true;
            DGV_rendelesek.Columns[3].ReadOnly = true;
            DGV_rendelesek.Columns[4].ReadOnly = true;






            //ez alapján tudom beállítani kódban a stílust




            this.BackColor= Color.FromArgb(255, 232, 232);


















        }

        private void OfficeClerkFormCheckOrders_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void getOrdersFromDatabase()
        {
            DGV_rendelesek.Rows.Clear();
            Database db = new Database();

            MySqlConnection conn = db.getConnection();

            int felhasznaloid = Transporter.getInstance().CurrentUser.Felhasznaloid;

            try
            {

                conn.Open();

                string sql = "select datum, nev, allapot, bevetel, rendelesid from rendelesek join felhasznalok on felhasznalok.felhasznaloid = rendelesek.userid where allapot IN ('Elbírálás alatt', 'Kezdeti elbírálás')";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataReader dr = cmd.ExecuteReader();



                while (dr.Read())
                {
                    DGV_rendelesek.Rows.Add(0, 0, dr.GetInt32(4), dr.GetString(0), dr.GetString(1), dr.GetString(2), dr.GetInt32(3));

                }

                DGV_rendelesek.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Bold);

                //oszlop szélességek beállítása
                DGV_rendelesek.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                DGV_rendelesek.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                DGV_rendelesek.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                DGV_rendelesek.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                DGV_rendelesek.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                for (int i = 0; i < DGV_rendelesek.Columns.Count; i++)
                {
                    DGV_rendelesek.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; //fejlécek középre igazítása
                    DGV_rendelesek.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //a többi cella középre igazítása
                }

                DGV_rendelesek.Refresh();

                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Nem sikerült csatlakozni az adatbázishoz!");
            }
        }

        private void OfficeClerkFormCheckOrders_Load(object sender, EventArgs e)
        {
            getOrdersFromDatabase();

            DataGridViewButtonColumn buttonelfogad = new DataGridViewButtonColumn();
            {
                buttonelfogad.Name = "Elfogadás";
                buttonelfogad.HeaderText = "A rendelés elfogadása";
                buttonelfogad.Text = "Elfogadás";
                buttonelfogad.UseColumnTextForButtonValue = true;
                this.DGV_rendelesek.Columns.Add(buttonelfogad);
            }

            DataGridViewButtonColumn buttonelutasit = new DataGridViewButtonColumn();
            {
                buttonelutasit.Name = "Elutasítás";
                buttonelutasit.HeaderText = "A rendelés elutasítása";
                buttonelutasit.Text = "Elutasítás";
                buttonelutasit.UseColumnTextForButtonValue = true;
                this.DGV_rendelesek.Columns.Add(buttonelutasit);
            }
        }


        private void DGV_rendelesek_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Database db = new Database();

            MySqlConnection conn = db.getConnection();

           

            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {

                int felhasznaloid = Transporter.getInstance().CurrentUser.Felhasznaloid;

                int rendelesid = 0;

                conn.Open();

                string datumseged = DGV_rendelesek.Rows[e.RowIndex].Cells[3].Value.ToString();

                string datumstr;

                datumstr = datumseged.Replace(". ", "-");
                StringBuilder sb = new StringBuilder(datumstr);
                sb[10] = ' ';
                datumstr = sb.ToString();

                string sql = "select rendelesid from rendelesek where userid=" + felhasznaloid + " and datum='" + datumstr + "'";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    rendelesid = dr.GetInt32(0);
                }

                conn.Close();
            }
           
        }

        private string getLatestState(int megrendelesid)
        {
            string allapot = "Nem tudom";
            Database db = new Database();

            MySqlConnection conn = db.getConnection();
            string sql = "select datum, allapot from rendelesek WHERE datum IN (SELECT MAX(datum) FROM rendelesek) and rendelesid = " + megrendelesid + " GROUP BY datum ";

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

        private int getProductQuantity(int termekid)
        {
            Database db = new Database();

            MySqlConnection conn = db.getConnection();

            conn.Open();

            int darab = 0;

            string sql = "SELECT osszesdarab FROM termekek WHERE termekid= " + termekid + "";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                darab = dr.GetInt32(0);
            }

            conn.Close();

            return darab;
        }

        private void DGV_rendelesek_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Database db = new Database();

            MySqlConnection conn = db.getConnection();


            var senderGrid = (DataGridView)sender;
            
           

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0 && (e.ColumnIndex == 0 || e.ColumnIndex == 1 || e.ColumnIndex == 7 || e.ColumnIndex == 8) )
            {
                if (e.ColumnIndex == 0)
                {
                    int rendelesid = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[2].Value);
                    Transporter.getInstance().setOrderId(rendelesid);
                    BuyerFormOrderDetails form = new BuyerFormOrderDetails();
                    form.ShowDialog();
                }
                else if(e.ColumnIndex == 1)
                {
                    int rendelesid = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[2].Value);
                    Transporter.getInstance().setOrderId(rendelesid);
                    OfficeClerkFormSendCounterOffer form = new OfficeClerkFormSendCounterOffer();
                    form.ShowDialog();
                }
                else if (e.ColumnIndex == 7)
                {
                    int rendelesid = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[2].Value);
                    //Transporter.getInstance().setOrderId(rendelesid);
                    string allapot = senderGrid.Rows[e.RowIndex].Cells[5].Value.ToString();
                    if(allapot == "Elfogadva" || allapot == "Elutasítva" || getLatestState(rendelesid) == "Nem tudom" || getLatestState(rendelesid) == "Elutasítva" || getLatestState(rendelesid) == "Elfogadva")
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

                        //rendelesid meghatározása

                        //rendeles_termekekbol termekid-k, darabok kivétele rendelesid alapján

                        conn.Open();

                        string sql2 = "SELECT rendeles_termekek.termekid, rendeles_termekek.db, nev FROM rendeles_termekek JOIN termekek ON termekek.termekid=rendeles_termekek.termekid WHERE rendelesid= " + rendelesid + "";

                        MySqlCommand cmd2 = new MySqlCommand(sql2, conn);

                        MySqlDataReader dr2 = cmd2.ExecuteReader();

                        while (dr2.Read())
                        {
                             if(getProductQuantity(dr2.GetInt32(0))< dr2.GetInt32(1))
                            {
                                MessageBox.Show("A " + dr2.GetInt32(2) + " nem áll rendelkezésre elég termék!");
                                return;
                            }
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
                    //Transporter.getInstance().setOrderId(rendelesid);
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
                getOrdersFromDatabase();
            }
           
        }
    }
}
