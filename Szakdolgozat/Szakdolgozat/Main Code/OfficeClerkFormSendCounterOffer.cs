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
    public partial class OfficeClerkFormSendCounterOffer : Form
    {
        StyleForms stilus = new StyleForms();

        public OfficeClerkFormSendCounterOffer()
        {
            InitializeComponent();
            DGV_termekek.Columns.Add("Col1", "Nev");
            DGV_termekek.Columns.Add("Col2", "Darabszam");
            DGV_termekek.Columns.Add("Col3", "Datum");
            DGV_termekek.Columns.Add("Col4", "Reszosszeg");

            DGV_termekek.Columns[0].ReadOnly = true;
            DGV_termekek.Columns[1].ReadOnly = true;
            DGV_termekek.Columns[2].ReadOnly = true;
            DGV_termekek.Columns[3].ReadOnly = false;


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

            getOrderDetails();

            stilus.styleChildForm(this);

            foreach (DataGridViewColumn elem in DGV_termekek.Columns)
            {
                elem.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }


        private void getOrderDetails()
        {
            Database db = new Database();

            MySqlConnection conn = db.getConnection();
            //SELECT t.nev, db, aktualis, datum, reszosszeg FROM rendeles_termekek rt JOIN termekek t ON rt.termekid = t.termekid WHERE rt.rendelesid = + rendelesid
            conn.Open();
            string sql = "SELECT t.nev, db, MAX(datum), reszosszeg FROM rendeles_termekek rt JOIN termekek t ON rt.termekid = t.termekid WHERE rt.rendelesid = " + Transporter.getInstance().getOrderID();

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            MySqlDataReader dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                DGV_termekek.Rows.Add(dr.GetString(0), dr.GetInt32(1), dr.GetDateTime(2).ToString(), dr.GetInt32(3));
            }

            conn.Close();

            DGV_termekek.Refresh();


            int vegosszeg = 0;

            foreach (DataGridViewRow elem in DGV_termekek.Rows)
            {
                if (elem != null)
                {
                    vegosszeg += Convert.ToInt32(elem.Cells[3].Value);
                    
                }
            }

        }

        private void BT_ellenajanlat_kuldese_Click_1(object sender, EventArgs e)
        {
            //Rendelés adatainak lekérése Selecttel
            int rendelesid = Transporter.getInstance().getOrderID();

            Database db = new Database();

            MySqlConnection conn = db.getConnection();
            
            conn.Open();

            string allapot = "";

            int bevetel = 0;

            int userid = 0;
            int logid = 0;
            string sql = "SELECT allapot, bevetel, userid, logid FROM rendelesek WHERE rendelesid=" + rendelesid;

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                allapot = dr.GetString(0);
                bevetel = dr.GetInt32(1);
                userid = dr.GetInt32(2);
                logid = dr.GetInt32(3);
            }

            conn.Close();
            conn.Open();
            sql = "UPDATE rendelesek SET allapot = 'Elbírálva' WHERE logid=" + logid;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            conn.Close();

            //Új rendelés állapot beszúrása új bevétel értékkel


            int vegosszeg = 0;

            foreach (DataGridViewRow elem in DGV_termekek.Rows)
            {
                if (elem != null)
                {
                    vegosszeg += Convert.ToInt32(elem.Cells[3].Value);

                }
            }

            if (vegosszeg == bevetel)
            {
                MessageBox.Show("Nem változott az ajánlat értéke!");
                return;
            }

            conn.Open();

            DateTime datum = DateTime.Now;

            string format = "yyyy-MM-dd HH:mm:ss";

            string sql2 = "INSERT INTO rendelesek(rendelesid, userid, datum, allapot, bevetel) VALUES (" + rendelesid + ", " + userid + ", '" + datum.ToString(format) + "', 'Elbírálás alatt', " + bevetel + ")";


            MySqlCommand cmd2 = new MySqlCommand(sql2, conn);

            try
            {
               cmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beszúrás nem sikerült! Indoka: " + ex.Message);
            }

            conn.Close();
            

            //Rendelés tételeinek beszúrása egyenként

            foreach (DataGridViewRow elem in DGV_termekek.Rows)
            {
               
                if (elem != null)
                {
                    conn.Open();
                    int termekid = 0;

                    if (elem.Cells[0].Value != null) { 
                    string sql3 = "SELECT termekid FROM termekek WHERE nev='" + elem.Cells[0].Value.ToString() + "'";

                    MySqlCommand cmd3 = new MySqlCommand(sql3, conn);

                    MySqlDataReader dr3 = cmd3.ExecuteReader();

                    while (dr3.Read())
                    {
                        termekid = dr3.GetInt32(0);
                    }
                    conn.Close();
                    conn.Open();
                    string sql4 = "INSERT INTO rendeles_termekek(rendelesid, termekid, db, datum, reszosszeg) VALUES (" + rendelesid + ", " + termekid + ", " + elem.Cells[1].Value.ToString() + ",'" + datum.ToString(format) + "', " + elem.Cells[3].Value.ToString() + ")";

                    MySqlCommand cmd4 = new MySqlCommand(sql4, conn);

                    try
                    {
                        cmd4.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Beszúrás nem sikerült! Indoka: " + ex.Message);
                        
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                
            }

            
            }
            MessageBox.Show("Sikeres ellenajánlat elkészítve!");



        }
    }
}
