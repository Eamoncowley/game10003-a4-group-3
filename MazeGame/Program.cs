// Created by Jonah, Makayla, Eamon, Sudhan and Param

using Raylib_cs;
using System;
using System.Diagnostics;
//using System.Drawing;
using System.Numerics;

namespace ConsoleApp1
{
    //2D Textures/ Images
    public Texture2D drawBoat;
    public Texture2D waterPath;

    internal class Program
    {
        // Setup window
        const string title = "Maze game created for Mohawk College";
        const int width = 800;
        const int height = 800;

        // Setup drawing
        public static int startY = 0;
        public static int startX = 400;
        public static int currentX = startX;
        public static int currentY = startY;
        public static int a;
        public static int numOfTilesToMove = 4;
        public static int currentTile = 0;

        // Game completed check variables
        public static bool gameOneCompleted = false;
        public static bool gameTwoCompleted = false;
        public static bool gameThreeCompleted = false;

        //Adding Images
        Raylib.LoadTextureFromImage("Boat.png");
        Texture2D drawBoat = Raylib.LoadImage("../../../../Assets/Boat.png");
        Raylib.LoadTextureFromImage("Water.png");
        Texture2D waterPath = Raylib.LoadImage("../../../../Assets/Water.png");

        static void Main(string[] args)
        {
            Raylib.InitWindow(width, height, title);
            Raylib.SetTargetFPS(60);
            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.DarkGreen);
                Update();
                //drawTree();
                Raylib.EndDrawing();
            }
            Raylib.CloseWindow();
        }

        static void Update()
        {

            //Console.WriteLine("Running game"); // Debug 
            // Your game code run each frame here
            if (gameOneCompleted == false)
            {
                drawLevelOne();
            }
            else if (gameOneCompleted && gameTwoCompleted == false)
            {
                drawLevelTwo();
            }
            else if (gameOneCompleted && gameTwoCompleted && gameThreeCompleted == false)
            {
                drawLevelThree();
            }
        }
        //Boat for moving object on path/water
        static void drawBoat()
        {
            Raylib.DrawTexturePro(Texture2D drawBoat,);
        }

        static void drawLevelOne()
        {
            //Calling Boat image
            drawBoat();

            currentX = startX;
            currentY = startY;
            goDown();
            drawStart();
            goDown();
            goDown();
            drawEnd();
        }
        static void drawLevelTwo()
        {
            //Calling Boat image
            drawBoat();

            currentX = startX;
            currentY = startY;
            goRight();
            drawStart();
            goDown();
            goLeft();
            goLeft();
            goUp();
            goLeft();
            goDown();
            goDown();
            goRight();
            goRight();
            goRight();
            goDown();
            goLeft();
            goLeft();
            goLeft();
            drawEnd();
        }
        static void drawLevelThree()
        {
            //Calling Boat image
            drawBoat();

            currentX = startX;
            currentY = startY;
            goRight();
            drawStart();
            goDown();
            goDown();
            goDown();
            goLeft();
            goLeft();
            goLeft();
            goUp();
            goUp();
            goUp();
            goRight();
            goDown();
            goDown();
            goRight();
            goUp();
            drawEnd();
        }
        static void drawStart()
        {
            Raylib.DrawRectangle(400, 0, 50, 50, Color.Green);
        }
        static void drawEnd()
        {
            Raylib.DrawRectangle(currentX, currentY, 50, 50, Color.Red);
        }
        static void goRight()
        {
            while (true) // Go right with path
            {

                currentX = currentX + a;
                currentTile++;
                if (currentTile > numOfTilesToMove)
                {
                    currentTile = 0;
                    a = 0;
                    break;

                }
                a = +50;
                Raylib.DrawRectangle(currentX, currentY, 50, 50, Color.Gray);
            }
            return;
        }
        static void goLeft()
        {
            while (true) // Go left with path
            {

                currentX = currentX + a;
                currentTile++;
                if (currentTile > numOfTilesToMove)
                {
                    currentTile = 0;
                    a = 0;
                    break;
                }
                a = -50;
                Raylib.DrawRectangle(currentX, currentY, 50, 50, Color.Gray);
            }
            return;
        }
        static void goDown()
        {
            while (true) // Go down with path
            {

                currentY = currentY + a;
                currentTile++;
                if (currentTile > numOfTilesToMove)
                {
                    currentTile = 0;
                    a = 0;
                    break;
                }
                a = +50;
                Raylib.DrawRectangle(currentX, currentY, 50, 50, Color.Gray);
            }
            return;
        }
        static void goUp()
        {
            while (true) // Go down with path
            {

                currentY = currentY + a;
                currentTile++;
                if (currentTile > numOfTilesToMove)
                {
                    currentTile = 0;
                    a = 0;
                    break;
                }
                a = -50;
                Raylib.DrawRectangle(currentX, currentY, 50, 50, Color.Gray);
            }
            return;
        }
    }
}
