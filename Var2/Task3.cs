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
            private string _Input;
            private string _Output;

            public string Input
            {
                get { return _Input; }
            }
            public string Output
            {
                get { return _Output; }
            }

            public Grep(string text)
            {
                _Input = text;
                _Output = FindAndRemoveWords(this.ToString());
            }

            private string FindAndRemoveWords(string text)
            {
                var letterCount = new int[52]; //26: a-z; 26: A-Z 

                foreach (char c in Input)
                {
                    if (char.IsLower(c))
                    {
                        letterCount[c - 'a']++;
                    }
                    else if (char.IsUpper(c))
                    {
                        letterCount[c - 'A' + 26]++;
                    }
                }
                int maxIndex = Array.IndexOf(letterCount, letterCount.Max());
                char mostFrequentLetter = maxIndex < 26 ? (char)(maxIndex + 'a') : (char)(maxIndex - 26 + 'A');

                var words = Input.Split(new[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
                var filteredWords = new List<string>();
                foreach (var word in words)
                {
                    if (!word.Contains(mostFrequentLetter))
                    {
                        filteredWords.Add(word);
                    }
                }

                return string.Join(" ", filteredWords);
            }
            public override string ToString()
            {
                return FindAndRemoveWords(this.ToString());
            }
        }
        public Task3(string text)
        {

        }
    }
}