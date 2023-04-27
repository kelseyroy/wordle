// See https://aka.ms/new-console-template for more information
using System;
using Wordle.Domain;

namespace Wordle.UI;

public static class Program
{
    public static void Main(string[] args)
    {
        try {
            List<string> guesses = new List<string>();
            Console.WriteLine("Hello");
            IWordleUI consoleUI = new ConsoleUI();
            
            Console.WriteLine(consoleUI.Board(guesses));
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message);
        }
        
    }
}
