public class Task3
{
    public class Searcher
    {
        private string input;
        private string[] output;
        public string Input
        {
            get { return input; }
        }

        public string[] Output
        {
            get { return output; }
        }
        public Searcher(string text)
        {
            input = text;
            if (string.IsNullOrEmpty(input))
            {
                output = new string[0]; 
            }
            else
            {
                string[] words = SplitWords(text.ToLower());
                output = FindPalindromes(words);
            }
        }
        private string[] SplitWords(string text)
        {
            char[] delimiters = new char[] { ' ', ',', '.', '!', '?', ':', ';', '-', '_', '(', ')', '[', ']', '{', '}', '"' };
            string[] words = new string[text.Length];
            int wordCount = 0;
            string currentWord = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (Array.IndexOf(delimiters, text[i]) == -1)
                {
                    currentWord += text[i];
                }
                else if (currentWord != "")
                {
                    words[wordCount++] = currentWord; 
                    currentWord = "";
                }
            }

            if (currentWord != "") 
            {
                words[wordCount++] = currentWord;
            }

            string[] result = new string[wordCount];
            for (int i = 0; i < wordCount; i++)
            {
                result[i] = words[i];
            }
            return result;
        }

        private string[] FindPalindromes(string[] words)
        {
            string[] palindromes = new string[words.Length]; 
            int palindromeCount = 0;

            foreach (string word in words)
            {
                if (word.Length > 1 && IsPalindrome(word))
                {
                    palindromes[palindromeCount++] = word;
                }
            }

            string[] result = new string[palindromeCount];
            for (int i = 0; i < palindromeCount; i++)
            {
                result[i] = palindromes[i];
            }
            return result;
        }

        private bool IsPalindrome(string word)
        {
            int left = 0;
            int right = word.Length - 1;

            while (left < right)
            {
                if (word[left] != word[right])
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
            if (output.Length == 0)
                return string.Empty;

            string result = "";
            for (int i = 0; i < output.Length; i++)
            {
                result += output[i] + "\n";
            }
            return result;
        }
    }

    //public static void Main(string[] args)
    //{

    //    string text = "Anna went to see civic duties with her level radar";

    //    Searcher searcher = new Searcher(text);
    //    Console.WriteLine("Found palindromes:");
    //    Console.WriteLine(searcher.ToString());
    //}
}