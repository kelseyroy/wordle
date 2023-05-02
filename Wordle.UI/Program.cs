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
            var game = new Game();
            DisplayEmptyBoard();

            Console.WriteLine("Type in your 5 letter guess, then hit enter:");
            var guess = Console.ReadLine();

            if (guess != null)
            {
                guessCount++;
                wordScoreArray[guessCount - 1] = new WordScore()
                {
                    GuessNumber = guessCount,
                    LetterScores = game.EvaluateGuess(secretWord, guess)
                };

                UpdateBoard(wordScoreArray, guessCount);
            }
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message);
        }

    }

    private static void DisplayEmptyBoard()
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine(@"
 ╔═══╦═══╦═══╦═══╦═══╗
 ║   ║   ║   ║   ║   ║
 ╠═══╬═══╬═══╬═══╬═══╣
 ║   ║   ║   ║   ║   ║
 ╠═══╬═══╬═══╬═══╬═══╣
 ║   ║   ║   ║   ║   ║
 ╠═══╬═══╬═══╬═══╬═══╣
 ║   ║   ║   ║   ║   ║
 ╠═══╬═══╬═══╬═══╬═══╣
 ║   ║   ║   ║   ║   ║
 ╠═══╬═══╬═══╬═══╬═══╣
 ║   ║   ║   ║   ║   ║
 ╚═══╩═══╩═══╩═══╩═══╝");
    }
    private static void RenderCell(LetterScore letter)
    {
        if (letter.Eval == Score.Correct)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
        }
        else if (letter.Eval == Score.InWord)
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
        }
        else
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
        }
        Console.Write($" {letter.Letter} ");
        Console.BackgroundColor = ConsoleColor.Black;
    }

    private static void RenderRow(WordScore word)
    {
        foreach (LetterScore letter in word.LetterScores)
        {
            Console.Write("║");
            RenderCell(letter);
        }
        Console.Write("║" + Environment.NewLine);
    }
    private static void UpdateBoard(WordScore[] words, int guessCount)
    {
        var topBorder = "╔═══╦═══╦═══╦═══╦═══╗";
        var bottomBorder = "╚═══╩═══╩═══╩═══╩═══╝";
        var rowBorder = "╠═══╬═══╬═══╬═══╬═══╣";
        var emptyRow = "║   ║   ║   ║   ║   ║";

        Console.Clear();
        Console.WriteLine(topBorder);
        
        int i = 0;
        while (i < 6)
        {
            while (i < guessCount)
            {
                RenderRow(words[i]);
                Console.WriteLine(rowBorder);
                i++;
            }
            Console.WriteLine(emptyRow);
            if (i == 5)
            {
                break;
            }
            else
            {
                Console.WriteLine(rowBorder);
            }
            i++;
        }
        Console.WriteLine(bottomBorder);
    }
}
