using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Szakdolgozat.Model;

namespace Szakdolgozat.Main_Code
{
    public partial class OfficeClerkFormCheckBalance : Form
    {
        public OfficeClerkFormCheckBalance()
        {
            InitializeComponent();
        }

        private void createFile(string ut)
        {
            File.Create(ut);
        }

        private void checkBalance(string ut)
        {
            FileStream fs = File.Open(ut, FileMode.Open);

            string szoveg = File.ReadAllText(ut);

            int fileegyenleg = Convert.ToInt32(szoveg);

            int egyenleg = Convert.ToInt32(TB_egyenleg.Text);

            if (fileegyenleg == 0)
            {
                File.WriteAllText(ut, egyenleg.ToString());
            }
            else
            {
                MessageBox.Show("Az egyenleg nem 0, ezért nem lehet átírni!");
            }

            fs.Close();
        }

        private void showBalance()
        {
            string ut = @"C:\Users\balla\source\repos\BallaPatrik\Szakdolgozat\Szakdolgozat\Szakdolgozat\Main Code\balance.txt";

            //megnézzük, hogy van-e már fájl
            //ha nincs létrehozzuk
            if (!File.Exists(ut))
            {
                createFile(ut);
            }
            //ha van megnézzük az értékét
            //ha 0 beleírhatunk
            //ha nem akkor nem írunk bele semmit
            checkBalance(ut);

            int jelenlegiegyenleg = Balance.getInstance().getCurrentBalance(ut);

            //Jelenlegi egyenleg: 0 Ft
            L_jelenlegi_egyenleg.Text = "Jelenlegi egyenleg: " + jelenlegiegyenleg + " Ft";
        }

        private void BT_egyenleg_lekerdezese_Click(object sender, EventArgs e)
        {
            showBalance();
        }
    }
}
