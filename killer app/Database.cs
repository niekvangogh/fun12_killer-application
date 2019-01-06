﻿using killer_app.Objects;
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
        private string connectionString = "Server=localhost;Uid=root;Database=killerapp;Pwd=root;";

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


        // very inefficient but ok i need to keep consis
        public Division GetDivision(Team team)
        {
            return null;
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
    }
}
