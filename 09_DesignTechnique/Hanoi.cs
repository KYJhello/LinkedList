using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_DesignTechnique
{
    internal class Hanoi
    {//static public void MoveAtoB( Stack<int> A, Stack<int> B)
     //{
     //    if (A == null)
     //        throw new ArgumentNullException();
     //    B.Push(A.Pop());
     //}
     //        public static void Move(int count, int start, int end)
     //        {
     //            //if(count > stick[0].Count)
     //            //{
     //            //    throw new ArgumentOutOfRangeException();
     //            //}
     //            if (count == 1)
     //            {
     //                int node = stick[start].Pop();
     //                stick[end].Push(node);
     //                Console.WriteLine($"{start} 스틱에서 {end} 스틱으로 {node} 블럭이 이동함");
     //                return;
     //            }
     //            int other = 3 - start - end;

        //            Move(count - 1, start, other);
        //            Move(1, start, end);
        //            Move(count - 1, other, end);
        //        }
        //        public static Stack<int>[] stick;

        //        //Stack<int> H1 = new Stack<int>();
        //        //Stack<int> H2 = new Stack<int>();
        //        //Stack<int> H3 = new Stack<int>();

        //        //H1.Push(4);
        //        //H1.Push(3);
        //        //H1.Push(2);
        //        //H1.Push(1);

        //        //MoveAtoB( H1,  H2);


        //        int stackLen = 5;

        //        stick = new Stack<int>[stackLen];
        //            for(int i  = 0; i<stick.Length; i++)
        //            {
        //                stick[i] = new Stack<int>();
        //            }
        //            for(int i = stackLen; i > 0 ; i--)
        //            {
        //                stick[0].Push(i);
        //}

        //Move(stackLen, 0, 2);

    }
}
