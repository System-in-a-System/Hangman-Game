using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman_Game
{

    /**
    * The Class Category 
    * that will serve as functional blueprints 
    * for Hangman semantic categories management
    */
    class Category
    {
        
        /** Representatives of the semantic category. */
        protected List<String> representatives = new List<String>();



        /**
	    * Method to populate a chosen semantic category 
        * with the respective content
	    * taken from an indicated external file
	    *
	    * @param path = the path for the text file that contains the wordlist
	    */
        public void PopulateWith(String path)
        {

            // If the text file exists...
            if (File.Exists(path))
            {
                // Read the text file line by line (= word by word).  
                string[] lines = File.ReadAllLines(path);

                // Populate representatives list with the respective content
                foreach (string line in lines)
                    representatives.Add(line.ToUpper());
                                        // uppercase the words for further "source material unification"
            }
            else
            {
                Console.WriteLine("File is not found");
            }

	    }



        /**
	    * Method to provide a random word form the respective category.
	    *
	    * @return the string representation of the secretWord
	    */
        public string ProvideRandomWord()
        {
            // Retrieve a random number within the range of the ArrayList size
            Random randomizer = new Random();
            int randomIndex = randomizer.Next(representatives.Count());


            // Use this number as an index to retrieve a respective element from the ArrayList
            // Retrieved String will be the secret Word
            string secretWord = representatives[randomIndex];

            return secretWord;
        }
    }
}
