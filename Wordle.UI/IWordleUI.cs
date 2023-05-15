using Wordle.Domain;
namespace Wordle.UI;

public interface IWordleUI
{
    void UpdateBoard(WordScore[] words);
    void DisplayEmptyBoard();
    string GetGuessInput();
    void DisplayMessage(string message);
}
