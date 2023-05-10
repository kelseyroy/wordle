using System;

namespace Wordle.Domain;
public class Game
{
    private string SecretWord;
    public Game(string? word)
    {
        if (word == null)
        {
            string relativePath = "../../../../Wordle.Domain/Data/5_letter_words.txt";
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.GetFullPath(Path.Combine(currentDirectory, relativePath));
            Answer answer = new Answer();
            SecretWord = answer.GetRandomWord(filePath);
        }
        else
        {
            SecretWord = word;
        }

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
                Eval = evaluateLetter(guessLetter, i, SecretWord)
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
