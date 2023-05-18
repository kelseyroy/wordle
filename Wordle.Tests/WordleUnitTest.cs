using Xunit;
using Wordle.Domain;

namespace Wordle.Tests;

public class WordleUnitTests
{
    public static string answer = "ADEPT";

    Game game = new Game(answer);

    [Fact]
    public void CanGuessBePlayed_WhenPlayerMakesInvalidGuess_ShouldReturnFalse()
    {
        var fourLetterGuess = "FOUR";
        Assert.False(game.CanGuessBePlayed(fourLetterGuess));
    }
    [Fact]
    public void CanGuessBePlayed_WhenGuessIsNotInWordList_ShouldReturnFalse()
    {
        var fourLetterGuess = "ABCDE";
        Assert.False(game.CanGuessBePlayed(fourLetterGuess));
    }
    [Fact]
    public void CanGuessBePlayed_WhenGuessIsInWordListAndValid_ShouldReturnTrue()
    {
        var fourLetterGuess = "OCEAN";
        Assert.True(game.CanGuessBePlayed(fourLetterGuess));
    }
    [Fact]
    public void MakeMove_WhenPlayerMakesValidGuess_ShouldUpdateGuessesDictionary()
    {
        var validGuess = "GROWN";
        var result = game.MakeMove(validGuess);
        bool isAdded = result.ContainsKey(0);
        Assert.True(isAdded);
    }
    [Fact]
    public void MakeMove_WhenPlayerMakesTwoValidGuesses_ShouldUpdateGuessesDictionary()
    {
        var validGuessOne = "GROWN";
        var validGuessTwo = "GUPPY";
        var result = new Dictionary<int, WordScore>(2);
        result = game.MakeMove(validGuessOne);
        result = game.MakeMove(validGuessTwo);
        bool isAdded = result.ContainsKey(0);
        Assert.True(result.ContainsKey(0));
        Assert.True(result.ContainsKey(1));
        Assert.NotNull(result);
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
            game.MakeMove(wrongGuess);
            i++;
        }
        Assert.Equal(GameState.Lost, game.EvaluateGameState(wrongGuess));
    }
}
