using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class Dragon : Monster
    {

        public override void MoveAction()
        {
            List<Vector2> path;
            AStar.PathFinding(Data.map, new Vector2(pos.x, pos.y),
                new Vector2(Data.player.pos.x, Data.player.pos.y), out path);

        }
    }
}
