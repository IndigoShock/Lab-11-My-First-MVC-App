using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FirstMVCApp.Models
{
    public class Person
    {
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Birth_Year { get; set; }
        public int DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }

        /// <summary>
        /// This method takes in the beginning year and end year the user inputs and will instantiate a new person object into a list.
        /// </summary>
        /// <param name="begYear"></param>
        /// <param name="endYear"></param>
        /// <returns></returns>
        public static List<Person> GetPersons(int begYear, int endYear)
        {
            //starting a person list called people and creating new list.
            List<Person> people = new List<Person>();
            
            //this is the path and will go to the environment's current directory
            string path = Environment.CurrentDirectory;
            
            //this is taking the csv file and combining the old path with the new path
            string newPath = Path.GetFullPath(Path.Combine(path, @"wwwroot\personOfTheYear.csv"));

            //this is reading all the lines in the new path and sending to the myFile array
            string[] myFile = File.ReadAllLines(newPath);

            //beginning the for loop that goes through the length of myFile
            for (int i = 1; i < myFile.Length; i++)
            {
                //the fields string array is splitting the file with the split based on the index number of myFile
                string[] fields = myFile[i].Split(',');
                
                //with the add method on the people variable, a new person is instantiated
                people.Add(new Person

                {
                    //the year is converting into an integer in the 0 index field
                    Year = Convert.ToInt32(fields[0]),
                    
                    //the honor string is filling in the 1 index field
                    Honor = fields[1],
                    
                    //the name string is filling in the 2 index field
                    Name = fields[2],
                    
                    //the country string is filling in the 3 index field
                    Country = fields[3],
                    
                    //the birth year uses a ternary function which will initially be blank. if blank, put in 0, if not, fill in the integer to 4 index field
                    Birth_Year = (fields[4] == "") ? 0 : Convert.ToInt32(fields[4]),
                    
                    //the death year uses a ternary function which will initially be blank. if blank, put in a 0, if not, fill in the integer to 5 index field
                    DeathYear = (fields[5] == "") ? 0 : Convert.ToInt32(fields[5]),
                    
                    //title string is filling in the 6 index field
                    Title = fields[6],
                    
                    //category string is filling in the 7 index field
                    Category = fields[7],
                    
                    //context string is filling in the 8 index field
                    Context = fields[8],
                });
            }

            //the listofpeople list moves the above people variable into the beginning and ending year and will shoot to the list.
            List<Person> listofPeople = people.Where(p => (p.Year >= begYear) && (p.Year <= endYear)).ToList();
            
            //returns the above and will populate with the people between the two years.
            return listofPeople;
        }
    }
}
