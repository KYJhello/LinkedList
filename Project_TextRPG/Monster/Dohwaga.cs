﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class Dohwaga : Monster
    {
        private Random random = new Random();
        private int moveTurn = 0;
        public Dohwaga()
        {
            name = "도화가";
            curHp = 5;
            maxHp = 5;
            ap = 1;
            dp = 1;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("####################");
            sb.AppendLine("#                  #");
            sb.AppendLine("#  (엄청 귀여운  )  #");
            sb.AppendLine("#  (도화가 이미지)  #");
            sb.AppendLine("#                  #");
            sb.AppendLine("####################");
            image = sb.ToString();
        }
        public override void MoveAction()
        {
            // 10턴마다
            if (moveTurn++ < 10)
            {
                return;
            }
            moveTurn = 0;

            // 한번에 5번 움직임
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
