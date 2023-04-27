// See https://aka.ms/new-console-template for more information
using Wordle.Domain;

try 
{
    var wordle = new Wordle.Domain.Game();
    Console.WriteLine(wordle.GetGreeting());
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}
