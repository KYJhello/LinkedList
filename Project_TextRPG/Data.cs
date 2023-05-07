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
        public static List<Monster> monsters;
        public static List<Item> inventory;
        public static List<Item> items;
        public static bool[,] map;


        // 플레이어 초기화 후 진행
        public static void Init() { 
            player = new Player();
            inventory = new List<Item>();
            monsters = new List<Monster>();
            items = new List<Item>();
            inventory.Add(new Potion());
            inventory.Add(new ProtectPotion());
            inventory.Add(new LargePotion());
            inventory.Add(new MeteorScroll());
        }
        public static bool IsObjectInPos(Vector2 pos)
        {
            return MonsterInPos(pos) == null && ItemInPos(pos) == null;
        }
        public static Monster MonsterInPos(Vector2 pos)
        {
            foreach (Monster monster in monsters)
            {
                if (monster.pos.x == pos.x &&
                    monster.pos.y == pos.y)
                {
                    return monster;
                }
            }
            return null;
        }
        public static Item ItemInPos(Vector2 pos)
        {
            foreach (Item item in items)
            {
                if (item.pos.x == pos.x &&
                    item.pos.y == pos.y)
                {
                    return item;
                }
            }
            return null;
        }

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

            monsters.Clear();
            items.Clear();

            Slime slime1 = new Slime();
            slime1.pos = new Vector2(3, 5);
            monsters.Add(slime1);

            Slime slime2 = new Slime();
            slime2.pos = new Vector2(7, 5);
            monsters.Add(slime2);

            Dragon dragon = new Dragon();
            dragon.pos = new Vector2(12, 12);
            monsters.Add(dragon);

            Item potion = new Potion();
            potion.pos = new Vector2(12, 1);
            items.Add(potion);

            Item largePotion = new LargePotion();
            largePotion.pos = new Vector2(12, 2);
            items.Add(largePotion);
        }
        
    }
    
}
