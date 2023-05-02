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
            int guessNum = 0;
            string secretWord = "ADEPT";
            WordScore[] wordScoreArray = new WordScore[6];
            var game = new Game();
            DisplayEmptyBoard();

            Console.WriteLine("Type in your 5 letter guess, then hit enter:");
            var guess = Console.ReadLine();

            if (guess != null)
            {   
                wordScoreArray[guessNum] = new WordScore()
                {
                    GuessNumber = guessNum + 1,
                    LetterScores = game.EvaluateGuess(secretWord, guess)
                };
                guessNum++;
                UpdateBoard(wordScoreArray, guessNum);
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
    private static void DisplayCell(LetterScore letter)
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

    private static void DisplayRow(WordScore word)
    {
        foreach (LetterScore letter in word.LetterScores)
        {
            Console.Write("║");
            DisplayCell(letter);
        }
        Console.Write("║" + Environment.NewLine);
    }
    private static void UpdateBoard(WordScore[] words, int guessCount)
    {
        Console.Clear();
        var topBorder = "╔═══╦═══╦═══╦═══╦═══╗";
        var bottomBorder = "╚═══╩═══╩═══╩═══╩═══╝";
        var rowBorder = "╠═══╬═══╬═══╬═══╬═══╣";
        var emptyRow = "║   ║   ║   ║   ║   ║";
        Console.WriteLine(topBorder); 
        for(int i = 0; i < guessCount; i++)
        {
            DisplayRow(words[i]);
            Console.WriteLine(rowBorder);

        }
        for(int i = guessCount; i <= 6; i++){
            Console.WriteLine(emptyRow);
            if (i == 6)
            {
                break;
            }
            else
            {
                Console.WriteLine(rowBorder);
            }
        }  
        Console.WriteLine(bottomBorder);
    }
}
