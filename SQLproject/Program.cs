using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;

namespace SQLproject
{
    class Program
    {

        static void Main(string[] args)
        {
            Game game1 = new Game();
            game1.Name = "john";
            game1.Genre = "Board game";
            game1.Type = "simple game";
            game1.Review = "Average";
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Game;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string InsertString = String.Format("INSERT INTO Game (name,game,type,review VALUES {0},{1},{2},{3}", game1.Name, game1.Genre,game1.Type,game1.Review);
            string InsertString2 = "INSERT INTO Game(name,game,type,review) VALUES ('tetri','board game','simple game','average')";
            string Update = String.Format("UPDATE Game SET name = 'name',game = 'game' WHERE review = 'review'");
            string Delete = ("DELETE FROM Game WHERE name ='tetri'");
            SqlConnection conn = new SqlConnection(connectionString);
           

            try
            {
               conn.Open();
                SqlCommand insertCommand = new SqlCommand(InsertString2,conn);
                SqlDataReader reader = insertCommand.ExecuteReader();
                Console.WriteLine("Record Inserted Successfully");
                conn.Close();
                conn.Open();
                
                SqlCommand insertCommand1 = new SqlCommand(Update, conn);
                SqlDataReader reader1 = insertCommand1.ExecuteReader();
                Console.WriteLine("Record updated Successfully");
                conn.Close();

                conn.Open();
                SqlCommand deleteCommand = new SqlCommand(Delete, conn);
                SqlDataReader reader2 = deleteCommand.ExecuteReader();
                Console.WriteLine("Record deleted Successfully");
                conn.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Sommething happened");
            }
            finally
            {
                conn.Close();
            }
        }
      public class Game
        {
           
            string name = "";
            string genre = "";
            string type = "";
            string review = "";

            public string Name { get => name; set => name = value; }
            public string Genre { get => genre; set => genre = value; }
            public string Type { get => type; set => type = value; }
            public string Review { get => review; set => review = value; }
            
        }
    }
    }
   
           
