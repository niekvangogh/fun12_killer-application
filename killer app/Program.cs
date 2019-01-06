using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace killer_app
{
    class Program
    {
        public static void Main(string[] args)
        {
            var clubs = Database.GetInstance().GetClubs();
            Random random = new Random();

            Console.WriteLine("Available clubs:");

            clubs.ForEach(club =>
            {
                Console.WriteLine("- " + club.Name);
                //Utils.CreateTeams(club, random.Next(4, 8));
            });

            clubs.ForEach(club =>
            {
                Console.WriteLine("Teams in club: " + club.Name);
                club.Teams.ForEach(team =>
                {
                    Console.WriteLine("  - " + team.Id + ":" + team.Division.Level);

                });
            });
   
            


            Console.ReadLine();
        }
    }
}
