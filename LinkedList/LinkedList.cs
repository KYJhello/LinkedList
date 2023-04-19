using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class LinkedListNode<T> {
        internal LinkedList<T> list;
        internal LinkedListNode<T> prev;
        internal LinkedListNode<T> next;
        private T item;

        public LinkedListNode(T value)
        {
            this.list = null;
            this.prev = null;
            this.next = null;
            this.item = value;
        }
        public LinkedListNode(LinkedList<T> list, T value)
        {
            this.list = list;
            this.prev = null;
            this.next = null;
            this.item = value;
        }
        public LinkedListNode(LinkedList<T> list, LinkedListNode<T> prev, LinkedListNode<T> next, T value)
        {
            this.list = list;
            this.prev = prev;
            this.next = next;
            this.item = value;
        }

        public LinkedListNode<T> Prev {  get { return prev; } }
        public LinkedListNode<T> Next { get {  return next; } }
        public T Value { get { return item; } set { item = value; } }
        
    }

    public class LinkedList<T>
    {
        private LinkedListNode<T> head;
        private LinkedListNode<T> tail;
        private int count;

        public LinkedList()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        public LinkedListNode<T> First {  get { return head; } }
        public LinkedListNode<T> Last { get {  return tail; } }
        public int Count { get { return count; } }

        public LinkedListNode<T> AddFirst(T value)
        {
            // 1. 새로운 노드 생성
            LinkedListNode<T> newNode = new LinkedListNode<T> (this, value);
            // 2. 연결구조 바꾸기
            // next의 주소에 head 넣고 헤드의 이전은 프리브로
            if(head != null) // 2-1. Head 노드가 있었을 때
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

        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)
        {
            // 1. 새로운 노드 만들기
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);

            // 2. 연결구조 바꾸기
            newNode.next = node;
            newNode.prev = node.prev;
            node.prev.next = newNode;
            if(node.prev != null)  // node.prev == null : node == head 
                node.prev = newNode;
            else
                head= newNode;

            // 3. 갯수 증가
            count++;

            return newNode;
        }
        public void Remove(LinkedListNode<T> node)
        {
            // 예외1) node가 linkedList에 포함된 노드가 아닌경우 에러 throw
            if (node.list != this) throw new InvalidOperationException();
            // 예외2) node가 NULL인 경우 에러 throw
            if(node == null) throw new ArgumentNullException(nameof(node));

            // 0. 지웠을 때 head나 tail이 변경되는 경우 적용
            if (head == node) head = node.next;
            if (tail == node) tail = node.prev;
            
            // 1. 연결구조 바꾸기
            if(node.prev != null) node.prev.next = node.next; // 이전 노드가 있을때만 이전 노드의 다음을 내 다음 노드로
            if(node.next != null) node.next.prev = node.prev; // 다음 노드가 있을때만 다음 노드의 이전을 내 이전 노드로

            // 2. 실제 노드 지우기
            count--;
        }
        public bool Remove(T value)
        {
            LinkedListNode<T> findNode = Find(value);
            if(findNode != null)
            {
                Remove(findNode);
                return true;
            }
            else
            {
                return false;
            }
        }
        public LinkedListNode<T> Find(T value) // where T : IComparable<T>
        {
            LinkedListNode<T> target = head;
            // 둘이 같은지 비교하는 클래스
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;

            while (target != null)
            {
                // 일반화로 인해 comparer를 사용해 둘이 동일한 애인지 확인
                //if(target.Value.Equals(value))return target;
                if (comparer.Equals(value, target.Value)) return target;
                else target = target.next;
            }
            return null;
        }
    }
}
