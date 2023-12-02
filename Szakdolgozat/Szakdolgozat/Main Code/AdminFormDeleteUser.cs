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
    public partial class AdminFormDeleteUser : Form
    {
        StyleForms stilus = new StyleForms();

        public AdminFormDeleteUser()
        {
            InitializeComponent();
            updateUsers();

            stilus.styleChildForm(this);

            foreach (DataGridViewColumn elem in dataGridView1.Columns)
            {
                elem.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            foreach (Button button in this.Controls.OfType<Button>())
            {
                stilus.styleButton(button);
            }
        }

        Database db = new Database();

        private void updateUsers()
        {
            
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            MySqlConnection conn = db.getConnection();

            conn.Open();

            string sql = "select nev, szerepkorid from felhasznalok where szerepkorid between 1 and 3 OR szerepkorid=5";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            MySqlDataReader dr = cmd.ExecuteReader();

            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "Név";
            dataGridView1.Columns[1].Name = "Jogosultság";

            while (dr.Read())
            {
                string jogosultsag = "";
                switch(dr.GetInt32(1))
                {
                    case 1: { jogosultsag = "Operátor"; } break;
                    case 2: { jogosultsag = "Irodista";  } break;
                    case 3: { jogosultsag = "Megrendelő"; } break;
                    case 5: { jogosultsag = "Beszállító"; } break;
                    default: { jogosultsag = "Nem megállapítható"; } break;
                }

                dataGridView1.Rows.Add(dr.GetString(0), jogosultsag);
            }

            conn.Close();
        }


        private void DeleteUserAdminForm_Load(object sender, EventArgs e)
        {

        }

        private void BT_felhasznalotorles_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Biztos töröljük a felhasználót?", "Figyelem!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    {
                        string nev = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();


                        MySqlConnection conn = db.getConnection();

                        conn.Open();

                        string sql = "delete from felhasznalok where nev='"+nev+"'";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);

                        MySqlDataReader dr = cmd.ExecuteReader();

                        dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);

                        conn.Close();
                        
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    dataGridView1.ClearSelection();
                }
            }
            else
            {
                MessageBox.Show("Kérlek válassz ki egy törlendő elemet!");
            }
        }

        private void AdminFormDeleteUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
