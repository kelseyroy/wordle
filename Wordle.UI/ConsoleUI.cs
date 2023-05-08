using Wordle.Domain;
namespace Wordle.UI;

public class ConsoleUI : IWordleUI
{
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
    public void UpdateBoard(WordScore[] words, int guessCount)
    {
        var topBorder = "╔═══╦═══╦═══╦═══╦═══╗";
        var bottomBorder = "╚═══╩═══╩═══╩═══╩═══╝";
        var rowBorder = "╠═══╬═══╬═══╬═══╬═══╣";
        var emptyRow = "║ ║ ║ ║ ║ ║";

        Console.Clear();
        Console.WriteLine(topBorder);

        int i = 0;
        while (i < 6)
        {
            while (i < guessCount)
            {
                RenderRow(words[i]);
                Console.WriteLine(rowBorder);
                i++;
            }
            Console.WriteLine(emptyRow);
            if (i == 5)
            {
                break;
            }
            else
            {
                Console.WriteLine(rowBorder);
            }
            i++;
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
        Console.BackgroundColor = ConsoleColor.Black;
    }
}
