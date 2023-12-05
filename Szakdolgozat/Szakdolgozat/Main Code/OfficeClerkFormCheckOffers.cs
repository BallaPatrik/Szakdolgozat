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
    public partial class OfficeClerkFormCheckOffers : Form
    {
        StyleForms stilus = new StyleForms();

        public OfficeClerkFormCheckOffers()
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

            comboBox1.SelectedIndex = 0;
        }

        private void OfficeClerkFormCheckOffers_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void getOrdersFromDatabase(string feltetel)
        {
            DGV_ajanlatok.Rows.Clear();
            Database db = new Database();

            MySqlConnection conn = db.getConnection();

            //int felhasznaloid = Transporter.getInstance().CurrentUser.Felhasznaloid;

            try
            {
                conn.Open();

                string sql;

                if (feltetel == "Minden")
                {
                    sql = "select ajanlatid, cegnev, allapot, datum, vegosszeg from ajanlat join beszallitok on beszallitok.beszallitoid = ajanlat.beszallitoid";
                }
                else
                {
                    sql = "select ajanlatid, cegnev, allapot, datum, vegosszeg from ajanlat join beszallitok on beszallitok.beszallitoid = ajanlat.beszallitoid where allapot='" + feltetel + "'";
                }

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    DGV_ajanlatok.Rows.Add(0, 0, dr.GetInt32(0), dr.GetString(3), dr.GetString(1), dr.GetString(2), dr.GetInt32(4));

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

        private void OfficeClerkFormCheckOffers_Load(object sender, EventArgs e)
        {
            getOrdersFromDatabase("Minden");

            DataGridViewButtonColumn buttonelfogad = new DataGridViewButtonColumn();
            {
                buttonelfogad.Name = "Elfogadás";
                buttonelfogad.HeaderText = "Az ajánlat elfogadása";
                buttonelfogad.Text = "Elfogadás";
                buttonelfogad.UseColumnTextForButtonValue = true;
                this.DGV_ajanlatok.Columns.Add(buttonelfogad);
            }

            DataGridViewButtonColumn buttonelutasit = new DataGridViewButtonColumn();
            {
                buttonelutasit.Name = "Elutasítás";
                buttonelutasit.HeaderText = "Az ajánlat elutasítása";
                buttonelutasit.Text = "Elutasítás";
                buttonelutasit.UseColumnTextForButtonValue = true;
                this.DGV_ajanlatok.Columns.Add(buttonelutasit);
            }
        }

        private void DGV_ajanlatok_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Database db = new Database();

            MySqlConnection conn = db.getConnection();

            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {
                conn.Open();
                string beszallitonev = DGV_ajanlatok.Rows[e.RowIndex].Cells[4].Value.ToString();

                int beszallitoid = 0;

                string sql;

                sql = "select beszallitoid from beszallitok where cegnev='" + beszallitonev + "'";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    beszallitoid = dr.GetInt32(0);
                }

                int ajanlatid = 0;
                conn.Close();
                conn.Open();

                string datumseged = DGV_ajanlatok.Rows[e.RowIndex].Cells[3].Value.ToString();

                string datumstr;

                datumstr = datumseged.Replace(". ", "-");
                StringBuilder sb = new StringBuilder(datumstr);
                sb[10] = ' ';
                datumstr = sb.ToString();

                sql = "select ajanlatid from ajanlat where beszallitoid=" + beszallitoid + " and datum='" + datumstr + "'";

                cmd = new MySqlCommand(sql, conn);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ajanlatid = dr.GetInt32(0);
                }

                //a következő sor remélem jó

                Transporter.getInstance().setOfferId(ajanlatid);

                conn.Close();
            }
        }
        private string getLatestState(int ajanlatid)
        {
            string allapot = "Nem tudom";
            Database db = new Database();

            MySqlConnection conn = db.getConnection();
            string sql = "select MAX(datum), allapot from ajanlat WHERE ajanlatid = " + ajanlatid + " GROUP BY datum ";

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

        private int getPartQuantity(int alkatreszid)
        {
            Database db = new Database();

            MySqlConnection conn = db.getConnection();

            conn.Open();

            int darab = 0;

            string sql = "SELECT osszesdarab FROM alkatreszek WHERE alkatreszid= " + alkatreszid + "";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                darab = dr.GetInt32(0);
            }

            conn.Close();

            return darab;
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
                    int ajanlatid = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[2].Value);
                    Transporter.getInstance().setOrderId(ajanlatid);;
                    SupplierOfferDetails form = new SupplierOfferDetails();
                    form.ShowDialog();
                    
                }
                else if (e.ColumnIndex == 1)
                {
                    int ajanlatid = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[2].Value);
                    string allapot = senderGrid.Rows[e.RowIndex].Cells[5].Value.ToString();

                    if (allapot == "Elfogadva" || allapot == "Elutasítva" || allapot == "Elbírálva" || getLatestState(ajanlatid) == "Nem tudom" || getLatestState(ajanlatid) == "Elutasítva" || getLatestState(ajanlatid) == "Elfogadva"|| getLatestState(ajanlatid) == "Elbírálva")
                    {
                        MessageBox.Show("A megrendelést ebben az állapotban (már) nem lehet módosítani, vagy létezik belőle aktuálisabb változat!");
                        return;
                    }

                    Transporter.getInstance().setOrderId(ajanlatid);
                    SupplierFormSendCounterOffer form = new SupplierFormSendCounterOffer();
                    form.ShowDialog();
                }
                else if (e.ColumnIndex == 7)
                {
                    int ajanlatid = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[2].Value);

                    string allapot = senderGrid.Rows[e.RowIndex].Cells[5].Value.ToString();
                    if (allapot == "Elfogadva" || allapot == "Elutasítva" || getLatestState(ajanlatid) == "Nem tudom" || getLatestState(ajanlatid) == "Elutasítva" || getLatestState(ajanlatid) == "Elfogadva")
                    {
                        MessageBox.Show("A megrendelést ebben az állapotban (már) nem lehet módosítani, vagy létezik belőle aktuálisabb változat!");
                    }
                    else
                    {
                        conn.Open();
                        DateTime datum = DateTime.Now;
                        string format = "yyyy-MM-dd HH:mm:ss";
                        allapot = "Elfogadva";
                        string sql = "select beszallitoid from beszallitok where cegnev='" + senderGrid.Rows[e.RowIndex].Cells[4].Value.ToString() + "'";
                        int beszallitoid = 0;
                        MySqlCommand cmd = new MySqlCommand(sql, conn);

                        MySqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            beszallitoid = dr.GetInt32(0);
                        }
                        conn.Close();


                        if (Balance.getInstance().getCurrentBalance() <= Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[6].Value))
                        {
                            MessageBox.Show("Nincs elég pénz a vásárláshoz!");
                            return;
                        }


                        conn.Open();

                        string sql2 = "SELECT alkatreszek.alkatreszid, ajanlat_alkatreszek.darabszam FROM ajanlat_alkatreszek JOIN alkatreszek ON ajanlat_alkatreszek.alkatreszid=alkatreszek.alkatreszid WHERE ajanlat_alkatreszek.ajanlatid= " + ajanlatid + "";

                        MySqlCommand cmd2 = new MySqlCommand(sql2, conn);

                        MySqlDataReader dr2 = cmd2.ExecuteReader();

                        Dictionary<int, int> alkatreszidkdarabszammal = new Dictionary<int, int>();

                        while (dr2.Read())
                        {
                            alkatreszidkdarabszammal.Add(dr2.GetInt32(0), dr2.GetInt32(1));
                        }
                        conn.Close();

                        foreach (var elem in alkatreszidkdarabszammal)
                        {
                            conn.Open();

                            sql2 = "UPDATE alkatreszek SET osszesdarab = osszesdarab + " + elem.Value + " WHERE alkatreszid = " + elem.Key;

                            cmd2.CommandText = sql2;
                            cmd2.ExecuteNonQuery();

                            conn.Close();
                        }

                        Balance.getInstance().subtractBalance(Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[6].Value));
                        conn.Open();
                        sql2 = "UPDATE ajanlat SET allapot = 'Elfogadva' WHERE ajanlatid = " + ajanlatid + " AND datum IN (SELECT MAX(datum) FROM ajanlat WHERE ajanlatid = " + ajanlatid + ")";
                        cmd2.CommandText = sql2;
                        cmd2.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("Ajánlat elfogadva!");

                    }
                }
                else if (e.ColumnIndex == 8)
                {
                    int ajanlatid = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[2].Value);

                    string allapot = senderGrid.Rows[e.RowIndex].Cells[5].Value.ToString();
                    string sql2 = "UPDATE ajanlat SET allapot = 'Elutasítva' WHERE ajanlatid = " + ajanlatid + " AND datum IN (SELECT MAX(datum) FROM ajanlat WHERE ajanlatid = " + ajanlatid + ")";

                    MySqlCommand cmd2 = new MySqlCommand(sql2, conn);


                    if (allapot == "Elfogadva" || allapot == "Elutasítva" || getLatestState(ajanlatid) == "Nem tudom" || getLatestState(ajanlatid) == "Elutasítva" || getLatestState(ajanlatid) == "Elfogadva")
                    {
                        MessageBox.Show("A megrendelést ebben az állapotban (már) nem lehet módosítani, vagy létezik belőle aktuálisabb változat!");
                    }
                    else
                    {
                        conn.Open();
                        cmd2.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("Ajánlat elutasítva!");
                    }
                }
                getOrdersFromDatabase("Minden");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            getOrdersFromDatabase(comboBox1.SelectedItem.ToString());
        }
    }
}
