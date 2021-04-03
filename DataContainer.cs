using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.IO;
using System.Drawing;



namespace GroupProject5ECharCreator
{
    public class DataContainer
    {
        //This class allows us to access all of the elements of our database. I tried this originally with data-binding but found it lacking. While this approach is more complex, it gives us flexibility we wouldn't otherwise have.
        static string db_name = Directory.GetCurrentDirectory() + "\\5EDatabase.accdb";//Must be static 
        OleDbConnection connection;
        OleDbDataReader reader;
        OleDbCommand command;

        public List<String> races;
        public List<String> classes;
        public List<String> backgrounds;

        public DataContainer()
        {
             connection = new OleDbConnection(
            "Provider=Microsoft.ACE.OLEDB.12.0;" +
            "Data Source=" + db_name + ";" +
            "Mode=Share Deny None");
            
            races = new List<string>();
            classes = new List<string>();
            backgrounds = new List<string>();
            
            LoadRaces();
            LoadClasses();
            LoadBackgrounds();
        }

        void LoadRaces()
        {
            //This function will load all of the data from the Race column in the Races Table.

            //Sets command to select race from the races table. 
            command = new OleDbCommand("SELECT Race FROM Races", connection);
            connection.Open();

            reader = command.ExecuteReader();

            //Loops through the entire column Race, adding each value to the list.
            while (reader.Read())
            {
                races.Add(reader.GetString(0));
            }

            reader.Close();
            connection.Close();
            command = null;//Null the command, just to be safe
        }

        void LoadClasses()
        {
            //This function will load all of the data from the Class column in the Classes table

            command = new OleDbCommand("SELECT Class FROM Classes", connection);
            connection.Open();

            reader = command.ExecuteReader();

            //Loops through the entire column Class
            while (reader.Read())
            {
                classes.Add(reader.GetString(0));
            }

            reader.Close();
            connection.Close();
            command = null;
        }

        void LoadBackgrounds()
        {
            //This function will load all of the data from the Background column in the Backgrounds table

            command = new OleDbCommand("SELECT Background FROM Backgrounds", connection);
            connection.Open();

            reader = command.ExecuteReader();

            //Loops through the entire column Class
            while (reader.Read())
            {
                backgrounds.Add(reader.GetString(0));
            }

            reader.Close();
            connection.Close();
            command = null;
        }


        public Image GetRaceImage(string race )
        {
            //NOT CURRENTLY IN USE

            command = new OleDbCommand("Select * Image from Race_Images", connection);
            connection.Open();




            //MemoryStream memoryStream = new 

            return null;

        }
        

        


    }
}
