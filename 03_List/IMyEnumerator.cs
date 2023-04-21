using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    // 실제 사용 X
    // 구성 확인용
    public interface IMyEnumerator 
    {
        object? Current { get; }
        bool MoveNext();
        void Reset();
    }
}
