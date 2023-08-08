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

namespace Szakdolgozat
{
    public partial class OperatorFormListDailyProducts : Form
    {
        public OperatorFormListDailyProducts()
        {
            InitializeComponent();
        }

        private void kilépésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm form = new LoginForm();
            form.Show();
            this.Hide();
        }

        private void OperatorFormListDailyProducts_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void legyártottTermékekFelviteleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperatorForm form = new OperatorForm();
            form.Show();
            this.Hide();
        }

        private void selectDailyProductsFromDatabase()
        {
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

            DGV_products.Columns.Add("Col2", "Termek");
            DGV_products.Columns.Add("Col3", "Datum");
            DGV_products.Columns.Add("Col4", "Darabszam");

            while (dr.Read())
            {

                if (dr.GetString(1).Contains(time.ToString(format))==true)
                {
                    
                    DGV_products.Rows.Add("",dr.GetString(0), dr.GetString(1), dr.GetInt32(2));
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

        private void maFelvittTermékekListázásaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void DGV_products_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0 && DGV_products.Rows[e.RowIndex].Cells[1].Value != null)
            {
                string termek = DGV_products.Rows[e.RowIndex].Cells[1].Value.ToString();
                string datum = DGV_products.Rows[e.RowIndex].Cells[2].Value.ToString();
                datum = datum.Replace(". ", "-");
                int darabszam = Convert.ToInt32(DGV_products.Rows[e.RowIndex].Cells[3].Value.ToString());

                //MessageBox.Show("Termék: " + termek + " dátum: " + datum + " darabszám: " + darabszam);


                Database db = new Database();

                MySqlConnection conn = db.getConnection();

                conn.Open();

                string sql = "delete from gyartas where datum='" + datum + "' and db=" + darabszam + " and termekid = (SELECT termekid FROM termekek WHERE nev = '" + termek + "')";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                try
                {

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Termek torlese sikeres!");
                    DGV_products.Rows.RemoveAt(e.RowIndex);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Torles nem sikerult! Indoka: " + ex.Message);
                }

                conn.Close();
            }

            

        }
    }
}
