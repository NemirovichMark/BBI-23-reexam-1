using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Variant_3
{
    public class Task3
    {
        [ProtoBuf.ProtoContract()]
        public class Searcher
        {
            private string input;
            private string[] output;

            [ProtoBuf.ProtoMember(0)]
            public string Input { get { return input; } }
            [ProtoBuf.ProtoMember(1)]
            public string[] Output { get { return output; } }

            public Searcher() { }
            public Searcher(string s)
            {
                input = s;
                List<string> result = new List<string>();
                string[] words = s.Split(' ');
                foreach (string word in words)
                {
                    if (word.Length > 1)
                    {
                        bool flag = true;
                        int k = word.Length - 1;
                        for (int i = 0; i < word.Length / 2; i++)
                        {
                            char a = word[i];
                            char b = word[k - i];
                            if (!char.IsLetter(a) || a != b)
                            {
                                flag = false;
                                break;
                            }
                            
                        }
                        if (flag)
                        {
                            result.Add(word);
                        }
                    }
                }
                output = result.ToArray();
            }

            public override string ToString()
            {
                if (output == null || output.Length < 1)
                {
                    return "";
                }
                return string.Join("\n", output);
            }
        }

        private Searcher palindromeSearcher;

        public Searcher PalindromeSearcher { get { return palindromeSearcher; } }
        public string Input { get { return palindromeSearcher.Input; } }
        public string[] Output { get { return palindromeSearcher.Output; } }

        public Task3(string text)
        {
            palindromeSearcher = new Searcher(text);
        }

        public override string ToString()
        {
            return palindromeSearcher.ToString();
        }
    }
}