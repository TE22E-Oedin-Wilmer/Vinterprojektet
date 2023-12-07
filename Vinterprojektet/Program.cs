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

Texture2D startBackground = Raylib.LoadTexture("SpaceGameStart.png");

Texture2D jungleBackground = Raylib.LoadTexture("JunglePixel.png");

Texture2D endBackground = Raylib.LoadTexture("SpaceGameEnd.png");

Texture2D StickIdle = Raylib.LoadTexture("StickIdle1.png");

Texture2D StickRun = Raylib.LoadTexture("StickRun1.png");

Texture2D StickRunL = Raylib.LoadTexture("StickRunL1.png");

Texture2D StickJump = Raylib.LoadTexture("StickJump1.png");

startBackground.Width = Raylib.GetMonitorWidth(monitordisplay);
startBackground.Height = Raylib.GetMonitorHeight(monitordisplay);

jungleBackground.Width = Raylib.GetMonitorWidth(monitordisplay);
jungleBackground.Height = Raylib.GetMonitorHeight(monitordisplay);

endBackground.Width = Raylib.GetMonitorWidth(monitordisplay);
endBackground.Height = Raylib.GetMonitorHeight(monitordisplay);

StickIdle.Width = 200;
StickIdle.Height = 200;

StickRun.Width = 200;
StickRun.Height = 200;

StickRunL.Width = 200;
StickRunL.Height = 200;

StickJump.Width = 200;
StickJump.Height = 200;





int currentRoom = 0;


while (!Raylib.WindowShouldClose())
{


  Raylib.BeginDrawing();

  Raylib.ClearBackground(Color.GREEN);




  if (currentRoom == 0)
  {
    Raylib.DrawTexture(startBackground, 0, 0, Color.WHITE);
    Raylib.DrawText("Press Alt + Enter for fullscreen", 100, 100, 50, Color.WHITE);

    if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER) && (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT_ALT) || Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT_ALT)))
    {

      // Check what display were on
      if (Raylib.IsWindowFullscreen())
      {
        // If we are fullscreen, go back to previous size
        Raylib.SetWindowSize(screenWidth, screenHeight);
        Raylib.DrawText("Press Alt + Enter for fullscreen", 100, 100, 50, Color.WHITE);
      }
      else
      {
        // Match the monitor size we're on if not on fullscreen
        Raylib.SetWindowSize(Raylib.GetMonitorWidth(monitordisplay), Raylib.GetMonitorHeight(monitordisplay));

      }

      // Toggle fullscreen state
      Raylib.ToggleFullscreen();
    }

    Raylib.DrawText("Press [P] to play", screenWidth / 2 + 110, screenHeight, 100, Color.GOLD);

    if (Raylib.IsKeyPressed(KeyboardKey.KEY_P))
    {
      currentRoom = 1;
    }
  }


  else if (currentRoom == 1)
  {
    // Kod för rum 1

    Raylib.DrawTexture(jungleBackground, 0, 0, Color.WHITE);



    if (stickCondition == "idle")
    {

      Raylib.DrawTexture(StickIdle, stickx, sticky, Color.WHITE);

    }

    else if (stickCondition == "runL")
    {
      Raylib.DrawTexture(StickRunL, stickx, sticky, Color.WHITE);
      stickx--;
    }

    else if (stickCondition == "runR")
    {
      Raylib.DrawTexture(StickRun, stickx, sticky, Color.WHITE);
      stickx++;
    }



    if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
    {
      stickCondition = "runL";
    }

    else if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
    {
      stickCondition = "runR";
    }



    if (Raylib.IsKeyReleased(KeyboardKey.KEY_A))
    {
      stickCondition = "idle";
    }

    else if (Raylib.IsKeyReleased(KeyboardKey.KEY_D))
    {
      stickCondition = "idle";
    }




  }
  else if (currentRoom == 2)
  {
    // Kod för rum 2
  }



  Raylib.EndDrawing();
}