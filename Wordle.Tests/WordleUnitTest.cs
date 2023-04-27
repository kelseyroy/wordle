using Xunit;
using Wordle.Domain;

namespace Wordle.Tests;

public class EvaluateGuess
{
    public static string answer = "ADEPT";

    Wordle.Domain.Game game = new Wordle.Domain.Game();


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

        var actualResult = game.EvaluateGuess(answer, incorrectGuess);

        Assert.Equal(expectedResult, actualResult);
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

        var actualResult = game.EvaluateGuess(answer, guessWithFirstLetterCorrect);

        Assert.Equal(expectedResult, actualResult);
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

        var actualResult = game.EvaluateGuess(answer, guessWithFirstLetterInWord);

        Assert.Equal(expectedResult, actualResult);
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

        var actualResult = game.EvaluateGuess(answer, guessWithOneCorrectAndOneInWord);

        Assert.Equal(expectedResult, actualResult);
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

        var actualResult = game.EvaluateGuess(answer, guessLowerCase);

        Assert.Equal(expectedResult, actualResult);
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

        var actualResult = game.EvaluateGuess(answer, guessAllLettersInWord);

        Assert.Equal(expectedResult, actualResult);
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

        var actualResult = game.EvaluateGuess(answer, correctGuess);

        Assert.Equal(expectedResult, actualResult);
    }
}
