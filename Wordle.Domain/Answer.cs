namespace Wordle.Domain;

public class Answer
{
    public string GetRandomWord(string filePath)
    {
        var words = ReadWordsFile(filePath);
        var i = new Random().Next(words.Length);

        return words[i];
    }
    public string[] ReadWordsFile(string filePath)
    {
        string[] words = new string[] { };
        try
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("This file was not found", filePath);
            }
            else
            {
                words = File.ReadAllLines(filePath);
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
