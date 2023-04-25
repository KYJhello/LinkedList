using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    // 1. 이진탐색트리 탐색, 추가, 삭제 구현
    internal class BinarySearchTree<T> where T : IComparable<T>
    {
        // 이진탐색트리 구현을 위한 private class Node
        private class Node
        {
            private T item;
            private Node parent;
            private Node left;
            private Node right;

            public Node(T item, Node parent, Node left, Node right)
            {
                this.item = item;
                this.parent = parent;
                this.left = left;
                this.right = right;
            }

            public T Item { get { return item; } set { item = value; } }
            public Node Parent { get { return parent; } set { parent = value; } }
            public Node Left { get { return left; } set { left = value; } }
            public Node Right { get { return right; } set { right = value; } }

            // 부모가 없는 루트 노드인가?
            public bool IsRootNode { get { return parent == null; } }
            // 부모가 있는 좌측 노드인가?
            public bool IsLeftChild { get { return parent != null && parent.left == this; } }
            // 부모가 있는 우측 노드인가?
            public bool IsRightChild { get { return parent != null && parent.right == this; } }

            // 자식이 없는 노드인가?
            public bool HasNoChild { get { return left == null && right == null; } }
            // 왼쪽 차일드를 지닌 노드인가?
            public bool HasLeftChild { get { return left != null && right == null; } }
            // 오른쪽 차일드를 지닌 노드인가?
            public bool HasRightChild { get { return left == null && right != null; } }
            // 왼쪽, 오른쪽 차일드(2명)을 지닌 노드인가?
            public bool HasBothChild { get { return left != null && right != null; } }
        }

        // root노드
        private Node root;

        // 생성자
        public BinarySearchTree()
        {
            this.root = null;
        }

        // 탐색
        private Node FindNode(T item)
        {
            Node newNode = new Node(item, null, null, null);

            if (root == null)
            {
                return null;
            }

            // 현재 노드를 루트로 초기화
            Node current = root;

            // root가 null이 아닌 경우
            while (current != null)
            {
                if (item.CompareTo(current.Item) < 0)
                {
                    current = current.Left;
                }
                else if (item.CompareTo(current.Item) > 0) {
                    current = current.Right;
                }
                else
                {
                    return current;
                }
            }
            return null;
        }

        // 추가
        public bool Add(T item)
        {
            // item, parent, left, right
            Node newNode = new Node(item, null, null, null);

            if (root == null)
            {
                root = newNode;
                return true;
            }

            // 현재 노드를 루트로 초기화
            Node current = root;

            // root가 null이 아닌 경우
            while (current != null)
            {
                // 새로들어온 아이템이 루트 아이템보다 작은경우
                if (item.CompareTo(current.Item) < 0)
                {
                    // 만약 현재 기준 왼쪽 노드가 있다면
                    if (current.Left != null)
                    {
                        // 현재에 왼쪽 노드 주소를 할당
                        current = current.Left;
                    }
                    else
                    {
                        // 왼쪽노드가 없는 경우 새로운 노드를 왼쪽노드로 추가
                        current.Left = newNode;
                        newNode.Parent = current;
                        break;
                    }
                }
                // 새로들어온 아이템이 루트 아이템보다 큰경우
                else if (item.CompareTo(current.Item) > 0)
                {
                    // 현재 오른쪽이 있다면
                    if (current.Right != null)
                    {
                        // 오른쪽 노드 주소를 현재에 할당
                        current = current.Right;
                    }
                    else
                    {   // 오른쪽 노드가 없는경우 새로운 노드를 오른쪽 노드로 추가
                        current.Right = newNode;
                        newNode.Parent = current;
                        break;
                    }
                }
                // 새로 들어온 아이템이 루트와 같다면(중복) false를 반환(허용안함)
                else
                {
                    return false;
                }
            }
            return true;
        }

        // 삭제
        public bool Remove(T item)
        {
            if (root == null)
            {
                return false;
            }

            Node findNode = FindNode(item);
            if (findNode == null)
            {
                return false;
            }
            else
            {
                EraseNode(findNode);
                return true;
            }
        }
        // 노드 삭제를 위한 함수
        private void EraseNode(Node node)
        {
            if (node.HasNoChild)
            {

            }
            else if (node.HasLeftChild || node.HasRightChild)
            {

            }
            else if (node.HasBothChild)
            {

            }
        }
    }
}
