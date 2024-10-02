using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variant_2
{
    public class Task3
    {
        public class Grep
        {
            private string _input;
            private string _output;

            public string Input => _input;

            public string Output => _output;

            public Grep(string text)
            {
                _input = text;
                ProcessText();
            }

            private void ProcessText()
            {
               
                var charCounts = new Dictionary<char, int>();
                foreach (char c in _input.ToLower())
                {
                    if (char.IsLetter(c))
                    {
                        if (charCounts.ContainsKey(c))
                        {
                            charCounts[c]++;
                        }
                        else
                        {
                            charCounts[c] = 1;
                        }
                    }
                }

                char mostFrequentChar = ' ';
                int maxCount = 0;
                foreach (var kvp in charCounts)
                {
                    if (kvp.Value > maxCount)
                    {
                        maxCount = kvp.Value;
                        mostFrequentChar = kvp.Key;
                    }
                }

                _output = string.Join(" ", _input.Split(' ')
                    .Where(word => !word.ToLower().Contains(mostFrequentChar)));
            }

            public override string ToString()
            {
                return Output;
            }
        }

        private Grep _greper;

        public Grep Greper
        {
            get => _greper;
            set => _greper = value;
        }

        public Task3(string text)
        {
            _greper = new Grep(text);
        }

        public override string ToString()
        {
            return _greper.ToString();
        }

        static void Main(string[] args)
        {
            string text = "This is a test string. It is used to demonstrate the Grep class.";
            Task3 task = new Task3(text);
            Console.WriteLine(task.ToString());
            Console.ReadKey();
        }
    }
}