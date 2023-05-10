using Xunit;
using Wordle.Domain;

namespace Wordle.Tests;

public class WordleUnitTests
{
    public static string answer = "ADEPT";

    Game game = new Game(answer);


    [Fact]
    public void EvaluateGuess_WhenNoLetterIsInWord_ShouldReturnAllNotInWord()
    {
        var incorrectGuess = "GROWN";

        Score[] expectedResult = {
            Score.NotInWord,
            Score.NotInWord,
            Score.NotInWord,
            Score.NotInWord,
            Score.NotInWord
        };

        var actualResult = game.EvaluateGuess(incorrectGuess);

        foreach (LetterScore ls in actualResult)
        {
            Assert.Equal(expectedResult[ls.Id], ls.Eval);
        }
    }

    [Fact]
    public void EvaluateGuess_WhenFirstLetterIsCorrect_ShouldReturnOneCorrect()
    {
        var guessWithFirstLetterCorrect = "ARBOR";

        Score[] expectedResult = {
            Score.Correct,
            Score.NotInWord,
            Score.NotInWord,
            Score.NotInWord,
            Score.NotInWord
        };

        var actualResult = game.EvaluateGuess(guessWithFirstLetterCorrect);

        foreach (LetterScore ls in actualResult)
        {
            Assert.Equal(expectedResult[ls.Id], ls.Eval);
        }
    }

    [Fact]
    public void EvaluateGuess_WhenFirstLetterIsInWord_ShouldReturnOneInWord()
    {
        var guessWithFirstLetterInWord = "TOURS";

        Score[] expectedResult = {
            Score.InWord,
            Score.NotInWord,
            Score.NotInWord,
            Score.NotInWord,
            Score.NotInWord
        };

        var actualResult = game.EvaluateGuess(guessWithFirstLetterInWord);

        foreach (LetterScore ls in actualResult)
        {
            Assert.Equal(expectedResult[ls.Id], ls.Eval);
        }
    }

    [Fact]
    public void EvaluateGuess_WhenOneLetterIsCorrectAndOneLetterIsInWord_ShouldReturnOneCorrectOneInWord()
    {
        var guessWithOneCorrectAndOneInWord = "AUDIO";

        Score[] expectedResult = {
            Score.Correct,
            Score.NotInWord,
            Score.InWord,
            Score.NotInWord,
            Score.NotInWord
        };

        var actualResult = game.EvaluateGuess(guessWithOneCorrectAndOneInWord);

        foreach (LetterScore ls in actualResult)
        {
            Assert.Equal(expectedResult[ls.Id], ls.Eval);
        }
    }

    [Fact]
    public void EvaluateGuess_WhenPlayersEnterAnyCase_ShouldStillEvaluateCorrectly()
    {
        var guessLowerCase = "audio";

        Score[] expectedResult = {
            Score.Correct,
            Score.NotInWord,
            Score.InWord,
            Score.NotInWord,
            Score.NotInWord
        };

        var actualResult = game.EvaluateGuess(guessLowerCase);

        foreach (LetterScore ls in actualResult)
        {
            Assert.Equal(expectedResult[ls.Id], ls.Eval);
        }
    }

    [Fact]
    public void EvaluateGuess_WhenAllLettersAreInWord_ShouldReturnAllInWord()
    {
        var guessAllLettersInWord = "TAPED";

        Score[] expectedResult = {
            Score.InWord,
            Score.InWord,
            Score.InWord,
            Score.InWord,
            Score.InWord
        };

        var actualResult = game.EvaluateGuess(guessAllLettersInWord);

        foreach (LetterScore ls in actualResult)
        {
            Assert.Equal(expectedResult[ls.Id], ls.Eval);
        }
    }
    [Fact]
    public void EvaluateGuess_WhenAllLettersAreCorrect_ShouldReturnAllCorrect()
    {
        var correctGuess = "ADEPT";

        Score[] expectedResult = {
            Score.Correct,
            Score.Correct,
            Score.Correct,
            Score.Correct,
            Score.Correct
        };

        var actualResult = game.EvaluateGuess(correctGuess);

        foreach (LetterScore ls in actualResult)
        {
            Assert.Equal(expectedResult[ls.Id], ls.Eval);
        }
    }
}
