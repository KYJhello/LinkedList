namespace LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataStructure.MyLinkedList<int> linkedList = new DataStructure.MyLinkedList<int>();

            linkedList.AddFirst(0);
            linkedList.AddFirst(1);
            linkedList.AddFirst(2);
            linkedList.AddFirst(3);
            linkedList.AddFirst(4);

            linkedList.Remove(linkedList.First);


        }
    }
}