using Wordle.Domain;
namespace Wordle.UI;

public interface IWordleUI
{
    // public string GetGuess();
    void UpdateBoard(WordScore[] words, int guessCount);
    void DisplayEmptyBoard();
    string GetGuessInput();
    void DisplayMessage(string message);
}
