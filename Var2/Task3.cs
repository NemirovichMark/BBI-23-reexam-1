using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Variant_2.Task3;

namespace Variant_2
{
    public class Task3
    {
        public class Grep
        {
            private string _text;

            public Grep(string text)
            {
                _text = text;
            }
            public List<string> Search(string pattern)
            {
                var matches = new List<string>();
                var regex = new Regex(pattern);
                var matchCollection = regex.Matches(_text);

                foreach (Match match in matchCollection)
                {
                    matches.Add(match.Value);
                }
                return matches;
            }
        }
    }      
}