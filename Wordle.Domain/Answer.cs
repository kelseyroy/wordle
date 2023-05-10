using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Reflection;

namespace Wordle.Domain;

public class Answer
{

    public string[] ReadWordsFile(string filePath)
    {
        Console.WriteLine(filePath);
        string[] words = new string[]{};
        try
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("file does not exist, better error message to come");
            }
            else
            {
                words = File.ReadAllLines(filePath, Encoding.UTF8);
            }

            return words;
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message);
            throw;
        }
    }
}
