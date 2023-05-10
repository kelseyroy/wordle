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
            Game game = new Game(null);
            var guesses = new Domain.GuessStatistics();
            var consoleUI = new ConsoleUI();

            void TakeTurns(string answer, GuessStatistics guesses)
            {
                var guess = consoleUI.GetGuess();
                var letterScoresList = game.EvaluateGuess(guess);
                guesses.UpdateGuessStatistics(letterScoresList);
                consoleUI.UpdateBoard(guesses.GuessArray, guesses.GuessCount);
            }

            consoleUI.DisplayEmptyBoard();
            while (guesses.GuessCount < 6)
            {
                TakeTurns(secretWord, guesses);
            }
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message);
        }
    }
}
