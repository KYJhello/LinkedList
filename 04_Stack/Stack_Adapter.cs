using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    // 스택 (어뎁터)
    internal class Stack_Adapter<T>
    {
        // T형 리스트를 담을 컨테이너
        private List<T> container;

        // container에 새로 할당
        public Stack_Adapter(){
            container = new List<T>();
        }
        // 스택에 아이탬을 push함
        public void Push(T item)
        {
            container.Add(item);
        }
        // 스택 맨 위의 아이템을 가져오고 기존값 삭제 x
        public T? Peek()
        {
            // 최상위 값을 가져옴
            return container[container.Count - 1];
        }
        // 스택에서 아이템을 꺼내오고 기존 값 삭제
        public T Pop()
        {
            T item = container[container.Count - 1];
            container.RemoveAt(container.Count - 1);
            return item;
        }
        public int GetCount() { return container.Count; }
    }
}
