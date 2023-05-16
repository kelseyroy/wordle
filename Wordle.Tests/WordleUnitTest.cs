using Xunit;
using Wordle.Domain;

namespace Wordle.Tests;

public class WordleUnitTests
{
    public static string answer = "ADEPT";

    Game game = new Game(answer);

    [Fact]
    public void TryMakeMove_WhenPlayerMakesInvalidGuess_ShouldNotReturnGuessesDictionary()
    {
        var fourLetterGuess = "FOUR";
        Dictionary<int,WordScore>? shouldBeNull = null;
        Assert.False(game.TryMakeMove(fourLetterGuess, out shouldBeNull));
        Assert.Null(shouldBeNull);
    }
    [Fact]
    public void TryMakeMove_WhenPlayerMakesValidGuess_ShouldUpdateGuessesDictionary()
    {
        var validGuess = "GROWN";
        var result = new Dictionary<int,WordScore>(1);
        Assert.True(game.TryMakeMove(validGuess, out result));
        // bool? isAdded = result.ContainsKey(0);
        Assert.NotNull(result);
    }
    [Fact]
    public void TryMakeMove_WhenPlayerMakesTwoValidGuesses_ShouldUpdateGuessesDictionary()
    {
        var validGuessOne = "GROWN";
        var validGuessTwo = "GUPPY";
        var twoValidWords =  new Dictionary<int,WordScore>(2);
        Assert.True(game.TryMakeMove(validGuessOne, out twoValidWords));
        Assert.True(game.TryMakeMove(validGuessTwo, out twoValidWords));
        Assert.NotNull(twoValidWords);
    }

    [Fact]
    public void EvaluateGameState_WhenGuessDoesNotEqualAnswer_ShouldReturnPlaying()
    {
        var wrongGuess = "ADAPT";
        Assert.Equal(GameState.Playing, game.EvaluateGameState(wrongGuess));
    }
    [Fact]
    public void EvaluateGameState_WhenGuessEqualsAnswer_ShouldReturnWon()
    {
        Assert.Equal(GameState.Won, game.EvaluateGameState(answer));
    }

    [Fact]
    public void EvaluateGameState_WhenPlayerMakesSixWrongGuesses_ShouldReturnLost()
    {
        var wrongGuess = "WRONG";
        int i = 0;
        Dictionary<int,WordScore>? result =  new Dictionary<int,WordScore>(6);
        while (i < 6)
        {
            game.TryMakeMove(wrongGuess, out result);
            i++;
        }
        Assert.Equal(GameState.Lost, game.EvaluateGameState(wrongGuess));
    }
}
