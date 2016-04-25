using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyGirl
{
    class MyArray
    {
        private int[] array;

        public MyArray(string path)
        {
            string[] strs = File.ReadAllLines(path);
            array = new int[strs.Length];
            for (int i = 0; i < strs.Length; i++)
                array[i] = Convert.ToInt32(strs[i]);
        }

        public MyArray(int n)
        {
            array = new int[n];
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                if (rand.Next(0, 2) < 1) array[i] = Convert.ToInt32(Math.Pow(i, 2));
                else array[i] =-Convert.ToInt32(Math.Pow(i, 2));
            }
                
        }

        public int GetPlus
        {
            get
            {
                return array.Count(i1 => i1 >= 0);
            }
        }

        public int GetSumBetween()
        {
            int sum = 0;
            int last = array.LastOrDefault(i => i < 0);
            int first = array.FirstOrDefault(i => i < 0);
            for (int i = first + 1; i < last; i++) sum += array[i];
            return sum;
        }

    }
}
