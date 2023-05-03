namespace Wordle.Domain;

public class GuessValidator
{
    // public int Number {get; set;} = 1;
    // public string Word {get; set;} = "";
    public bool IsFiveLetters(string guess)
    {
        return guess.Length == 5;
    }

    public bool IsValid(string guess)
    {
        // TODO: Guess should be validated against an actual dictionary
        return IsFiveLetters(guess);
    }
}