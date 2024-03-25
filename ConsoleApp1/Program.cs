using Raylib_cs;
using System.Numerics;

namespace ConsoleApp1
{
    internal class Program
    {
        // Console.WriteLine("Setting up the file");

        const string title = "Basic Raylib Demo";
        const int width = 800;
        const int height = 800;

        static void Main(string[] args)
        {
            Raylib.InitWindow(width, height, title);
            Raylib.SetTargetFPS(60);

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.White);
                Vector2 position = Raylib.GetMousePosition();
                Raylib.DrawCircleV(position, 50, Color.Black);
                Raylib.EndDrawing();
            }
            Raylib.CloseWindow();
        }
    }
}
