using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    // 1. Dictionary 구현
    public class Dictionary<TKey, TValue> where TKey : IEquatable<TKey>
    {
        private const int DefaultCapacity = 1000;

        private struct Entry
        {
            public enum State { None, Using, Deleted }

            public int hashCode;
            public State state;
            public TKey Key;
            public TValue Value;
        }

        private Entry[] table;

        public Dictionary() { 
            table = new Entry[DefaultCapacity];
        }
        public TValue this[TKey key]
        {
            get
            {
                // 1. key를 index로 해싱
                int index = Math.Abs(key.GetHashCode()%table.Length);

                // 2. key와 일치하는 데이터가 나올때까지 다음으로 이동
                while (table[index].state == Entry.State.Using)
                {
                    // 찾는 값과 같다면 
                    if (key.Equals(table[index].Key))
                    {
                        return table[index].Value;
                    }
                    // 사용중이 아닌걸 만났을땐 잘못만남
                    if(table[index].state != Entry.State.Using)
                    {
                        break;
                    }
                    else
                    {
                        index = index < table.Length - 1 ? index + 1 : 0;
                    }
                }
                throw new InvalidOperationException();
            }
            set
            {
                // 1. key를 index로 해싱
                int index = Math.Abs(key.GetHashCode() % table.Length);

                // 2. key와 일치하는 데이터가 나올때까지 다음으로 이동
                while (table[index].state == Entry.State.Using)
                {
                    // 동일한 키값을 찾았을 때 덮어쓰기
                    if (key.Equals(table[index].Key))
                    {
                        table[index].Value = value;
                    }
                    // 사용중이 아닌걸 만났을땐 잘못만남
                    if (table[index].state != Entry.State.Using)
                    {
                        break;
                    }
                    else
                    {
                        index = index < table.Length - 1 ? index + 1 : 0;
                    }
                }
                throw new InvalidOperationException();
            }
        }
        public void Add(TKey key, TValue value)
        {
            // 1. key값을 index의 값으로 해싱해줘야한다.(c#에선 gethastcode 지원)
            int index = Math.Abs(key.GetHashCode() % table.Length);

            // 2. 사용중이 아닌 index까지 다음으로 이동
            while (table[index].state == Entry.State.Using) {
                if (key.Equals(table[index].Key))
                {
                    //table[index].Key = key;
                    //table[index].Value = value;
                    throw new InvalidOperationException();
                }
                else
                {
                    index = index < table.Length - 1 ? index + 1 : 0;
                }
            }
            // 3. 사용중이 아닌 index를 발견한 경우 그 위치에 저장
            table[index].hashCode = key.GetHashCode();
            table[index].Key = key;
            table[index].Value = value;
            table[index].state = Entry.State.Using;
        }
        public void Remove(TKey key)
        {
            // 1. key값을 index의 값으로 해싱해줘야한다.(c#에선 gethastcode 지원)
            int index = Math.Abs(key.GetHashCode() % table.Length);

            // 2. key값과 동일한 데이터를 찾을때까지 index 증가
            while (table[index].state == Entry.State.Using)
            {
                if (key.Equals(table[index].Key))
                {
                    table[index].state = Entry.State.Deleted;
                }
                // 사용중이 아닌걸 만났을땐 잘못만남
                if (table[index].state != Entry.State.Using)
                {
                    break;
                }
                index = index < table.Length - 1 ? index + 1 : 0;
            }
        }
    }
}
