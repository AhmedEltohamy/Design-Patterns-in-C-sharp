using Memento;

var game = new HangManGame("secret");
var states = new Stack<HangManGame.HangManGameMemento>();

while (!game.IsPlayerWon && !game.IsPlayerLosed)
{
    Console.Clear();
    Console.WriteLine("Welcom to Hangman Game");
    Console.WriteLine(game.GuessedWord);
    Console.WriteLine($"Previous Guesses: {game.Guesses}");
    Console.WriteLine($"Guesses Left: {game.NumberOfLeftGuesses}");
    var s = states.Any() ? " or 0 to undo last guess" : string.Empty;
    Console.WriteLine($"Guess (a - z{s}): ");
    
    char c;
    if (!Char.TryParse(Console.ReadLine(), out c))
    {
        Console.WriteLine("Please enter valid char");
        continue;
    }

    if (c == '0' && states.Any())
        game.Restore(states.Pop());
    else
    {
        states.Push(game.SaveCurrentState());
        game.Guess(c);
    }
}

if (game.IsPlayerLosed)
    Console.WriteLine("SORRY, You lost this time. Try again.");
else
    Console.WriteLine("Congratulation, You won :)");

Console.ReadKey();