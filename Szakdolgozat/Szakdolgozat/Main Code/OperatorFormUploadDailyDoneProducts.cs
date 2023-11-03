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
using System.Globalization;

namespace Szakdolgozat
{
    public partial class OperatorFormUploadDailyDoneProducts : Form
    {
        public OperatorFormUploadDailyDoneProducts()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getProductsFromDatabase();
        }

        private void getProductsFromDatabase()
        {

            Database db = new Database();

            MySqlConnection conn = db.getConnection();

            conn.Open();

            string sql = "select nev from termekek";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                LB_termekek.Items.Add(dr.GetString(0));
            }

            conn.Close();
        }

        private void kilépésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm form = new LoginForm();
            form.Show();
            this.Hide();
        }

        private void OperatorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void legyártottTermékekFelviteleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void LB_termekek_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BT_termekfelvitele_Click(object sender, EventArgs e)
        {
            string termek = LB_termekek.SelectedItem.ToString();
            int darabszam = Convert.ToInt32(TB_darabszam.Text);


            Database db = new Database();

            MySqlConnection conn = db.getConnection();

            conn.Open();

            string sql = "select termekid from termekek where nev='" + termek + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            MySqlDataReader dr = cmd.ExecuteReader();

            int termekid = 0;

            while (dr.Read())
            {
                termekid = dr.GetInt32(0);
            }

            conn.Close();


            conn.Open();

            DateTime time = DateTime.Now;

            string format = "yyyy-MM-dd HH:mm:ss";

            string sql2 = "insert into gyartas(termekid, datum, db) values(" + termekid + ", '" + time.ToString(format) + "' , " + darabszam + ");";
            MySqlCommand cmd2 = new MySqlCommand(sql2, conn);

            try
            {

                cmd2.ExecuteNonQuery();
                MessageBox.Show("Termek felvitele sikeres!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Beszuras nem sikerult! Indoka: " + ex.Message);
            }

            conn.Close();

        }

        private void maFelvittTermékekListázásaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperatorFormListDailyProducts form = new OperatorFormListDailyProducts();
            form.Show();
            this.Hide();
        }
    }
}
