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
            string secretWord = "ADEPT";
            var guesses = new Domain.GuessStatistics();
            var game = new Domain.Game();
            var guessValidator = new GuessValidator();
            var consoleUI = new ConsoleUI();

            consoleUI.DisplayEmptyBoard();
            while (guesses.GuessCount < 6)
            {
                consoleUI.TakeTurns(secretWord, guesses);
            }
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message);
        }
    }
}
