// See https://aka.ms/new-console-template for more information
using System;
using Wordle.Domain;

namespace Wordle.UI;

public static class Program
{
    public static void Main(string[] args)
    {
        try {
            // List<string> guesses = new List<string>();
            // IWordleUI consoleUI = new ConsoleUI();
            
            // Console.Clear();
            // Console.WriteLine(consoleUI.StringifyBoard(guesses));

            var wordle = new Game();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
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

            var guess = Console.ReadLine();
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message);
        }
        
    }
}
