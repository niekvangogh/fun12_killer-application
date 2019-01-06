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

        private Database()
        {
            INSTANCE = this;
        }

        public static Database GetInstance()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new Database();
            }
            return INSTANCE;
        }
    }
}
