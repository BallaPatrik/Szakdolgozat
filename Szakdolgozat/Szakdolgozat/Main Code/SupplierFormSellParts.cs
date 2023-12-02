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
    public partial class SupplierFormSellParts : Form
    {
        StyleForms stilus = new StyleForms();

        public SupplierFormSellParts()
        {
            InitializeComponent();
            DGV_parts.Columns.Add("Col1", "Alkatresz neve");
            DGV_parts.Columns.Add("Col2", "Darabszama");
            DGV_parts.Columns.Add("Col3", "Erteke");
            DGV_parts.Columns[0].ReadOnly = true;
            updateParts();

            stilus.styleChildForm(this);
        }

        private void updateParts()
        {
            Database db = new Database();

            MySqlConnection conn = db.getConnection();

            MySqlCommand cmd;

            conn.Open();

            cmd = new MySqlCommand("select nev from alkatreszek", conn);

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                DGV_parts.Rows.Add(dr.GetString(0),0,0);
            }

            foreach (Button button in this.Controls.OfType<Button>())
            {
                stilus.styleButton(button);
            }

            DGV_parts.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Bold);

            //oszlop szélességek beállítása
            DGV_parts.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < DGV_parts.Columns.Count; i++)
            {
                DGV_parts.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; //fejlécek középre igazítása
                DGV_parts.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //a többi cella középre igazítása
            }

            conn.Close();
        }

        private void BT_alkatreszeladas_Click(object sender, EventArgs e)
        {
            Database db = new Database();

            MySqlConnection conn = db.getConnection();

            MySqlCommand cmd, cmd2;

            conn.Open();

            int userid = Transporter.getInstance().CurrentUser.Felhasznaloid;

            DateTime datum = DateTime.Now;

            string format = "yyyy-MM-dd HH:mm:ss";

            string allapot = "Elbírálás alatt";

            int vegosszeg = 0;

            foreach (DataGridViewRow row in DGV_parts.Rows)
            {
                vegosszeg += Convert.ToInt32(row.Cells[1].Value) * Convert.ToInt32(row.Cells[2].Value);
            }

            if(vegosszeg == 0)
            {
                MessageBox.Show("Nem választott ki egyetlen alkatrészt sem!");
                return;
            }

            string sql = "INSERT INTO ajanlat(beszallitoid, allapot, datum, vegosszeg) values(" + userid + ", '" + allapot + "', '" + datum.ToString(format) + "', " + vegosszeg + ");";

            cmd = new MySqlCommand(sql, conn);
            
            cmd.ExecuteNonQuery();
            int ajanlatid = 0;

            List<string> alkatreszek = new List<string>();

            string sql2 = "select ajanlatid FROM ajanlat GROUP BY ajanlatid DESC LIMIT 1";
            cmd2 = new MySqlCommand(sql2, conn);

            MySqlDataReader dr = cmd2.ExecuteReader();

            while (dr.Read())
            {
                ajanlatid = dr.GetInt32(0);
            }

           Transporter.getInstance().setOfferId(ajanlatid);

            List<int> darabszamok = new List<int>();

            foreach (DataGridViewRow elem in DGV_parts.Rows)
            {
                if (!elem.Cells[1].Value.ToString().Equals("0"))
                {
                    alkatreszek.Add(elem.Cells[0].Value.ToString());
                    darabszamok.Add(Convert.ToInt32(elem.Cells[1].Value));
                }
            }

            conn.Close();

            List<int> alkatreszidk = new List<int>();

            foreach (var elem in alkatreszek)
            {
                conn.Open();
                string sql3 = "SELECT alkatreszid FROM alkatreszek WHERE nev='" + elem + "'";
                MySqlCommand cmd3 = new MySqlCommand(sql3, conn);
                MySqlDataReader dr3 = cmd3.ExecuteReader();

                while (dr3.Read())
                {
                    alkatreszidk.Add(dr3.GetInt32(0));
                }

                conn.Close();
            }
            for (int i = 0; i < alkatreszidk.Count; i++)
            {
                conn.Open();

                string sql4 = "INSERT INTO ajanlat_alkatreszek(ajanlatid, alkatreszid, ar, darabszam, datum) VALUES(" + ajanlatid + ", " + alkatreszidk[i] + ", '" + DGV_parts.Rows[i].Cells[2].Value.ToString() + "', " + darabszamok[i] + ", '" + datum.ToString(format) + "')";
                MySqlCommand cmd4 = new MySqlCommand(sql4, conn);
                try
                {
                    cmd4.ExecuteNonQuery();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ajanlattétel nem sikerült! Indoka: " + ex.Message);
                    return;
                }
                conn.Close();
            }
            MessageBox.Show("Ajanlattétel sikerült!");
        }
    }
}
