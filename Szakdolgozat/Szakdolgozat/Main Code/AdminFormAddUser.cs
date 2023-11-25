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
using Szakdolgozat.Model;

namespace Szakdolgozat.Main_Code
{
    public partial class AdminFormAddUser : Form
    {
        StyleForms stilus = new StyleForms();
        public AdminFormAddUser()
        {
            InitializeComponent();

            foreach(Button button in this.Controls.OfType<Button>())
            {
                stilus.styleButton(button);
            }
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
            //ki vannak-e töltve a textboxok
            if(TB_jelszo.Text=="" || TB_nev.Text == "")
            {
                MessageBox.Show("Kérem töltse ki a beviteli mezőket!");
                return;
            }
            //ki lett a választva szerepkör
            if (LB_szerepkorok.SelectedItem == null)
            {
                MessageBox.Show("Kérem válasszon ki szerepkört!");
                return;
            }

            string nev = TB_nev.Text;
            string jelszo = TB_jelszo.Text;
            string szerepkor = LB_szerepkorok.SelectedItem.ToString();

            Database db = new Database();

            MySqlConnection conn = db.getConnection();


            //van-e ilyen nevű felhasználó a rendszerben

            conn.Open();

            string sql = "select nev from felhasznalok where nev='" + nev + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            MySqlDataReader dr = cmd.ExecuteReader();

            string vanenev = "";

            while (dr.Read())
            {
                vanenev = dr.GetString(0);
            }

            conn.Close();

            if (vanenev != "")
            {
                MessageBox.Show("Ilyen nevű felhasználó már van a rendszerben! Kérem válasszon másik nevet!");
                return;
            }

            //ha minden passzol beszúrás elvégzése

            //szerepkorid meghatározása

            conn.Open();

            string sql2 = "select szerepkorid from szerepkorok where szerepkor='" + szerepkor + "'";
            MySqlCommand cmd2 = new MySqlCommand(sql2, conn);

            MySqlDataReader dr2 = cmd2.ExecuteReader();

            int szerepkorid = 0;

            while (dr2.Read())
            {
                szerepkorid = dr2.GetInt32(0);
            }

            conn.Close();

            //beszúrás elvégzése

            conn.Open();

            string sql3 = "insert into felhasznalok(nev, jelszo, szerepkorid) values('" + nev + "', '" + jelszo + "' , " + szerepkorid + ");";
            MySqlCommand cmd3 = new MySqlCommand(sql3, conn);

            try
            {

                cmd3.ExecuteNonQuery();
                MessageBox.Show("Felhasználó felvitele sikeres!");

            }catch(Exception ex)
            {
                MessageBox.Show("Beszúrás nem sikerült! Indoka: " + ex.Message);
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
