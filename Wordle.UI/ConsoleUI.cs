using Wordle.Domain;
namespace Wordle.UI;

public class ConsoleUI : IWordleUI
{
    Game game = new Game(null);
    public void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }
    public string GetGuessInput()
    {
        string? guess = Console.ReadLine();
        if (guess != null)
        {
            return guess.Trim().ToUpper();
        }
        else
        {
            return "";
        }
    }

    public void DisplayEmptyBoard()
    {

        Console.Clear();
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
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
    public void UpdateBoard(WordScore[] words)
    {
        var topBorder = "╔═══╦═══╦═══╦═══╦═══╗";
        var bottomBorder = "╚═══╩═══╩═══╩═══╩═══╝";
        var rowBorder = "╠═══╬═══╬═══╬═══╬═══╣";
        var emptyRow = "║   ║   ║   ║   ║   ║";

        Console.Clear();
        Console.WriteLine(topBorder);

        int i = 0;
        foreach (WordScore word in words)
        {
            if (word != null)
            {
                RenderRow(word);
            }
            else
            {
                Console.WriteLine(emptyRow);
            }
            i++;
            if (i <= 5)
            {
                Console.WriteLine(rowBorder);
            }
        }
        Console.WriteLine(bottomBorder);
    }
    private void RenderRow(WordScore word)
    {
        foreach (LetterScore letter in word.LetterScores)
        {
            Console.Write("║");
            RenderCell(letter);
        }
        Console.Write("║" + Environment.NewLine);
    }
    private void RenderCell(LetterScore letter)
    {
        Console.ForegroundColor = ConsoleColor.Black;
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
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Black;
    }
}
