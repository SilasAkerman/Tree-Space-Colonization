using System;
using Raylib_cs;

namespace Tree_Space_Colonization
{
    class Program
    {
        public const int WIDTH = 1400;
        public const int HEIGHT = 1000;

        public const int MAX_DIST = 100;
        public const int MIN_DIST = 10;

        static void Main(string[] args)
        {
            Raylib.InitWindow(WIDTH, HEIGHT, "Tree Space Colonization");
            Raylib.SetTargetFPS(0);

            Tree myTree = new Tree();

            while (!Raylib.WindowShouldClose())
            {
                myTree.Grow();
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);
                myTree.Show();
                Raylib.EndDrawing();
                if (Raylib.IsKeyPressed(KeyboardKey.KEY_R)) myTree = new Tree();
            }

            Raylib.CloseWindow();
        }
    }
}
