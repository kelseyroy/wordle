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

            WordScore[] GetGuess()
            {
                consoleUI.DisplayMessage("Type in your 5 letter guess, then hit enter:");
                currentGuess = consoleUI.GetGuessInput();
                if (game.TryMakeMove(currentGuess, out Dictionary<int, WordScore>? guesses))
                {
                    return guesses.Values.ToArray();
                }
                else
                {
                    consoleUI.DisplayMessage("Invalid word.");
                    return GetGuess();
                }
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
