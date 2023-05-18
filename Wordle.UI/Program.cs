// See https://aka.ms/new-console-template for more information
namespace Wordle.UI;

public static class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Menu menu = new Menu();
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = menu.WelcomeMenu();
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
}
