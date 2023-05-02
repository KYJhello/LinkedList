namespace _12_ShortestPath
{
    
    internal class Program
    {
        public static int[,] GetSolution(int[,] arr1, int[,] arr2)
        {
            int[,] answer = new int[arr1.GetLength(0), arr1.GetLength(1)] ;

            for (int i = 0; i < arr1.GetLength(0); i++)
            {
                for(int j = 0;  j < arr1.GetLength(1); j++)
                {
                    answer[i, j] = arr1[i, j] + arr2[i, j];
                }
            }

            return answer;
        }
        static void Main(string[] args)
        {
            int[,] arr1 = { { 1, 2 }, { 2, 3 } };
            int[,] arr2 = { { 3, 4 }, { 5, 6 } };

            GetSolution(arr1, arr2);
        }
    }
}