using Wordle.Domain;
namespace Wordle.UI;

public class Play
{
    private Game game = new Game(null);
    private ConsoleUI consoleUI = new ConsoleUI();
    private string CurrentGuess = "";
    private GameState CurrentGameState = GameState.Playing;
    private string? answer = null;
    public void NewWordleGame()
    {
        consoleUI.DisplayEmptyBoard();
        while (CurrentGameState == GameState.Playing)
        {
            CurrentGameState = TakeTurn();
        }
        EndGameMessage();
        PlayNewGameOrQuit();
    }
    private WordScore[] GetGuess()
    {
        WordScore[]? guesses = null;
        while (guesses == null)
        {
            consoleUI.DisplayMessage("Type in your 5 letter guess, then hit enter:");
            CurrentGuess = consoleUI.GetGuessInput();
            guesses = game.MakeMove(CurrentGuess);
        }
        return guesses;
    }
    private GameState TakeTurn()
    {
        WordScore[] guesses = GetGuess();
        consoleUI.UpdateBoard(guesses);
        return game.EvaluateGameState(CurrentGuess);
    }
    private void EndGameMessage()
    {
        if (CurrentGameState == GameState.Won)
        {
            int count = game.GetGuessCount();
            Console.WriteLine($"Congrats! You guessed {answer} in {count} {PluralizeTry(count)}.");
        }
        else if (CurrentGameState == GameState.Lost)
        {
            string answer = game.GetAnswer();
            consoleUI.DisplayMessage($"The word was {answer}. Beter luck next time!");
        }
    }
    private string PluralizeTry(int count)
    {
        if (count == 1) { return "try"; }
        else { return "tries"; }
    }
    private static void PlayNewGameOrQuit()
    {
        Console.WriteLine(@"
Would you like to play again?
Press [ enter | return ] for a new game or [ esc ] to quit.");
        ConsoleKey key = Console.ReadKey(true).Key;
        switch (key)
        {
            case ConsoleKey.Enter:
                Play play = new Play();
                play.NewWordleGame();
                break;
            case ConsoleKey.Escape:
                break;
        }
    }
}
