﻿namespace _07_BinarySearchTree
{
    internal class Program
    {
        // #######################################
        // 2023-04-25
        // 김용준
        // BinarySearchTree(이진탐색트리)
        // #######################################


        // 2. 이진탐색트리의 한계점과 극복방법 조사
        // 문제점 : 부모의 노드보다 오름차순 혹은 내림차순으로 데이터가 삽입되는 경우 트리의 높이가 높아진다.
        // 극복방법 : 균형이진탐색트리 사용 (AVL, Red-Black), 높이를 O(log(n))으로 제한하여 고안
        // 
        // AVL : 노드가 삽입&삭제될 때 트리의 균형 상태를 파악해서 스스로 그 구조를 변경하여 균형을 유지하는 트리
        // 각 노드의 BF는 {-1, 0, 1}값만 가지게 함으로서 왼쪽 서브 트리와 오른쪽 서브 트리의 균형을 상시유지
        // 균형인수(BF, Balance Factor)는 균형의 정도를 표현하기 위해서 사용하며 
        // BF = 왼쪽 서브트리의 높이 - 오른쪽 서브트리의 높이
        // 각 노드의 왼쪽 서브 트리의 높이와 오른쪽 서브트리 높이의 차이이다
        // 리밸런싱 작업 : 노드의 BF가 '+' 면 왼쪽서브트리, '-' 면 오른쪽 서브트리의 문제
        // 회전연산 : 단순회전, 이중회전이 있고
        // LL, RR, LR, RL 유형에 따른 회전연산을 수행한다.

        // Red-Black : 자가균형 이진탐색 트리
        // 1) 모든 노드는 빨간색 혹은 검은색
        // 2) 루트 노드는 검은색
        // 3) 모든 리프(NIL)들은 검은색
        // 4) 빨간색 노드의 자식은 검은색(빨간색 노드가 연속으로 못나옴)
        // 5) 모든 리프 노드에서 Black Depth 는 같다(리프노드에서 루트노드까지 가는 경로에서 만나는 검은색 노드의 개수가 같다)
        // 삽입) 새로운 노드는 항상 빨간색으로 삽입함, Double Red 발생시 삼촌 노드가 검은색이냐 빨간색이냐로 수행 내용이 달라짐
        // 삼촌노드가 검은색(Restructuring) : 새로운 노드, 부모노드, 조상 노드를 오름차순으로 정렬
        //                                  셋중 중간값을 부모로 만들고 나머지 둘을 자식으로 만듬
        //                                  새로 부모가 된 노드를 검은색으로 만들고 나머지 자식들을 빨간색으로 만듬
        // 삼촌노드가 빨간색(Recoloring) : 새로운 노드의 부모와 삼촌을 검은색으로 바꾸고 조상을 빨간색으로 바꿈
        //                              조상이 루트노드라면 검은색으로 바꿈
        //                              조상을 빨간색으로 바꿨을 때 또다시 Double Red 발생시 Restructuring과 Recoloring을
        //                              문제 해결시까지 반복한다.

        // 3. 이진탐색트리의 순회방법 조사와 순회순서
        // 전위 순회(Preorder Traversal)    :
        // 깊이 우선순회(DFT,Depth-First Traversal)이라고도 불림
        // 트리를 복사하거나, 전위 표기법을 구하는데 주로 사용됨
        // 순회 순서) 현재 노드 처리 -> 왼쪽 노드 방문 -> 오른쪽 노드 방문 
        //
        // 중위 순회(Inorder Traversal)     :
        // 대칭순회(symmetric traversal)이라고도 불림 
        // BST에서 오름차순 혹은 내림차순으로 값을 가져올 때 사용됨
        // 순회 순서) 왼쪽 노드 방문 -> 현재 노드 처리 -> 오른쪽 노드 방문
        // 
        // 후위 순회(Postorder Traversal)   :
        // 트리를 삭제하는데 주로 사용됨
        // 부모노드를 삭제하기 전에 자식노드를 삭제해야 하기 때문
        // 순회 순서) 왼쪽 노드 방문 -> 오른쪽 노드 방문 -> 현재 노드 처리




        static void Main(string[] args)
        {
            DataStructure.BinarySearchTree<int> bst = new DataStructure.BinarySearchTree<int>();

            bst.Add(3);
            bst.Add(1);
            bst.Add(5);
            bst.Add(2);
            bst.Add(4);
            bst.Add(6);

            bst.Remove(3);
            bst.Remove(4);
        }
    }
}