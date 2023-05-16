// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
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

            Dictionary<int, WordScore> GetGuess()
            {
                consoleUI.DisplayMessage("Type in your 5 letter guess, then hit enter:");
                currentGuess = consoleUI.GetGuessInput();
                if (game.IsMoveAccepted(currentGuess, out Dictionary<int, WordScore>? guesses))
                {
                    return guesses;
                }
                else
                {
                    consoleUI.DisplayMessage("Invalid word.");
                    return GetGuess();
                }
            }
            GameState TakeTurn()
            {
                WordScore[] guesses = new WordScore[6];
                Dictionary<int, WordScore> getGuesses = GetGuess();
                getGuesses.Values.ToArray().CopyTo(guesses, 0);
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
