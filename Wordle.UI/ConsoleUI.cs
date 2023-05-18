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
        Console.WriteLine(@"╔═══╦═══╦═══╦═══╦═══╗
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

        for (int i = 0; i < 6; i++)
        {
            if (words[i] != null)
            {
                RenderRow(words[i]);
            }
            else
            {
                Console.WriteLine(emptyRow);
            }
            if (i < 5)
            {
                Console.WriteLine(rowBorder);
            }
        }
        Console.WriteLine(bottomBorder);
    }
    private void RenderRow(WordScore word)
    {
        var sortedLetterScore = word.LetterScores.OrderBy(ls => ls.Id);
        foreach (LetterScore letterScore in sortedLetterScore)
        {
            Console.Write("║");
            RenderCell(letterScore);
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
