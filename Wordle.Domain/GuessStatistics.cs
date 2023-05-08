namespace Wordle.Domain;

public class GuessStatistics
{
    public WordScore[] GuessArray = new WordScore[6];
    public int GuessCount = 0;
    public void UpdateGuessStatistics(List<LetterScore> letterScores)
    {
        GuessCount++;
        GuessArray[GuessCount - 1] = new WordScore()
        {
            GuessNumber = GuessCount,
            LetterScores = letterScores
        };
    }
}
