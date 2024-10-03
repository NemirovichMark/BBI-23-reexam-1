public class Task3
{
    public class Searcher
    {
        private string _input;
        private List<string> _output = new List<string>();

        public string Input
        {
            get { return _input; }
        }

        public List<string> Output
        {
            get { return _output; }
        }

        public Searcher(string text)
        {
            _input = text;
            FindPalindromes();
        }

        private void FindPalindromes()
        {
            if (string.IsNullOrEmpty(_input))
            {
                return;
            }

            string[] words = _input.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                if (word.Length > 1 && IsPalindrome(word))
                {
                    _output.Add(word);
                }
            }

            GnomeSort(_output);
        }

        private bool IsPalindrome(string word)
        {
            int left = 0;
            int right = word.Length - 1;

            while (left < right)
            {
                if (word[left] != word[right])
                {
                    return false;
                }

                left++;
                right--;
            }

            return true;
        }

        private void GnomeSort(List<string> list)
        {
            int i = 1;
            int j = 2;

            while (i < list.Count)
            {
                if (string.Compare(list[i - 1], list[i], StringComparison.Ordinal) > 0)
                {
                    string temp = list[i - 1];
                    list[i - 1] = list[i];
                    list[i] = temp;
                    i--;
                    if (i == 0)
                    {
                        i = 1;
                    }
                }
                else
                {
                    i = j;
                    j++;
                }
            }
        }

        public override string ToString()
        {
            if (_output.Count == 0)
            {
                return string.Empty;
            }

            string outputString = string.Join("\n", _output);
            return outputString;
        }
    }

}

    //3. В классе Task3 заполните класс Searcher полями для входной строки и выходного массива строк.
    //    Сделайте публичные свойства для чтения этих полей Input и Output соответственно. В конструктор должен передаваться текст и сохраняться как входная строка.
    //    После этого нужно найти все слова-палиндромы в тексте и поместить их в выходной массив строк. Палиндром - это слово, которое читается одинаково как слева направо,
    //    так и справа налево (длина слова > 1). Переопределите метод ToString(), чтобы он возвращал выходное значение построчно или пустую строку, если входной текст был 
    //    неверного формата.

