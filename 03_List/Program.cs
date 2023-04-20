namespace _03_List
{
    internal class Program
    {
        public void Iterator()
        {
            // 대부분의 자료구조가 반복기를 지원함
            // 반복기를 이용한 기능을 구현할 경우, 그 기능은 대부분의 자료구조를 호환할 수 있음
            List<int> list = new List<int>();
            LinkedList<int> linkedList = new LinkedList<int>();
            Stack<int> stack = new Stack<int>();
            Queue<int> queue = new Queue<int>();
            SortedList<int, int> sList = new SortedList<int, int>();
            SortedSet<int> set = new SortedSet<int>();
            SortedDictionary<int, int> map = new SortedDictionary<int, int>();
            Dictionary<int, int> dic = new Dictionary<int, int>();

            // 반복기를 이용한 순회
            // foreach 반복문은 데이터집합의 반복기를 통해서 단계별로 반복
            // 즉, 반복기가 있다면 foreach 반복문으로 순회 가능
            foreach (int i in list) { }
            foreach (int i in linkedList) { }
            foreach (int i in stack) { }
            foreach (int i in queue) { }
            foreach (int i in set) { }
            foreach (KeyValuePair<int, int> i in sList) { }
            foreach (KeyValuePair<int, int> i in map) { }
            foreach (KeyValuePair<int, int> i in dic) { }
            foreach (int i in IterFunc()) { }

            // 반복기 직접조작
            List<string> strings = new List<string>();
            for (int i = 0; i < 5; i++) strings.Add(string.Format("{0}데이터", i));

            IEnumerator<string> iter = strings.GetEnumerator();
            iter.MoveNext();
            Console.WriteLine(iter.Current);    // output : 0데이터
            iter.MoveNext();
            Console.WriteLine(iter.Current);    // output : 1데이터

            iter.Reset();
            while (iter.MoveNext())
            {
                Console.WriteLine(iter.Current);
            }
        }

        IEnumerable<int> IterFunc()
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }


        // ####################
        // 2023-04-21
        // 김용준
        // Iterator
        // IEnumerator, IEnumerable
        // ####################



        // ##################################################
        //
        // 3. 반복기(이터레이터) - 디자인패턴 반복자 기술 면접
        //
        // ##################################################


        static void Main(string[] args)
        {
            Iterator.MyList<int> list = new Iterator.MyList<int>();
            for (int i = 1; i <= 5; i++) list.Add(i);

            foreach (int i in list) Console.WriteLine(i);

            //foreach
            IEnumerator<int> listIter = list.GetEnumerator();
            while (listIter.MoveNext())
            {
                Console.WriteLine(listIter.Current);
            }

            // dispose
            Iterator.LinkedList<int> linkedList = new Iterator.LinkedList<int>();
            for (int i = 1; i <= 5; i++) linkedList.AddLast(i);

            foreach (int i in linkedList) Console.WriteLine(i);

            //IEnumerator<int> linkedListIter = linkedList.GetEnumerator();
            //while (linkedListIter.MoveNext())
            //{
            //    Console.WriteLine(linkedListIter.Current);
            //}
        }
    }
}