﻿namespace _11_searching
{
    internal class Program
    {
        // 깊이 우선 탐색 Depth First Search
        // 그래프의 분기를 만났을 때 최대한 깊이 내려간 뒤,
        // 더이상 깊이 갈 곳이 없을 경우 다음 분기를 탐색 
        // 백트래킹
        public static void DFS(bool[,] graph, int start, out bool[] visited, out int[] parent)
        {
            visited = new bool[graph.GetLength(0)];
            parent = new int[graph.GetLength(0)];

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                visited[i] = false;
                parent[i] = -1;
            }

            SearchNode(graph, start, visited, parent);
        }
        private static void SearchNode(in bool[,] graph, int start, bool[] visited, int[] parents)
        {
            visited[start] = true;
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                if (graph[start, i] &&      // 연결되어 있는 정점이며,
                    !visited[i])            // 방문한적 없는 정점
                {
                    parents[i] = start;
                    SearchNode(graph, i, visited, parents);
                }
            }
        }                                                                                                                                                                                                                                         
        // 너비 우선 탐색 Breadth First Search
        // 그래프의 분기를 만났을 때 모든 분기를 저장한 뒤,
        // 저장한 분기를 하나씩 탐색 
        // 동적계획
        public static void BFS() { 
        
        }

        static void Main(string[] args)
        {
            Search.Searching.Test();
        }
    }
}