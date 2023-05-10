using Wordle.Domain;

namespace Wordle.Tests;

public class GuessStatisticsUnitTests
{
    public static string answer = "ADEPT";
    public static Game game = new Game(answer);
    GuessStatistics guessStatistics = new GuessStatistics();
    public static List<Domain.LetterScore> guessOne = game.EvaluateGuess("GROWN");
    public static List<Domain.LetterScore> guessTwo = game.EvaluateGuess("GROWN");
    private void TwoGuesses()
    {
        guessStatistics.UpdateGuessStatistics(guessOne);
        guessStatistics.UpdateGuessStatistics(guessTwo);
    }
    [Fact]
    public void GuessCount_WhenNoGuessesHaveBeenMade_ShouldEqualcsZero()
    {
        Assert.Equal(0, guessStatistics.GuessCount);
    }
    [Fact]
    public void GuessArray_WhenNoGuessesHaveBeenMade_ShouldHoldNoGuesses()
    {
        foreach (Domain.WordScore item in guessStatistics.GuessArray)
        {
            Assert.Null(item);
        }
    }
    [Fact]
    public void GuessCount_WhenUpdateGuessStatisticsIsCalledOnce_ShouldEqualOne()
    {
        guessStatistics.UpdateGuessStatistics(guessOne);

        Assert.Equal(1, guessStatistics.GuessCount);
    }
    [Fact]
    public void GuessArray_WhenUpdateGuessStatisticsIsCalledOnce_ShouldHaveOneWordScoreItem()
    {
        var expectedResult = game.EvaluateGuess("ARBOR");
        guessStatistics.UpdateGuessStatistics(expectedResult);
        var actualResult = guessStatistics.GuessArray[0].LetterScores;
        Assert.Equal(expectedResult, actualResult);
    }
    [Fact]
    public void GuessCount_WhenUpdateGuessStatisticsIsCalledTwice_ShouldEqualTwo()
    {
        TwoGuesses();

        Assert.Equal(2, guessStatistics.GuessCount);
    }
    [Fact]
    public void GuessArray_WhenUpdateGuessStatisticsIsCalledTwice_ShouldHaveTwoWordScoreItems()
    {
        var expectedResult = guessTwo;
        TwoGuesses();
        var actualResult = guessStatistics.GuessArray[1].LetterScores;

        Assert.Equal(expectedResult, actualResult);
    }
}
