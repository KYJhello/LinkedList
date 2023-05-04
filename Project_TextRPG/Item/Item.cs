using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public abstract class Item
    {
        public string name;
        public string description;
        public int weight;
        public char icon = '★';
        public Vector2 pos;
        public abstract void Use();
    }
}
