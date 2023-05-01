namespace Wordle.Domain;

class Guess
{
    public int Row {get; set;} = 1;
    public string GuessString {get; set;} = " ";
    public Score[] GuessScore {get; set;} = {
            Score.NotInWord,
            Score.NotInWord,
            Score.NotInWord,
            Score.NotInWord,
            Score.NotInWord
        };
}