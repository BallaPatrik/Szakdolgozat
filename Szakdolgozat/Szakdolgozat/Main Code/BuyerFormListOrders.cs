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

namespace Szakdolgozat.Main_Code
{
    public partial class BuyerFormListOrders : Form
    {
        public BuyerFormListOrders()
        {
            InitializeComponent();
            DGV_rendelesek.Columns.Add("Col1", "Azonosító");
            DGV_rendelesek.Columns.Add("Col2", "Dátum");
            DGV_rendelesek.Columns.Add("Col3", "Állapot");
            DGV_rendelesek.Columns.Add("Col4", "Végösszeg");
            

            DGV_rendelesek.Columns[1].ReadOnly = true;
            DGV_rendelesek.Columns[2].ReadOnly = true;
            DGV_rendelesek.Columns[3].ReadOnly = true;
            DGV_rendelesek.Columns[4].ReadOnly = true;

            


        }

        private void BuyerFormListOrders_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void getOrdersFromDatabase()
        {

            Database db = new Database();

            MySqlConnection conn = db.getConnection();

            int felhasznaloid = Transporter.getInstance().CurrentUser.Felhasznaloid;

            try
            {

                conn.Open();

                string sql = "select datum, allapot, bevetel, rendelesid from rendelesek where userid="+felhasznaloid;

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataReader dr = cmd.ExecuteReader();

               

                while (dr.Read())
                {
                    DGV_rendelesek.Rows.Add(0,dr.GetInt32(3),dr.GetString(0), dr.GetString(1), dr.GetInt32(2));
                    
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

        private void BuyerFormListOrders_Load(object sender, EventArgs e)
        {
            getOrdersFromDatabase();
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

                string datumseged= DGV_rendelesek.Rows[e.RowIndex].Cells[2].Value.ToString();

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

        private void DGV_rendelesek_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                int rendelesid = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[1].Value);
                Transporter.getInstance().setOrderId(rendelesid);
                BuyerFormOrderDetails form = new BuyerFormOrderDetails();
                form.ShowDialog();

            }
        }
    }
}
