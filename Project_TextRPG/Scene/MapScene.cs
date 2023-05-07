using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    internal class MapScene : Scene
    {
        public MapScene(Game game) : base(game) { }
        public override void Render()
        {
            PrintMap();
        }
        public override void Update()
        {
            ConsoleKeyInfo input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                    Data.player.Move(Direction.Up);
                    break;
                case ConsoleKey.DownArrow:
                    Data.player.Move(Direction.Down);
                    break;
                case ConsoleKey.LeftArrow:
                    Data.player.Move(Direction.Left);
                    break;
                case ConsoleKey.RightArrow:
                    Data.player.Move(Direction.Right);
                    break;
            }
            // 아이템 습득
            Item item = Data.ItemInPos(Data.player.pos);
            if (item != null)
            {
                Data.player.GetItem(item);
                Data.items.Remove(item);
            }
            // 몬스터 전투
            Monster monster = Data.MonsterInPos(Data.player.pos);
            if (monster != null)
            {
                game.Battle(monster);
                return;
            }
            // 몬스터 이동
            foreach (Monster m in Data.monsters)
            {
                m.MoveAction();
                if (m.pos.x == Data.player.pos.x &&
                    m.pos.y == Data.player.pos.y)
                {
                    game.Battle(m);
                    return;
                }
            }
        }
        private void PrintMap()
        {
            StringBuilder sb = new StringBuilder();
            for(int y = 0; y < Data.map.GetLength(0); y++)
            {
                for(int x= 0;  x < Data.map.GetLength(1); x++)
                {
                    if (Data.map[y, x]) { sb.Append('　'); }
                    else { sb.Append('▨'); }
                }
                sb.AppendLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(sb.ToString());

            foreach (Monster monster in Data.monsters)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(monster.pos.x*2, monster.pos.y);
                Console.Write(monster.icon);
            }

            foreach (Item item in Data.items)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(item.pos.x*2, item.pos.y);
                Console.Write(item.icon);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(Data.player.pos.x * 2, Data.player.pos.y);
            Console.Write(Data.player.icon);
        }
    }
}
