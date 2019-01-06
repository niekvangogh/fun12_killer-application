using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace killer_app.Objects
{
    public class Club
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ZipCode { get; set; }

        public int StreetNumber { get; set; }

        public Club(int id, string name, string zipCode, int streetNumber)
        {
            this.Id = id;
            this.Name = name;
            this.ZipCode = zipCode;
            this.StreetNumber = streetNumber;
        }

        public readonly List<Team> Teams
        {
            get
            {
                return Database.GetInstance().GetTeams(this);
            }
        }
    }
}
