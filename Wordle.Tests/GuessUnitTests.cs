using Xunit;
using Wordle.Domain;
namespace Wordle.Tests;


public class GuessUnitTests
{
    public Guess Guess = new Guess();
    public string answer = "ADEPT";

    [Fact]
    public void GuessCount_WhenNoGuessesHaveBeenMade_ShouldEqualZero()
    {
        Assert.Equal(0, Guess.GuessCount);
    }

    [Fact]
    public void GuessArray_WhenNoGuessesHaveBeenMade_ShouldHoldNoGuesses()
    {
        foreach (KeyValuePair<int, WordScore> entry in Guess.Guesses)
        {
            Assert.Null(entry.Value);
        }
    }
    [Fact]
    public void GuessCount_WhenTryUpdateGuessesIsCalledOnce_ShouldEqualOne()
    {
        Guess.UpdateGuesses(answer, "ARBOR");
        Assert.Equal(1, Guess.GuessCount);
    }
    [Fact]
    public void GuessArray_WhenIsGuessesUpdatedIsTrue_ShouldHaveOneWordScoreItem()
    {
        Guess.UpdateGuesses(answer, "ARBOR");

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
    public void GuessCount_WhenIsGuessesUpdatedIsTrueTwice_ShouldEqualTwo()
    {
        Guess.UpdateGuesses(answer, "ARBOR");
        Guess.UpdateGuesses(answer, "GROWN");

        Assert.Equal(2, Guess.GuessCount);
    }
    [Fact]
    public void GuessArray_WhenIsGuessesUpdatedIsTrueTwice_ShouldHaveTwoWordScoreItems()
    {
        Score[] expectedResult = {
            Score.NotInWord,
            Score.NotInWord,
            Score.NotInWord,
            Score.NotInWord,
            Score.NotInWord
        };

        Guess.UpdateGuesses(answer, "ARBOR");
        Guess.UpdateGuesses(answer, "GROWN");

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
    public void EvaluateGuess_WhenOneDuplicateLetterIsCorrectAndOneIsInWord_ShouldReturnCorrectAndInWord()
    {
        var happyGuess = "HAPPY";
        var apply = "APPLY";

        Score[] expectedResult = {
            Score.NotInWord,
            Score.InWord,
            Score.Correct,
            Score.InWord,
            Score.Correct
        };

        var actualResult = Guess.EvaluateGuess(apply, happyGuess);

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
    public void IsValid_WhenGuessIsNotInWordList_ShouldReturnFalse()
    {
        var wordsInDataFile = new string[]
        {
            "RULER",
            "MODEL",
            "AWARD",
            "HOTLY",
            "NICHE",
            "JOUST",
            "ARBOR",
            "EERIE",
            "CARAT",
            "ROUGH"
        };
    var invalidWord = "ABCDE";
    Assert.False(Guess.IsValid(invalidWord, wordsInDataFile));
    }
[Fact]
public void IsValid_WhenGuessIsInWordList_ShouldReturnTrue()
{
    var wordsInDataFile = new string[]
        {
            "RULER",
            "MODEL",
            "AWARD",
            "HOTLY",
            "NICHE",
            "JOUST",
            "ARBOR",
            "EERIE",
            "CARAT",
            "ROUGH"
        };
    var validWord = "MODEL";
    Assert.True(Guess.IsValid(validWord, wordsInDataFile));
}
[Fact]
public void EvaluateGuess_WhenOneLetterIsCorrectAndThereIsADuplicate_ShouldReturnCorrectAndNotInWord()
{
    var duplicateP = "GUPPY"; // ADEPT is answer

    Score[] expectedResult = {
            Score.NotInWord,
            Score.NotInWord,
            Score.NotInWord,
            Score.Correct,
            Score.NotInWord
        };

    var actualResult = Guess.EvaluateGuess(answer, duplicateP);

    foreach (LetterScore ls in actualResult)
    {
        Assert.Equal(expectedResult[ls.Id], ls.Eval);
    }
}
[Fact]
public void EvaluateGuess_PlayerGuessesAllPs_ShouldReturnTwoCorrect()
{
    var happyAnswer = "HAPPY";
    var fivePs = "PPPPP"; // ADEPT is answer

    Score[] expectedResult = {
            Score.NotInWord,
            Score.NotInWord,
            Score.Correct,
            Score.Correct,
            Score.NotInWord
        };

    var actualResult = Guess.EvaluateGuess(happyAnswer, fivePs);

    foreach (LetterScore ls in actualResult)
    {
        Assert.Equal(expectedResult[ls.Id], ls.Eval);
    }
}
[Fact]
public void EvaluateGuess_PlayerGuessesAllNs_ShouldReturnOneCorrect()
{
    var tunisAnswer = "TUNIS";
    var fiveNs = "NNNNN";

    Score[] expectedResult = {
            Score.NotInWord,
            Score.NotInWord,
            Score.Correct,
            Score.NotInWord,
            Score.NotInWord
        };

    var actualResult = Guess.EvaluateGuess(tunisAnswer, fiveNs);

    foreach (LetterScore ls in actualResult)
    {
        Assert.Equal(expectedResult[ls.Id], ls.Eval);
    }
}

[Fact]
public void LetterFrequency_WhenEveryLetterIsInWordOnce_ShouldReturnZero()
{
    // var letterNotInWord = 'G';
    var testWord = "PODLE";

    var actualFrequency = Guess.LetterFrequency(testWord);

    foreach (KeyValuePair<char, int> letter in actualFrequency)
    {
        Assert.Equal(1, letter.Value);
    }
}

[Fact]
public void LetterFrequency_WhenALetterIsInWordTwice_ShouldReturnTwo()
{
    char P = 'P';
    string doubleP = "GUPPY";

    var actualFrequency = Guess.LetterFrequency(doubleP);

    Assert.Equal(2, actualFrequency[P]);
}
[Fact]
public void LetterFrequency_WhenEveryLetterIsTheSame_ShouldReturnFive()
{
    char M = 'M';
    string fiveMs = "MMMMM";

    var actualFrequency = Guess.LetterFrequency(fiveMs);

    Assert.Equal(5, actualFrequency[M]);
}
}

