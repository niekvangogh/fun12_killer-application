using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace killer_app.Objects
{
    public class Team
    {

        public Team(int id, Club club, int serialNumber)
        {
            this.Id = id;
            this.Club = club;
            this.SerialNumber = serialNumber;
        }

        public int Id { get; private set; }

        public Club Club { get; private set; }

        public Division Division
        {
            get
            {
                return Database.GetInstance().GetDivision(this);
            }
        }

        public int SerialNumber { get; private set; }
    }
}
