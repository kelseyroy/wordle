using System;

namespace Wordle.Domain;
public class Game
{
    private string answer;

    public Game(string answer)
    {
        this.answer = answer;
    }

    public List<LetterScore> EvaluateGuess(string guess)
    {
        int i = 0;
        var cleanGuess = guess.ToUpper();

        List<LetterScore> letterScoresList = new List<LetterScore>();
        foreach (char guessLetter in cleanGuess)
        {   
            LetterScore letterScore = new LetterScore()
            {
                Id = i,
                Letter = guessLetter,
                Eval = evaluateLetter(guessLetter, answer[i], letterScoresList, i, cleanGuess)
            };
            letterScoresList.Add(letterScore);
            i++;
        }

        return letterScoresList;
    }
    
    public int LetterFrequency(char letter, string word)
    {
        var letterCount = 0;

        foreach (char wordLetter in word)
        {
            if (wordLetter == letter) { letterCount++; }
        }

        return letterCount;
    }

    private Score evaluateLetter(char guessLetter, char answerLetter, List<LetterScore> letterScoresList, int scorePosition, string guess)
    {
        var score = Score.NotInWord;

        if (LetterFrequency(guessLetter, guess) == 1)
        {
            if (answer.Contains(guessLetter))
            {
                score = Score.InWord;
            }
            if (answerLetter == guessLetter)
            {
                score = Score.Correct;
            } 
        }

        if (answer.Contains(guessLetter) && LetterFrequency(guessLetter, guess) > 1) 
        {
            for (int i = scorePosition; i < guess.Length; i++) 
            {
                if (guess[i] == guessLetter && guess[i] == answerLetter)
                {
                    score = Score.Correct;
                }
            }
        }

        return score;
    }
}
