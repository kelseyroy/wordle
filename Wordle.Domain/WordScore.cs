namespace Wordle.Domain;

public class WordScore
{
    public int GuessNumber { get; set; }
    public List<LetterScore> LetterScores { get; set; }
    public WordScore()
    {
        LetterScores = new List<LetterScore>();
    }
}
