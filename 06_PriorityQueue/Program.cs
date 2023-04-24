namespace _06_PriorityQueue
{
    // #######################
    // 2023-04-24
    // 김용준
    // PriorityQueue
    // #######################

    // 2. 힙정렬 기술면접 준비
    // 힙 : Tree의 구조로 이루어진 자료구조, 최소값을 찾는데 항상 O(1)의 시간복잡도 보장
    //      각 노드의 키값이 자식의 키값보다 작지 않거나(최대힙) 
    //      그 자식의 키값보다 크지않은(최소힙) 완전 이진트리이다.
    // 추가 : 마지막 노드에 값을 추가 후 부모의 우선순위와 비교하여
    //       부모의 우선순위보다 큰 경우 서로 위치를 바꿔가며 힙을 완성한다
    //       O(log n)의 시간복잡도를 가짐
    // 삭제 : 루트노드를 삭제 후 마지막 노드를 처음 노드에 넣은 뒤
    //       자식 노드들과 비교를 하여 swap을 해가며 힙을 완성한다.
    //       O(log n)의 시간복잡도를 가짐
    // 완전이진트리 배열표현 :
    // 이진 트리의 경우 보통 리스트 자료구조로 구현
    // 완전 이진트리의 경우 배열도 유용하지만 계층의 개념이 주입되어야함
    // 부모가 N이면 왼쪽 자식은 2 * N + 1이고
    // 오른쪽 자식은 2 * N + 2 이다.
    // 자식의 값이 K라면 부모의 값은 ((K - 1) / 2)이다(나머지는 버림)

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