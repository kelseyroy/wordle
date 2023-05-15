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
        Logo(Console.ForegroundColor, Console.BackgroundColor);
        Console.WriteLine(@"
Choose an option from the following list and press enter:
    [ -g | --game ] to play the game
    [ -h | --help ] for usage/instructions
    [ -q | --quit ] to quit
What would you like to do? ");
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
        Console.WriteLine("Welcome to" + Environment.NewLine);
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
        Console.WriteLine("╚═══╩═══╩═══╩═══╩═══╩═══╝");
    }
    private static void HelpMenu()
    {
        Console.Clear();
        HelpMenuInstructions();
        ReturnToMainMenu();
    }
    private static void HelpMenuInstructions()
    {

        Console.WriteLine(@"
How To Play:
Guess the word in 6 tries.

  * When prompted, type in a valid 5-letter word 
    and press enter.
  * The color of the board tiles will change to 
    show how close your guess was to the word.
          
For Example:

The word to guess is ADEPT");
        HelpMenuExample(Console.ForegroundColor, Console.BackgroundColor);
        Console.WriteLine(@"
A is in ADEPT and in the correct spot.
D is in ADEPT but in the wrong spot.
U, I and O are not in the word in any spot."
);

    }
    private static void HelpMenuExample(ConsoleColor foreground, ConsoleColor background)
    {
        ConsoleColor[] audioColors = new ConsoleColor[] { ConsoleColor.DarkGreen, ConsoleColor.DarkGray, ConsoleColor.DarkYellow, ConsoleColor.DarkGray, ConsoleColor.DarkGray };

        Console.WriteLine("╔═══╦═══╦═══╦═══╦═══╗");
        string str = "AUDIO";
        for (int i = 0; i < str.Length; i++)
        {
            char letter = str[i];
            Console.Write("║");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = audioColors[i];
            Console.Write($" {letter} ");
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
        }
        Console.Write("║" + Environment.NewLine);
        Console.WriteLine("╚═══╩═══╩═══╩═══╩═══╝");
    }
    private static void ReturnToMainMenu()
    {
        Console.Write("\r\nPress any key to return to Main Menu");
        Console.ReadKey();
    }
    private static void PlayNewGameOrQuit()
    {
        Console.Write("\r\nWould you like to play again?");
        Console.Write("\r\nPress [ enter | return ] for a new game or [ esc ] to quit.");
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
            string PluralizeTry(int count)
            {
                if (count == 1) { return "try"; }
                else { return "tries"; }
            }
            Console.WriteLine("Congrats! You guessed {0} in {1} {2}.", answer, count, PluralizeTry(count));
        }
        else if (gameState == GameState.Lost)
        {
            string answer = game.GetAnswer();
            Console.WriteLine("The word was {0}. Beter luck next time!", answer);
        }

        PlayNewGameOrQuit();
    }
}
