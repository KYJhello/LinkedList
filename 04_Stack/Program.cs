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
            stack.Peek();

            for (int i = 0; i < 10; i++)
            {
                stack.Push(i);
            }
            while (stack.Count > 0) Console.WriteLine(stack.Pop());
        }

        
        static void Main(string[] args)
        {
            DataStructure.Stack_Adapter<int> stack = new DataStructure.Stack_Adapter<int>();

            for(int i = 0;i < 10;i++) stack.Push(i);

            Console.WriteLine(stack.Peek());

            while (stack.GetCount() > 0) Console.WriteLine(stack.Pop());

        }
    }
}