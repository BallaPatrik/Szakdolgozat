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
    public partial class SupplierFormSendCounterOffer : Form
    {
        StyleForms stilus = new StyleForms();

        public SupplierFormSendCounterOffer()
        {
            InitializeComponent();

            DGV_ajanlatok.Columns.Add("Col1", "Nev");
            DGV_ajanlatok.Columns.Add("Col2", "Darabszam");
            DGV_ajanlatok.Columns.Add("Col3", "Datum");
            DGV_ajanlatok.Columns.Add("Col4", "Reszosszeg");

            DGV_ajanlatok.Columns[0].ReadOnly = true;
            DGV_ajanlatok.Columns[1].ReadOnly = true;
            DGV_ajanlatok.Columns[2].ReadOnly = true;
            DGV_ajanlatok.Columns[3].ReadOnly = false;


            DGV_ajanlatok.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Bold);

            //oszlop szélességek beállítása
            DGV_ajanlatok.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DGV_ajanlatok.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DGV_ajanlatok.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DGV_ajanlatok.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < DGV_ajanlatok.Columns.Count; i++)
            {
                DGV_ajanlatok.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; //fejlécek középre igazítása
                DGV_ajanlatok.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //a többi cella középre igazítása
            }

            getOfferDetails();

            stilus.styleChildForm(this);

            foreach (DataGridViewColumn elem in DGV_ajanlatok.Columns)
            {
                elem.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            foreach (Button button in this.Controls.OfType<Button>())
            {
                stilus.styleButton(button);
            }

        }
        private void getOfferDetails()
        {
            DGV_ajanlatok.Rows.Clear();
            Database db = new Database();

            MySqlConnection conn = db.getConnection();

            conn.Open();

            string sql = "SELECT DISTINCT alkatreszek.nev, ajanlat_alkatreszek.darabszam, ajanlat_alkatreszek.datum, ajanlat_alkatreszek.ar FROM ajanlat_alkatreszek JOIN alkatreszek ON ajanlat_alkatreszek.alkatreszid = alkatreszek.alkatreszid WHERE ajanlat_alkatreszek.ajanlatid=" + Transporter.getInstance().getOfferID() + " AND datum IN (SELECT MAX(datum) FROM ajanlat_alkatreszek ar2) AND datum is not null GROUP BY alkatreszek.nev ORDER BY datum DESC;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                DGV_ajanlatok.Rows.Add(dr.GetString(0), dr.GetInt32(1), dr.GetDateTime(2).ToString(), dr.GetInt32(3));
            }

            conn.Close();

            DGV_ajanlatok.Refresh();

            int vegosszeg = 0;

            foreach (DataGridViewRow elem in DGV_ajanlatok.Rows)
            {
                if (elem != null)
                {
                    vegosszeg += Convert.ToInt32(elem.Cells[3].Value);
                }
            }
        }

        private void BT_ellenajanlat_kuldese_Click(object sender, EventArgs e)
        {
            //Ajánlat adatainak lekérése Selecttel
            int ajanlatid = Transporter.getInstance().getOfferID();

            Database db = new Database();

            MySqlConnection conn = db.getConnection();

            conn.Open();

            string allapot = "";

            int bevetel = 0;

            int beszallitoid = 0;

            int logid = 0;

            string sql = "SELECT allapot, vegosszeg, beszallitoid, logid FROM ajanlat WHERE ajanlatid=" + ajanlatid;

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                allapot = dr.GetString(0);
                bevetel = dr.GetInt32(1);
                beszallitoid = dr.GetInt32(2);
                logid = dr.GetInt32(3);
            }

            conn.Close();
            conn.Open();
            sql = "UPDATE ajanlat SET allapot = 'Elbírálva' WHERE logid=" + logid;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            conn.Close();

            //Új rendelés állapot beszúrása új bevétel értékkel

            int vegosszeg = 0;

            foreach (DataGridViewRow elem in DGV_ajanlatok.Rows)
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

            string sql2 = "INSERT INTO ajanlat(ajanlatid, beszallitoid, datum, allapot, vegosszeg) VALUES (" + ajanlatid + ", " + beszallitoid + ", '" + datum.ToString(format) + "', 'Elbírálás alatt', " + vegosszeg + ")";

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

            foreach (DataGridViewRow elem in DGV_ajanlatok.Rows)
            {

                if (elem != null)
                {
                    conn.Open();
                    int alkatreszid = 0;

                    if (elem.Cells[0].Value != null)
                    {
                        string sql3 = "SELECT alkatreszid FROM alkatreszek WHERE nev='" + elem.Cells[0].Value.ToString() + "'";

                        MySqlCommand cmd3 = new MySqlCommand(sql3, conn);

                        MySqlDataReader dr3 = cmd3.ExecuteReader();

                        while (dr3.Read())
                        {
                            alkatreszid = dr3.GetInt32(0);
                        }
                        conn.Close();
                        conn.Open();
                        
                        string sql4 = "INSERT INTO ajanlat_alkatreszek(ajanlatid, alkatreszid, ar, darabszam, datum) VALUES (" + ajanlatid + ", " + alkatreszid + ", " + elem.Cells[3].Value.ToString() + ", " + elem.Cells[1].Value.ToString() + ", '" + datum.ToString(format) + "')";

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
            getOfferDetails();
        }
    }
}
