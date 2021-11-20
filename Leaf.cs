using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Raylib_cs;

namespace Tree_Space_Colonization
{
    class Leaf
    {
        Vector2 _pos;
        public Vector2 Pos { get { return _pos; } }

        public bool Reached { get; set; } = false;

        Random vectorRandom = new Random();
        bool showUnclearedLeaf = true;

        public Leaf()
        {
            _pos = new Vector2(vectorRandom.Next(Program.WIDTH), vectorRandom.Next(Program.HEIGHT));
        }

        public void Show()
        {
            if (Reached) Raylib.DrawCircleV(_pos, 4, Color.GREEN);
            else if (showUnclearedLeaf && !Reached) Raylib.DrawCircleV(_pos, 3, Color.WHITE);
            //if (showUnclearedLeaf && !Reached) Raylib.DrawCircleV(_pos, 3, Color.WHITE);
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE)) showUnclearedLeaf = !showUnclearedLeaf;
        }
    }
}
