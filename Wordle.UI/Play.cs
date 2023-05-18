using Wordle.Domain;
namespace Wordle.UI;

public class Play
{
    private Game game = new Game(null);
    private ConsoleUI consoleUI = new ConsoleUI();
    private string CurrentGuess = "";
    private GameState CurrentGameState = GameState.Playing;
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
    private Dictionary<int, WordScore> GetGuess()
    {
        consoleUI.DisplayMessage("Type in your 5 letter guess, then hit enter:");
        CurrentGuess = consoleUI.GetGuessInput();
        if (game.CanGuessBePlayed(CurrentGuess))
        {
            return game.MakeMove(CurrentGuess);
        }
        else
        {
            consoleUI.DisplayMessage("Invalid word.");
            return GetGuess();
        }
    }
    private GameState TakeTurn()
    {
        WordScore[] guesses = new WordScore[6];
        Dictionary<int, WordScore> getGuesses = GetGuess();
        getGuesses.Values.ToArray().CopyTo(guesses, 0);
        consoleUI.UpdateBoard(guesses);
        return game.EvaluateGameState(CurrentGuess);
    }
    private void EndGameMessage()
    {
        if (CurrentGameState == GameState.Won)
        {
            int count = game.GetGuessCount();
            string answer = game.GetAnswer();
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
