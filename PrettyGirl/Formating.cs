using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PrettyGirl
{



    /// <summary>
    /// Разделитель слов по слогам
    /// </summary>
    public static class WordSeparator
    {
        /// <summary>
        /// массив гласных букв
        /// </summary>
        public static char[] Vowels = new[] { 'а', 'о', 'у', 'ы', 'е', 'ю', 'я', 'и', 'э', 'ё' };

        /// <summary>
        /// масив пунктуационыых символов
        /// </summary>
        public static char[] Puncts = new[] { ' ', ',', '.', ':', ';', '?', '!', '"', '(', ')' };

        /// <summary>
        /// возвращает графическую длину слова
        /// </summary>
        /// <param name="word">слово</param>
        /// <returns></returns>
        public static int GetWordLength(string word)
        {
            int length = 0;

            foreach (char c in word)
            {

                foreach (LetterConfig letter in HandWriteConfig.Letters)
                {
                    if (letter.Value == c && letter.Variable == 0)
                        length = length + letter.LeftDx + letter.Size.Width + letter.RightDx;

                }
                if (c == ' ')
                    length += HandRandom.DefaultSpace;
            }


            return length;
        }

        /// <summary>
        /// возвращает массив длин слов текста
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int[] GenerateWordsLength(string text)
        {
            List<int> list = new List<int>();
            string[] strs = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < strs.Length; i++)
                list.Add(GetWordLength(strs[i]));
            return list.ToArray();
        }

        /// <summary>
        /// возвращает две части слова, 
        /// разделенного по слогу
        /// </summary>
        /// <param name="word">слово</param>
        /// <param name="freeSpace">свободное место
        ///  до разделения</param>
        /// <returns></returns>
        public static string[] SubEdge(string word, int freeSpace)
        {
            string str = "";
            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                int length = GetWordLength(str + "-");
                if ((length >= freeSpace || i > word.Length / 2) && i > 0)
                    return new[] { str.Remove(str.Length - 1), word.Remove(0, i - 1) };
                str += c;
            }
            return new[] { str, "" };
        }

        /// <summary>
        /// Возвращает слово с тире,
        /// разделенного дефисом
        /// </summary>
        /// <param name="text">текст</param>
        /// <param name="wordNumber">номер слова в тексте</param>
        /// <param name="freeSpace">свободное место до правой 
        /// границы в холсте</param>
        /// <returns></returns>
        public static string GetSeparateWord(string text, int wordNumber, int freeSpace)
        {
            if (text.Trim().Length <= 1 || freeSpace <= 0) return "";
            string[] strs = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string word = "";
            if (strs.Length > wordNumber) word = strs[wordNumber];
            string sepword = word;
            string[] edge = SubEdge(word, freeSpace);
            word = edge[1];
            int syllables = word.Sum(c => Vowels.Count(vowel => c == vowel));
            if (syllables > 1)
            {
                int count = 0;
                int first = 0;
                for (int i = 0; i < word.Length; i++)
                {
                    foreach (char vowel in Vowels)
                    {
                        if (word[i] == vowel && i > 0 && i < word.Length - 2)
                        {
                            first = i;
                            i = word.Length;
                            break;
                        }
                    }
                }

                if (first > 0)
                    sepword = word.Substring(0, first + 1) + "~" + word.Substring(first + 1);



            }
            return edge[0] + sepword;
        }

    }


    public static class SymbolReplacer
    {
        public static Dictionary<char, char> SymbolsDictionary = new Dictionary<char, char>();

        public static void BuildDictionary()
        {
            try
            {
                SymbolsDictionary.Clear();
                string[] strs = File.ReadAllLines(@"data\assos.cfg");
                foreach (string str in strs)
                {
                    string[] sub = str.Split(new[] { ' ' });
                    if (sub.Length >= 2)
                        SymbolsDictionary.Add(sub[0][0], sub[1][0]);
                }

            }
            catch
            {

            }
        }

        public static string ReplaceSymbols(string str)
        {
            str = str.Replace("\r\n", "\n");
            str = str.Replace("\r", "\n");
            string ret = "";

            foreach (char c in str)
            {
                char buf = c;
                foreach (KeyValuePair<char, char> pair in SymbolsDictionary)
                {
                    if (c == pair.Key) buf = pair.Value;
                }
                ret += buf;
            }

            return ret;

        }
    }
}
