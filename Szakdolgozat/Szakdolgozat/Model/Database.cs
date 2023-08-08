using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Szakdolgozat
{
    class Database
    {
        private MySqlConnection conn = new MySqlConnection(@"server = localhost; userid=root;password=;database=szakdoga");

        public MySqlConnection getConnection()
        {
            return conn;
        }

        public void openConnection()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public void closeConnection()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
