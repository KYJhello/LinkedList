using Project_TextRPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class Player
    {
        public string image;
        public char icon = '♥';
        public Vector2 pos;
        public List<Skill> skills;
        public List<Buff> buffs;

        public Player()
        {
            CurHp = 190;
            MaxHp = 200;
            CurDp = 0;
            Level = 1;
            CurExp = 0;
            MaxExp = 100;
            AP = 5;
            DP = 1;

            image = "\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⡴⠖⣒⡀⣤⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⣀⣠⣤⣤⣤⣼⣇⣀⢸⡇⣭⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⢀⣴⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⢸⣿⣿⣿⣿⣿⡏⠿⣿⣿⣿⣿⣿⣿⣿⣿⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⢸⣿⡷⣿⣿⣿⠐⣶⣭⣽⡿⣿⣿⣿⣿⣿⣿⣧⠀⠀⠀⠀⠀⠀⢀⠠⠂⢁⠆\r\n⠀⠀⢀⣾⣿⠧⠸⣿⣿⠈⠸⠿⣿⠁⠋⢙⣿⣿⣿⣿⣿⣆⠀⠀⢀⠠⠂⠁⡀⠊⠀⠀\r\n⠤⠴⠟⣿⠟⠓⢦⣬⣍⣥⣴⣶⣿⣿⣿⡏⡇⠉⠻⢿⣿⣿⣿⣊⡀⢀⣴⠊⠀⠀⠀⠀\r\n⠀⠀⠀⢿⠞⠉⡹⠟⢿⣿⣿⣿⣿⣿⣿⣷⣿⡿⣦⣼⣿⣿⣿⣿⣷⣿⣿⣧⠀⠀⠀⠀\r\n⠀⠀⠀⠘⣄⠈⠁⠀⢈⣿⣿⠟⣏⣡⡼⡟⢻⣿⣿⣹⣿⣿⣿⣿⣿⡿⣿⣿⡆⠀⠀⠀\r\n⠀⠀⠀⠀⣻⣷⣶⣾⣿⣿⣿⣶⡟⠯⠄⠀⠘⣿⣿⡀⣿⣿⣿⣿⢿⣿⣿⣿⠗⠁⠀⠀\r\n⠀⠀⢀⡠⠟⣿⣿⡿⢿⣿⣿⡌⣷⠟⢣⠁⠈⡻⣿⣿⣾⣿⣿⣿⣷⣞⠉⠁⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⢿⡇⠀⠀⠹⣿⣷⡙⠇⠡⣢⣵⣿⡿⢿⣿⣿⣿⣿⣿⣿⣷⡀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠈⢻⠀⠀⠀⣿⣿⣷⣦⣾⣿⣏⠁⠀⠀⠈⢻⣿⣿⢿⣿⣿⠇⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠈⣦⣤⣤⣿⣿⣿⣿⣿⣿⡿⠷⣶⣤⣀⣴⣿⢿⣿⣟⡁⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⡓⠛⣉⠏⠉⠀⠀⠀⠈⠁⠀⠀⠀⠘⠛⠁⠊⠉⠉⠁⠀⠀⠀⠀⠀\r\n";
        }
        public int CurHp { get; private set; }
        public int MaxHp { get; private set; }
        public int CurDp { get; set; }
        public int Level { get; private set; }
        public int CurExp { get; private set; }
        public int MaxExp { get; private set; }
        public int AP { get; private set; }
        public int DP { get; private set; }


        public void Move(Direction dir)
        {
            Vector2 prevPos = pos;
            // 플레이어 이동
            switch (dir)
            {
                case Direction.Up:
                    pos.y--;
                    break;
                case Direction.Down:
                    pos.y++;
                    break;
                case Direction.Left:
                    pos.x--;
                    break;
                case Direction.Right:
                    pos.x++;
                    break;
            }

            // 이동한 자리가 벽일 경우
            if (!Data.map[pos.y, pos.x])
            {
                // 원위치 시키기
                pos = prevPos;
            }
        }
    }
}
