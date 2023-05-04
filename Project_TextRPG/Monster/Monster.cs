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
        public string image;
        public abstract void MoveAction();
    }
}
