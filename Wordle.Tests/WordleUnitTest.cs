using Xunit;
using Wordle.Domain;
using static Wordle.Domain.Game;


namespace Wordle.Tests;

public class WordleUnitTests
{
    public static string answer = "APPLY";


    [Fact]
    public void PassingTest() => Assert.True(true);

    [Fact]
    public void EvaluateGuess_ShouldReturnAllNotInWordNoLetterIsInWord(){
        var guess = "GROUT";
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
}
