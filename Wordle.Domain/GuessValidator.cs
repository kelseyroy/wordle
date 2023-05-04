namespace Wordle.Domain;

public class GuessValidator
{
    public bool IsFiveLetters(string guess)
    {
        return guess.Length == 5 && guess.All(Char.IsLetter);
    }

    public bool IsValid(string guess)
    {
        // TODO: Guess should be validated against an actual dictionary
        return IsFiveLetters(guess);
    }
}
