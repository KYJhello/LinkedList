using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    internal static class Dijkstra
    {
        // int.MaxValue는 오버플로우 위험있어 사용하지 말기
        //              2147483647
        const int INF = 9999999;

        // 사용할 그래프를 받아오고 distance와 path를 out 참조로 사용
        public static void ShortestPath(in int[,] graph, int start, out int[] distance, out int[] path )
        {
            // 그래프의 y좌표 길이 받기
            int size = graph.GetLength(0);
            // 방문했는지 확인을 위한 배열 선언
            bool[] visited = new bool[size];

            // out 참조로 받아온 매개변수 초기화
            distance = new int[size];
            path = new int[size];

            // path와 distance 배열에 값 넣기
            for (int i = 0; i < size; i++)
            {
                distance[i] = graph[start, i];
                path[i] = graph[start, i] < INF ? start : -1;
                // i가 시작점이라면 path[i]는 -1로
                if (i == start)
                {
                    path[i] = -1;
                }
            }

            ////////////// 탐색 시작 /////////////////
            // 최대 반복 횟수
            for (int i = 0; i < size; i++)
            {
                // 1. 방문하지 않은 정점 중 가장 가까운 정점부터 탐색
                // 1-1)경로 및 코스트 초기화
                int next = -1;
                int minCost = INF;
                for (int j = 0; j < size; j++)
                {
                    if (!visited[j] &&
                        distance[j] < minCost)
                    {
                        next = j;
                        minCost = distance[j];
                    }
                }
                // exption(경로 없음) : next가 -1이면 탈출
                if (next < 0)
                    break;

                // 2. 직접연결된 거리보다 거쳐서 연결된 거리가 더 짧아진다면 갱신.
                for (int j = 0; j < size; j++)
                {
                    // cost[j]        : 목적지까지 직접 연결된 거리
                    // cost[next]     : 탐색중인 정점까지 거리
                    // graph[next, j] : 탐색중인 정점부터 목적지의 거리
                    if (distance[j] > distance[next] + graph[next, j])
                    {
                        distance[j] = distance[next] + graph[next, j];
                        path[j] = next;
                    }
                }
                // visited 트루로 변경
                visited[next] = true;
            }
        }

    }
}
