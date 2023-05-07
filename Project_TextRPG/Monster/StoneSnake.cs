using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class StoneSnake : Monster
    {
        private Random random = new Random();
        private int moveTurn = 0;
        public StoneSnake()
        {
            name = "돌뱀";
            curHp = 5;
            maxHp = 5;
            ap = 10;
            dp = 5;
            shield = 2;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("####################");
            sb.AppendLine("#                  #");
            sb.AppendLine("#  (엄청 귀여운  )  #");
            sb.AppendLine("#  (돌뱀   이미지)  #");
            sb.AppendLine("#                  #");
            sb.AppendLine("####################");
            image = sb.ToString();
        }
        public override void MoveAction()
        {
            // 3턴마다
            if (moveTurn++ < 3)
            {
                return;
            }
            moveTurn = 0;

            // 한번에 3번 움직임
            for (int i = 0; i < 5; i++)
            {
                switch (random.Next(0, 4))
                {
                    case 0:
                        Move(Direction.Up);
                        break;
                    case 1:
                        Move(Direction.Down);
                        break;
                    case 2:
                        Move(Direction.Left);
                        break;
                    case 3:
                        Move(Direction.Right);
                        break;
                }
            }
        }
    }
}
