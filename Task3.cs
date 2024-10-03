using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static Variant_2.Task3;

namespace Variant_2
{
    public class Task3
    {
        public class Grep
        {
            private string input;
            private string output;

            public string Input { get => input; }
            public string Output { get => output; }

            public Grep(string text)
            {
                input = text;

                char mostFrequentLetter = FindMostFrequentLetter(text);

                output = RemoveWordsWithLetter(text, mostFrequentLetter);
            }

            private char FindMostFrequentLetter(string text)
            {
                int[] letterCounts = new int[26];
                text = text.ToLower();

                foreach (char ch in text)
                {
                    if (ch >= 'a' && ch <= 'z')
                    {
                        letterCounts[ch - 'a']++;
                    }
                }

                int maxCount = 0;
                char mostFrequentLetter = ' ';
                for (int i = 0; i < 26; i++)
                {
                    if (letterCounts[i] > maxCount)
                    {
                        maxCount = letterCounts[i];
                        mostFrequentLetter = (char)(i + 'a');
                    }
                }

                return mostFrequentLetter;
            }

            private string RemoveWordsWithLetter(string text, char letter)
            {
                string[] words = SplitWords(text);
                string result = "";

                foreach (string word in words)
                {
                    if (!word.ToLower().Contains(letter))
                    {
                        result += word + " ";
                    }
                }

                return result.Trim();
            }

            private string[] SplitWords(string text)
            {
                char[] delimiters = { ' ', '.', ',', '!', '?', ';', ':' };
                string[] words = new string[text.Length];
                int wordIndex = 0;
                string currentWord = "";

                foreach (char ch in text)
                {
                    if (Array.Exists(delimiters, d => d == ch))
                    {
                        if (!string.IsNullOrEmpty(currentWord))
                        {
                            words[wordIndex++] = currentWord;
                            currentWord = "";
                        }
                    }
                    else
                    {
                        currentWord += ch;
                    }
                }

                if (!string.IsNullOrEmpty(currentWord))
                {
                    words[wordIndex++] = currentWord;
                }

                string[] resultWords = new string[wordIndex];
                Array.Copy(words, resultWords, wordIndex);

                return resultWords;
            }

            public override string ToString()
            {
                return output;
            }
        }

        private Grep greper;

        public Grep Greper { get => greper; }

        public Task3(string text)
        {
            greper = new Grep(text);
        }

        public override string ToString()
        {
            return greper.ToString();
        }
    }
}