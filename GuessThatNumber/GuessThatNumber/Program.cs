using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GuessThatNumber
{
    public class Program
    {
        //this is the number the user needs to guess.  Set its value in your code using a RNG.
        static int NumberToGuess = 0;

        // var used to hold userGuess int data from string
        static int userGuess = 0;

        //starts and continues game when set to true
        static bool gameOn = true;

        //counts attempts to guess the number, starts at 1 since first guess will still be one attempt
        static int attempts = 1;


        static void Main(string[] args)
        {
            //used will goto to restart the game
            start:

            //sets random number for the game
            Random rng = new Random();
            
            //random number is between 1 and 100
            SetNumberToGuess(rng.Next(1, 101));

            //prompts the use to input data
            Console.Write("The computer has chosen a number between 1 and 100. Please enter your guess: ");
            string userInput = Console.ReadLine();

            //convers userInput from string to int and stores in userGuess
            userGuess = Convert.ToInt32(userInput);

            //if input is valid send data to functions to check high or low
            if (ValidateInput(userInput) == true)
            {
                IsGuessTooHigh(userGuess);
                IsGuessTooLow(userGuess);
            }
            else
            {
                //restarts game if input is not valid
                goto start;
            }

            //covers edge case of user guessing correctly in the first attempt
            if (userGuess == NumberToGuess)
            {
                //added for readability
                Console.WriteLine();

                //winning message sent to user
                Console.WriteLine("You chose wisely and won the game!");
                Console.WriteLine("It took you {0} attempt to guess the right number!", attempts);

                //added for readability
                Console.WriteLine();

                //gives user the option to play again
                Console.WriteLine("You are terrible at this game. Would you like to play again? yes/no");
                userInput = Console.ReadLine();

                //added for readability
                Console.WriteLine();

                //takes string input from user and restarts game
                if (userInput == "yes" || userInput == "y" || userInput == "YES" || userInput == "Y")
                {
                    goto start;
                }

                //takes string input from user and ends game
                if (userInput == "no" || userInput == "n" || userInput == "n" || userInput == "NO" || userInput == "N")
                {
                    Console.WriteLine();
                    Console.WriteLine("Quitter...");
                    Console.ReadKey();
                    gameOn = false;
                }

            }

            //loop continues game as long at condition stays true
            while (gameOn == true)
            {

                //returns congrats to user for guessing correctly
                if (userGuess == NumberToGuess)
                {
                    Console.WriteLine();
                    Console.WriteLine("You chose wisely and won the game!");
                    Console.WriteLine("It took you {0} attempts to guess the right number!", attempts);
                    Console.WriteLine();

                    //gives user the option to play again
                    Console.WriteLine("You are terrible at this game. Would you like to play again? yes/no");
                    userInput = Console.ReadLine();
                    Console.WriteLine();

                    //takes string input from user and restarts game
                    if (userInput == "yes" || userInput == "y" || userInput == "YES" || userInput == "Y")
                    {
                        goto start;
                    }

                    //takes string input from user and ends game
                    if (userInput == "no" || userInput == "n" || userInput == "n" || userInput == "NO" || userInput == "N")
                    {
                        Console.WriteLine();
                        Console.WriteLine("Quitter...");
                        Console.ReadKey();
                        gameOn = false;
                    }
                }
                
                //continues to ask for user input
                else if (userGuess != NumberToGuess)
                {
                    Console.Write("Please try again. Choose a number from 1 - 100: ");
                    userInput = Console.ReadLine();
                    userGuess = Convert.ToInt32(userInput);

                    //call function to validate input
                    if (ValidateInput(userInput) == true)
                    {
                        IsGuessTooHigh(userGuess);
                        IsGuessTooLow(userGuess);
                    }
                    else
                    {
                        //restarts game if input is not valid
                        goto start;
                    }
                }
            }

        }

        public static bool ValidateInput(string userInput)
        {
            //check to make sure that the users input is a valid number between 1 and 100.
            if (userGuess >= 1 && userGuess <= 100 || userInput.All(char.IsDigit) == true)
            {
                return true;
            }
            if (userGuess < 1 || userGuess > 100 || userInput == "" || userInput == null)
            {
                Console.WriteLine();
                Console.WriteLine("Invalid input will NOT be accepted. Please enter a NUMBER from 1 - 100.");
                Console.WriteLine();
                return false;
            }
            else
            {
                return false;
            }
        }

        public static void SetNumberToGuess(int number)
        {
            //TODO: make this function override your global variable holding the number the user needs to guess.  This is used only for testing methods.
            NumberToGuess = number;

        }

        public static bool IsGuessTooHigh(int userGuess)
        {

            if (userGuess > NumberToGuess)
            {
                //TODO: return true if the number guessed by the user is too high
                Console.WriteLine();
                Console.WriteLine("You chose poorly. {0} is too high. Please enter and try again.", userGuess);
                Console.WriteLine();
                Console.WriteLine();
                attempts++;
                return true;
            }
            return false;
        }

        public static bool IsGuessTooLow(int userGuess)
        {
            if (userGuess < NumberToGuess)
            {
                //TODO: return true if the number guessed by the user is too low
                Console.WriteLine();
                Console.WriteLine("You chose poorly. {0} is too low. Please enter and try again.", userGuess);
                Console.WriteLine();
                Console.WriteLine();
                attempts++;
                return true;
            }
            return false;
        }
       /* public static bool HotOrCold(int hOCguess)
            hOCguess = userGuess;
        {
            if (userGuess > (NumberToGuess + 50)) || (userGuess < (NumberToGuess + 50)) || (userGuess > (NumberToGuess - 50)) || (userGuess > (NumberToGuess - 50))
            {
                Console.WriteLine("Very Cold!");
            }
            if userGuess > (NumberToGuess + 10) || userGuess < (NumberToGuess + 10)) || userGuess > (NumberToGuess - 10) || userGuess < (NumberToGuess - 10)
            {
            Console.WriteLine("Getting warmer...");
            }

        }*/
    }
}