public class Task3
{
    public class Searcher
    {
        private string _input;
        private string[] _output;

        public string Input { get { return _input; } }
        public string[] Output { get { return _output; } }

        public Searcher(string text)
        {
            _input = text;
            _output = FindPalindromes(text);
        }

        private string[] FindPalindromes(string text)
        {
            var words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var palindromes = new List<string>();

            foreach (var word in words)
            {
                var cleanWord = new string(word.Where(c => char.IsLetter(c)).ToArray());
                if (IsPalindrome(cleanWord))
                {
                    palindromes.Add(word);
                }
            }

            return palindromes.ToArray();
        }

        private bool IsPalindrome(string word)
        {
            if (word.Length <= 1) return false;

            int left = 0;
            int right = word.Length - 1;

            while (left < right)
            {
                if (char.ToLower(word[left]) != char.ToLower(word[right])) return false;
                left++;
                right--;
            }

            return true;
        }

        public override string ToString()
        {
            if (_output == null || _output.Length == 0) return string.Empty;

            return string.Join(Environment.NewLine, _output);
        }
    }

    public Task3(string text)
    {
        var searcher = new Searcher(text);
        Console.WriteLine(searcher.ToString());
    }

}


