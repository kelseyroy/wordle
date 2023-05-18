namespace Wordle.UI;

public class Menu
{
    public bool WelcomeMenu()
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
                Play play = new Play();
                play.NewWordleGame();
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
    private void Logo(ConsoleColor foreground, ConsoleColor background)
    {
        ConsoleColor[] colors = new ConsoleColor[] { ConsoleColor.DarkGreen, ConsoleColor.DarkGray, ConsoleColor.DarkYellow };
        Console.WriteLine("Welcome to" + Environment.NewLine);
        Console.WriteLine("╔═══╦═══╦═══╦═══╦═══╦═══╗");
        foreach (char letter in "WORDLE")
        {
            Console.Write("║");
            Random random = new Random();
            int i = random.Next(0, 3);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = colors[i];
            Console.Write($" {letter} ");
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
        }
        Console.Write("║" + Environment.NewLine);
        Console.WriteLine("╚═══╩═══╩═══╩═══╩═══╩═══╝");
    }
    private void HelpMenu()
    {
        Console.Clear();
        HelpMenuInstructions();
        ReturnToMainMenu();
    }
    private void HelpMenuInstructions()
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
    private void HelpMenuExample(ConsoleColor foreground, ConsoleColor background)
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
    private void ReturnToMainMenu()
    {
        Console.Write("\r\nPress any key to return to Main Menu");
        Console.ReadKey();
    }
}
