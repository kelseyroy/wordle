using Xunit;
using Wordle.Domain;
using static Wordle.Domain.Game;

namespace Wordle.Tests;

public class WordleUnitTests
{
    public static string answer = "ADEPT";

    Wordle.Domain.Game game = new Wordle.Domain.Game();


    [Fact]
    public void EvaluateGuess_WhenNoLetterIsInWord_ShouldReturnAllNotInWord()
    {
        var incorrectGuess = new Guess()
        {
            Number = 1,
            Word = "GROWN"
        };

        Score[] expectedResult = {
            Score.NotInWord,
            Score.NotInWord,
            Score.NotInWord,
            Score.NotInWord,
            Score.NotInWord
        };

        var actualResult = game.EvaluateGuess(answer, incorrectGuess);

        foreach (LetterScore ls in actualResult)
        {
            Assert.Equal(expectedResult[ls.Id], ls.Eval);
        }
    }

    [Fact]
    public void EvaluateGuess_WhenFirstLetterIsCorrect_ShouldReturnOneCorrect()
    {
        var guessWithFirstLetterCorrect = new Guess()
        {
            Number = 2,
            Word = "ARBOR"
        };

        Score[] expectedResult = {
            Score.Correct,
            Score.NotInWord,
            Score.NotInWord,
            Score.NotInWord,
            Score.NotInWord
        };

        var actualResult = game.EvaluateGuess(answer, guessWithFirstLetterCorrect);

        foreach (LetterScore ls in actualResult)
        {
            Assert.Equal(expectedResult[ls.Id], ls.Eval);
        }
    }

    [Fact]
    public void EvaluateGuess_WhenFirstLetterIsInWord_ShouldReturnOneInWord()
    {
        var guessWithFirstLetterInWord = new Guess()
        {
            Number = 3,
            Word = "TOURS"
        };

        Score[] expectedResult = {
            Score.InWord,
            Score.NotInWord,
            Score.NotInWord,
            Score.NotInWord,
            Score.NotInWord
        };

        var actualResult = game.EvaluateGuess(answer, guessWithFirstLetterInWord);

        foreach (LetterScore ls in actualResult)
        {
            Assert.Equal(expectedResult[ls.Id], ls.Eval);
        }
    }

    [Fact]
    public void EvaluateGuess_WhenOneLetterIsCorrectAndOneLetterIsInWord_ShouldReturnOneCorrectOneInWord()
    {
        var guessWithOneCorrectAndOneInWord = new Guess()
        {
            Number = 4,
            Word = "AUDIO"
        };

        Score[] expectedResult = {
            Score.Correct,
            Score.NotInWord,
            Score.InWord,
            Score.NotInWord,
            Score.NotInWord
        };

        var actualResult = game.EvaluateGuess(answer, guessWithOneCorrectAndOneInWord);

        foreach (LetterScore ls in actualResult)
        {
            Assert.Equal(expectedResult[ls.Id], ls.Eval);
        }
    }

    [Fact]
    public void EvaluateGuess_WhenPlayersEnterAnyCase_ShouldStillEvaluateCorrectly()
    {
        var guessLowerCase = new Guess()
        {
            Number = 4,
            Word = "audio"
        };

        Score[] expectedResult = {
            Score.Correct,
            Score.NotInWord,
            Score.InWord,
            Score.NotInWord,
            Score.NotInWord
        };

        var actualResult = game.EvaluateGuess(answer, guessLowerCase);

        foreach (LetterScore ls in actualResult)
        {
            Assert.Equal(expectedResult[ls.Id], ls.Eval);
        }
    }

    [Fact]
    public void EvaluateGuess_WhenAllLettersAreInWord_ShouldReturnAllInWord()
    {
        var guessAllLettersInWord = new Guess()
        {
            Number = 5,
            Word = "TAPED"
        };

        Score[] expectedResult = {
            Score.InWord,
            Score.InWord,
            Score.InWord,
            Score.InWord,
            Score.InWord
        };

        var actualResult = game.EvaluateGuess(answer, guessAllLettersInWord);

        foreach (LetterScore ls in actualResult)
        {
            Assert.Equal(expectedResult[ls.Id], ls.Eval);
        }
    }
    [Fact]
    public void EvaluateGuess_WhenAllLettersAreCorrect_ShouldReturnAllCorrect()
    {
        var correctGuess = new Guess()
        {
            Number = 6,
            Word = "ADEPT"
        };

        Score[] expectedResult = {
            Score.Correct,
            Score.Correct,
            Score.Correct,
            Score.Correct,
            Score.Correct
        };

        var actualResult = game.EvaluateGuess(answer, correctGuess);

        foreach (LetterScore ls in actualResult)
        {
            Assert.Equal(expectedResult[ls.Id], ls.Eval);
        }
    }
}
