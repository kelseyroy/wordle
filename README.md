# C# Wordle Clone

## Overview

The goal of this feature is to implement Wordle as a command line application. At the start of the game, the computer will randomly generate a secret five-letter word. One human player ought to be able to submit a valid word guess via the command line and the computer opponent will evaluate their guess. The computer will then provide feedback to the player by highlighting the letters in different colors:
* Gray/No Color: Incorrect Letter
* Yellow: Correct letter in the incorrect position
* Green: Correct letter in the correct position

The human player will then be able to use the feedback to make an educated guess on what the secret word could be. The game will continue until the secret word is guessed by the human player, resulting in a win, or until the player submits 6 incorrect guesses, resulting in a loss.

## Functional Requirements

* Upon starting the game from the command line, the user should be presented with simple instructions on how to play the game.
* The game should generate a random, secret five-letter word to guess.
* A human player should be able to input at most 6 guesses for the secret word, as long as the guess is a valid five-letter word.
* The game should evaluate the user's guesses and provide feedback on the correctness of each letter by highlighting the letters with colors that correspond to the correctness and position of the letter.
* The game should keep track of the player's progress--including the number of attempts remaining, the letters guessed, and the feedback recieved--and update the game state accordingly.
* Winning or losing the game should be identified and the app should close gracefully after the game ends.

## Technical Requirements

* The game will be created using C# on the .NET platform
* All business logic should have close to 100% test coverage with unit tests.
* The code should be well organized and follow the Four Rules of Simple Design.
* There should be no major violations of the SOLID principles in the code.

## Dependencies
* C#
* [.NET 7.0](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)

## Setup
1. [Clone the repository](https://docs.github.com/en/repositories/creating-and-managing-repositories/cloning-a-repository) to your local computer.
2. Use your terminal to navigate into your new wordle folder and install project dependencies by running `dotnet build`.
3. To run the CLI application, call `dotnet run --project Wordle.UI` from within the wordle folder.
4. To run the tests, call `dotnet test` from within the wordle foler.

## Start

![Screenshot 2023-05-18 at 3 36 32 PM](https://github.com/kelseyroy/wordle/assets/89801075/57eaff95-22d5-43f6-b738-57a10224b50a)

To start Wordle from the command line, call `dotnet run --project Wordle.UI` from within the wordle folder. The main menu should display a list of the available commands. The commands available to you include:

### `[-h | --help]`

<img width="354" alt="Screenshot 2023-05-17 at 4 00 41 PM" src="https://github.com/kelseyroy/wordle/assets/89801075/23c7a406-ab8f-42fb-aa92-ea36ab47ba60">

The help command provides players with game rules and instructions on how to play the game.

### `[-g | --game]`

![Screenshot 2023-05-18 at 4 29 04 PM](https://github.com/kelseyroy/wordle/assets/89801075/2f0a871c-c5c6-4cb7-9438-a2c9b8181a6e)

The game command will allow players to begin a new game. When prompted, players will type in a valid 5-letter word and press enter. After each turn, the board will update to display all previous guesses and the color of the board tiles will change to show how close the player's guess was to the answer. When the game is over, the player will be prompted to press the `[enter]` or `[return]` key to start a new game, or `[esc]` to quit the application.

### `[-q | --quit]` or `[CTRL + C]`
To quit the game from the main menu, players may enter `-q` or `--quit`. To exit the application from the game page, players must press the `[CTRL]` + `[C]` keys.

## Stretch Goals
* Update the UI so the app is playable in the browser
* Track the collective scores of players
* Add options to increase difficulty level or select secret words that are thematically similar
