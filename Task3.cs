using System;
using System.Collections.Generic;

namespace Variant_3
{
    public class Task3
    {
        public class Searcher
        {
            private string textI = "";  
            private List<string> palindromes = new List<string>();  
            
            public string Input { get { return textI; } }

            
            private bool IsPalindrome(string input)
            {
                for (int i = 0; i < input.Length / 2; i++)
                {
                    if (input[i] != input[input.Length - i - 1])
                        return false;
                }
                return true;
            }

            
            public Searcher(string x)
            {
                this.textI = x; 

                string buf = "";  
                for (int i = 0; i < textI.Length; i++)
                {
                    
                    if (textI[i] == '\n' || textI[i] == ',' || textI[i] == ' ')
                    {
                        
                        if (buf.Length <= 1)
                        {
                            buf = "";
                            continue;
                        }

                        
                        string buf2 = buf.ToLower();
                        if (IsPalindrome(buf2))
                        {
                            this.palindromes.Add(buf2);  
                        }
                        buf = ""; 
                    }
                    else
                    {
                        buf += textI[i];  
                    }
                }

                
                if (buf.Length > 1 && IsPalindrome(buf.ToLower()))
                {
                    this.palindromes.Add(buf.ToLower());
                }
            }

            
            public override string ToString()
            {
                string result = "";
                for (int i = 0; i < palindromes.Count; i++)
                {
                    result += palindromes[i];

                    
                    if (i + 1 < palindromes.Count)
                    {
                        result += "\n";
                    }
                }
                return result;
            }
        }
    }
}

