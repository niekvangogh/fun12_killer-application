using killer_app.Objects;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace killer_app
{
    public class Database
    {

        public static Database INSTANCE { get; set; }

        private readonly MySqlConnection connection;
        private string connectionString = "Server=studmysql01.fhict.local;Uid=dbi407624;Database=dbi407624;Pwd=yourPassword;";

        private Database()
        {
            INSTANCE = this;
            this.connection = new MySqlConnection(connectionString);
        }

        public static Database GetInstance()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new Database();
            }
            return INSTANCE;
        }

        public List<Club> GetClubs()
        {
            List<Club> clubs = new List<Club>();
            
            return clubs;
        }
    }
}
