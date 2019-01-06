using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace killer_app.Objects
{
    public class Team
    {

        public Team(long id, Club club, Division division, long serialNumber)
        {
            this.Id = id;
            this.Club = club;
            this.Division = division;
            this.SerialNumber = serialNumber;
        }

        public long Id { get; private set; }

        public Club Club { get; private set; }

        public Division Division { get; private set; }

        public long SerialNumber { get; private set; }
    }
}
