using System;

namespace Wordle.Domain;
public class Game
{
    // create a letter score


    public List<LetterScore> EvaluateGuess(string answer, Guess guess)
    {
        int i = 0;

        List<LetterScore> letterScoresList = new List<LetterScore>();
        foreach (char guessLetter in guess.Word.ToUpper())
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
