using killer_app.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace killer_app
{
    public static class Utils
    {
        public static void CreateTeams(Club club, int amount)
        {
            Random random = new Random();
            List<Division> divisions = Database.GetInstance().GetDivisions();
            int teamsCount = club.Teams.Count;
            for (int i = 0; i < amount; i++)
            {
                teamsCount++;
                Division randomDivision = divisions[random.Next(divisions.Count)];
                Database.GetInstance().CreateTeam(club, randomDivision, teamsCount);
            }
        }
    }
}
