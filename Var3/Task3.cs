public class Task3
{
    public class Searcher
    {
        private string input;
        private string[] output;

        public string Input { get { return input; } }
        public string[] Output { get { return output; } }

        public Searcher(string text)
        {
            input = text;

            string[] words = ExtractWords(input);

            string[] tempOutput = new string[words.Length];
            int palindromeCount = 0;

            for (int i = 0; i < words.Length; i++)
            {
                if (IsPalindrome(words[i]) && words[i].Length > 1)
                {
                    tempOutput[palindromeCount++] = words[i];
                }
            }

            output = new string[palindromeCount];
            Array.Copy(tempOutput, output, palindromeCount);
        }

        private string[] ExtractWords(string text)
        {
            string[] words = new string[text.Length];
            int wordIndex = 0;
            string currentWord = string.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                char ch = text[i];

                if (char.IsLetter(ch))
                {
                    currentWord += ch;
                }
                else
                {
                    if (currentWord.Length > 0)
                    {
                        words[wordIndex++] = currentWord;
                        currentWord = string.Empty;
                    }
                }
            }

            if (currentWord.Length > 0)
            {
                words[wordIndex] = currentWord;
                wordIndex++;
            }

            string[] resultWords = new string[wordIndex];
            Array.Copy(words, resultWords, wordIndex);

            return resultWords;
        }

        private bool IsPalindrome(string word)
        {
            int len = word.Length;
            for (int i = 0; i < len / 2; i++)
            {
                if (char.ToLower(word[i]) != char.ToLower(word[len - i - 1]))
                {
                    return false;
                }
            }
            return true;
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(input) || output.Length == 0)
            {
                return string.Empty;
            }

            string result = "";
            for (int i = 0; i < output.Length; i++)
            {
                result += output[i] + "\n";
            }

            return result;
        }
    }
}