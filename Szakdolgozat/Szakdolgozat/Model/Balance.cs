using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MySql.Data.MySqlClient;

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

        public int getCurrentBalance()
        {
            Database db = new Database();
            MySqlConnection conn = db.getConnection();

            conn.Open();

            int egyenleg = 0;
            string sql = "select datum, egyenleg from tranzakciok WHERE datum IN (SELECT MAX(datum) FROM tranzakciok) GROUP BY datum";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    egyenleg = dr.GetInt32(1);
                }
            }

            conn.Close();

            return egyenleg;
        }

        public void subtractBalance(int levonando)
        {

            Database db = new Database();
            MySqlConnection conn = db.getConnection();

            conn.Open();

            int egyenleg = 0;
            string sql = "select datum, egyenleg from tranzakciok WHERE datum IN (SELECT MAX(datum) FROM tranzakciok) GROUP BY datum";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    egyenleg = dr.GetInt32(1);
                }
            } 

            if(egyenleg != 0)
            {
                egyenleg = egyenleg - levonando;
            }
            

            conn.Close();
            conn.Open();
            string tipus = "Kimenő";
            DateTime datum = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss";
            string sql2 = "insert into tranzakciok (datum, tipus, ertek, egyenleg) values ('" + datum.ToString(format) + "', '" + tipus + "', " + levonando + ", " + egyenleg + ")";
            MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
            cmd2.ExecuteNonQuery();
            conn.Close();
        }

        public void addBalance(int hozzaadando)
        {
            Database db = new Database();
            MySqlConnection conn = db.getConnection();

            conn.Open();

            int egyenleg = 0;
            string sql = "select datum, egyenleg from tranzakciok WHERE datum IN (SELECT MAX(datum) FROM tranzakciok) GROUP BY datum";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            MySqlDataReader dr = cmd.ExecuteReader();

            if(dr.Read())
            {
                if(!dr.IsDBNull(0)) 
                { 
                egyenleg = dr.GetInt32(1);
                }
            }

            egyenleg = egyenleg + hozzaadando;

            conn.Close();
            conn.Open();
            string tipus = "Bejövő";
            DateTime datum = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss";
            string sql2 = "insert into tranzakciok (datum, tipus, ertek, egyenleg) values ('" + datum.ToString(format) + "', '" + tipus + "', " + hozzaadando + ", " + egyenleg + ")";
            MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
            cmd2.ExecuteNonQuery();
            conn.Close();
        }
    }
}
