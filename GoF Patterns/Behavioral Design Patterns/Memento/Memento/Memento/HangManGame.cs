using System.Text;

namespace Memento
{
    internal class HangManGame
    {
        private readonly string _originalWord;
        public string OriginalWord => _originalWord;

        private StringBuilder _guessedWord;
        public string GuessedWord => _guessedWord.ToString();

        public byte NumberOfLeftGuesses { get; private set; }

        public bool IsPlayerWon { get; private set; } = false;

        public bool IsPlayerLosed { get; private set; } = false;

        private readonly List<char> _guesses = new List<char>();
        public string Guesses => string.Join(',', _guesses);

        public HangManGame(string originalWord)
        {
            if (string.IsNullOrWhiteSpace(originalWord))
                throw new ArgumentNullException(nameof(originalWord));

            if (originalWord.Length > byte.MaxValue)
                throw new ArgumentOutOfRangeException(nameof(originalWord));

            _originalWord = originalWord;
            _guessedWord = new StringBuilder(string.Join(string.Empty, Enumerable.Range(0, _originalWord.Length).Select(_ => '_').ToArray()));
            NumberOfLeftGuesses = (byte)_originalWord.Length;
        }

        public void Guess(char c)
        {
            if (IsPlayerWon || IsPlayerLosed)
                throw new InvalidOperationException("Game has benn completed");

            _guesses.Add(c);
            for (int i = 0; i < _originalWord.Length; i++)
            {
                if (_originalWord[i] == c && _guessedWord[i] == '_')
                {
                    _guessedWord[i] = c;
                    if (_originalWord == _guessedWord.ToString())
                        IsPlayerWon = true;
                    return;
                }
            }
            if (--NumberOfLeftGuesses == 0)
                IsPlayerLosed = true;
        }

        public HangManGameMemento SaveCurrentState() =>
            new HangManGameMemento(_guessedWord.ToString(), NumberOfLeftGuesses, _guesses);

        public void Restore(HangManGameMemento memento)
        {
            _guessedWord = new StringBuilder(memento.GuessedWord);
            NumberOfLeftGuesses = memento.NumberOfLeftGuesses;
            _guesses.Clear();
            _guesses.AddRange(memento.Guesses);
        }

        public class HangManGameMemento
        {
            private readonly string _guessedWord;
            private readonly byte _numberOfLeftGuesses;
            private readonly IReadOnlyList<char> _guesses;

            public HangManGameMemento(string guessedWord, byte numberOfLeftGuesses, List<char> guesses)
            {
                _guessedWord = guessedWord;
                _numberOfLeftGuesses = numberOfLeftGuesses;
                _guesses = guesses.ToList().AsReadOnly();
            }

            public string GuessedWord => _guessedWord;

            public byte NumberOfLeftGuesses => _numberOfLeftGuesses;

            public List<char> Guesses => _guesses.ToList();
        }

    }

}