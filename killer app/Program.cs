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

            Console.WriteLine("Available clubs:");
            clubs.ForEach(club =>
            {
                Console.WriteLine("- " + club.Name);
            });

            clubs.ForEach(club =>
            {
                Console.WriteLine("Teams in club: " + club.Name);
                club.Teams.ForEach(team =>
                {
                    Console.WriteLine(" " + team.Id);

                });
            });

            Console.ReadLine();
        }
    }
}
