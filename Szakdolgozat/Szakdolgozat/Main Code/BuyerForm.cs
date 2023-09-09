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
    public partial class BuyerForm : Form
    {
        public BuyerForm()
        {
            InitializeComponent();
        }

        private void kilépésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm form = new LoginForm();
            form.Show();
            this.Hide();
        }

        private void BuyerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void getProductsFromDatabase()
        {

            Database db = new Database();

            MySqlConnection conn = db.getConnection();

            conn.Open();

            string sql = "select nev from termekek";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            MySqlDataReader dr = cmd.ExecuteReader();

            DGV_termekek.Columns.Add("Col2", "Termek");
            DGV_termekek.Columns.Add("Col3", "Darab");
            DGV_termekek.Columns.Add("Col3", "Arajanlat (Ft-ban)");

            while (dr.Read())
            {
                DGV_termekek.Rows.Add(dr.GetString(0), 0, 0);
            }

            DGV_termekek.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Bold);

            //oszlop szélességek beállítása
            DGV_termekek.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DGV_termekek.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DGV_termekek.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < DGV_termekek.Columns.Count; i++)
            {
                DGV_termekek.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; //fejlécek középre igazítása
                DGV_termekek.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //a többi cella középre igazítása
            }

            conn.Close();
        }


        private void BuyerForm_Load(object sender, EventArgs e)
        {
            getProductsFromDatabase();
        }

        private void Megrendelés_Click(object sender, EventArgs e)
        {

            Database db = new Database();

            MySqlConnection conn = db.getConnection();

            MySqlCommand cmd;

            conn.Open();

            int rendelesid;
            int userid = Transporter.getInstance().CurrentUser.Felhasznaloid;
            string datum;
            string allapot = "Elküldve";
            int bevetel = 0;

            DateTime time = DateTime.Now;

            MessageBox.Show(time.ToString());

            /*

            string format = "yyyy. MM. dd";

            string sql = "delete from gyartas where datum='" + datum + "' and db=" + darabszam + " and termekid = (SELECT termekid FROM termekek WHERE nev = '" + termek + "')";

            if (dr.GetString(1).Contains(time.ToString(format)) == true)

            */

                

            //MySqlCommand cmd = new MySqlCommand(sql, conn);
        }
    }
}
