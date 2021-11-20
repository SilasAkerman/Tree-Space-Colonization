using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Raylib_cs;

namespace Tree_Space_Colonization
{
    class Branch
    {
        Branch parent;
        public Leaf ChildLeaf { get; set; } = null;

        Vector2 _pos;
        public Vector2 Pos { get { return _pos; } }

        public Vector2 Dir { get; set; }
        Vector2 origDir;

        const int LENGTH = 10;

        public int LeafInfluenceCount { get; set; } = 0;

        public Branch(Branch aParent, Vector2 aPos, Vector2 aDir)
        {
            parent = aParent;
            _pos = aPos;
            Dir = aDir;
            origDir = new Vector2(Dir.X, Dir.Y);
        }

        public void Reset()
        {
            Dir = new Vector2(origDir.X, origDir.Y);
            LeafInfluenceCount = 0;
        }

        public Branch NextBranch()
        {
            Vector2 nextDir = Vector2.Multiply(Dir, LENGTH);
            Vector2 nextPos = Vector2.Add(_pos, nextDir);
            return new Branch(this, nextPos, new Vector2(Dir.X, Dir.Y));
        }

        public void Show()
        {
            if (parent is not null)
            {
                Raylib.DrawLineEx(_pos, parent.Pos, 4, Color.WHITE);
            }
            if (ChildLeaf is not null)
            {
                Raylib.DrawLineEx(_pos, ChildLeaf.Pos, 3, Color.GREEN);
            }
        }
    }
}
