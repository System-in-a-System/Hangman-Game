using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman_Game
{
    class Player
    {
        /** Player's name. */
        private string name;

        /** Player's score. */
        private int score = 0;



        /**
         * Instantiates a new player.
         *
         * @param nameInput - the name of the player 
         */
        public Player(string nameInput)
        {
            setName(nameInput);
        }



        /** Getters and Setters for private data fields: */

        /**
         * Gets the name.
         *
         * @return the name
         */
        public string Name()
        {
            return name;
        }


        /**
         * Sets the name.
         *
         * @param nameInput the new name
         */
        public void setName(string nameInput)
        {
            if (nameInput != "")
                name = nameInput;
            else
                name = "Unknown hero";
        }



        /**
         * Records player's score (establishes player-score pair)
         *
         * @param theScore = the current score of the current player within the current round
         */
        public void RecordScore(int theScore) 
        {
			score = theScore;
        }



        /**
	    * Retrieves player's score (established in player-score pair)
	    *
	    * @return the int value of the player's score
	    */
        public int RetrieveScore()
        {
            return score;
        }
    }
}
