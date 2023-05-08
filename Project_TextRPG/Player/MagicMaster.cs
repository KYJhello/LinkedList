using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class MagicMaster : Player
    {
        public MagicMaster()
        {
            CurHp = 70;
            MaxHp = 100;
            CurDp = 50;
            Level = 1;
            CurExp = 0;
            MaxExp = 100;
            AP = 30;
            DP = 1;

            skills = new List<Skill>();
            skills.Add(new Skill("공격하기", Attack));
            skills.Add(new Skill("회복하기", Recovery));

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("####################");
            sb.AppendLine("#                  #");
            sb.AppendLine("#  (  마법사     )  #");
            sb.AppendLine("#  (텍스트 이미지)  #");
            sb.AppendLine("#                  #");
            sb.AppendLine("####################");
            image = sb.ToString();
        }
    }
}
