public class Task3
{
    private Searcher _searcher;
    public class Searcher
    {

        private string _input;
        private string[] _output;

        public string Input => _input;
        public string[] Output => _output;

        public Searcher(string input)
        {
            _input = input;
            FindPalindromes();
        }

        private void FindPalindromes()
        {
            if (string.IsNullOrWhiteSpace(_input))
            {
                _output = Array.Empty<string>();
                return;
            }

            char[] separators = { ' ', ',', '.', '!', '?', ';', ':', '-', '\n', '\r', '\t' };
            string[] words = _input.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            string[] tempOutput = new string[words.Length];
            int count = 0;

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i].ToLower();

                if (word.Length > 1 && IsPalindrome(word))
                {
                    bool isDuplicate = false;
                    for (int j = 0; j < count; j++)
                    {
                        if (tempOutput[j] == word)
                        {
                            isDuplicate = true;
                            break;
                        }
                    }

                    if (!isDuplicate)
                    {
                        tempOutput[count] = word;
                        count++;
                    }
                }
            }

            _output = new string[count];
            for (int i = 0; i < count; i++)
            {
                _output[i] = tempOutput[i];
            }
        }

        private bool IsPalindrome(string word)
        {
            int length = word.Length;
            for (int i = 0; i < length / 2; i++)
            {
                if (word[i] != word[length - i - 1])
                {
                    return false;
                }
            }
            return true;
        }

        public override string ToString()
        {
            if (_output == null || _output.Length == 0)
            {
                return string.Empty;
            }

            return string.Join("\n", _output);
        }
    }

    public Task3(string text)
    {
        _searcher = new Searcher(text);
    }

    public override string ToString()
    {
        return _searcher.ToString();
    }

}


