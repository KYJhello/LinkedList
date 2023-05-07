using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public abstract class Monster
    {
        public string name;
        public char icon = '▼';
        public Vector2 pos;

        public string image;
        public int curHp;
        public int maxHp;
        public int ap;
        public int dp;

        // 상속받은 개체에서 오버라이드할 함수
        public abstract void MoveAction();
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
