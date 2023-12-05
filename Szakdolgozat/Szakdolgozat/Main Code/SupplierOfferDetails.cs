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

            foreach (Button button in this.Controls.OfType<Button>())
            {
                stilus.styleButton(button);
            }

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

            string sql = "SELECT DISTINCT alkatreszek.nev, ajanlat_alkatreszek.darabszam, ajanlat_alkatreszek.datum, ajanlat_alkatreszek.ar FROM ajanlat_alkatreszek JOIN alkatreszek ON ajanlat_alkatreszek.alkatreszid = alkatreszek.alkatreszid WHERE ajanlat_alkatreszek.ajanlatid=" + Transporter.getInstance().getOfferID() + " AND datum IN (SELECT MAX(datum) FROM ajanlat_alkatreszek ar2 WHERE ar2.ajanlatid=ajanlat_alkatreszek.ajanlatid) AND datum is not null GROUP BY alkatreszek.nev ORDER BY datum DESC;";

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
