using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Queue
{
    // 순환 배열
    internal class Queue<T>
    {
        private const int DefaultCapacity = 10;

        private T[] items;
        private int head;
        private int tail;

        // Queue 생성자
        public Queue()
        {
            // 배열이 비어있는지 꽉차있는지 확인을 위한 최대 용량보다 1 추가해 만들기
            items = new T[DefaultCapacity + 1];
            head = 0;
            tail = 0;
        }
        // Queue의 현재 element 갯수
        public int Count
        {
            get
            {
                if (head <= tail) return tail - head;
                else return tail + (items.Length - head);
            }
        }

        // Queue에 값을 넣음
        public void Enqueue(T value)
        {
            // 꽉차있으면 실행
            if (IsFull())
            {
                // 용량 늘리고 기존값 복사
                Grow();
            }
            // tail에 값을 넣고
            items[tail] = value;
            // tail의 위치를 변환
            MoveNext(ref tail);
        }
        // 배열의 최대 크기를 늘림
        private void Grow()
        {
            int newCapacity = items.Length * 2;
            T[] newArray = new T[newCapacity + 1];

            if (head < tail)
            {
                Array.Copy(items, head, newArray, 0, tail);
            }
            else
            {
                Array.Copy(items, head, newArray, 0, items.Length - head);
                Array.Copy(items, 0, newArray, items.Length - head, tail);
            }

            items = newArray;
            tail = Count;
            head = 0;
        }

        // 원형 큐를 사용했기에 head와 tail의 index값이 역전 될 수 있어 경우의 수를 따져 반환함
        private bool IsFull()
        {
            // head가 tail보다 큰 경우
            if (head > tail)
            {
                return head == tail + 1;
            }
            // head가 tail보다 작은경우
            else
            {
                return head == 0 && tail == items.Length - 1;
            }
            // 큐에서 (최대크기 +1 )한 공간을 쓸 수 없다는걸 활용하여 
            // tail의 다음 좌표 index를 최대 공간으로 나눈 나머지 값이 head의 값이라면
            // 꽉차있다(true)를 반환함
            // return ((tail + 1 ) % (items.Length) == head;

        }
        // 인덱스의 참조를 받아와 다음으로 이동하는데
        // 만약 최대 크기를 넘어간경우 환형이라 index는 0이 된다
        // 그 외의 경우에는 index에 1을 더한다
        private void MoveNext(ref int index)
        {
            index = (index == items.Length - 1) ? 0 : index + 1;
        }



    }
}
