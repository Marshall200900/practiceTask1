using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Program
    {
        public static int Int(string sentence, int minBorder = int.MinValue, int maxBorder = int.MaxValue)
        {
            int result = 0;
            bool ok = true;
            do
            {
                Console.Write(sentence);
                ok = int.TryParse(Console.ReadLine(), out result);
                if (result < minBorder || result > maxBorder)
                {
                    ok = false;
                }
            }
            while (!ok);
            return result;
        }
        public static int[] IntList(string sentence, int size, double minBorder = double.MinValue, double maxBorder = double.MaxValue)
        {
            int[] array = null;
            bool ok = true;
            do
            {
                Console.Write(sentence);
                try
                {
                    array = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
                    foreach (int a in array)
                    {
                        if (a < minBorder || a > maxBorder)
                        {
                            ok = false;
                            break;
                        }
                    }

                }
                catch (Exception)
                {
                    ok = false;
                }

            }
            while (!ok);
            return array;
        }
        static void Main(string[] args)
        {
            int size = Int("");
            List<int> numbers = IntList("", size).ToList();
            List<int> tempArray = new List<int>();
            bool ismax = size % 2 == 0;
            while (numbers.Count != 1)
            {

                for (int i = 0; i < numbers.Count-1; i++)
                {
                    if (ismax)
                        tempArray.Add(Math.Max(numbers[i], numbers[i + 1]));
                    else
                        tempArray.Add(Math.Min(numbers[i], numbers[i + 1]));
                }
                ismax = !ismax;
                numbers = tempArray;
                tempArray = new List<int>();
            }
            Console.WriteLine(numbers[0]);

        }
    }
}
