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
    public partial class LoginForm : Form
    {

        static User user = new User();

        DataTable dt = new DataTable();
        MySqlDataAdapter sda;
        MySqlCommand cmd = new MySqlCommand();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void BT_bejelentkezes_Click(object sender, EventArgs e)
        {
            string nev = TB_felhnev.Text;
            string jelszo = TB_jelszo.Text;

            user.Name = nev;
            user.Jelszo = jelszo;
            
            Database db = new Database();
            cmd = new MySqlCommand("select szerepkorid, felhasznaloid from felhasznalok " +
                "where nev='" + nev + "' and jelszo='" + jelszo +"' ", db.getConnection());
            sda = new MySqlDataAdapter(cmd);
            sda.Fill(dt);

            try
            {
                int szerepkorid = Convert.ToInt32(dt.Rows[0][0].ToString());
                if (szerepkorid == 4)
                {
                    MySqlConnection conn = db.getConnection();

                    conn.Open();

                    string sql = "select szerepkor from szerepkorok where szerepkorid=" + szerepkorid;
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    MySqlDataReader dr = cmd.ExecuteReader();

                    string szerepkor = "";

                    while (dr.Read())
                    {
                        szerepkor = dr.GetString(0);
                    }

                    conn.Close();


                    MessageBox.Show("Sikeres belepes " + szerepkor + "-kent!");

                    user.Felhasznaloid = Convert.ToInt32(dt.Rows[0][1].ToString());

                    Transporter.getInstance().CurrentUser = user;

                    this.Hide();
                    AdminForm form = new AdminForm();
                    form.Show();
                }
                if (szerepkorid == 3)
                {
                    MySqlConnection conn = db.getConnection();

                    conn.Open();

                    string sql = "select szerepkor from szerepkorok where szerepkorid=" + szerepkorid;
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    MySqlDataReader dr = cmd.ExecuteReader();

                    string szerepkor = "";

                    while (dr.Read())
                    {
                        szerepkor = dr.GetString(0);
                    }

                    conn.Close();


                    MessageBox.Show("Sikeres belepes " + szerepkor + "-kent!");

                    user.Felhasznaloid = Convert.ToInt32(dt.Rows[0][1].ToString());

                    Transporter.getInstance().CurrentUser = user;

                    this.Hide();
                    BuyerForm form = new BuyerForm();
                    form.Show();
                }
                if (szerepkorid == 2)
                {
                    MySqlConnection conn = db.getConnection();

                    conn.Open();

                    string sql = "select szerepkor from szerepkorok where szerepkorid=" + szerepkorid;
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    MySqlDataReader dr = cmd.ExecuteReader();

                    string szerepkor = "";

                    while (dr.Read())
                    {
                        szerepkor = dr.GetString(0);
                    }

                    conn.Close();


                    MessageBox.Show("Sikeres belepes " + szerepkor + "-kent!");

                    user.Felhasznaloid = Convert.ToInt32(dt.Rows[0][1].ToString());

                    Transporter.getInstance().CurrentUser = user;

                    this.Hide();
                    OfficeClerkForm form = new OfficeClerkForm();
                    form.Show();
                }
                if (szerepkorid == 1)
                {
                    MySqlConnection conn = db.getConnection();

                    conn.Open();

                    string sql = "select szerepkor from szerepkorok where szerepkorid=" + szerepkorid;
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    MySqlDataReader dr = cmd.ExecuteReader();

                    string szerepkor = "";

                    while (dr.Read())
                    {
                        szerepkor = dr.GetString(0);
                    }

                    conn.Close();


                    MessageBox.Show("Sikeres belepes " + szerepkor + "-kent!");

                    user.Felhasznaloid = Convert.ToInt32(dt.Rows[0][1].ToString());

                    Transporter.getInstance().CurrentUser = user;

                    this.Hide();
                    OperatorForm form = new OperatorForm();
                    form.Show();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Sikertelen belépés!");
                dt.Clear();
            }

            db.closeConnection();

            
        }
    }
}
