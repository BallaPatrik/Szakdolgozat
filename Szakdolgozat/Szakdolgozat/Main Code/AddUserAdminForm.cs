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

namespace Szakdolgozat.Main_Code
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        

        

        private void loadRoles()
        {
            Database db = new Database();

            var conn = db.getConnection();

            conn.Open();

            var sql = "select szerepkor from szerepkorok";
            var cmd = new MySqlCommand(sql, conn);

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                LB_szerepkorok.Items.Add(dr.GetString(0));
            }

            conn.Close();
        }

        private void BT_felhasznalofelvitel_Click(object sender, EventArgs e)
        {
            string nev = TB_nev.Text;
            string jelszo = TB_jelszo.Text;
            string szerepkor = LB_szerepkorok.SelectedItem.ToString();

            Database db = new Database();

            MySqlConnection conn = db.getConnection();

            conn.Open();

            string sql = "select szerepkorid from szerepkorok where szerepkor='" + szerepkor + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            MySqlDataReader dr = cmd.ExecuteReader();

            int szerepkorid = 0;

            while (dr.Read())
            {
                szerepkorid = dr.GetInt32(0);
            }

            conn.Close();


            conn.Open();

            string sql2 = "insert into felhasznalok(nev, jelszo, szerepkorid) values('" + nev + "', '" + jelszo + "' , " + szerepkorid + ");";
            MySqlCommand cmd2 = new MySqlCommand(sql2, conn);

            try
            {

                cmd2.ExecuteNonQuery();
                MessageBox.Show("Felhasznalo felvitele sikeres!");

            }catch(Exception ex)
            {
                MessageBox.Show("Beszuras nem sikerult! Indoka: " + ex.Message);
            }

            conn.Close();


        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            loadRoles();
        }

        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void kilépésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm form = new LoginForm();
            form.Show();
            this.Hide();
        }
    }
}
