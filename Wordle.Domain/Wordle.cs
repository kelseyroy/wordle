using System;

namespace Wordle.Domain;
public class Game
{
    public string GetGreeting() => "Hello!";

    public Score[] EvaluateGuess(string answer, string guess)
    {
        Score[] result = {
            Score.NotInWord,
            Score.NotInWord,
            Score.NotInWord,
            Score.NotInWord,
            Score.NotInWord
        };
        int i = 0;
        foreach (char guessLetter in guess.ToUpper())
        {
            if (answer.Contains(guessLetter))
            {
                result[i] = Score.InWord;
                if (answer[i] == guessLetter)
                {
                    result[i] = Score.Correct;
                }
            }
            i++;
        }

        return result;
    }

}
