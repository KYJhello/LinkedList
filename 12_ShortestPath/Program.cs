using System.Linq;
namespace _12_ShortestPath
{
    internal class Program
    {
        private static void PrintDijkstra(int[] distance, int[] path)
        {
            Console.Write("Vertex");
            Console.Write("\t");
            Console.Write("dist");
            Console.Write("\t");
            Console.WriteLine("path");

            for (int i = 0; i < distance.Length; i++)
            {
                Console.Write("{0,3}", i);
                Console.Write("\t");
                if (distance[i] >= INF)
                    Console.Write("INF");
                else
                    Console.Write("{0,3}", distance[i]);
                Console.Write("\t");
                if (path[i] < 0)
                    Console.WriteLine("  X ");
                else
                    Console.WriteLine("{0,3}", path[i]);
            }
        }

        const int INF = 9999999;
        static void Main(string[] args)
        {
            int[,] arr1 = new int[8, 8] {{0  ,9  ,9  ,INF,INF,INF,INF,INF},
                                         {8  ,0  ,6  ,INF,INF,INF,INF,INF},
                                         {5  ,INF,0  ,INF,6  ,INF,5  ,INF},
                                         {INF,4  ,INF,0  ,INF,INF,INF,INF},
                                         {INF,INF,5  ,INF,0  ,INF,2  ,INF},
                                         {INF,INF,INF,INF,INF,0  ,9  ,5  },
                                         {INF,INF,INF,INF,INF,INF,0  ,INF},
                                         {INF,INF,INF,INF,INF,9  ,9  ,0  }};

            // out 매개변수 사용예정이라 초기화 생략가능
            int[] distance;
            int[] path;
            DataStructure.Dijkstra.ShortestPath(in arr1, 1,out distance, out path);
            Console.WriteLine("<Dijkstra>");
            PrintDijkstra(distance, path);

        }
    }
}