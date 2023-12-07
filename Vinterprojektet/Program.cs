using Raylib_cs;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

int display = Raylib.GetCurrentMonitor();

const int screenWidth = 800;
const int screenHeight = 450;

int monitordisplay = Raylib.GetCurrentMonitor();

Raylib.InitWindow(screenWidth, screenHeight, "Gaming");
Raylib.SetTargetFPS(60);

int stickx = 200;
int sticky = 200;

string stickCondition;

stickCondition = "idle";

Texture2D jungleBackground = Raylib.LoadTexture("JunglePixel.png");

Texture2D StickIdle = Raylib.LoadTexture("StickIdle1.png");

Texture2D StickRun = Raylib.LoadTexture("StickRun1.png");

Texture2D StickRunL = Raylib.LoadTexture("StickRunL1.png");

Texture2D StickJump = Raylib.LoadTexture("StickJump1.png");

jungleBackground.Width = Raylib.GetMonitorWidth(monitordisplay);
jungleBackground.Height = Raylib.GetMonitorHeight(monitordisplay);

StickIdle.Width = 200;
StickIdle.Height = 200;

StickRun.Width = 200;
StickRun.Height = 200;

StickRunL.Width = 200;
StickRunL.Height = 200;

StickJump.Width = 200;
StickJump.Height = 200;




while (!Raylib.WindowShouldClose())
{

    if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER) && (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT_ALT) || Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT_ALT)))
 		{
            // see what display we are on right now
 			
 
            
            if (Raylib.IsWindowFullscreen())
            {
                // if we are full screen, then go back to the windowed size
                Raylib.SetWindowSize(screenWidth, screenHeight);
            }
            else
            {
                // if we are not full screen, set the window size to match the monitor we are on
                Raylib.SetWindowSize(Raylib.GetMonitorWidth(monitordisplay), Raylib.GetMonitorHeight(monitordisplay));
            }
 
            // toggle the state
 			Raylib.ToggleFullscreen();
 		}

    Raylib.BeginDrawing();

    Raylib.ClearBackground(Color.GREEN);



    Raylib.DrawTexture(jungleBackground, 0, 0, Color.WHITE);



    if (stickCondition == "idle")
    {

        Raylib.DrawTexture(StickIdle, stickx, sticky, Color.WHITE);

    }

    else if (stickCondition == "runL")
    {
    Raylib.DrawTexture(StickRunL, stickx, sticky, Color.WHITE);
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