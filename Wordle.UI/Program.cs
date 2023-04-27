// See https://aka.ms/new-console-template for more information
using System;
using Wordle.Domain;

namespace Wordle.UI;

public static class Program
{
    public static void Main(string[] args)
    {
        try {
            Console.WriteLine("Hello");
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message);
        }
        
    }
}
