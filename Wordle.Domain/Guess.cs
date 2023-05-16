namespace Wordle.Domain;

public class Guess
{
    public Dictionary<int, WordScore> Guesses = new Dictionary<int, WordScore>(6);
    public int GuessCount = 0;
    public bool TryUpdateGuesses(string answer, string guess)
    {
        if (IsValid(guess))
        {
            GuessCount++;
        }
        if (GuessCount == 0 || GuessCount > 6)
        {
            return false;
        }
        WordScore wordScore = new WordScore()
        {
            GuessNumber = GuessCount,
            LetterScores = EvaluateGuess(answer, guess)
        };
        return Guesses.TryAdd((GuessCount - 1), wordScore);
    }
    public List<LetterScore> EvaluateGuess(string answer, string guess)
    {
        int i = 0;

        List<LetterScore> letterScoresList = new List<LetterScore>();
        foreach (char guessLetter in guess.ToUpper())
        {
            LetterScore letterScore = new LetterScore()
            {
                Id = i,
                Letter = guessLetter,
                Eval = evaluateLetter(guessLetter, i, answer)
            };
            letterScoresList.Add(letterScore);
            i++;
        }

        return letterScoresList;
    }
    public bool IsFiveLetters(string guess)
    {
        return guess.Length == 5 && guess.All(Char.IsLetter);
    }

    public bool IsValid(string guess)
    {
        // TODO: Guess should be validated against an actual dictionary
        return IsFiveLetters(guess);
    }
    private Score evaluateLetter(char guessLetter, int i, string answer)
    {
        if (answer[i] == guessLetter)
        {
            return Score.Correct;
        }
        if (answer.Contains(guessLetter))
        {
            return Score.InWord;
        }

        return Score.NotInWord;
    }
}
