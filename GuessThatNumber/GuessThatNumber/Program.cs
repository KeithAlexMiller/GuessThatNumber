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
        static int userGuess = 0;
        static bool gameOn = true;
        static int attempts = 1;


        static void Main(string[] args)
        {
            SetNumberToGuess(NumberToGuess);
            Console.Write("The computer has chosen a number between 1 and 100. Please enter your guess: ");
            string userInput = Console.ReadLine();
            userGuess = Convert.ToInt32(userInput);
            if (ValidateInput(userInput) == true)
            {
                IsGuessTooHigh(userGuess);
                IsGuessTooLow(userGuess);
            }
            else
            {
                gameOn = false;
            }

            if (userGuess == NumberToGuess)
            {
                Console.WriteLine();
                Console.WriteLine("You chose wisely and won the game!");
                Console.WriteLine("It took you {0} attempt to guess the right number!", attempts);
                Console.ReadKey();
                gameOn = false;
            }

            while (gameOn == true)
            {

                if (userGuess == NumberToGuess)
                {
                    Console.WriteLine();
                    Console.WriteLine("You chose wisely and won the game!");
                    Console.WriteLine("It took you {0} attempts to guess the right number!", attempts);
                    Console.ReadKey();
                    gameOn = false;
                }

                else if (userGuess != NumberToGuess)
                {
                    Console.Write("The computer has chosen a number between 1 and 100. Please enter your guess: ");
                    userInput = Console.ReadLine();
                    userGuess = Convert.ToInt32(userInput);

                    if (ValidateInput(userInput) == true)
                    {
                        IsGuessTooHigh(userGuess);
                        IsGuessTooLow(userGuess);
                    }
                    else
                    {
                        gameOn = false;
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
                Console.WriteLine("Please choose a number betweeen 1 and 100.");
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
            Random randomNumberGenerator = new Random();
            NumberToGuess = randomNumberGenerator.Next(1, 101);

        }

        public static bool IsGuessTooHigh(int userGuess)
        {

            if (userGuess > NumberToGuess)
            {
                //TODO: return true if the number guessed by the user is too high
                Console.WriteLine();
                Console.WriteLine("You chose poorly. {0} is too high. Please enter and try again.", userGuess);
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
                attempts++;
                return true;
            }
            return false;
        }
    }
}