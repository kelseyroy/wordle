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
            Game game = new Game(null);
            ConsoleUI consoleUI = new ConsoleUI();
            string currentGuess = "";
            GameState gameState = GameState.Playing;

            consoleUI.DisplayEmptyBoard();
            while (gameState == GameState.Playing)
            {
                // Console.WriteLine(game.GetAnswer());
                gameState = TakeTurn();
            }

            WordScore[] GetGuess()
            {
                WordScore[]? guesses = null;
                while (guesses == null)
                {
                    consoleUI.DisplayMessage("Type in your 5 letter guess, then hit enter:");
                    currentGuess = consoleUI.GetGuessInput();
                    // guesses = game.MakeMove(currentGuess);
                }
                return guesses;
            }
            GameState TakeTurn()
            {
                WordScore[] guesses = GetGuess();
                consoleUI.UpdateBoard(guesses);
                return game.EvaluateGameState(currentGuess);
            }
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message);
        }
    }
}
