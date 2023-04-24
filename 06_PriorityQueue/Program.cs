﻿namespace _06_PriorityQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataStructure.PriorityQueue<string, int> pq1 = new DataStructure.PriorityQueue<string, int>();

            pq1.Enqueue("데이터1", 1);     // 우선순위와 데이터를 추가
            pq1.Enqueue("데이터2", 3);
            pq1.Enqueue("데이터3", 5);
            pq1.Enqueue("데이터4", 2);
            pq1.Enqueue("데이터5", 4);

            while (pq1.Count > 0) Console.WriteLine(pq1.Dequeue()); // 우선순위가 높은 순서대로 데이터 출력


            // 수정 int 우선순위 적용
            DataStructure.PriorityQueue<string, int> pq2 = new DataStructure.PriorityQueue<string, int>(Comparer<int>.Create((a, b) => b - a));

            pq2.Enqueue("데이터1", 1);     // 우선순위와 데이터를 추가
            pq2.Enqueue("데이터2", 3);
            pq2.Enqueue("데이터3", 5);
            pq2.Enqueue("데이터4", 2);
            pq2.Enqueue("데이터5", 4);

            while (pq2.Count > 0) Console.WriteLine(pq2.Dequeue()); // 우선순위가 높은 순서대로 데이터 출력

        }
    }
}