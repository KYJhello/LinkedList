namespace _10_Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 8개 원소 지닌 int 배열
            int[] ints = { 6, 5, 4, 3, 2, 1 };
            // int[] ints = { 5, 6, 7, 8, 1, 3, 9, 2 };
            Datastructure.BubbleSort bubble = new Datastructure.BubbleSort(ints);
        }
    }
}