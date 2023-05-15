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
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message);
            throw;
        }
        finally
        {
            Console.ResetColor();
            Console.Clear();
            Console.WriteLine("Thanks for playing! Wordle was closed.");
        }


        // NewGame();
    }
    private static bool MainMenu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Clear();
        Console.WriteLine("Welcome to");
        Logo(Console.ForegroundColor, Console.BackgroundColor);
        Console.WriteLine("Choose an option from the following list and hit enter:");
        Console.WriteLine("\t[ -g | --game ] to play the game");
        Console.WriteLine("\t[ -h | --help ] for usage/instructions");
        Console.WriteLine("\t[ -q | --quit ] to quit");
        Console.WriteLine("What would you like to do?");
        switch (Console.ReadLine())
        {
            case "-g":
            case "--game":
                NewGame();
                return true;
            case "-h":
            case "--help":
                HelpMenu();
                return true;
            case "-q":
            case "--quit":
                return false;
            default:
                return true;
        }
    }
    private static void HelpMenu()
    {
        Console.WriteLine("Help Menu to come");
    }
    private static void Logo(ConsoleColor foreground, ConsoleColor background)
    {
        ConsoleColor[] colors = new ConsoleColor[] { ConsoleColor.DarkGreen, ConsoleColor.DarkGray, ConsoleColor.DarkYellow };
        Console.WriteLine("╔═══╦═══╦═══╦═══╦═══╦═══╗");
        foreach (char letter in "WORDLE")
        {
            Console.Write("║");
            Random random = new Random();
            int idx = random.Next(0, 3);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = colors[idx];
            Console.Write($" {letter} ");
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
        }
        Console.Write("║" + Environment.NewLine);
        Console.WriteLine("╚═══╩═══╩═══╩═══╩═══╩═══╝" + Environment.NewLine);
    }
    private static void NewGame()
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
}
