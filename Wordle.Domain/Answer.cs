namespace Wordle.Domain;

public class Answer
{
    public string[] ReadWordsFile(string filePath)
    {
        string[] words = new string[] {};
        try
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("file does not exist, better error message to come");
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
