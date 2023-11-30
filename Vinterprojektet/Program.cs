﻿using Raylib_cs;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;


Raylib.InitWindow(1000, 800, "Gaming");
Raylib.SetTargetFPS(60);

int stickx = 200;
int sticky = 200;

string stickCondition;

stickCondition = "idle";

Texture2D jungleBackground = Raylib.LoadTexture("JunglePixel.png");

Texture2D StickIdle = Raylib.LoadTexture("StickIdle1.png");

Texture2D StickRun = Raylib.LoadTexture("StickRun1.png");

Texture2D StickJump = Raylib.LoadTexture("StickJump1.png");

jungleBackground.Width = 1000;
jungleBackground.Height = 800;

StickIdle.Width = 200;
StickIdle.Height = 200;

StickRun.Width = 200;
StickRun.Height = 200;

StickJump.Width = 200;
StickJump.Height = 200;




while (!Raylib.WindowShouldClose())
{

    Raylib.BeginDrawing();

    Raylib.ClearBackground(Color.GREEN);



    Raylib.DrawTexture(jungleBackground, 0, 0, Color.WHITE);



    if (stickCondition == "idle")
    {

        Raylib.DrawTexture(StickIdle, stickx, sticky, Color.WHITE);

    }

    else if (stickCondition == "runL")
    {
    Raylib.DrawTexture(StickRun, stickx, sticky, Color.WHITE);
    stickx --;
    }

    else if (stickCondition == "runR")
    {
    Raylib.DrawTexture(StickRun, stickx, sticky, Color.WHITE);
    stickx ++;
    }


  
    if (Raylib.IsKeyDown(KeyboardKey.KEY_A)){
        stickCondition = "runL";
    }

    else if  (Raylib.IsKeyDown(KeyboardKey.KEY_D)){
        stickCondition = "runR";
    }



        if (Raylib.IsKeyReleased(KeyboardKey.KEY_A)){
        stickCondition = "idle";
    }

    else if  (Raylib.IsKeyReleased(KeyboardKey.KEY_D)){
        stickCondition = "idle";
    }




    Raylib.EndDrawing();
}