using Xunit;
using Wordle.Domain;
namespace Wordle.Tests;


public class GuessUnitTests
{
    public Guess Guess = new Guess();
    public string answer = "ADEPT";

    [Fact]
    public void GuessCount_WhenNoGuessesHaveBeenMade_ShouldEqualcsZero()
    {
        Assert.Equal(0, Guess.GuessCount);
    }

    [Fact]
    public void GuessArray_WhenNoGuessesHaveBeenMade_ShouldHoldNoGuesses()
    {
        foreach (WordScore item in Guess.Guesses)
        {
            Assert.Null(item);
        }
    }
    [Fact]
    public void GuessCount_WhenUpdateGuessStatisticsIsCalledOnce_ShouldEqualOne()
    {
        List<LetterScore> guessOne = Guess.EvaluateGuess(answer, "ARBOR");

        Guess.UpdateGuesses(guessOne);

        Assert.Equal(1, Guess.GuessCount);
    }
    [Fact]
    public void GuessArray_WhenUpdateGuessStatisticsIsCalledOnce_ShouldHaveOneWordScoreItem()
    {
        List<LetterScore> guessOne = Guess.EvaluateGuess(answer, "ARBOR");
        Guess.UpdateGuesses(guessOne);

        var actualResult = Guess.Guesses[0].LetterScores;

        Score[] expectedResult = {
            Score.Correct,
            Score.NotInWord,
            Score.NotInWord,
            Score.NotInWord,
            Score.NotInWord
        };

        foreach (LetterScore ls in actualResult)
        {
            Assert.Equal(expectedResult[ls.Id], ls.Eval);
        }
    }
    [Fact]
    public void GuessCount_WhenUpdateGuessStatisticsIsCalledTwice_ShouldEqualTwo()
    {
        List<LetterScore> guessOne = Guess.EvaluateGuess(answer, "ARBOR");
        List<LetterScore> guessTwo = Guess.EvaluateGuess(answer, "GROWN");

        Guess.UpdateGuesses(guessOne);
        Guess.UpdateGuesses(guessTwo);

        Assert.Equal(2, Guess.GuessCount);
    }
    [Fact]
    public void GuessArray_WhenUpdateGuessStatisticsIsCalledTwice_ShouldHaveTwoWordScoreItems()
    {
        Score[] expectedResult = {
            Score.NotInWord,
            Score.NotInWord,
            Score.NotInWord,
            Score.NotInWord,
            Score.NotInWord
        };

        List<LetterScore> guessOne = Guess.EvaluateGuess(answer, "ARBOR");
        List<LetterScore> guessTwo = Guess.EvaluateGuess(answer, "GROWN");

        Guess.UpdateGuesses(guessOne);
        Guess.UpdateGuesses(guessTwo);

        var actualResult = Guess.Guesses[1].LetterScores;

        foreach (LetterScore ls in actualResult)
        {
            Assert.Equal(expectedResult[ls.Id], ls.Eval);
        }
    }
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

        var actualResult = Guess.EvaluateGuess(answer, incorrectGuess);

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

        var actualResult = Guess.EvaluateGuess(answer, guessWithFirstLetterCorrect);

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

        var actualResult = Guess.EvaluateGuess(answer, guessWithFirstLetterInWord);

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

        var actualResult = Guess.EvaluateGuess(answer, guessWithOneCorrectAndOneInWord);

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

        var actualResult = Guess.EvaluateGuess(answer, guessLowerCase);

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

        var actualResult = Guess.EvaluateGuess(answer, guessAllLettersInWord);

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

        var actualResult = Guess.EvaluateGuess(answer, correctGuess);

        foreach (LetterScore ls in actualResult)
        {
            Assert.Equal(expectedResult[ls.Id], ls.Eval);
        }
    }
    [Fact]
    public void IsFiveLetters_WhenGuessIsEmpty_ShouldReturnFalse()
    {
        var emptyStringGuess = "";
        Assert.False(Guess.IsFiveLetters(emptyStringGuess));
    }

    [Fact]
    public void IsFiveLetters_WhenGuessIsLessThanFiveLetters_ShouldReturnFalse()
    {
        var lessThanFiveLetterGuess = "FOUR";
        Assert.False(Guess.IsFiveLetters(lessThanFiveLetterGuess));
    }

    [Fact]
    public void IsFiveLetters_WhenGuessIsMoreThanFiveLetters_ShouldReturnFalse()
    {
        var moreThanFiveLetterGuess = "SUPERCALIFRAGILISTICEXPIALIDOCIOUS";
        Assert.False(Guess.IsFiveLetters(moreThanFiveLetterGuess));
    }

    [Fact]
    public void IsFiveLetters_WhenGuessIsExactlyFiveLetters_ShouldReturnTrue()
    {
        var fiveLetterGuess = "ADEPT";
        Assert.True(Guess.IsFiveLetters(fiveLetterGuess));
    }

    [Fact]
    public void IsFiveLetters_WhenGuessHasNumericCharacter_ShouldReturnFalse()
    {
        var leetSpeakGuess = "H4X0R";
        Assert.False(Guess.IsFiveLetters(leetSpeakGuess));
    }

    [Fact]
    public void IsValid_WhenGuessIsAnyFiveLetters_ShouldReturnTrue()
    {
        var fiveLetterGuess = "ABCDE";
        Assert.True(Guess.IsValid(fiveLetterGuess));
    }

}

