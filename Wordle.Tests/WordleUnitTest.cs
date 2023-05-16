using Xunit;
using Wordle.Domain;

namespace Wordle.Tests;

public class WordleUnitTests
{
    public static string answer = "ADEPT";

    Game game = new Game(answer);

    [Fact]
    public void IsMoveAccepted_WhenPlayerMakesInvalidGuess_ShouldNotReturnGuessesDictionary()
    {
        var fourLetterGuess = "FOUR";
        Dictionary<int, WordScore>? shouldBeNull = null;
        Assert.False(game.IsMoveAccepted(fourLetterGuess, out shouldBeNull));
        Assert.Null(shouldBeNull);
    }
    [Fact]
    public void IsMoveAccepted_WhenPlayerMakesValidGuess_ShouldUpdateGuessesDictionary()
    {
        var validGuess = "GROWN";
        var result = new Dictionary<int, WordScore>(1);
        Assert.True(game.IsMoveAccepted(validGuess, out result));
        bool? isAdded = result.ContainsKey(0);
        Assert.True(isAdded);
    }
    [Fact]
    public void IsMoveAccepted_WhenPlayerMakesTwoValidGuesses_ShouldUpdateGuessesDictionary()
    {
        var validGuessOne = "GROWN";
        var validGuessTwo = "GUPPY";
        var twoValidWords = new Dictionary<int, WordScore>(2);
        Assert.True(game.IsMoveAccepted(validGuessOne, out twoValidWords));
        bool? isAdded = twoValidWords.ContainsKey(0);
        Assert.True(twoValidWords.ContainsKey(0));
        Assert.True(game.IsMoveAccepted(validGuessTwo, out twoValidWords));
        Assert.True(twoValidWords.ContainsKey(1));
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
        while (i < 6)
        {
            game.IsMoveAccepted(wrongGuess, out Dictionary<int, WordScore>? result);
            i++;
        }
        Assert.Equal(GameState.Lost, game.EvaluateGameState(wrongGuess));
    }
}
