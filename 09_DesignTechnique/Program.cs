using System.Text;

namespace _09_DesignTechnique
{
    internal class Program
    {
        static StringBuilder? tempStr;
        // 1. 재귀 하노이탑 문제
        /*
        static StringBuilder? printStr;
        static int count = 0;

        public static void Move(int n, int start, int end, ref Stack<int>[] stick)
        {

            if (n == 1)
            {
                count++;
                int node = stick[start].Pop();
                stick[end].Push(node);
                printStr.Append((start + 1) + " " + (end + 1) + "\n");
                return;
            }
            int other = 3 - start - end;

            Move(n - 1, start, other, ref stick);
            Move(1, start, end, ref stick);
            Move(n - 1, other, end, ref stick);
        }
        public void Hanoi()
        {
            printStr = new StringBuilder("");
            int n = int.Parse(Console.ReadLine());
            // 0, 1, 2 스택 생성
            Stack<int>[] stick = new Stack<int>[3];
            // 각 스택 선언
            stick[0] = new Stack<int>();
            stick[1] = new Stack<int>();
            stick[2] = new Stack<int>();

            // 처음 스택에 n, n-1, ... , 1 순으로 저장
            for (int i = n; i > 0; i--)
            {
                stick[0].Push(i);
            }

            Move(n, 0, 2, ref stick);
            Console.WriteLine(count);
            Console.WriteLine(printStr.ToString());
        }
        */
        // 2. 백트래킹
        public static bool NandM(int n , int m)
        {
            //int len = 1;
            //for(int i = 0; i < m; i++)
            //{
            //    len *= n;
            //}
            //int[] arr = new int[len];

            // arr의 x 최대 길이는 m
            // arr의 y 최대 길이는 n

            int[,] answer = new int[m, n];
            List<int> ans = new List<int>();
            for(int i = 0; i < m; i++)
            {
                
                
                return true;
            }
            return false;
        }


        static void Main(string[] args)
        {
            tempStr = new StringBuilder("");

            int input = int.Parse(Console.ReadLine().Trim());
            int n1 = input / 10;
            int n2 = input % 10;
            NandM(n1, n2);
            
        }
    }
}