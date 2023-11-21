using Raylib_cs;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;


Raylib.InitWindow(1000, 800, "Gaming");
Raylib.SetTargetFPS(60);


Texture2D jungleBackground = Raylib.LoadTexture("JunglePixel.png");

Texture2D StickIdle = Raylib.LoadTexture("Vinterprojektet/StickChar/StickIdle/StickIdle1.png");

Texture2D StickRun = Raylib.LoadTexture("Vinterprojektet/StickChar/StickRun");

Texture2D StickJump = Raylib.LoadTexture("Vinterprojektet/StickChar/StickJump/StickJump1.png");

jungleBackground.Width = 1000;
jungleBackground.Height = 800;

   



while (!Raylib.WindowShouldClose())
{








Raylib.BeginDrawing();

Raylib.ClearBackground(Color.GREEN);

Raylib.DrawTexture(jungleBackground, 0, 0, Color.WHITE);




  Raylib.EndDrawing();
}