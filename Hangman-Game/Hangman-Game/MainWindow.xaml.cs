using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hangman_Game
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameRound currentRound;

        public MainWindow()
        {
            InitializeComponent();
        }


        private void ContinentsButton_Click(object sender, RoutedEventArgs e)
        {
            // Instantiate a new player
            Player player = new Player("TestPlayer");

            // Instantiate a category
            Category categoryContinents = new Category();
            categoryContinents.PopulateWith("continents.txt");

            // Start a game round
            GameRound roundOnContinents = new GameRound(player, categoryContinents);
            currentRound = roundOnContinents;
            currentRound.Start();

            // Display a secret word scheme
            secretWordBlock.Text = currentRound.GetSecretWordScheme();
            
            
            
            //updateScoreList(player);
        }



        private void SuggestLetterButton_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve the suggested letter
            char suggestedLetter = letterBox.Text[0];

            // If the letter is present in the word...
            if(currentRound.LetterIsPresent(suggestedLetter))
            {
               // update the word scheme
               currentRound.UpdateSecretWordScheme(suggestedLetter);
               secretWordBlock.Text = currentRound.GetSecretWordScheme(); 
            }

            // If the letter is NOT present in the word...
            else
            {
                // update the Hanging Man
                int hangingProgress = currentRound.GetNumberOfTries();
                pr.Content = hangingProgress;
            }
            
        }



        private void SuggestWordButton_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve the suggested word
            string suggestedWord = wordBox.Text;

            // If the suggested word is correct...
            if(currentRound.IsTheSecretWord(suggestedWord))
            {
                // stop the hanging process and save the Hanging Man
                pr.Content = "The man is saved";
            }

            // If the word is NOT the word...
            else
            {
                // update the Hanging Man
                int hangingProgress = currentRound.GetNumberOfTries();
                pr.Content = hangingProgress;
            }
        }
    }
}
