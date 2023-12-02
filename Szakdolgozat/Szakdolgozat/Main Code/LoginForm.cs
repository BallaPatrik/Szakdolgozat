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
using Szakdolgozat.Main_Code;
using Szakdolgozat.Model;

namespace Szakdolgozat
{
    public partial class LoginForm : Form
    {
        StyleForms stilus = new StyleForms();

        static User user = new User();

        DataTable dt = new DataTable();
        MySqlDataAdapter sda;
        MySqlCommand cmd = new MySqlCommand();

        public LoginForm()
        {
            InitializeComponent();
            stilus.styleChildForm(this);

            foreach (Button button in this.Controls.OfType<Button>())
            {
                stilus.styleButton(button);
            }
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
            string szerepkor = "";
            user.Name = nev;
            user.Jelszo = jelszo;

            Database db = new Database();

            try
            {
                 
            cmd = new MySqlCommand("select szerepkorid, felhasznaloid from felhasznalok " +
                "where nev='" + nev + "' and jelszo='" + jelszo +"' ", db.getConnection());
            sda = new MySqlDataAdapter(cmd);
            sda.Fill(dt);
                int szerepkorid = Convert.ToInt32(dt.Rows[0][0].ToString());

                if (szerepkorid == 5)
                {
                    MySqlConnection conn = db.getConnection();

                    conn.Open();

                    string sql = "select szerepkor from szerepkorok where szerepkorid=" + szerepkorid;
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    MySqlDataReader dr = cmd.ExecuteReader();



                    while (dr.Read())
                    {
                        szerepkor = dr.GetString(0);
                    }

                    conn.Close();


                    MessageBox.Show("Sikeres belepes " + szerepkor + "-kent!");

                    user.Felhasznaloid = Convert.ToInt32(dt.Rows[0][1].ToString());

                    Transporter.getInstance().CurrentUser = user;


                }

                if (szerepkorid == 4)
                {
                    MySqlConnection conn = db.getConnection();

                    conn.Open();

                    string sql = "select szerepkor from szerepkorok where szerepkorid=" + szerepkorid;
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    MySqlDataReader dr = cmd.ExecuteReader();

                    

                    while (dr.Read())
                    {
                        szerepkor = dr.GetString(0);
                    }

                    conn.Close();


                    MessageBox.Show("Sikeres belepes " + szerepkor + "-kent!");

                    user.Felhasznaloid = Convert.ToInt32(dt.Rows[0][1].ToString());

                    Transporter.getInstance().CurrentUser = user;

                    
                }
                if (szerepkorid == 3)
                {
                    MySqlConnection conn = db.getConnection();

                    conn.Open();

                    string sql = "select szerepkor from szerepkorok where szerepkorid=" + szerepkorid;
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    MySqlDataReader dr = cmd.ExecuteReader();

                    

                    while (dr.Read())
                    {
                        szerepkor = dr.GetString(0);
                    }

                    conn.Close();


                    MessageBox.Show("Sikeres belepes " + szerepkor + "-kent!");

                    user.Felhasznaloid = Convert.ToInt32(dt.Rows[0][1].ToString());

                    Transporter.getInstance().CurrentUser = user;

                    
                }
                if (szerepkorid == 2)
                {
                    MySqlConnection conn = db.getConnection();

                    conn.Open();

                    string sql = "select szerepkor from szerepkorok where szerepkorid=" + szerepkorid;
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    MySqlDataReader dr = cmd.ExecuteReader();

                    

                    while (dr.Read())
                    {
                        szerepkor = dr.GetString(0);
                    }

                    conn.Close();


                    MessageBox.Show("Sikeres belepes " + szerepkor + "-kent!");

                    user.Felhasznaloid = Convert.ToInt32(dt.Rows[0][1].ToString());
                    Transporter.getInstance().CurrentUser = user;


                    
                }
                if (szerepkorid == 1)
                {
                    MySqlConnection conn = db.getConnection();

                    conn.Open();

                    string sql = "select szerepkor from szerepkorok where szerepkorid=" + szerepkorid;
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    MySqlDataReader dr = cmd.ExecuteReader();

                   

                    while (dr.Read())
                    {
                        szerepkor = dr.GetString(0);
                    }

                    conn.Close();


                    MessageBox.Show("Sikeres belepes " + szerepkor + "-kent!");

                    user.Felhasznaloid = Convert.ToInt32(dt.Rows[0][1].ToString());
                    Transporter.getInstance().CurrentUser = user;
                }

                switch (szerepkor)
                {
                    case "Beszállító":
                        {
                            this.Hide();
                            SupplierHomeForm form = new SupplierHomeForm();
                            form.Show();
                        }
                        break;
                    case "Operátor":
                        {
                            this.Hide();
                            OperatorHomeForm form = new OperatorHomeForm();
                            form.Show();
                        }
                        break;
                    case "Irodista":
                        {
                            this.Hide();
                            OfficeClerkHomeForm form = new OfficeClerkHomeForm();
                            form.Show();
                        }
                        break;
                    case "Megrendelő":
                        {
                            this.Hide();
                            BuyerHomeForm form = new BuyerHomeForm();
                            form.Show();
                        }
                        break;
                    case "Adminisztrátor":
                        {
                            this.Hide();
                            AdminHomeForm form = new AdminHomeForm();
                            form.Show();
                        }
                        break;
                    default:
                        {
                            MessageBox.Show("Nincs jogosultsága!");
                        }
                        break;
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
