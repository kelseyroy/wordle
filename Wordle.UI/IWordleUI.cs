using Wordle.Domain;
namespace Wordle.UI;

public interface IWordleUI
{
    public void TakeTurns(string answer, GuessStatistics guesses);
    public string GetGuess();
    void UpdateBoard(WordScore[] words, int guessCount);
    void DisplayEmptyBoard();
    string GetGuessInput();
    void DisplayMessage(string message);
}
