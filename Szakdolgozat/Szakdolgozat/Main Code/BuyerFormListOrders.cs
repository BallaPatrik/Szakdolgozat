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
    public partial class BuyerFormListOrders : Form
    {
        StyleForms stilus = new StyleForms();

        public BuyerFormListOrders()
        {
            InitializeComponent();
            DGV_rendelesek.Columns.Add("Col1", "Azonosító");
            DGV_rendelesek.Columns.Add("Col2", "Dátum");
            DGV_rendelesek.Columns.Add("Col3", "Név");
            DGV_rendelesek.Columns.Add("Col4", "Állapot");
            DGV_rendelesek.Columns.Add("Col5", "Végösszeg");


            DGV_rendelesek.Columns[2].ReadOnly = true;
            DGV_rendelesek.Columns[3].ReadOnly = true;
            DGV_rendelesek.Columns[4].ReadOnly = true;
            DGV_rendelesek.Columns[5].ReadOnly = true;
            DGV_rendelesek.Columns[6].ReadOnly = true;

            stilus.styleChildForm(this);

            foreach (DataGridViewColumn elem in DGV_rendelesek.Columns)
            {
                elem.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void BuyerFormListOrders_FormClosed(object sender, FormClosedEventArgs e)
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

                string sql = "select datum, nev, allapot, bevetel, rendelesid from rendelesek join felhasznalok on felhasznalok.felhasznaloid = rendelesek.userid where userid=" + felhasznaloid;

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    DGV_rendelesek.Rows.Add(0, 0, dr.GetInt32(4), dr.GetString(0), dr.GetString(1), dr.GetString(2), dr.GetInt32(3));
                }

                DGV_rendelesek.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Bold);

                //oszlop szélességek beállítása
                DGV_rendelesek.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                DGV_rendelesek.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                DGV_rendelesek.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                DGV_rendelesek.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                DGV_rendelesek.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

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

        private void BuyerFormListOrders_Load(object sender, EventArgs e)
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

            if (e.ColumnIndex == 0)
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

                Transporter.getInstance().setOrderId(rendelesid);

                conn.Close();
            }
        }

        private void DGV_rendelesek_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            int rendelesid = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[2].Value);

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0 && (e.ColumnIndex == 0 || e.ColumnIndex == 1 || e.ColumnIndex == 7 || e.ColumnIndex == 8))
            {
                if (e.ColumnIndex == 0)
                {

                    Transporter.getInstance().setOrderId(rendelesid);
                    BuyerFormOrderDetails form = new BuyerFormOrderDetails();
                    form.ShowDialog();
                }
                else if (e.ColumnIndex == 1)
                {
                    string allapot = senderGrid.Rows[e.RowIndex].Cells[5].Value.ToString();
                    if (allapot != "Elbírálás alatt")
                    {
                        MessageBox.Show("A megrendelést ebben az állapotban (már) nem lehet módosítani!");
                        return;
                    }

                    Transporter.getInstance().setOrderId(rendelesid);
                    OfficeClerkFormSendCounterOffer form = new OfficeClerkFormSendCounterOffer();
                    form.ShowDialog();
                }
                else if (e.ColumnIndex == 7)
                {
                    string allapot = senderGrid.Rows[e.RowIndex].Cells[5].Value.ToString();
                    if (allapot == "Elfogadva" || allapot == "Elutasítva" || getLatestState(rendelesid) == "Nem tudom" || getLatestState(rendelesid) == "Elutasítva" || getLatestState(rendelesid) == "Elfogadva")
                    {
                        MessageBox.Show("A megrendelést ebben az állapotban (már) nem lehet módosítani, vagy létezik belőle aktuálisabb változat!");
                    }
                    else
                    {
                        //hozzáadni a balance-hoz az összegüket

                        int vegosszeg = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[6].Value);

                        Balance.getInstance().addBalance(vegosszeg);

                        //ajánlatot megváltoztatjuk elfogadottra

                        Database db = new Database();

                        MySqlConnection conn = db.getConnection();

                        allapot = "Elfogadva";

                        string sql = "UPDATE rendelesek SET allapot='" + allapot + "' WHERE rendelesid=" + rendelesid + " AND datum IN (SELECT MAX(datum) FROM rendelesek WHERE rendelesid=" + rendelesid + ")";

                        conn.Open();

                        MySqlCommand cmd = new MySqlCommand(sql, conn);

                        cmd.ExecuteNonQuery();

                        conn.Close();

                        //megnézni a termékeket darabszámmal együtt
                        //ha van hozzájuk elég termék akkor levonjuk az összesdarabukat

                        conn.Open();

                        Dictionary<int, int> termekidkdarabszamokkal = new Dictionary<int, int>();

                        cmd.CommandText = "SELECT termekid, db FROM rendeles_termekek WHERE rendelesid=" + rendelesid + " AND datum IN (SELECT MAX(datum) FROM rendelesek WHERE rendelesid=" + rendelesid + ")";

                        MySqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            termekidkdarabszamokkal.Add(dr.GetInt32(0), dr.GetInt32(1));
                        }

                        conn.Close();

                        Dictionary<int, int> termekidkosszesdarabszammal = new Dictionary<int, int>();

                        foreach (var elem in termekidkdarabszamokkal)
                        {
                            conn.Open();

                            cmd.CommandText = "SELECT termekid, osszesdarab FROM termekek WHERE termekid=" + elem.Key;

                            dr = cmd.ExecuteReader();

                            while (dr.Read())
                            {
                                termekidkosszesdarabszammal.Add(dr.GetInt32(0), dr.GetInt32(1));
                            }

                            conn.Close();
                        }

                        List<int> termekidkosszesdarabszammalkivonvaegymasbol = new List<int>();

                        foreach (var elem in termekidkdarabszamokkal)
                        {
                            if (termekidkosszesdarabszammal.ContainsKey(elem.Key))
                            {
                                termekidkosszesdarabszammalkivonvaegymasbol.Add(termekidkosszesdarabszammal[elem.Key] - elem.Value);
                            }
                        }

                        bool nincselegtermek = false;

                        foreach (var elem in termekidkosszesdarabszammalkivonvaegymasbol)
                        {
                            if (elem <= 0)
                            {
                                nincselegtermek = true;
                            }
                        }

                        if (nincselegtermek)
                        {
                            MessageBox.Show("Nincs elég termék a rendelés teljesítéséhez!");
                            return;
                        }
                        foreach (var elem in termekidkdarabszamokkal)
                        {
                            conn.Open();

                            cmd.CommandText = "UPDATE termekek SET osszesdarab=osszesdarab-" + elem.Value + " WHERE termekid=" + elem.Key;

                            cmd.ExecuteNonQuery();

                            conn.Close();
                        }

                        getOrdersFromDatabase();
                    }
                }
                else if (e.ColumnIndex == 8)
                {
                    string allapot = senderGrid.Rows[e.RowIndex].Cells[5].Value.ToString();
                    if (allapot == "Elfogadva" || allapot == "Elutasítva" || getLatestState(rendelesid) == "Nem tudom" || getLatestState(rendelesid) == "Elutasítva" || getLatestState(rendelesid) == "Elfogadva")
                    {
                        MessageBox.Show("A megrendelést ebben az állapotban (már) nem lehet módosítani, vagy létezik belőle aktuálisabb változat!");
                    }
                    else
                    {
                        Database db = new Database();

                        MySqlConnection conn = db.getConnection();

                        allapot = "Elutasítva";

                        string sql = "UPDATE rendelesek SET allapot='" + allapot + "' WHERE rendelesid=" + rendelesid + " AND datum IN (SELECT MAX(datum) FROM rendelesek WHERE rendelesid=" + rendelesid + ")";

                        conn.Open();

                        MySqlCommand cmd = new MySqlCommand(sql, conn);

                        cmd.ExecuteNonQuery();

                        conn.Close();

                        getOrdersFromDatabase();
                    }
                }
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
    }
}
