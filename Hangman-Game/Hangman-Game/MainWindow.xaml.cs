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
        int hangingProgress = 0;


        public MainWindow()
        {
            InitializeComponent();

            suggestLetterButton.Visibility = Visibility.Hidden;
            letterBox.Visibility = Visibility.Hidden;
            suggestWordButton.Visibility = Visibility.Hidden;
            wordBox.Visibility = Visibility.Hidden;
        }



        private void ContinentsButton_Click(object sender, RoutedEventArgs e)
        {

            // Reset the hanging progress
            hangingProgress = 0;
            
            
            // Instantiate a new player
            Player player = new Player("TestPlayer");

            // Instantiate a category
            Category categoryContinents = new Category();
            categoryContinents.PopulateWith("resources/continents.txt");

            
            // Display the elements of player interface
            suggestLetterButton.Visibility = Visibility.Visible;
            letterBox.Visibility = Visibility.Visible;
            suggestWordButton.Visibility = Visibility.Visible;
            wordBox.Visibility = Visibility.Visible;

            
            // Start a game round
            GameRound roundOnContinents = new GameRound(player, categoryContinents);
            currentRound = roundOnContinents;
            currentRound.Start();

            // Display a secret word scheme
            secretWordBlock.Text = currentRound.GetSecretWordScheme();
            
        }



        private void CountriesButton_Click(object sender, RoutedEventArgs e)
        {
            // Reset the hanging progress
            hangingProgress = 0;

            
            // Instantiate a new player
            Player player = new Player("TestPlayer");

            // Instantiate a category
            Category categoryCountries = new Category();
            categoryCountries.PopulateWith("resources/countries.txt");

            
            // Display the elements of player interface
            suggestLetterButton.Visibility = Visibility.Visible;
            letterBox.Visibility = Visibility.Visible;
            suggestWordButton.Visibility = Visibility.Visible;
            wordBox.Visibility = Visibility.Visible;

            
            // Start a game round
            GameRound roundOnCountries = new GameRound(player, categoryCountries);
            currentRound = roundOnCountries;
            currentRound.Start();

            // Display a secret word scheme
            secretWordBlock.Text = currentRound.GetSecretWordScheme();
        }



        private void CapitalsButton_Click(object sender, RoutedEventArgs e)
        {
            // Reset the hanging progress
            hangingProgress = 0;

            
            // Instantiate a new player
            Player player = new Player("TestPlayer");

            // Instantiate a category
            Category categoryCapitals = new Category();
            categoryCapitals.PopulateWith("resources/capitals.txt");

            
            // Display the elements of player interface
            suggestLetterButton.Visibility = Visibility.Visible;
            letterBox.Visibility = Visibility.Visible;
            suggestWordButton.Visibility = Visibility.Visible;
            wordBox.Visibility = Visibility.Visible;

            
            // Start a game round
            GameRound roundOnCapitals = new GameRound(player, categoryCapitals);
            currentRound = roundOnCapitals;
            currentRound.Start();

            // Display a secret word scheme
            secretWordBlock.Text = currentRound.GetSecretWordScheme();
        }









        private void SuggestLetterButton_Click(object sender, RoutedEventArgs e)
        {
            if(letterBox.Text.Length > 0)
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
                    hangingProgress++;

                    // progress the hanging process
                    if (hangingProgress <= 12)
                        hangmanImage.Source = new BitmapImage(new Uri("pack://application:,,,/images/" + hangingProgress + ".jpg"));

                    // or finish the hanging process
                    else
                    {
                        pr.Content = "The man has been hanged...";

                        // Reveal the secret word
                        l.Content = "secret word: " + currentRound.GetSecretWord();

                        // Hide the elements of player interface
                        suggestLetterButton.Visibility = Visibility.Hidden;
                        letterBox.Visibility = Visibility.Hidden;
                        suggestWordButton.Visibility = Visibility.Hidden;
                        wordBox.Visibility = Visibility.Hidden;
                    }
                        
                }

                // Clean up the text field
                letterBox.Text = "";
                

            }
            
        }



        private void SuggestWordButton_Click(object sender, RoutedEventArgs e)
        {
            
            if(wordBox.Text.Length > 0)
            {
                // Retrieve the suggested word
                string suggestedWord = wordBox.Text;
        

                // If the suggested word is correct...
                if(currentRound.IsTheSecretWord(suggestedWord))
                {
                    // stop the hanging process and save the Hanging Man
                    pr.Content = "The man has been saved!";

                    // Display the word on the board
                    secretWordBlock.Text = currentRound.GetSecretWord();

                    // Hide the elements of player interface
                    suggestLetterButton.Visibility = Visibility.Hidden;
                    letterBox.Visibility = Visibility.Hidden;
                    suggestWordButton.Visibility = Visibility.Hidden;
                    wordBox.Visibility = Visibility.Hidden;
                }

                // If the word is NOT the word...
                else
                {
                    // update the Hanging Man
                    hangingProgress++;


                    // progress the hanging process
                    if (hangingProgress <= 12)
                        hangmanImage.Source = new BitmapImage(new Uri("pack://application:,,,/images/" + hangingProgress + ".jpg"));


                    // or finish the hanging process
                    else
                    {
                        pr.Content = "The man has been hanged...";

                        // Reveal the secret word
                        l.Content = "secret word: " + currentRound.GetSecretWord();

                        // Hide the elements of player interface
                        suggestLetterButton.Visibility = Visibility.Hidden;
                        letterBox.Visibility = Visibility.Hidden;
                        suggestWordButton.Visibility = Visibility.Hidden;
                        wordBox.Visibility = Visibility.Hidden;
                    }
                }


                // Clean up the text field
                wordBox.Text = "";

            }
            
        }

    }
}
