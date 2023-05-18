namespace Wordle.Domain;

public class Guess
{
    public Dictionary<int, WordScore> Guesses = new Dictionary<int, WordScore>(6);
    public int GuessCount = 0;
    public bool IsGuessesUpdated(string answer, string guess)
    {
        if (IsValid(guess))
        {
            GuessCount++;
            WordScore wordScore = new WordScore()
            {
                GuessNumber = GuessCount,
                LetterScores = EvaluateGuess(answer, guess)
            };
            return Guesses.TryAdd((GuessCount - 1), wordScore);
        }
        return false;
    }
    public List<LetterScore> EvaluateGuess(string answer, string guess)
    {
        List<LetterScore> tempLettersList = new List<LetterScore>();

        List<LetterScore> letterScoresList = new List<LetterScore>();
        var editedAnswer = answer.ToUpper();
        var editedGuess = guess.ToUpper();

        if (editedAnswer == editedGuess)
        {

            for (int i = 0; i < 5; i++)
            {
                var ls = new LetterScore()
                {
                    Id = i,
                    Letter = editedGuess[i],
                    Eval = Score.Correct
                };
                letterScoresList.Add(ls);
            }
            // return letterScoresList;
        }

        for (int i = 0; i < 5; i++)
        {
            if (editedAnswer[i] == editedGuess[i])
            {
                var ls = new LetterScore()
                {
                    Id = i,
                    Letter = editedGuess[i],
                    Eval = Score.Correct
                };
                letterScoresList.Add(ls);
                editedAnswer.Remove(i, 1);
            }
            else
            {
                tempLettersList.Add(new LetterScore()
                {
                    Id = i,
                    Letter = editedGuess[i],
                    Eval = Score.NotInWord
                });
            }
        }

        foreach (LetterScore ls in tempLettersList)
        {
            if (editedAnswer.Contains(ls.Letter))
            {
                ls.Eval = Score.InWord;
                // letterScoresList.Add(ls);
            }
            letterScoresList.Add(ls);
        }
        return letterScoresList;
    }
    public Dictionary<char, int> LetterFrequency(string word)
    {
        Dictionary<char, int> frequencyMap = new Dictionary<char, int>();
        foreach (char letter in word)
        {
            if (frequencyMap.ContainsKey(letter))
            {
                frequencyMap[letter]++;
            }
            else
            {
                frequencyMap[letter] = 1;
            }
        }
        return frequencyMap;
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
