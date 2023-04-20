using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    // ########################
    // 2023-04-19
    // 김용준
    // LinkedList
    // ########################

    public class MyLinkedListNode<T>
    {
        // 클래스 내에서 사용될 변수들
        internal MyLinkedListNode<T> prev;
        internal MyLinkedListNode<T> next;
        private T item;

        // MyLinkedListNode의 생성자
        public MyLinkedListNode(T value)
        {
            this.List = null;
            this.prev = null;
            this.next = null;
            this.item = value;
        }
        // 리스트와 값을 받아오는 생성자
        internal MyLinkedListNode(MyLinkedList<T> list, T value)
        {
            this.List = list;
            this.prev = null;
            this.next = null;
            this.item = value;
        }
        // 리스트와 이전과 다음과 값을 받아오는 생성자
        internal MyLinkedListNode(MyLinkedList<T> list, MyLinkedListNode<T> prev, MyLinkedListNode<T> next, T value)
        {
            this.List = list;
            this.prev = prev;
            this.next = next;
            this.item = value;
        }
        // MyLinkedList<T>가 속하는 MyLinkedListNode<T>을 가져옵니다.
        public MyLinkedList<T>? List { get; }
        // MyLinkedList<T>의 다음 노드를 가져옵니다.
        public MyLinkedListNode<T>? Next { get { return next; } }
        // MyLinkedList<T>의 이전 노드를 가져옵니다.
        public MyLinkedListNode<T>? Previous { get { return prev; } }
        // 노드에 포함된 값을 가져옵니다.
        public T Value { get { return item; } set { item = value; } }

        // 노드에서 보유한 값에 대한 참조를 가져옴
        // public ref T ValueRef { get; }

    }
    public class MyLinkedList<T> //: IEnumerable<T>
    {
        // 
        private MyLinkedListNode<T> head;
        private MyLinkedListNode<T> tail;
        private int count;

        // MyLinkedList<T>에 실제로 포함된 노드의 수를 가져옵니다.
        public int Count { get { return count; } }
        // MyLinkedList<T>의 첫 번째 노드를 가져옵니다.
        public MyLinkedListNode<T>? First { get { return head; } }
        // MyLinkedList<T>의 마지막 노드를 가져옵니다.
        public MyLinkedListNode<T>? Last { get { return tail; } }
        // 비어 있는 MyLinkedList<T> 클래스의 새 인스턴스를 초기화합니다.
        public MyLinkedList()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }
        /*
        // 지정한 MyLinkedList<T>에서 복사된 요소가 포함되어 있고 복사된 요소의 수를 수용하는 충분한 용량을 가지는 IEnumerable 클래스의 새 인스턴스를 초기화합니다.
        public MyLinkedList(IEnumerable<T> collection)
        {
        }
        */

        // 1_AddFirst()
        // 1_1 AddFirst(LinkedListNode<T>)
        // MyLinkedList<T>의 시작 위치에 지정한 새 노드를 추가합니다.
        public void AddFirst(MyLinkedListNode<T> node)
        {

        }

        // 1_2 AddFirst(T)
        // LinkedList<T>의 시작 위치에 지정한 값이 포함된 새 노드를 추가합니다.
        public MyLinkedListNode<T> AddFirst(T value)
        {
            // 1. 새로운 노드 생성
            MyLinkedListNode<T> newNode = new MyLinkedListNode<T>(this, value);

            // 2. 연결구조 바꾸기
            // next의 주소에 head 넣고 헤드의 이전은 프리브로
            if (First != null)
            {
                newNode.next = head;
                head.prev = newNode;
                head = newNode;
            }
            else // 2-2. Head 노드가 없었을 때
            {
                head = newNode;
                tail = newNode;
            }
            // 3. 갯수 늘리기
            count++;
            return newNode;
        }

        // 2_AddLast()
        // MyLinkedList<T>의 마지막 위치에 지정한 값이 포함된 새 노드를 추가합니다.
        public MyLinkedListNode<T> AddLast(T value)
        {
            // 1. 새로운 노드 생성
            MyLinkedListNode<T> newNode = new MyLinkedListNode<T>(this, value);

            // 2. 연결구조 바꾸기
            // newNode의 
            if (Last != null)
            {
                newNode.prev = tail;
                tail.next = newNode;
                tail = newNode;
            }
            else
            {
                head = newNode;
                tail = newNode;
            }
            // 3. 갯수 늘리기
            count++;
            return newNode;
        }
        // 3_AddBefore()
        // MyLinkedList<T>의 지정한 기존 노드 앞에 지정한 새 노드를 추가합니다.
        public void AddBefore(MyLinkedListNode<T> node, MyLinkedListNode<T> newNode)
        {
            // 1. 연결구조 바꾸기
            newNode.next = node;
            newNode.prev = node.prev;
            node.prev.next = newNode;

            // node의 앞이 비어있다면 == node는 head
            if (node.prev != null)
                node.prev = newNode;
            else
                head = newNode;

            // 2. 갯수 늘리기
            count++;
        }
        // MyLinkedList<T>의 지정한 기존 노드 앞에 지정한 값이 포함된 새 노드를 추가합니다.
        public MyLinkedListNode<T> AddBefore(MyLinkedListNode<T> node, T value)
        {
            // 1. 새로운 노드 만들기
            MyLinkedListNode<T> newNode = new MyLinkedListNode<T>(this, value);

            // 2. 연결구조 바꾸기
            newNode.next = node;
            newNode.prev = node.prev;
            node.prev.next = newNode;

            // node의 앞이 비어있다면 == node는 head
            if (node.prev != null)
                node.prev = newNode;
            else
                head = newNode;

            // 3. 갯수 늘리기
            count++;

            return newNode;
        }
        // 4_AddAfter()
        // MyLinkedList<T>의 지정한 기존 노드 다음에 지정한 새 노드를 추가합니다.
        public void AddAfter(MyLinkedListNode<T> node, MyLinkedListNode<T> newNode)
        {
            // 1. 연결구조 바꾸기
            newNode.prev = node;
            newNode.next = node.next;
            node.next.prev = newNode;

            if(node.next != null)
                node.next = newNode;
            else head = newNode;

            count++;
        }

        // MyLinkedList<T>의 지정한 기존 노드 다음에 지정한 값이 포함된 새 노드를 추가합니다
        public MyLinkedListNode<T> AddAfter(MyLinkedListNode<T> node, T value)
        {
            MyLinkedListNode<T> newNode = new MyLinkedListNode<T>(this, value);

            // 1. 연결구조 바꾸기
            newNode.prev = node;
            newNode.next = node.next;
            node.next.prev = newNode;

            if (node.next != null)
                node.next = newNode;
            else head = newNode;

            count++;

            return newNode;
        }

        // 5_Remove(T value)
        // Removes the first occurrence of the specified value from the LinkedList<T>.
        public bool Remove(T value)
        {
            MyLinkedListNode<T>? node = Find(value);
            // find로 찾은 노드가 존재 한다면
            if(node != null)
            {
                Remove(node);
                return true;
            }
            // 존재하지 않거나 null이라면
            else
            {
                return false;
            }
        }
        // 6_Remove(node)
        // Removes the specified node from the LinkedList<T>.
        public void Remove(MyLinkedListNode<T> node)
        {
            // node가 head면 head에 다음 노드넣고
            if (head == node) head = node.next;
            // 노드가 tail이면 tail에 이전 노드 넣고
            if (tail == node) tail = node.prev;

            // 노드 앞이 null이 아니라면 앞노드의 다음을 현 노드의 다음으로 설정
            if (node.prev != null)
                node.prev.next = node.next;
            // 노드 다음이 null이 아니라면 뒷노드의 앞을 현 노드의 앞으로 설정
            if (node.next != null)
                node.next.prev = node.prev;

            count--;
        }

        // 7_Find
        public MyLinkedListNode<T>? Find(T value)
        {
            MyLinkedListNode<T>? node = head;
            // EqyalityComaprer의 기본 같음 비교자를 반환
            EqualityComparer<T> c = EqualityComparer<T>.Default;

            // 입력값이 null이 아니면
            if(value != null)
            {
                while(node != null)
                {
                    // 만약 노드의 value(아이템)이 value의 값과 같다면 true
                    if(c.Equals(node.Value, value))
                    {
                        return node;
                    }
                    else
                    {
                        node = node.Next;
                    }
                }
            }
            // 입력값이 null이라면(null인 노드 찾기)
            else
            {
                while(node != null)
                {
                    if (node.Value == null)
                        return node;
                    else
                        node = node.Next;
                }
            }
            return null;
        }
        


        // ###################

        // 2. LinkedList 기술면접 준비
        //
        //

        // ###################

        // 0_1 Contains

        // 0_2 FindLast

        // 0_3 RemoveFirst

        // 0_4 RemoveLast
    }
}
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime;
//using System.Text;
//using System.Threading.Tasks;

//namespace DataStructure
//{
//    // ########################
//    // 2023-04-19
//    // 김용준
//    // LinkedList
//    // ########################

//    public class MyLinkedListNode<T>
//    {
//        // 클래스 내에서 사용될 변수들
//        internal MyLinkedListNode<T> prev;
//        internal MyLinkedListNode<T> next;
//        private T item;

//        // MyLinkedListNode의 생성자
//        public MyLinkedListNode(T value)
//        {
//            this.List = null;
//            this.prev = null;
//            this.next = null;
//            this.item = value;
//        }
//        // 리스트와 값을 받아오는 생성자
//        internal MyLinkedListNode(MyLinkedList<T> list, T value)
//        {
//            this.List = list;
//            this.prev = null;
//            this.next = null;
//            this.item = value;
//        }
//        // 리스트와 이전과 다음과 값을 받아오는 생성자
//        internal MyLinkedListNode(MyLinkedList<T> list, MyLinkedListNode<T> prev, MyLinkedListNode<T> next, T value)
//        {
//            this.List = list;
//            this.prev = prev;
//            this.next = next;
//            this.item = value;
//        }
//        // MyLinkedList<T>가 속하는 MyLinkedListNode<T>을 가져옵니다.
//        public MyLinkedList<T>? List { get; }
//        // MyLinkedList<T>의 다음 노드를 가져옵니다.
//        public MyLinkedListNode<T>? Next { get { return next; } }
//        // MyLinkedList<T>의 이전 노드를 가져옵니다.
//        public MyLinkedListNode<T>? Previous { get { return prev; } }
//        // 노드에 포함된 값을 가져옵니다.
//        public T Value { get { return item; } set { item = value; } }

//        // 노드에서 보유한 값에 대한 참조를 가져옴
//        // public ref T ValueRef { get; }

//    }
//    public class MyLinkedList<T>{
//        // 
//        private MyLinkedListNode<T> head;
//        private MyLinkedListNode<T> tail;
//        private int count;

//        // MyLinkedList<T>에 실제로 포함된 노드의 수를 가져옵니다.
//        public int Count { get { return count; } }
//        // MyLinkedList<T>의 첫 번째 노드를 가져옵니다.
//        public MyLinkedListNode<T>? First { get { return head; } }
//        // MyLinkedList<T>의 마지막 노드를 가져옵니다.
//        public MyLinkedListNode<T>? Last { get { return tail; } }
//        // 비어 있는 MyLinkedList<T> 클래스의 새 인스턴스를 초기화합니다.
//        public MyLinkedList()
//        {
//            this.head = null;
//            this.tail = null;
//            this.count = 0;
//        }
//        /*
//        // 지정한 MyLinkedList<T>에서 복사된 요소가 포함되어 있고 복사된 요소의 수를 수용하는 충분한 용량을 가지는 IEnumerable 클래스의 새 인스턴스를 초기화합니다.
//        public MyLinkedList(IEnumerable<T> collection)
//        {
//        }
//        */

//        // 1_AddFirst()
//        // 1_1 AddFirst(LinkedListNode<T>)
//        // MyLinkedList<T>의 시작 위치에 지정한 새 노드를 추가합니다.
//        public void AddFirst(MyLinkedListNode<T> node)
//        {

//        }

//        // 1_2 AddFirst(T)
//        // LinkedList<T>의 시작 위치에 지정한 값이 포함된 새 노드를 추가합니다.
//        public MyLinkedListNode<T> AddFirst(T value)
//        {
//            // 1. 새로운 노드 생성
//            MyLinkedListNode<T> newNode = new MyLinkedListNode<T>(this, value);

//            // 2. 연결구조 바꾸기
//            // next의 주소에 head 넣고 헤드의 이전은 프리브로
//            if (First != null)
//            {
//                newNode.next = head;
//                head.prev = newNode;
//                head = newNode;
//            }
//            else // 2-2. Head 노드가 없었을 때
//            {
//                head = newNode;
//                tail = newNode;
//            }
//            // 3. 갯수 늘리기
//            count++;
//            return newNode;
//        }

//        // 2_AddLast()
//        // LinkedList<T>의 마지막 위치에 지정한 값이 포함된 새 노드를 추가합니다.
//        public MyLinkedListNode<T> AddLast(T value)
//        {
//            // 1. 새로운 노드 생성
//            MyLinkedListNode<T> newNode = new MyLinkedListNode<T>(this, value);

//            //// 2. 연결구조 바꾸기
//            //if (Last != null)
//            //{
//            //    newNode.prev = 
//            //}
//            //else
//            //{
//            //    head = newNode;
//            //    tail = newNode;
//            //}
//            // 3. 갯수 늘리기
//            count++;
//            return newNode;
//        }
//            // 3_AddBefore()

//            // 4_AddAfter()

//            // 5_Remove(T value)

//            // 6_Remove(node)

//            // 7_Find

//            // ###################

//            // 2. LinkedList 기술면접 준비
//            //
//            //

//            // ###################

//            // 0_1 Contains

//            // 0_2 FindLast

//            // 0_3 RemoveFirst

//            // 0_4 RemoveLast
//        }
//}
