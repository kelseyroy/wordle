using Xunit;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Reflection;
using Wordle.Domain;
namespace Wordle.Tests;

public class AnswerUnitTests
{
    Answer answer = new Answer();
    private static string relativePath = "../../../Data/words_test.txt";
    private static string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
    public static string filePath = Path.GetFullPath(Path.Combine(currentDirectory, relativePath));

    [Fact]
    public void ReadWordsFileIntoList_WhenFilePathIsNotNull_ShouldReturnFileWordsInList()
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
}


// private static string _WordFileName = @"word.txt";
// public static string CurrentPath
// {
//     get
// }"Wordle.Test.Data.words_test.txt"
