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
            public string Input { get; private set; } 
            public string Output { get; private set; } 

           
            public Grep(string input)
            {
                Input = input;
                ProcessInput();
            }

            
            private void ProcessInput()
            {
                
                if (string.IsNullOrWhiteSpace(Input))
                {
                    Output = Input;  
                    return;
                }

               
                var letters = Input.Where(char.IsLetter).ToArray();

                if (letters.Length == 0)
                {
                    Output = Input;  
                    return;
                }

                var charFrequency = letters
                    .GroupBy(char.ToLower) 
                    .OrderByDescending(g => g.Count()) 
                    .First().Key; 

              
                Output = string.Join(" ", Input
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries) 
                    .Where(word => !word.ToLower().Contains(charFrequency))
                );
            }

          
            public override string ToString()
            {
                return Output;
            }
        }

        
        private Grep greper;

        
        public Grep Greper
        {
            get { return greper; }
        }

       
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