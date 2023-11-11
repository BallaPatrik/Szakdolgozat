using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Szakdolgozat.Model
{
    class Balance
    {
        static private Balance instance = null;

        private Balance()
        {

        }
        
        public static Balance getInstance()
        {
            if (instance == null)
            {
                instance = new Balance();
            }
            return instance;
        }

        public int getCurrentBalance(string ut)
        {
            //FileStream fs = File.Open(ut, FileMode.Open);

            string szoveg = File.ReadAllText(ut);

            int fileegyenleg = Convert.ToInt32(szoveg);

            return fileegyenleg;
        }

        public void subtractBalance(string ut, int levonando)
        {
            //FileStream fs = File.Open(ut, FileMode.Open);

            string szoveg = File.ReadAllText(ut);

            int fileegyenleg = Convert.ToInt32(szoveg);

            fileegyenleg = -levonando;

            File.WriteAllText(ut, fileegyenleg.ToString());
        }

        public void addBalance(string ut, int hozzaadando)
        {
          //  FileStream fs = File.Open(ut, FileMode.Open);

            string szoveg = File.ReadAllText(ut);

            int fileegyenleg = Convert.ToInt32(szoveg);

            fileegyenleg = +hozzaadando;

            File.WriteAllText(ut, fileegyenleg.ToString());
        }
    }
}
