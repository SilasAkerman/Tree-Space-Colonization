using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using System.Numerics;

namespace Tree_Space_Colonization
{
    class Tree
    {
        List<Leaf> leafs = new List<Leaf>();
        List<Branch> branches = new List<Branch>();

        bool initFound = false;

        Random branchRandom = new Random();

        public Tree()
        {
            branches.Add(new Branch(null, new Vector2(Program.WIDTH / 2, Program.HEIGHT / 2), new Vector2(0, 0)));
            for (int i = 0; i < 1000; i++)
            {
                leafs.Add(new Leaf());
            }
        }

        public void Grow()
        {
            switch (initFound)
            {
                case false:
                    foreach (Leaf leaf in leafs)
                    {
                        if (Vector2.Distance(branches[branches.Count - 1].Pos, leaf.Pos) < Program.MAX_DIST)
                        {
                            initFound = true;
                        }
                    }
                    if (!initFound)
                    {
                        branches.Add(branches[branches.Count - 1].NextBranch());
                    }
                    break;

                case true:
                    foreach (Leaf leaf in leafs)
                    {
                        Branch closestBranch = null;
                        double recordDistance = Program.MAX_DIST;
                        foreach (Branch branch in branches)
                        {
                            double distance = Vector2.Distance(branch.Pos, leaf.Pos);
                            if (distance < Program.MIN_DIST)
                            {
                                leaf.Reached = true;
                                closestBranch = null;
                                branch.ChildLeaf = leaf;
                                break;
                            }
                            else if (distance < recordDistance)
                            {
                                closestBranch = branch;
                                recordDistance = distance;
                            }
                        }
                        if (closestBranch is not null)
                        {
                            Vector2 newDir = Vector2.Subtract(leaf.Pos, closestBranch.Pos);
                            newDir = Vector2.Normalize(newDir);
                            float scalar = 1;
                            float randomValue1 = (float)branchRandom.NextDouble() * scalar - scalar/2;
                            float randomValue2 = (float)branchRandom.NextDouble() * scalar - scalar/2;
                            newDir = Vector2.Add(newDir, new Vector2(randomValue1, randomValue2));
                            closestBranch.Dir = Vector2.Add(closestBranch.Dir, newDir);
                            closestBranch.LeafInfluenceCount++;
                        }
                    }
                    for (int i = branches.Count - 1; i >= 0; i--)
                    {
                        Branch branch = branches[i];
                        if (branch.LeafInfluenceCount > 0)
                        {
                            branch.Dir = Vector2.Divide(branch.Dir, branch.LeafInfluenceCount + 1);
                            branches.Add(branch.NextBranch());
                            branch.Reset();
                        }
                    }
                    break;
            }
        }

        public void Show()
        {
            foreach (Leaf leaf in leafs)
            {
                leaf.Show();
            }
            foreach (Branch branch in branches)
            {
                branch.Show();
            }
        }
    }
}
