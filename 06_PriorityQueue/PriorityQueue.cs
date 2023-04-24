using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    internal class PriorityQueue<TElement, TPriority>
    {
        private struct Node
        {
            public TElement Element;
            public TPriority Priority;
        }
        private List<Node> nodes;
        private IComparer<TPriority> comparer;

        public PriorityQueue()
        {
            this.nodes = new List<Node>();
            this.comparer = Comparer<TPriority>.Default;
        }
        public PriorityQueue(IComparer<TPriority> comparer)
        {
            this.nodes = new List<Node>();
            this.comparer = comparer;
        }

        public int Count { get { return nodes.Count; } }
        public IComparer<TPriority> Comparer { get {  return comparer; } }

        // 큐에 우선순위와 값을 가진 노드를 집어넣음
        public void Enqueue(TElement element, TPriority priority)
        {
            Node newNode = new Node() { Element = element, Priority = priority };
            pushHeap(newNode);
        }
        // 큐의 루트값을 반환함
        public TElement Peek()
        {
            if(nodes.Count == 0)
            {
                throw new InvalidOperationException();
            }
            return nodes[0].Element;
        }
        // 노드가 존재한다면 노드의 값과 우선순위를 참조를 통해 인수를 전달하고 true를 반환, 
        // 존재하지 않는다면 기본값을 참조하여 전달하고 false를 반환한다.
        public bool TryPeek(out TElement element, out TPriority priority)
        {
            // 노드가 존재하지 않는경우
            if (nodes.Count == 0)
            {
                element = default(TElement);
                priority = default(TPriority);
                return false;
            }

            // 노드가 존재하는경우
            element = nodes[0].Element;
            priority = nodes[0].Priority;
            return true;
        }
        // 우선순위가 가장 높은 노드 제거 및 반환
        public TElement Dequeue()
        {
            //노드가 없다면 에러 
            if (nodes.Count == 0)
                throw new InvalidOperationException();
            // 루트 노드 주소 저장
            Node rootNode= nodes[0];
            // 우선순위 높은 노드 제거후 힙 복구하는 함수
            PopHeap();
            return rootNode.Element;
        }
        public bool TryDequeue(out TElement element, out TPriority priority)
        {
            if (nodes.Count == 0)
            {
                element = default(TElement);
                priority = default(TPriority);
                return false;
            }

            Node rootNode = nodes[0];
            element = rootNode.Element;
            priority = rootNode.Priority;
            PopHeap();
            return true;
        }

        // 힙에 넣는 과정을 구현한 함수
        private void pushHeap(Node newNode)
        {
            // 노드 리스트에 새로운 값을 추가
            nodes.Add(newNode);
            // 새로운 노드의 인덱스값
            int newNodeIndex = nodes.Count - 1;
            // root에 가면 비교대상 없어서 총료
            while(newNodeIndex > 0)
            {
                int parentIndex = GetParentIndex(newNodeIndex);
                Node parentNode = nodes[parentIndex];

                // compare() 결과 값이 newNode가 작은 경우
                if(comparer.Compare(newNode.Priority, parentNode.Priority) < 0)
                {
                    // 1. 새로운 노드 위치로 부모노드를 참조하여 옮기고
                    nodes[newNodeIndex] = parentNode;
                    // 2. 새로운 노드 인덱스를 부모노드 인덱스로 바꾼다
                    newNodeIndex = parentIndex;
                }
                else
                {
                    break;
                }
            }
            // 3. 바뀐 노드 인덱스에 기존 노드를 집어 넣는다
            nodes[newNodeIndex] = newNode;
        }
        // 루트노드를 pop하는 과정을 나타낸 함수
        private void PopHeap()
        {
            // 마지막 노드를 루트노드 위치로 보내기 위해 저장
            Node lastNode = nodes[nodes.Count - 1];
            nodes.RemoveAt(nodes.Count - 1);

            int index = 0;
            while(index < nodes.Count)
            {
                int leftChildIndex = GetLeftChildIndex(index);
                int rightChildIndex = GetRightChildIndex(index);

                // 자식노드가 오른쪽 값도 있다면(두개)
                if(rightChildIndex < nodes.Count)
                {
                    // 왼쪽 노드와 오르쪽 노드를 비교해 우선순위가 높은(값으론 낮은) 값의 인덱스를 반환
                    int compareIndex = comparer.Compare(nodes[leftChildIndex].Priority, nodes[rightChildIndex].Priority) < 0 ? leftChildIndex : rightChildIndex;

                    if (comparer.Compare(nodes[compareIndex].Priority, lastNode.Priority) < 0)
                    {
                        nodes[index] = nodes[compareIndex];
                        index = compareIndex;
                    }
                    else
                    {
                        nodes[index] = lastNode;
                        break;
                    }
                }
                // 자식 노드가 왼쪽값만 있다면(한개)
                else if( leftChildIndex < nodes.Count )
                {
                    if (comparer.Compare(nodes[leftChildIndex].Priority, lastNode.Priority) < 0)
                    {
                        nodes[index] = nodes[leftChildIndex];
                        index = leftChildIndex;
                    }
                    else
                    {
                        nodes[index] = lastNode;
                        break;
                    }
                }
                // 자식 노드가 아에 없다면 (0개)
                else
                {
                    nodes[index] = lastNode;
                    break;
                }
            }
        }

        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }
        private int GetLeftChildIndex(int index)
        {
            return index * 2 + 1;
        }

        private int GetRightChildIndex(int index)
        {
            return index * 2 + 2;
        }
    }
}
