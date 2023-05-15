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
                return false;
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
    private static void HelpMenu()
    {
        Console.Clear();
        Console.WriteLine("Help Menu to come");

        ReturnToMainMenu();
    }
    private static void ReturnToMainMenu()
    {
        // Console.WriteLine($"\r\nYour modified string is: {message}");
        Console.Write("\r\nPress Enter to return to Main Menu");
        Console.ReadLine();
    }
    private static void PlayNewGameOrQuit()
    {
        Console.WriteLine("Would you like to play again?");
        Console.WriteLine("Press [ enter | return ] for a new game or [ esc ] to quit.");
        ConsoleKey key = Console.ReadKey(true).Key;
        switch (key)
        {
            case ConsoleKey.Enter:
                NewGame();
                break;
            case ConsoleKey.Escape:
                break;
        }
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

        consoleUI.DisplayEmptyBoard();
        while (gameState == GameState.Playing)
        {
            // Console.WriteLine(game.GetAnswer());
            gameState = TakeTurn();
        }

        if (gameState == GameState.Won)
        {
            string answer = game.GetAnswer();
            int count = game.GetGuessCount();
            string isGuessCountOne(int count)
            {
                if (count == 1) { return "try"; }
                else { return "tries"; }
            }
            Console.WriteLine("Congrats! You guessed {0} in {1} {2}.", answer, count, isGuessCountOne(count));
        }
        else if (gameState == GameState.Lost)
        {
            string answer = game.GetAnswer();
            Console.WriteLine("The word was {0}. Beter luck next time!", answer);
        }

        PlayNewGameOrQuit();
    }
}
