﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    public class MyLinkedListNode<T> 
    {
        internal MyLinkedList<T> list;
        internal MyLinkedListNode<T> prev;
        internal MyLinkedListNode<T> next;
        private T item;

        public MyLinkedListNode(T value)
        {
            this.list = null;
            this.prev = null;
            this.next = null;
            this.item = value;
        }

        public MyLinkedListNode(MyLinkedList<T> list, T value)
        {
            this.list = list;
            this.prev = null;
            this.next = null;
            this.item = value;
        }

        public MyLinkedListNode(MyLinkedList<T> list, MyLinkedListNode<T> prev, MyLinkedListNode<T> next, T value)
        {
            this.list = list;
            this.prev = prev;
            this.next = next;
            this.item = value;
        }

        public MyLinkedList<T> List { get { return list; } }
        public MyLinkedListNode<T> Prev { get { return prev; } }
        public MyLinkedListNode<T> Next { get { return next; } }

        public T Item { get { return item; } set { item = value; } }
    }

    public class MyLinkedList<T> : IEnumerable<T>
    {
        private MyLinkedListNode<T> head;
        private MyLinkedListNode<T> tail;
        private int count;

        public MyLinkedList()
        {
            this.head = null;
            this.tail = null;
            count = 0;
        }

        public MyLinkedListNode<T> First { get { return head; } }
        public MyLinkedListNode<T> Last { get { return tail; } }
        public int Count { get { return count; } }

        public MyLinkedListNode<T> AddBefore(MyLinkedListNode<T> node, T value)
        {
            ValidateNode(node);
            MyLinkedListNode<T> newNode = new MyLinkedListNode<T>(this, value);
            InsertNodeBefore(node, newNode);
            if (node == head)
                head = newNode;
            return newNode;
        }

        public MyLinkedListNode<T> AddAfter(MyLinkedListNode<T> node, T value)
        {
            ValidateNode(node);
            MyLinkedListNode<T> newNode = new MyLinkedListNode<T>(this, value);
            InsertNodeAfter(node, newNode);
            if (node == tail)
                tail = newNode;
            return newNode;
        }

        public MyLinkedListNode<T> AddFirst(T value)
        {
            MyLinkedListNode<T> newNode = new MyLinkedListNode<T>(this, value);
            if (head != null)
            {
                InsertNodeBefore(head, newNode);
                head = newNode;
            }
            else
            {
                InsertNodeToEmptyList(newNode);
            }
            return newNode;
        }

        public MyLinkedListNode<T> AddLast(T value)
        {
            MyLinkedListNode<T> newNode = new MyLinkedListNode<T>(this, value);
            if (tail != null)
            {
                InsertNodeAfter(tail, newNode);
                tail = newNode;
            }
            else
            {
                InsertNodeToEmptyList(newNode);
            }
            return newNode;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(T value)
        {
            return Find(value) != null;
        }

        public MyLinkedListNode<T> Find(T value)
        {
            MyLinkedListNode<T>? node = head;
            EqualityComparer<T> c = EqualityComparer<T>.Default;
            if (value != null)
            {
                while (node != null)
                {
                    if (c.Equals(node.Item, value))
                        return node;
                    else
                        node = node.next;
                }
            }
            else
            {
                while (node != null)
                {
                    if (node.Item == null)
                        return node;
                    else
                        node = node.next;
                }
            }
            return null;
        }

        public bool Remove(T value)
        {
            MyLinkedListNode<T>? node = Find(value);
            if (node != null)
            {
                Remove(node);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Remove(MyLinkedListNode<T> node)
        {
            ValidateNode(node);
            if (head == node)
                head = node.next;
            if (tail == node)
                tail = node.prev;
            RemoveNode(node);
        }

        public void RemoveFirst()
        {
            if (head == null)
                throw new InvalidOperationException();

            MyLinkedListNode<T> headNode = head;
            Remove(headNode);
        }

        public void RemoveLast()
        {
            if (tail == null)
                throw new InvalidOperationException();

            MyLinkedListNode<T> tailNode = tail;
            Remove(tailNode);
        }

        private void ValidateNode(MyLinkedListNode<T> node)
        {
            if (node == null)
                throw new ArgumentNullException();
            if (node.list != this)
                throw new InvalidOperationException();
        }

        private void InsertNodeBefore(MyLinkedListNode<T> node, MyLinkedListNode<T> newNode)
        {
            newNode.next = node;
            newNode.prev = node.prev;
            if (newNode.prev != null)
                newNode.prev.next = newNode;

            node.prev = newNode;

            count++;
        }

        private void InsertNodeAfter(MyLinkedListNode<T> node, MyLinkedListNode<T> newNode)
        {
            newNode.prev = node;
            newNode.next = node.next;
            if (newNode.next != null)
                newNode.next.prev = newNode;

            node.next = newNode;

            count++;
        }

        private void InsertNodeToEmptyList(MyLinkedListNode<T> newNode)
        {
            if (count != 0)
                throw new InvalidOperationException();

            head = newNode;
            tail = newNode;
            count++;
        }

        private void RemoveNode(MyLinkedListNode<T> node)
        {
            if (node.list != this)
                throw new InvalidOperationException();

            if (node.prev != null)
                node.prev.next = node.next;
            if (node.next != null)
                node.next.prev = node.prev;

            count--;
        }

        // IEnumerator의 GetEnumerator 구현

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }
        
        // IEnumerable 의  GetEnumerator 구현
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        public struct Enumerator : IEnumerator<T>
        {
            private MyLinkedList<T> list;
            private MyLinkedListNode<T> node;
            private T current;

            internal Enumerator(MyLinkedList<T> list)
            {
                this.list = list;
                this.node = list.head;
                this.current = default(T);
            }

            public T Current { get { return current; } }

            object IEnumerator.Current { get { return current; } }

            public void Dispose() { }

            public bool MoveNext()
            {
                if (node != null)
                {
                    current = node.Item;
                    node = node.next;
                    return true;
                }
                else
                {
                    current = default(T);
                    return false;
                }
            }

            public void Reset()
            {
                this.node = list.head;
                current = default(T);
            }
        }
    }
}
