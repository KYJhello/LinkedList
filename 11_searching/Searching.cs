using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search
{
    internal class Searching
    {
        // <순차 탐색>
        public static int SequentialSearch<T>(in IList<T> list, in T item) where T : IComparable<T>
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (item.CompareTo(list[i]) == 0)
                    return i;
            }
            return -1;
        }

        // <이진 탐색>
        public static int BinarySearch<T>(in IList<T> list, in T item) where T : IComparable<T>
        {
            int low = 0;
            int high = list.Count - 1;

            while(low <= high)
            {
                int middle =(low+high) / 2; // >> 1 과 같다.
                int compare = list[middle].CompareTo(item);

                // 비교해서 더 작은 경우
                if (compare < 0) 
                    low = middle + 1;
                // 비교해서 더 큰 경우
                else if (compare > 0)
                    high = middle - 1;
                else
                    return middle;
            }
            return -1;

        }
        //public static int BinarySearch<T>(in IList<T> list, in T item) where T : IComparable<T>, IEquatable<T>
        //{
        //    return BinarySearch(list, item, 0, list.Count);
        //}
        //public static int BinarySearch<T>(in IList<T> list, in T item, int index, int count) where T : IComparable<T>
        //{
        //    if (index < 0)
        //        throw new IndexOutOfRangeException();
        //    if (count < 0)
        //        throw new ArgumentOutOfRangeException();
        //    if (index + count > list.Count)
        //        throw new ArgumentOutOfRangeException();

        //    int low = index;
        //    int high = index + count - 1;
        //    while (low <= high)
        //    {
        //        int middle = low + (high - low) / 2;
        //        int compare = list[middle].CompareTo(item);

        //        if (compare < 0)
        //            low = middle + 1;
        //        else if (compare > 0)
        //            high = middle - 1;
        //        else
        //            return middle;
        //    }


        // <인접행렬 그래프>
        // [시작정점, 끝정점] ex) [1,3] 1번정점 -> 3번정점
        public static bool[,] matrixGraph3 = new bool[5, 5]
        {
            { false, true , true , true , true  },
            { true , false,  true, false, true  },
            { true ,  true, false, false, false },
            { true , false, false, false,  true },
            {  true, true , false,  true, false }
        };
        const int INF = int.MaxValue;

        // 예시 - 단방향 가중치 그래프 (단절은 최대값으로 표현)
        int[,] matrixGraph4 = new int[5, 5]
        {
            {   0, 132, INF, INF,  16 },
            {  12,   0, INF, INF, INF },
            { INF,  38,   0, INF, INF },
            { INF,  12, INF,   0,  54 },
            { INF, INF, INF, INF,   0 },
        };

        public static void Test()
        {
            if (matrixGraph3[3, 0])
            {
                Console.WriteLine( "가능");
            }
        }

         

        // <인접리스트 그래프>
        List<List<int>> listGraph1;             // 연결그래프
        List<List<(int, int)>> listGraph2;		// 가중치 그래프

        public void CreateGraph()
        {
            listGraph1 = new List<List<int>>();
            for(int i = 0; i < 5; i++)
            {
                listGraph1.Add(new List<int>());
            }
            // 0번에서 1번으로 갈 수 있다.
            listGraph1[0].Add(1);
            listGraph1[1].Add(0);
            listGraph1[1].Add(3);
            listGraph1[2].Add(0);
            listGraph1[2].Add(1);
            listGraph1[2].Add(4);
            listGraph1[3].Add(1);
            listGraph1[4].Add(3);
            
        }


    }
}
