using MySql.Data.MySqlClient;
using QRCoder;
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
    public partial class BuyerFormOrderDetails : Form
    {
        public BuyerFormOrderDetails()
        {
            StyleForms stilus = new StyleForms();

            InitializeComponent();
            DGV_termekek.Columns.Add("Col1", "Nev");
            DGV_termekek.Columns.Add("Col2", "Darabszam");
            DGV_termekek.Columns.Add("Col3", "Datum");
            DGV_termekek.Columns.Add("Col4", "Reszosszeg");

            DGV_termekek.Columns[0].ReadOnly = true;
            DGV_termekek.Columns[1].ReadOnly = true;
            DGV_termekek.Columns[2].ReadOnly = true;
            DGV_termekek.Columns[3].ReadOnly = true;


            DGV_termekek.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Bold);

            //oszlop szélességek beállítása
            DGV_termekek.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DGV_termekek.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DGV_termekek.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DGV_termekek.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < DGV_termekek.Columns.Count; i++)
            {
                DGV_termekek.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; //fejlécek középre igazítása
                DGV_termekek.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //a többi cella középre igazítása
            }

            foreach (DataGridViewColumn elem in DGV_termekek.Columns)
            {
                elem.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            getOrderDetails();

            stilus.styleChildForm(this);
        }



        private void getOrderDetails()
        {
            Database db = new Database();

            MySqlConnection conn = db.getConnection();
            //SELECT t.nev, db, aktualis, datum, reszosszeg FROM rendeles_termekek rt JOIN termekek t ON rt.termekid = t.termekid WHERE rt.rendelesid = + rendelesid
            conn.Open();
            string sql = "SELECT t.nev, db, datum, reszosszeg FROM rendeles_termekek rt JOIN termekek t ON rt.termekid = t.termekid WHERE rt.rendelesid = " + Transporter.getInstance().getOrderID();

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            MySqlDataReader dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                DGV_termekek.Rows.Add(dr.GetString(0), dr.GetInt32(1), dr.GetDateTime(2).ToString(), dr.GetInt32(3));
            }

            conn.Close();

            DGV_termekek.Refresh();

            string qrkodszoveg = "Köszönjük a vásárlást!\nA rendelés adatai:\n";

            int vegosszeg = 0;

            foreach (DataGridViewRow elem in DGV_termekek.Rows)
            {
                if (elem != null)
                {
                    vegosszeg += Convert.ToInt32(elem.Cells[3].Value);
                    string sor = "Termék: " + elem.Cells[0].Value + ", Darab: " + elem.Cells[1].Value + ", Részösszeg: " + elem.Cells[3].Value + ", Rendelve: " + elem.Cells[2].Value + "\n";
                    qrkodszoveg += sor;
                }
            }

            qrkodszoveg += "\nVégösszeg: " + vegosszeg;

            //QRKÓD működése

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrkodszoveg, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(2);

            pictureBox1.Image = qrCodeImage;
        }

        private void BuyerFormOrderDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
