using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure {
    // 괄호 bracket인데 일단 바켓으로...
    internal class BarcketTest
    {
        private Stack<char> stack = new Stack<char>();
        private char[] charArr;

        // stack에 넣기 위해 char 형으로 변환
        public BarcketTest(string str)
        {
            charArr = str.ToCharArray();
        }
        
        // 대괄호 3, 중괄호 2, 소괄호 1
        // 괄호의 순서     [ { ( ) } ] 순 확인 및
        // 열고 닫는게 맞는지 확인
        public bool IsTrue()
        {
            foreach (char c in charArr)
            {
                switch (c)
                {
                    case '(':
                    case '{':
                    case '[':
                        if(stack.Count > 0)
                        {
                            if(stack.Peek() )
                        }
                        stack.Push(c);
                        break;
                    case ')':
                    case '}':
                    case ']':
                        // 괄호 앞이 없는 경우라서 return false
                        if (stack.Count == 0)
                        {
                            return false;
                        }
                        else
                        {
                            char temp = stack.Pop();
                            if ()

                            return true;
                        }
                        break;
                }
            }
            return false;
        }
    }
}
