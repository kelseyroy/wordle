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
    private string[] wordsInDataFile = new string[]
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
    [Fact]
    public void ReadWordsFile_WhenFilePathIsNotNull_ShouldReturnFileWordsArray()
    {

        var actualResult = answer.ReadWordsFile(filePath);
        bool isEqualLists = wordsInDataFile.All(actualResult.Contains) && actualResult.All(wordsInDataFile.Contains);

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
        bool isRandomWordFromDataFile = Array.Exists(wordsInDataFile, element => element == randomWord);

        Assert.True(isRandomWordFromDataFile);
    }
}
