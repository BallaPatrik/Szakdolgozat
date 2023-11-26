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
    public partial class SupplierOfferDetails : Form
    {
        public SupplierOfferDetails()
        {
            InitializeComponent();


            StyleForms stilus = new StyleForms();

            
            DGV_ajanlatok.Columns.Add("Col1", "Név");
            DGV_ajanlatok.Columns.Add("Col2", "Darabszám");
            DGV_ajanlatok.Columns.Add("Col3", "Dátum");
            DGV_ajanlatok.Columns.Add("Col4", "Részösszeg");

            DGV_ajanlatok.Columns[0].ReadOnly = true;
            DGV_ajanlatok.Columns[1].ReadOnly = true;
            DGV_ajanlatok.Columns[2].ReadOnly = true;
            DGV_ajanlatok.Columns[3].ReadOnly = true;

            DGV_ajanlatok.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Bold);

            //oszlop szélességek beállítása
            DGV_ajanlatok.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DGV_ajanlatok.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DGV_ajanlatok.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DGV_ajanlatok.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < DGV_ajanlatok.Columns.Count; i++)
            {
                DGV_ajanlatok.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; //fejlécek középre igazítása
                DGV_ajanlatok.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //a többi cella középre igazítása
            }

            foreach (DataGridViewColumn elem in DGV_ajanlatok.Columns)
            {
                elem.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            

            stilus.styleChildForm(this);



            getOfferDetails();
        }


        private void getOfferDetails()
        {
            DGV_ajanlatok.Rows.Clear();
            Database db = new Database();

            MySqlConnection conn = db.getConnection();
            
            conn.Open();

            string sql = "SELECT a.nev, aa.darabszam, MAX(aa.datum), aa.ar FROM ajanlat_alkatreszek aa JOIN alkatreszek a ON a.alkatreszid = aa.alkatreszid WHERE aa.ajanlatid = " + Transporter.getInstance().getOfferID() + " AND datum is not null GROUP BY a.nev;";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            MySqlDataReader dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                DGV_ajanlatok.Rows.Add(dr.GetString(0), dr.GetInt32(1), dr.GetDateTime(2).ToString(), dr.GetInt32(3));    
            }

            conn.Close();

            DGV_ajanlatok.Refresh();
            
        }

        private void SupplierOfferDetails_Load(object sender, EventArgs e)
        {

        }
    }
}
