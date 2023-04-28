using System;
using System.Text;
namespace Wordle.UI;

interface IWordleUI
{
    string StringifyBoard(List<string> guesses);
}

class ConsoleUI : IWordleUI
{
    public string StringifyBoard(List<string> guesses) 
    {   
        string upperBoardString = "╔═══╦═══╦═══╦═══╦═══╗";
        StringBuilder sb = new StringBuilder(upperBoardString);
        string middleBoardString = "╠═══╬═══╬═══╬═══╬═══╣";
        string endBoardString = "╚═══╩═══╩═══╩═══╩═══╝";
        string sideBoardString = "║";


        foreach(string guess in guesses)
        {
            sb.Append(Environment.NewLine);
            
        }

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