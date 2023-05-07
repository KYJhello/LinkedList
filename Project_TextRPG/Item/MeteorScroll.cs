using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class MeteorScroll : Item
    {

        public MeteorScroll()
        {
            name = "메테오 스크롤";
            description = $"모든 몬스터를 소멸시킵니다.";
            weight = 5;
        }
        public override void Use()
        {
            Console.WriteLine($"모든 몬스터가 소멸되었습니다.");
            Thread.Sleep(1000);
            Data.monsters.Clear();
        }
    }
}
