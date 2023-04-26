namespace Wordle.Domain;
public class Game
{
    public string GetGreeting() => "Hello!";

    public Score[] EvaluateGuess(string answer, string guess){
        Score[] result = {Score.NotInWord, Score.NotInWord, Score.NotInWord, Score.NotInWord, Score.NotInWord};
        return result;
    }

}
