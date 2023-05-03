namespace Wordle.Domain;
using System.Text.RegularExpressions;

public class GuessValidator
{
    public bool IsFiveLetters(string guess)
    {
        return guess.Length == 5 && Regex.IsMatch(guess, @"^[a-zA-Z]+$");
    }

    public bool IsValid(string guess)
    {
        // TODO: Guess should be validated against an actual dictionary
        return IsFiveLetters(guess);
    }
}
