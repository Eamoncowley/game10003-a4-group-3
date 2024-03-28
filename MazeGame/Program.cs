
﻿// Created by Jonah, Makayla, Eamon, Sudhan and Param
// Test
using Raylib_cs;
using System;
using System.Diagnostics;
//using System.Drawing;

using System.Numerics;

namespace ConsoleApp1
{
    internal class Program
    {
        // Setup window
        const string title = "Maze game created for Mohawk College";
        const int width = 800;
        const int height = 800;
        // Ball variables
        const int ballRadius = 20;
        const float ballSpeed = 200f;
        public static Vector2 ballPosition = new Vector2(width / 2, height / 2);

        // Setup drawing
        public static int startX = 400;
        public static int startY = 0;
        // Setup drawing
        public static int currentX = startX;
        public static int currentY = startY;
        public static int a;
        public static int numOfTilesToMove = 4;
        public static int currentTile = 0;

        // Game completed check variables
        public static bool gameOneCompleted = false;
        public static bool gameTwoCompleted = false;
        public static bool gameThreeCompleted = false;
        // Timer variables
        static Stopwatch timer = new Stopwatch();
        static TimeSpan elapsedTime;

        static void Main(string[] args)
        {
            Raylib.InitWindow(width, height, title);
            Raylib.SetTargetFPS(60);
            timer.Start(); // Start the timer when the game starts
            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.DarkGreen);
                Update();
                DrawTimer();
                //drawTree();
                Raylib.EndDrawing();
            }
            Raylib.CloseWindow();
        }

        static void Update()
        {
            if (gameOneCompleted == false)
            {
                drawLevelOne();
                UpdateBall();

            //Console.WriteLine("Running game"); // Debug 
            // Your game code run each frame here
            if (gameOneCompleted == false)
            {
                drawLevelOne();
            }
            else if (gameOneCompleted && gameTwoCompleted == false)
            {
                drawLevelTwo();
                UpdateBall();
            }
            else if (gameOneCompleted && gameTwoCompleted && gameThreeCompleted == false)
            {
                drawLevelThree();
                UpdateBall();
            }
            // Check if all games completed, stop the timer
            if (gameOneCompleted && gameTwoCompleted && gameThreeCompleted)
            {
                timer.Stop();
            }
        }

        static void UpdateBall()
        {
            Vector2 ballDirection = new Vector2(0, 0);

            if (Raylib.IsKeyDown(KeyboardKey.D))
            {
                ballDirection = new Vector2(1, 0);
            }
            else if (Raylib.IsKeyDown(KeyboardKey.A))
            {
                ballDirection = new Vector2(-1, 0);
            }
            else if (Raylib.IsKeyDown(KeyboardKey.W))
            {
                ballDirection = new Vector2(0, -1);
            }
            else if (Raylib.IsKeyDown(KeyboardKey.S))
            {
                ballDirection = new Vector2(0, 1);
            }

            ballPosition += ballDirection * ballSpeed * Raylib.GetFrameTime();

            if (ballPosition.X > width)
                ballPosition.X = 0;
            else if (ballPosition.X < 0)
                ballPosition.X = width;

            if (ballPosition.Y > height)
                ballPosition.Y = 0;
            else if (ballPosition.Y < 0)
                ballPosition.Y = height;

            Raylib.DrawCircle((int)ballPosition.X, (int)ballPosition.Y, ballRadius, Color.Yellow);
        }
            }
        }

        static void drawLevelOne()
        {
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
            for (int i = 0; i < numOfTilesToMove; i++)
            {
                currentX += 50;
                Raylib.DrawRectangle(currentX, currentY, 50, 50, Color.Gray);
            }
        }

        static void goLeft()
        {
            for (int i = 0; i < numOfTilesToMove; i++)
            {
                currentX -= 50;
                Raylib.DrawRectangle(currentX, currentY, 50, 50, Color.Gray);
            }
        }

        static void goDown()
        {
            for (int i = 0; i < numOfTilesToMove; i++)
            {
                currentY += 50;
                Raylib.DrawRectangle(currentX, currentY, 50, 50, Color.Gray);
            }
        }

        static void goUp()
        {
            for (int i = 0; i < numOfTilesToMove; i++)
            {
                currentY -= 50;
                Raylib.DrawRectangle(currentX, currentY, 50, 50, Color.Gray);
            }
        }

        static void DrawTimer()
        {
            elapsedTime = timer.Elapsed;
            string timerText = $"Time: {elapsedTime.Minutes:00}:{elapsedTime.Seconds:00}.{elapsedTime.Milliseconds / 10:00}";
            Raylib.DrawText(timerText, 10, 10, 20, Color.White);
        }
    }
}
