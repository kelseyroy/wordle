﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

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
    // public WordScore[]? MakeMove(string playerGuess)
    // {
    //     if (Guess.IsValid(playerGuess))
    //     {
    //         Guess.UpdateGuesses(SecretWord, playerGuess);
    //         return Guess.Guesses;
    //     }
    //     else
    //     {
    //         return null;
    //     }
    // }
    public bool TryMakeMove(string playerGuess, out Dictionary<int,WordScore>? value)
    {
        value = default;

        if (Guess.TryUpdateGuesses(SecretWord, playerGuess))
        {
            value = Guess.Guesses;
            return true;
        }
        else
        {
            return false;
        }
    }
    public GameState EvaluateGameState(string playerGuess)
    {
        GameState result = GameState.Playing;
        if (IsWin(playerGuess)) { result = GameState.Won; }
        else if (IsGuessCountSix()) { result = GameState.Lost; }
        return result;
    }

    private bool IsWin(string guess)
    {
        return guess == SecretWord;
    }
    private bool IsGuessCountSix()
    {
        return Guess.GuessCount == 6;
    }
}
