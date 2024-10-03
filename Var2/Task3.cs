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
            private string _input;
            private string _output;

            public Grep(string text)
            {
                _input = text;
                _output = RemoveWordsWithMostFrequentLetter(text);
            }

            public string Input
            {
                get { return _input; }
            }

            public string Output
            {
                get { return _output; }
            }

            private string RemoveWordsWithMostFrequentLetter(string text)
            {
                // Найти самую часто встречающуюся букву
                Dictionary<char, int> letterCounts = new Dictionary<char, int>();
                foreach (char c in text.ToLower())
                {
                    if (char.IsLetter(c))
                    {
                        if (letterCounts.ContainsKey(c))
                        {
                            letterCounts[c]++;
                        }
                        else
                        {
                            letterCounts.Add(c, 1);
                        }
                    }
                }

                char mostFrequentLetter = ' ';
                int maxCount = 0;
                foreach (var kvp in letterCounts)
                {
                    if (kvp.Value > maxCount)
                    {
                        maxCount = kvp.Value;
                        mostFrequentLetter = kvp.Key;
                    }
                }

                string[] words = text.Split(' ');
                string result = "";
                foreach (string word in words)
                {
                    if (!word.ToLower().Contains(mostFrequentLetter))
                    {
                        result += word + " ";
                    }
                }

                return result.TrimEnd(); 
            }

            public override string ToString()
            {
                return Output;
            }
        }
        private Grep _greper;
        public Task3(string text)
        {
            _greper = new Grep(text);
        }
        public Grep Greper
        {
            get { return _greper; }
        }

        public override string ToString()
        {
            return Greper.ToString();
        }
    }
}