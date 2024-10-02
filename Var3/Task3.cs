using System.Text.RegularExpressions;

public class Task3
{
    public class Searcher
    {
        private string input;
        private string[] output;

        public string Input => input;
        public string[] Output => output;

        public Searcher(string text)
        {
            input = text;
            output = FindPalindromes(input);
        }

        private string[] FindPalindromes(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return Array.Empty<string>();

            
            MatchCollection matches = Regex.Matches(text, @"\b\w{2,}\b");
            HashSet<string> palindromesSet = new HashSet<string>();

            foreach (Match match in matches)
            {
                string word = match.Value;
                if (IsPalindrome(word))
                {
                    palindromesSet.Add(word.ToLower()); 
                }
            }

            
            string[] palindromesArray = new string[palindromesSet.Count];
            palindromesSet.CopyTo(palindromesArray);

            BubbleSort(palindromesArray); 

            return palindromesArray;
        }

        private bool IsPalindrome(string word)
        {
            int len = word.Length;
            for (int i = 0; i < len / 2; i++)
            {
                if (word[i] != word[len - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }

        private void BubbleSort(string[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (String.Compare(array[j], array[j + 1], StringComparison.Ordinal) > 0)
                    {
                        
                        string temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        public override string ToString()
        {
            if (output.Length == 0)
                return string.Empty;
            return string.Join(Environment.NewLine, output);
        }
    }

    private Searcher searcher;
    public Task3(string text)
    {
        searcher = new Searcher(text);
    }
    public string GetPalindromes()
    {
        return searcher.ToString();
    }

}

