using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace killer_app.Objects
{
    public class Division
    {

        public Division(int id, int level)
        {
            this.ID = id;
            this.Level = level;
        }

        public int ID { get; private set; }
        public int Level { get; private set; }
    }
}
