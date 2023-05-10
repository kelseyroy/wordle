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
    // public static string path = Path.Combine(Environment.CurrentDirectory, "/Wordle.Tests/Data/words_test.txt");
    // public static String exePath = new Uri(Assembly.GetExecutingAssembly().Location).LocalPath;
    public static string filePath = "/Users/kroy/git/wordle/Wordle.Tests/Data/words_test.txt";
            //  Environment.CurrentDirectory;
    public static string currentDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
    public static string path = Path.Combine(currentDirectory, filePath);
    // public static string path = Path.Combine(Environment.CurrentDirectory, "Wordle.Tests/Data/words_test.txt");

// public static string fileName = @"/Users/praveen/Desktop/images\November.pdf";  
    // FileInfo fi = new FileInfo(fileName); 
    // public static string relativePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString();
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
