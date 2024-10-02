public class Task3
{
    public class Searcher
    {
        private string input; 
        private List<string> output; 

        public string Input => input; 
        public string[] Output => output.ToArray(); 

        public Searcher(string text)
        {
            input = text;
            output = new List<string>();
            FindPalindromes();
        }

        private void FindPalindromes()
        {
            if (string.IsNullOrWhiteSpace(input)) return;

            string[] words = input.Split(new[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                if (IsPalindrome(word) && word.Length > 1)
                {
                    output.Add(word);
                }
            }
        }

        private bool IsPalindrome(string word)
        {
            int left = 0;
            int right = word.Length - 1;

            while (left < right)
            {
                if (char.ToLower(word[left]) != char.ToLower(word[right]))
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }

        public override string ToString()
        {
            return output.Count > 0 ? string.Join(Environment.NewLine, output) : string.Empty;
        }
    }
    public Task3(string text)
    {
        var searcher = new Searcher(text);
        Console.WriteLine(searcher.ToString());
    }

}


