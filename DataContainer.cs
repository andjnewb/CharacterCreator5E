using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.IO;
using System.Drawing;
using Microsoft.Office.Interop.Access.Dao;




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
        public List<Tuple<string,string>> backgrounds;
        public List<Tuple<string, Image>> raceImages;
        public Image test;


        public DataContainer()
        {
             connection = new OleDbConnection(
            "Provider=Microsoft.ACE.OLEDB.12.0;" +
            "Data Source=" + db_name + ";" +
            "Mode=Share Deny None");
            
            races = new List<string>();
            classes = new List<string>();
            backgrounds = new List<Tuple<string, string>>();
            raceImages = new List<Tuple<string, Image>>();
            
            LoadRaces();
            LoadClasses();
            LoadBackgrounds();
            GetRaceImages();
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

            List<string> backgroundNames = new List<string>();
            List<string> backgroundsDescriptions = new List<string>();

            command = new OleDbCommand("SELECT Background FROM Backgrounds", connection);
            connection.Open();

            reader = command.ExecuteReader();

            

            //Loops through the entire column Class
            while (reader.Read())
            {
                //Add the names charlatan urchin etc. to a list
                backgroundNames.Add(reader.GetString(0));

                
                
            }

            command = new OleDbCommand("SELECT Description FROM Backgrounds ", connection);

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                backgroundsDescriptions.Add(reader.GetString(0));
            }

            for (int i = 0; i < backgroundNames.Count; i++)
            {
                backgrounds.Add(Tuple.Create(backgroundNames[i], backgroundsDescriptions[i]));
            }


           
            reader.Close();
            connection.Close();
            command = null;
        }


        public void GetRaceImages()
        {
            //NOT CURRENTLY IN USE
            List<string> RaceNames = new List<string>();
            List<Image> RaceImages = new List<Image>();


            command = new OleDbCommand("SELECT Race FROM Races", connection);
            connection.Open();
            


            reader = command.ExecuteReader();


            //MemoryStream memoryStream = new 

            while (reader.Read())
            {
                RaceNames.Add(reader.GetString(0));
            }

            command = new OleDbCommand("SELECT Image FROM Races", connection);

            reader = command.ExecuteReader();



            while (reader.Read())
            {

                Byte[] buffer = new Byte[10000];

                buffer = (byte[])reader.GetValue(0);

                Image image = ByteArrayToImage(buffer);

                RaceImages.Add(image);
                

            }

            for (int i = 0; i < RaceNames.Count; i++)
            {
                raceImages.Add(Tuple.Create(RaceNames[i], RaceImages[i]));
            }

            
            

            

        }

        Image ByteArrayToImage(byte[] b)
        {
            ImageConverter converter = new ImageConverter();
            Image img = (Image)converter.ConvertFrom(b);
            
            return img;
        }




    }
}
