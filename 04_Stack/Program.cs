namespace _04_Stack
{
    internal class Program
    {
        /******************************************************
		 * 스택 (Stack)
		 * 
		 * 선입후출(FILO), 후입선출(LIFO) 방식의 자료구조
		 * 가장 최신 입력된 순서대로 처리해야 하는 상황에 이용
		 ******************************************************/

        static void Test1()
        {
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < 10; i++)
            {
                stack.Push(i);
            }
            while (stack.Count > 0) Console.WriteLine(stack.Pop());
        }

        /******************************************************
		 * 큐 (Queue)
		 * 
		 * 선입선출(FIFO), 후입후출(LILO) 방식의 자료구조
		 * 입력된 순서대로 처리해야 하는 상황에 이용
		 ******************************************************/

        static void Test2()
        {
            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < 5; i++) queue.Enqueue(i);                   // 입력순서 : 0, 1, 2, 3, 4

            Console.WriteLine(queue.Peek());                                // 최전방 : 0

            while (queue.Count > 0) Console.WriteLine(queue.Dequeue());     // 출력순서 : 0, 1, 2, 3, 4
        }
        static void Main(string[] args)
        {
            Test2();
        }
    }
}