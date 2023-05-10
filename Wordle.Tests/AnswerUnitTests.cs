using Wordle.Domain;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Wordle.Tests;

public class AnswerUnitTests
{
    Answer answer = new Answer();
    private static string relativePath = "../../../Data/5_letter_words_test.txt";
    private static string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
    public static string filePath = Path.GetFullPath(Path.Combine(currentDirectory, relativePath));
    [Fact]
    public void ReadWordsFile_WhenFilePathIsNotNull_ShouldReturnFileWordsArray()
    {
        string[] expectedResult = new string[]
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

        var actualResult = answer.ReadWordsFile(filePath);
        bool isEqualLists = expectedResult.All(actualResult.Contains) && actualResult.All(expectedResult.Contains);

        Assert.True(isEqualLists);
    }
    [Fact]
    public void ReadWordsFile_WhenFilePathDoesNotExist_ShouldThrowException()
    {
        var relativePathToWrongFile = "../../../Data/nonexistent_file.txt";
        var wrongFilePath = Path.GetFullPath(Path.Combine(currentDirectory, relativePathToWrongFile));

        Assert.Throws<FileNotFoundException>(() => answer.ReadWordsFile(wrongFilePath));
    }
    [Fact]
    public void GetRandomWord_ShouldReturnWordFromWordsFile()
    {
        var randomWord = answer.GetRandomWord(filePath);
        string[] wordsArray = new string[]
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

        bool isRandomWordFromWordsArray = Array.Exists(wordsArray, element => element == randomWord);
        Assert.True(isRandomWordFromWordsArray);
    }
}
