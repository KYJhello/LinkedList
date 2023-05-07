using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public static class Data
    {
        // 인터페이스, 플레이어
        public static Player player;
        public static List<Monster> monster;
        public static bool[,] map;

        // 플레이어 초기화 후 진행
        public static void Init() { player = new Player(); }

        public static void LoadLevel()
        {
            map = new bool[,]
                {
                { false, false, false, false, false, false, false, false, false, false, false, false, false, false },
                { false,  true,  true,  true,  true, false,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true, false,  true,  true,  true,  true, false, false,  true, false },
                { false,  true,  true,  true,  true, false,  true,  true,  true,  true, false,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true, false,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true, false, false, false, false,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false,  true, false },
                { false,  true, false,  true,  true,  true,  true,  true,  true,  true,  true, false,  true, false },
                { false,  true, false,  true,  true,  true,  true,  true,  true,  true,  true, false,  true, false },
                { false,  true, false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true, false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false, false, false, false, false, false, false, false, false, false, false, false, false, false },
                };
            player.pos = new Vector2(2, 2);
        }
        
    }
    
}
