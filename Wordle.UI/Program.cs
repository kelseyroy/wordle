// See https://aka.ms/new-console-template for more information
using Wordle.Domain;

var wordle = new Wordle.Domain.Game();
Console.WriteLine(wordle.GetGreeting());
