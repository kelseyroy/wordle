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
    
}

/*
using System;

namespace Wordle.Domain;
public class Game
{
    private string SecretWord;
    Guess Guess = new Guess();
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
    public string GetAnswer()
    {
        return SecretWord;
    }
    public WordScore[] MakeMove(string playerGuess)
    {
        var letterScoreList = EvaluateGuess(playerGuess);
        Guess.UpdateGuesses(letterScoreList);
        return Guess.Guesses;
    }
    public int GetGuessCount()
    {
        return Guess.GuessCount;
    }
    public GameState IsGameOver(string playerGuess)
    {
        GameState result = GameState.Continue;
        if (Guess.IsWin(playerGuess, SecretWord)) { result = GameState.Win; }
        else if (Guess.IsGuessCountSix()) { result = GameState.Loss; }
        return result;
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
                Eval = evaluateLetter(guessLetter, SecretWord[i], letterScoresList, i, guess)
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
            if (SecretWord.Contains(guessLetter))
            {
                score = Score.InWord;
            }
            if (answerLetter == guessLetter)
            {
                score = Score.Correct;
            }
        }

        if (SecretWord.Contains(guessLetter) && LetterFrequency(guessLetter, guess) > 1)
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



*/