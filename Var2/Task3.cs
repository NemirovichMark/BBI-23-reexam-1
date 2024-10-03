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
            public string Input { get; }
            public string Output { get; private set; }

            public Grep(string text)
            {
                Input = text;
                ProcessText();
            }

            private void ProcessText()
            {
                var mostFrequentLetter = Input
                    .Where(char.IsLetter)
                    .GroupBy(char.ToLower)
                    .OrderByDescending(g => g.Count())
                    .First()
                    .Key;

                var words = Input.Split(' ');
                Output = string.Join(" ", words.Where(word => !word.Contains(mostFrequentLetter, StringComparison.OrdinalIgnoreCase)));
            }

            public override string ToString()
            {
                return Output;
            }
        }

        private Grep greper;

        public Grep Greper => greper;

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