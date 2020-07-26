using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman_Game
{
    /**
    * The Class GameRound
    * represents the functionality of the game round logic.
    */
    class GameRound
    {
        /** Current player. */
        private Player player;

        /** Current category. */
        private Category category;


        /** The recieved secret word. */
        private string secretWord;

        /** The recieved secret word scheme. */
        private string secretWordScheme;


        /** The number of tries. */
        private int numberOfTries = 0;

        /** The  score. */
        private int score = 0;


        /** Game round status. */
        private bool roundIsWon = false;

        /** Game round status. */
        private bool roundIsLost = false;


        
        
        /**
	    * Instantiates a new game round.
	    *
	    * @param thePlayer is the current the player
	    * @param theCategory the current semantic category
	    */
        public GameRound(Player thePlayer, Category theCategory)
        {
            setPlayer(thePlayer);
            setCategory(theCategory);
        }



        /**
	    * Sets the player.
	    *
	    * @param thePlayer is a new player
	    * @throws ArgumentException
	    */
        public void setPlayer(Player thePlayer) 
        {
		    if(thePlayer is Player)
                player = thePlayer;
		    else 
			    throw new ArgumentException("The input parameters should be of type Player");
        }



        /**
	    * Sets the category.
	    *
	    * @param theCategory is a new category
	    * @throws IllegalArgumentException
	    */
        public void setCategory(Category theCategory)
        {
		    if(theCategory is Category)
                category = theCategory;
		    else 
			    throw new ArgumentException("The input parameters should be of type Category");
        }


        // Basic run method of the game
        public void Start()
        {
            GenerateSecretWord();
            SetSecretWordScheme();
        }

		
		    
	
	    /**
	    *----------------------------  Help methods used in the game logic: -----------------------------------------
	    */
	

	    /**
	    * Assigns secretWord randomly picked out within the respective Category class
	    * 
	    */
	    public void GenerateSecretWord()
        {

            if (category.GetSize() > 0)
                secretWord = category.ProvideRandomWord();

            else
                secretWord = "X";
		
	    }


        public string GetSecretWord()
        {
            return secretWord;
        }
	
	
	
	    /**
	    * Constructs the secret word scheme.
	    *
	    * @return the string
	    */
	    public void SetSecretWordScheme()
        {

            if (secretWord.Length > 0)
            {
                string scheme = "";

                for (int i = 0; i < secretWord.Length; i++)
                    scheme += ".";

                secretWordScheme = scheme;
            }

            else
            {
                secretWordScheme = "";
            }
        }



       /**
        * Gets the secret word scheme.
        *
        * @return the secret word scheme
        */
        public string GetSecretWordScheme()
        {
            return secretWordScheme;
        }



        /**
        * Updates secret word scheme.
        *
        * @param theLetter = the letter to update the secret word with
        * @throws ArgumentException
        */
        public void UpdateSecretWordScheme(char theLetter)
        {

            if (theLetter != '\0')
            {

                // Uppercase the letter before the search
                theLetter = Char.ToUpper(theLetter);

                
                // Locate matched letters
                for (int i = 0; i < secretWord.Length; i++)
                {
                    if (secretWord[i] == theLetter)

                        // Update the word scheme
                        secretWordScheme = secretWordScheme.Substring(0, i)
                                           + theLetter
                                           + secretWordScheme.Substring(i + 1);
                }

            }
            
            // Catch possible illegal argument exceptions	
            else
            {
                throw new ArgumentException("Error: No letter has been provided");
            }
        }




        /**
        * Checks if the suggested letter is present in the secret word.
        *
        * @param theLetter = the suggested letter
        * @return true, if the suggested letter is present in the word
        * 
        * @throws ArgumentException
        */
        public bool LetterIsPresent(char theLetter) 
        {
		
		    if (theLetter != '\0')
            {
                // Uppercase the letter before the search
                theLetter = Char.ToUpper(theLetter);


                // Check the uppercased letter against the uppercased secret word
                // If indexOf returns >= 0, the letter is present in the word
                if (secretWord.IndexOf(theLetter) >= 0)
                    return true;

                // If indexOf returns "-1", the letter is NOT present in the word
                else
                {
                    numberOfTries++;
                    return false;
                }
                    
                
            }

            // Catch possible illegal argument exceptions	
            else
            {
                throw new ArgumentException("Error: No letter has been provided");
            }

        }



        /**
        * Checks if the suggested word corresponds to the secret word
        *
        * @param theWord = the suggested word
        * @return true, if the suggested word corresponds to the secret word
        * 
        * @throws ArgumentException
        */
        public bool IsTheSecretWord(string theWord)
        {
		
		    if (theWord != "")
            {
                // Uppercase the input word before the check
                theWord = theWord.ToUpper();


                // If the word corresponds to the secret word
                if (theWord.Equals(secretWord))
                {
                    roundIsWon = true;
                    return true;   	
                }
            
                // If the word does not correspond to the secret word
                else
                {
                    numberOfTries++;
                    return false;
                }
            }

            // Catch possible Illegal Argument Exceptions
            else
            {
                throw new ArgumentException("Error: No word has been provided");
            }
        }



        /**
        * Gets the number of tries.
        *
        * @return the number of tries
        */
        public int GetNumberOfTries()
        {
            return numberOfTries;
        }


        
        /**
        * Calculates score based on the number of failed tries.
        *
        * @return player's score
        */
        public int CalculateScore()
        {
            if (roundIsWon)
            {
                score = ((8 - numberOfTries) * 10) + 20;
                player.RecordScore(score);
                return score;
            }

            else
            {
                return 0;
            }

        }



        /**
        * Game round "switcher"
        *
        * @return true, if the game round outcome has not yet been established = the round is still on
        */
        public bool RoundIsOn()
        {
            if (!roundIsWon && !roundIsLost)
                return true;
            else
                return false;
        }

    }	
}


