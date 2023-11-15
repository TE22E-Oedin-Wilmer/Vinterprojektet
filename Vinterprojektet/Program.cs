using Raylib_cs;
using System.Numerics;
using System.Reflection.Metadata;
using System.Security.Cryptography;


Raylib.InitWindow(1000, 800, "Gaming");
Raylib.SetTargetFPS(60);


Texture2D jungleBackground = Raylib.LoadTexture("JunglePixel.png");

jungleBackground.Width = 1000;
jungleBackground.Height = 800;

while (!Raylib.WindowShouldClose())
{

                          //variabler




Raylib.BeginDrawing();
Raylib.ClearBackground(Color.GREEN);             //efter börjar allt som inte är variabler
Raylib.DrawTexture(jungleBackground, 0, 0, Color.WHITE);



  Raylib.EndDrawing();
}