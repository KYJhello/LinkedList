using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class MainMenuScene : Scene
    {
        public MainMenuScene(Game game) : base(game)
        {
        }

        public override void Render()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("1:게임시작");
            sb.AppendLine("2:게임종료");

            Console.WriteLine(sb);
        }
        public override void Update()
        {
            string input = Console.ReadLine();

            int command;
            if (!int.TryParse(input, out command))
            {
                Console.WriteLine("잘못 입력 하셨습니다.");
                // 5sec 기다리기
                Thread.Sleep(1000);
                return;
            }
            switch (command)
            {
                case 1:
                    Console.WriteLine("잘못 입력 하셨습니다.");
                    Thread.Sleep(1000);
                    break;
                case 2:
                    Console.WriteLine("잘못 입력 하셨습니다.");
                    Thread.Sleep(1000);
                    break;
                default:
                    Console.WriteLine("잘못 입력 하셨습니다.");
                    Thread.Sleep(1000);
                    break;
            }
        }

    }
}
