using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class ProtectPotion : Item
    {
        private int Point = 50;

        public ProtectPotion()
        {
            name = "보호포션";
            description = $"플레이어에 {Point} 만큼 보호막을 부여합니다.";
            weight = 4;
        }
        public override void Use()
        {
            Console.WriteLine($"보호포션을 사용하여 플레이어는 {Point} 만큼 보호막을 얻었습니다.");
            Thread.Sleep( 1000 );
            Data.player.CurDp += 50;
        }
    }
}
