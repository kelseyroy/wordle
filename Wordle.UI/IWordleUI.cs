namespace Wordle.UI;

interface IWordleUI
{
    string Board(List<string> guesses);
}

class ConsoleUI : IWordleUI
{
    public string Board(List<string> guesses) 
    {
        string upperBoardString = "╔═══╦═══╦═══╦═══╦═══╗";
        string middleBoardString = "╠═══╬═══╬═══╬═══╬═══╣";
        string endBoardString = "╚═══╩═══╩═══╩═══╩═══╝";
        string sideBoardString = "║";

        string emptyBoard = $@"
        {upperBoardString}
        {sideBoardString}   {sideBoardString}   {sideBoardString}   {sideBoardString}   {sideBoardString}   {sideBoardString}
        {middleBoardString}
        {sideBoardString}   {sideBoardString}   {sideBoardString}   {sideBoardString}   {sideBoardString}   {sideBoardString}
        {middleBoardString}
        {sideBoardString}   {sideBoardString}   {sideBoardString}   {sideBoardString}   {sideBoardString}   {sideBoardString}
        {middleBoardString}
        {sideBoardString}   {sideBoardString}   {sideBoardString}   {sideBoardString}   {sideBoardString}   {sideBoardString}
        {middleBoardString}
        {sideBoardString}   {sideBoardString}   {sideBoardString}   {sideBoardString}   {sideBoardString}   {sideBoardString}
        {middleBoardString}
        {sideBoardString}   {sideBoardString}   {sideBoardString}   {sideBoardString}   {sideBoardString}   {sideBoardString}
        {endBoardString}
        ";
            return emptyBoard;
    }
}