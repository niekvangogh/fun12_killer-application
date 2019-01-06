using killer_app.Objects;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace killer_app
{
    public class Database
    {

        private static Database INSTANCE { get; set; }

        private readonly MySqlConnection connection;
        private readonly string connectionString;



        private Database()
        {
            INSTANCE = this;

            Console.WriteLine("Please provide your connection string here: ");
            this.connectionString = Console.ReadLine();
            if(connectionString == "")
            {
                this.connectionString = "Server=localhost;Uid=root;Database=killerapp;Pwd=root;";
            }
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

        public List<Team> GetTeams(Club club)
        {
            List<Team> teams = new List<Team>();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM teams WHERE club_id = @club_id;", this.connection);
            cmd.Parameters.AddWithValue("@club_id", club.Id);
            DataTable dataTable = new DataTable();
            this.connection.Open();
            dataTable.Load(cmd.ExecuteReader());
            this.connection.Close();
            foreach (DataRow row in dataTable.Rows)
            {
                teams.Add(new Team((int)row["id"], club, (int)row["serial_number"]));
            }
            return teams;
        }


        // very inefficient but ok i need to keep consistent
        public Division GetDivision(Team team)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM divisions WHERE id = (SELECT division_id FROM teams WHERE id = @team_id);", this.connection);
            cmd.Parameters.AddWithValue("@team_id", team.Id);
            DataTable dataTable = new DataTable();
            this.connection.Open();
            dataTable.Load(cmd.ExecuteReader());
            this.connection.Close();
            if(dataTable.Rows.Count == 0)
            {
                return null;
            }
            var row = dataTable.Rows[0];
            return new Division((int)row["id"], (int)row["level"]);
        }

        public List<Club> GetClubs()
        {
            List<Club> clubs = new List<Club>();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM clubs;", this.connection);
            DataTable dataTable = new DataTable();
            this.connection.Open();     
            dataTable.Load(cmd.ExecuteReader());
            this.connection.Close();
            foreach (DataRow row in dataTable.Rows)
            {
                clubs.Add(new Club((int)row["id"], (string)row["name"], (string)row["zip_code"], (int)row["street_number"]));
            }
            return clubs;
        }

        public void CreateTeam(Club club, Division division, int serialNumber)
        {
            MySqlCommand cmd = new MySqlCommand("INSERt INTO teams (club_id, division_id, serial_number) values (@club_id, @division_id, @serial_number)", this.connection);
            cmd.Parameters.AddWithValue("@club_id", club.Id);
            cmd.Parameters.AddWithValue("@division_id", division.Id);
            cmd.Parameters.AddWithValue("@serial_number", serialNumber);
            this.connection.Open();
            cmd.ExecuteNonQuery();
            this.connection.Close();
        }

        public List<Division> GetDivisions()
        {
            List<Division> divisions = new List<Division>();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM divisions;", this.connection);
            DataTable dataTable = new DataTable();
            this.connection.Open();
            dataTable.Load(cmd.ExecuteReader());
            this.connection.Close();
            foreach (DataRow row in dataTable.Rows)
            {
                divisions.Add(new Division((int) row["id"], (int) row["level"]));
            }
            return divisions;
        }

    }
}
