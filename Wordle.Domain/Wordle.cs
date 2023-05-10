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

        List<LetterScore> letterScoresList = new List<LetterScore>();
        foreach (char guessLetter in guess.ToUpper())
        {   
            LetterScore letterScore = new LetterScore()
            {
                Id = i,
                Letter = guessLetter,
                Eval = evaluateLetter(guessLetter, answer[i], letterScoresList, i)
            };
            letterScoresList.Add(letterScore);
            i++;
        }

        return letterScoresList;
    }
    
    public int LetterFrequency(char guessLetter)
    {
        var letterCount = 0;

        foreach (char answerLetter in answer)
        {
            if (answerLetter == guessLetter) { letterCount++; }
        }

        return letterCount;
    }

    private Score evaluateLetter(char guessLetter, char answerLetter, List<LetterScore> letterScoresList, int scorePosition)
    {
        if (answerLetter == guessLetter)
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
