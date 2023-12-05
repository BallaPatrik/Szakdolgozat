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
            DGV_ajanlatok.Columns[5].ReadOnly = true;
            DGV_ajanlatok.Columns[6].ReadOnly = true;

            stilus.styleChildForm(this);


            foreach (DataGridViewColumn elem in DGV_ajanlatok.Columns)
            {
                elem.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            foreach (Button button in this.Controls.OfType<Button>())
            {
                stilus.styleButton(button);
            }

            comboBox1.SelectedIndex = 0;

            getOffersFromDatabase("Minden");
        }

        private void getOffersFromDatabase(string feltetel)
        {
            DGV_ajanlatok.Rows.Clear();
            Database db = new Database();

            MySqlConnection conn = db.getConnection();

            int felhasznaloid = Transporter.getInstance().CurrentUser.Felhasznaloid;

            try
            {
                conn.Open();

                string sql;

                if (feltetel == "Minden")
                {
                    sql = "select datum, cegnev, allapot, vegosszeg, ajanlatid from ajanlat join beszallitok on ajanlat.beszallitoid = beszallitok.beszallitoid";
                }
                else
                {
                    sql = "select datum, cegnev, allapot, vegosszeg, ajanlatid from ajanlat join beszallitok on ajanlat.beszallitoid = beszallitok.beszallitoid where allapot='" + feltetel + "'";
                }

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
                DGV_ajanlatok.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                DGV_ajanlatok.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

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
                //MessageBox.Show("Nem sikerült csatlakozni az adatbázishoz!");
                MessageBox.Show(ex.Message);
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
                    Transporter.getInstance().setOfferId(ajanlatid);
                    SupplierOfferDetails form = new SupplierOfferDetails();
                    form.ShowDialog();
                }
                else if (e.ColumnIndex == 1)
                {
                    int ajanlatid = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[2].Value);
                    string allapot = senderGrid.Rows[e.RowIndex].Cells[5].Value.ToString();

                    if (allapot == "Elfogadva" || allapot == "Elutasítva" || allapot == "Elbírálva" || getLatestState(ajanlatid) == "Nem tudom" || getLatestState(ajanlatid) == "Elutasítva" || getLatestState(ajanlatid) == "Elfogadva" || getLatestState(ajanlatid) == "Elbírálva")
                    {
                        MessageBox.Show("A megrendelést ebben az állapotban (már) nem lehet módosítani, vagy létezik belőle aktuálisabb változat!");
                        return;
                    }
                    
                    Transporter.getInstance().setOfferId(ajanlatid);
                    SupplierFormSendCounterOffer form = new SupplierFormSendCounterOffer();
                    form.ShowDialog();
                }
                else if (e.ColumnIndex == 7)
                {
                    int ajanlatid = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[2].Value);

                    string allapot = senderGrid.Rows[e.RowIndex].Cells[5].Value.ToString();

                    if (allapot == "Elfogadva" || allapot == "Elutasítva" || allapot == "Elbírálva" || getLatestState(ajanlatid) == "Nem tudom" || getLatestState(ajanlatid) == "Elutasítva" || getLatestState(ajanlatid) == "Elfogadva" || getLatestState(ajanlatid) == "Elbírálva")
                    {
                        MessageBox.Show("A megrendelést ebben az állapotban (már) nem lehet módosítani, vagy létezik belőle aktuálisabb változat!");
                    }

                    else
                    {
                        //EZ AZ ELFOGADÁS

                        //levonni a balance-ból az összegüket

                        int vegosszeg = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[6].Value);

                        if (vegosszeg > Balance.getInstance().getCurrentBalance())
                        {
                            MessageBox.Show("Hiba! Nincs elég pénz az alkatészek megvásárolásához!");
                            return;
                        }
                        else
                        {
                            Balance.getInstance().subtractBalance(vegosszeg);

                            //ajánlatot megváltoztatjuk elfogadottra

                            allapot = "Elfogadva";

                            string sql = "UPDATE ajanlat SET allapot='"+allapot+"' WHERE ajanlatid="+ajanlatid;

                            conn.Open();

                            MySqlCommand cmd = new MySqlCommand(sql, conn);

                            cmd.ExecuteNonQuery();

                            conn.Close();

                            //hozzáadni az alkatrésszámokat amiket megvásároltunk

                            conn.Open();

                            Dictionary<int, int> alkatreszidkdarabszammal = new Dictionary<int, int>();

                            cmd.CommandText = "SELECT alkatreszid, darabszam FROM ajanlat_alkatreszek WHERE ajanlatid=" + ajanlatid;

                            MySqlDataReader dr = cmd.ExecuteReader();

                            while (dr.Read())
                            {
                                alkatreszidkdarabszammal.Add(dr.GetInt32(0), dr.GetInt32(1));
                            }

                            conn.Close();

                            foreach (var elem in alkatreszidkdarabszammal)
                            {
                                conn.Open();

                                cmd.CommandText = "UPDATE alkatreszek SET osszesdarab=osszesdarab+" + elem.Value + " WHERE alkatreszid=" + elem.Key;

                                cmd.ExecuteNonQuery();

                                conn.Close();

                            }

                            MessageBox.Show("Ajánlat sikeresen elfogadva!");

                            getOffersFromDatabase("Minden");
                        }
                    }
                }
                else if (e.ColumnIndex == 8)
                {
                    int ajanlatid = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[2].Value);

                    string allapot = senderGrid.Rows[e.RowIndex].Cells[5].Value.ToString();

                    if (allapot == "Elfogadva" || allapot == "Elutasítva" || allapot == "Elbírálva" || getLatestState(ajanlatid) == "Nem tudom" || getLatestState(ajanlatid) == "Elutasítva" || getLatestState(ajanlatid) == "Elfogadva" || getLatestState(ajanlatid) == "Elbírálva")
                    {
                        MessageBox.Show("A megrendelést ebben az állapotban (már) nem lehet módosítani, vagy létezik belőle aktuálisabb változat!");
                    }
                    else
                    {
                        //elutasításnál meg nem történik semmi csak az ajánlatot változtatjuk meg elutasítvára

                        allapot = "Elutasítva";

                        string sql = "UPDATE ajanlat SET allapot='" + allapot + "' WHERE ajanlatid=" + ajanlatid;

                        conn.Open();

                        MySqlCommand cmd = new MySqlCommand(sql, conn);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Ajánlat elutasítva!");

                        conn.Close();
                    }
                }
                getOffersFromDatabase("Minden");
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            getOffersFromDatabase(comboBox1.SelectedItem.ToString());
        }
    }
}
