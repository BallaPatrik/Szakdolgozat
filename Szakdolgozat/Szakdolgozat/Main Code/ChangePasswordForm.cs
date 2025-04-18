﻿using MySql.Data.MySqlClient;
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
    public partial class ChangePasswordForm : Form
    {
        StyleForms stilus = new StyleForms();

        public ChangePasswordForm()
        {
            InitializeComponent();

            stilus.styleChildForm(this);

            foreach (Button button in this.Controls.OfType<Button>())
            {
                stilus.styleButton(button);
                button.Size = new Size(185, 23);
            }
        }

        private void ChangePasswordForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void BT_jelszavak_elrejtese_mutatasa_Click(object sender, EventArgs e)
        {
            if (TB_regi_jelszo.PasswordChar == '*' && TB_uj_jelszo_1.PasswordChar == '*' && TB_uj_jelszo_2.PasswordChar == '*')
            {
                TB_regi_jelszo.PasswordChar = '\0';
                TB_uj_jelszo_1.PasswordChar = '\0';
                TB_uj_jelszo_2.PasswordChar = '\0';
            }
            else
            {
                TB_regi_jelszo.PasswordChar = '*';
                TB_uj_jelszo_1.PasswordChar = '*';
                TB_uj_jelszo_2.PasswordChar = '*';
            }
        }

        private void BT_jelszovaltoztat_Click(object sender, EventArgs e)
        {
            string regijelszo = TB_regi_jelszo.Text;
            string ujjelszo1 = TB_uj_jelszo_1.Text;
            string ujjelszo2 = TB_uj_jelszo_2.Text;

            //megnézzük hogy az összes érték ki van-e töltve

            if (regijelszo == "" || ujjelszo1 == "" || ujjelszo2 == "")
            {
                MessageBox.Show("Az összes mezőt ki kell tölteni!");
                return;
            }
            

            //a 2 új jelszó megegyezik-e

            if (ujjelszo1 != ujjelszo2)
            {
                MessageBox.Show("Az új jelszavak nem egyenek meg!");
                return;
            }
            //eredeti jelszó meghatározása

            int felhasznaloid = Transporter.getInstance().CurrentUser.Felhasznaloid;

            string regijelszoadatbazisbol="";

            Database db = new Database();

            MySqlConnection conn = db.getConnection();

            try
            {
                conn.Open();

                string sql = "select jelszo from felhasznalok where felhasznaloid=" + felhasznaloid;

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    regijelszoadatbazisbol = dr.GetString(0);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Adatbázis hiba! Oka: " + ex.Message);
            }

            //eredeti jelszó megegyezik-e

            if (regijelszo != regijelszoadatbazisbol)
            {
                MessageBox.Show("Jelszóváltozatás sikertelen!");
                return;
            }

            //ha megegyezik átírás adatbázisban

            try
            {
                conn.Open();

                string sql = "update felhasznalok set jelszo='" + ujjelszo1 + "' where felhasznaloid=" + felhasznaloid;

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    regijelszoadatbazisbol = dr.GetString(0);
                }

                conn.Close();

                MessageBox.Show("Jelszóváltozatás sikeres!");

                TB_regi_jelszo.Text = "";
                TB_uj_jelszo_1.Text = "";
                TB_uj_jelszo_2.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Adatbázis hiba! Oka: " + ex.Message);
            }
        }

        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {

        }
    }
}
