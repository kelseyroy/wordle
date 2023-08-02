namespace Wordle.Domain;
public class Game
{
    private string SecretWord;
    Guess Guess = new Guess();
    private static string relativePath = "../../../../Wordle.Domain/Data/5_letter_words.txt";
    private static string answerRelativePath = "../../../../Wordle.Domain/Data/answers.txt";
    private static string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
    private static string filePath = Path.GetFullPath(Path.Combine(currentDirectory, relativePath));
    private static string answerFilePath = Path.GetFullPath(Path.Combine(currentDirectory, answerRelativePath));
    Answer Answer = new Answer();
    public Game(string word)
    {
        SecretWord = word;
    }
    public Game()
    {
        SecretWord = Answer.GetRandomWord(answerFilePath);
    }
    public string GetAnswer()
    {
        return SecretWord;
    }
    public int GetGuessCount()
    {
        return Guess.GuessCount;
    }
    public Dictionary<int, WordScore> MakeMove(string playerGuess)
    {
        Guess.UpdateGuesses(SecretWord, playerGuess);
        return Guess.Guesses;
    }
    public GameState EvaluateGameState(string playerGuess)
    {
        GameState result = GameState.Playing;
        if (IsWin(playerGuess)) { result = GameState.Won; }
        else if (IsGuessCountSix()) { result = GameState.Lost; }
        return result;
    }
    public bool CanGuessBePlayed(string playerGuess)
    {
        var words = Answer.ReadWordsFile(filePath);
        return Guess.IsValid(playerGuess, words);
    }

    private bool IsWin(string guess)
    {
        return guess == SecretWord;
    }
    private bool IsGuessCountSix()
    {
        return Guess.GuessCount == 6;
    }
}
