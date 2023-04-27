using Xunit;
using Wordle.Domain;
using static Wordle.Domain.Game;

namespace Wordle.Tests;

public class WordleUnitTests
{
    public static string answer = "ADEPT";

    [Fact]
    public void PassingTest() => Assert.True(true);

    [Fact]
    public void EvaluateGuess_WhenNoLetterIsInWord_ShouldReturnAllNotInWord()
    {
        var guess = "GROWN";
        var game = new Wordle.Domain.Game();
        Score[] expected_result = {
            Score.NotInWord,
            Score.NotInWord,
            Score.NotInWord,
            Score.NotInWord,
            Score.NotInWord
        };

        var actual_result = game.EvaluateGuess(answer, guess);

        Assert.Equal(expected_result, actual_result);
    }

    [Fact]
    public void EvaluateGuess_WhenFirstLetterIsCorrect_ShouldReturnOneCorrect()
    {
        var guess = "ARBOR";
        var game = new Wordle.Domain.Game();
        Score[] expected_result = {
            Score.Correct,
            Score.NotInWord,
            Score.NotInWord,
            Score.NotInWord,
            Score.NotInWord
        };

        var actual_result = game.EvaluateGuess(answer, guess);

        Assert.Equal(expected_result, actual_result);
    }

    [Fact]
    public void EvaluateGuess_WhenFirstLetterIsInWord_ShouldReturnOneInWord()
    {
        var guess = "TOURS";
        var game = new Wordle.Domain.Game();
        Score[] expected_result = {
            Score.InWord,
            Score.NotInWord,
            Score.NotInWord,
            Score.NotInWord,
            Score.NotInWord
        };

        var actual_result = game.EvaluateGuess(answer, guess);

        Assert.Equal(expected_result, actual_result);
    }

    [Fact]
    public void EvaluateGuess_WhenOneLetterIsCorrectAndOneLetterIsInWord_ShouldReturnOneCorrectOneInWord()
    {
        var guess = "AUDIO";
        var game = new Wordle.Domain.Game();
        Score[] expected_result = {
            Score.Correct,
            Score.NotInWord,
            Score.InWord,
            Score.NotInWord,
            Score.NotInWord
        };

        var actual_result = game.EvaluateGuess(answer, guess);

        Assert.Equal(expected_result, actual_result);
    }

    [Fact]
    public void EvaluateGuess_WhenPlayersEnterAnyCase_ShouldStillEvaluateCorrectly()
    {
        var guess = "audio";
        var game = new Wordle.Domain.Game();
        Score[] expected_result = {
            Score.Correct,
            Score.NotInWord,
            Score.InWord,
            Score.NotInWord,
            Score.NotInWord
        };

        var actual_result = game.EvaluateGuess(answer, guess);

        Assert.Equal(expected_result, actual_result);
    }

    [Fact]
    public void EvaluateGuess_WhenAllLettersAreInWord_ShouldReturnAllInWord()
    {
        var guess = "TAPED";
        var game = new Wordle.Domain.Game();
        Score[] expected_result = {
            Score.InWord,
            Score.InWord,
            Score.InWord,
            Score.InWord,
            Score.InWord
        };

        var actual_result = game.EvaluateGuess(answer, guess);

        Assert.Equal(expected_result, actual_result);
    }
    [Fact]
    public void EvaluateGuess_WhenAllLettersAreCorrect_ShouldReturnAllCorrect()
    {
        var guess = "ADEPT";
        var game = new Wordle.Domain.Game();
        Score[] expected_result = {
            Score.Correct,
            Score.Correct,
            Score.Correct,
            Score.Correct,
            Score.Correct
        };

        var actual_result = game.EvaluateGuess(answer, guess);

        Assert.Equal(expected_result, actual_result);
    }
}
