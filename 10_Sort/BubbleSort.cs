using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastructure
{
    internal class BubbleSort
    {
        public BubbleSort(int[] input) {
            for (int j = input.Length-1; j > 0; j--)
            {
                for (int i = 1; i < input.Length; i++)
                {
                    if (input[i - 1] > input[i])
                    {
                        int temp = input[i];
                        input[i] = input[i - 1];
                        input[i - 1] = temp;
                    }
                }
                Print(input);
                Console.WriteLine();
            }
            
        }
        private void Print(int[] input)
        {
            foreach (int i in input)
            {
                Console.Write(i + " ");
            }
        }
    }
}
