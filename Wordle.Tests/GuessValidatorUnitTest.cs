using Xunit;
using Wordle.Domain;

namespace Wordle.Tests;

public class GuessValidatorUnitTest
{
    Wordle.Domain.GuessValidator guessValidator = new Wordle.Domain.GuessValidator();

    [Fact]
    public void IsFiveLetters_WhenGuessIsEmpty_ShouldReturnFalse()
    {
        var emptyStringGuess = "";
        Assert.False(guessValidator.IsFiveLetters(emptyStringGuess));
    }

    [Fact]
    public void IsFiveLetters_WhenGuessIsLessThanFiveLetters_ShouldReturnFalse()
    {
        var lessThanFiveLetterGuess = "FOUR";
        Assert.False(guessValidator.IsFiveLetters(lessThanFiveLetterGuess));
    }

    [Fact]
    public void IsFiveLetters_WhenGuessIsMoreThanFiveLetters_ShouldReturnFalse()
    {
        var moreThanFiveLetterGuess = "SUPERCALIFRAGILISTICEXPIALIDOCIOUS";
        Assert.False(guessValidator.IsFiveLetters(moreThanFiveLetterGuess));
    }

    [Fact]
    public void IsFiveLetters_WhenGuessIsExactlyFiveLetters_ShouldReturnTrue()
    {
        var fiveLetterGuess = "ADEPT";
        Assert.True(guessValidator.IsFiveLetters(fiveLetterGuess));
    }

    [Fact]
    public void IsValid_WhenGuessIsAnyFiveLetters_ShouldReturnTrue()
    {
        var fiveLetterGuess = "ABCDE";
        Assert.True(guessValidator.IsValid(fiveLetterGuess));
    }

    [Fact]
    public void IsValid_WhenGuessHasNumericCharacter_ShouldReturnFalse()
    {
        var leetSpeakGuess = "H4X0R";
        Assert.False(guessValidator.IsValid(leetSpeakGuess));
    }
}
