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
        var answerLetterFrequency = LetterFrequency(answer);

        List<LetterScore> tempLettersList = new List<LetterScore>();
        List<LetterScore> letterScoresList = new List<LetterScore>();
        // var answerToCompare = "     ";
        // var guessToCompare = "";

        if (answer == guess)
        {

            for (int i = 0; i < 5; i++)
            {
                var ls = new LetterScore()
                {
                    Id = i,
                    Letter = guess[i],
                    Eval = Score.Correct
                };
                letterScoresList.Add(ls);
            }
            // return letterScoresList;
        }

        for (int i = 0; i < 5; i++)
        {
            if (answer[i] == guess[i])
            {
                var ls = new LetterScore()
                {
                    Id = i,
                    Letter = guess[i],
                    Eval = Score.Correct
                };
                letterScoresList.Add(ls);
                answerLetterFrequency[answer[i]]--;
            }
            else
            {
                tempLettersList.Add(new LetterScore()
                {
                    Id = i,
                    Letter = guess[i],
                    Eval = Score.NotInWord
                });
                // answerToCompare[i] = guess[i];
            }
        }

        foreach (LetterScore ls in tempLettersList)
        {
            if (answerLetterFrequency.ContainsKey(ls.Letter) && answerLetterFrequency[ls.Letter] != 0)
            {
                ls.Eval = Score.InWord;
                answerLetterFrequency[ls.Letter]--;
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
