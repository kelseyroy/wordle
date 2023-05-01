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
            Wordle.Domain.Game game = new Wordle.Domain.Game();
            var correctGuess = new Guess()
            {
                Number = 6,
                Word = "ADEPT"
            };
            Console.WriteLine(game.EvaluateGuess("ADEPT", correctGuess));
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message);
        }

    }
}
