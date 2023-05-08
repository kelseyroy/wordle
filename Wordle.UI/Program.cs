// See https://aka.ms/new-console-template for more information
using System;
using Wordle.Domain;

namespace Wordle.UI;

public static class Program
{
    public static void Main(string[] args)
    {
        try
        {
            int guessCount = 0;
            string secretWord = "ADEPT";
            WordScore[] wordScoreArray = new WordScore[6];
            var game = new Domain.Wordle();
            var guessValidator = new GuessValidator();
            var consoleUI = new ConsoleUI();
            consoleUI.DisplayEmptyBoard();

            Console.WriteLine("Type in your 5 letter guess, then hit enter:");
            var guess = Console.ReadLine();

            if (guess == null || !guessValidator.IsValid(guess))
            {
                throw new ArgumentException(String.Format("{0} is not a valid word", guess),"guess");
            }
            else
            {
                

                consoleUI.UpdateBoard(wordScoreArray, guessCount);
            }
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message);
        }

    }
}
