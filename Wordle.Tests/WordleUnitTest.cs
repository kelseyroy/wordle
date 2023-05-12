using Xunit;
using Wordle.Domain;

namespace Wordle.Tests;

public class WordleUnitTests
{
    public static string answer = "ADEPT";

    Game game = new Game(answer);

    [Fact]
    public void MakeMove_WhenPlayerMakesInvalidGuess_ShouldNotReturnWordScoreArray()
    {
        var fourLetterGuess = "FOUR";
        Assert.Null(game.MakeMove(fourLetterGuess));
    }
    [Fact]
    public void MakeMove_WhenPlayerMakesValidGuess_ShouldUpdateWordScoreArray()
    {
        var validGuess = "GROWN";
        var makeMove = game.MakeMove(validGuess);

        int result = makeMove.Count(ws => ws != null);
        Assert.True(result == 1);
    }
    [Fact]
    public void MakeMove_WhenPlayerMakesTwoValidGuesses_ShouldUpdateWordScoreArray()
    {
        var validGuessOne = "GROWN";
        var validGuessTwo = "GUPPY";
        game.MakeMove(validGuessOne);
        var makeSecondMove = game.MakeMove(validGuessTwo);

        int result = makeSecondMove.Count(ws => ws != null);
        Assert.True(result == 2);
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
