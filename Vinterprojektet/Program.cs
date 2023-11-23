using Raylib_cs;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;


Raylib.InitWindow(1000, 800, "Gaming");
Raylib.SetTargetFPS(60);

int stickx = 200;
int sticky = 200;



Texture2D jungleBackground = Raylib.LoadTexture("JunglePixel.png");

Texture2D StickIdle = Raylib.LoadTexture("StickIdle1.png");

Texture2D StickRun = Raylib.LoadTexture("StickRunCollage");

Texture2D StickJump = Raylib.LoadTexture("Vinterprojektet/StickChar/StickJump/StickJump1.png");

jungleBackground.Width = 1000;
jungleBackground.Height = 800;

StickIdle.Width = 300;
StickIdle.Height = 300;

StickRun.Width = 300;
StickRun.Height = 300;

StickJump.Width = 50;
StickJump.Height = 50;
  



while (!Raylib.WindowShouldClose())
{

Raylib.BeginDrawing();

Raylib.ClearBackground(Color.GREEN);



Raylib.DrawTexture(jungleBackground, 0, 0, Color.WHITE);

if (Raylib.IsKeyUp()) {

Raylib.DrawTexture(StickIdle, stickx, sticky, Color.WHITE);
}



else if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) {

Raylib.DrawTexture(StickRun, stickx, sticky, Color.WHITE);

stickx --;

}

Raylib.EndDrawing();
}