using System;

namespace Wordle.Domain;
public class Game
{
    List<string> guesses = new List<string>();
    public string Board(List<string> guesses) 
    {
        string upperBoardString = "╔═══╦═══╦═══╦═══╦═══╗";
        string middleBoardString = "╠═══╬═══╬═══╬═══╬═══╣";
        string endBoardString = "╚═══╩═══╩═══╩═══╩═══╝";
        string sideBoardString = "║";

        string emptyBoard = @"
 ╔═══╦═══╦═══╦═══╦═══╗
 ║   ║   ║   ║   ║   ║
 ╠═══╬═══╬═══╬═══╬═══╣
 ║   ║   ║   ║   ║   ║
 ╠═══╬═══╬═══╬═══╬═══╣
 ║   ║   ║   ║   ║   ║
 ╠═══╬═══╬═══╬═══╬═══╣
 ║   ║   ║   ║   ║   ║
 ╠═══╬═══╬═══╬═══╬═══╣
 ║   ║   ║   ║   ║   ║
 ╠═══╬═══╬═══╬═══╬═══╣
 ║   ║   ║   ║   ║   ║
 ╚═══╩═══╩═══╩═══╩═══╝
 ";
            return emptyBoard;
    }
        


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

