namespace _05_Queue
{
    internal class Program
    {
        /******************************************************
		 * 큐 (Queue)
		 * 
		 * 선입선출(FIFO), 후입후출(LILO) 방식의 자료구조
		 * 입력된 순서대로 처리해야 하는 상황에 이용
		 ******************************************************/


        // 원형큐 
        // 원형 배열 전단과 후단이 겹쳐있는경우 가득차있는지 비어있는지 판단이 애매해져서
        // n +1배열을 만들어서 전단보다 후단이 하나 전에 있다면 꽉차있다 판단한다
        // 

        //static void Test2()
        //{
        //    Queue<int> queue = new Queue<int>();

        //    for (int i = 0; i < 5; i++) queue.Enqueue(i);                   // 입력순서 : 0, 1, 2, 3, 4

        //    Console.WriteLine(queue.Peek());                                // 최전방 : 0

        //    while (queue.Count > 0) Console.WriteLine(queue.Dequeue());     // 출력순서 : 0, 1, 2, 3, 4
        //}
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}