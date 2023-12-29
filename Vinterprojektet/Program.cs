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

int frames=0, time=0;   

int stickx = 200;
int sticky = 600;

string stickCondition;

stickCondition = "idle";

Texture2D startBackground = Raylib.LoadTexture("SpaceGameStart.png");

Texture2D stationBackground = Raylib.LoadTexture("SpaceStation.png");

Texture2D rocketTakeoff = Raylib.LoadTexture("RocketTakeoff.png");

Texture2D endBackground = Raylib.LoadTexture("SpaceGameEnd.png");

Texture2D StickIdle = Raylib.LoadTexture("StickIdle1.png");

Texture2D StickRun = Raylib.LoadTexture("StickRun1.png");

Texture2D StickRunL = Raylib.LoadTexture("StickRunL1.png");

Texture2D StickJump = Raylib.LoadTexture("StickJump1.png");

Texture2D Rocket = Raylib.LoadTexture("RelPixelRoket.png");

startBackground.Width = Raylib.GetMonitorWidth(monitordisplay);
startBackground.Height = Raylib.GetMonitorHeight(monitordisplay);

stationBackground.Width = Raylib.GetMonitorWidth(monitordisplay);
stationBackground.Height = Raylib.GetMonitorHeight(monitordisplay);

rocketTakeoff.Width = Raylib.GetMonitorWidth(monitordisplay);
rocketTakeoff.Height = Raylib.GetMonitorHeight(monitordisplay);

endBackground.Width = Raylib.GetMonitorWidth(monitordisplay);
endBackground.Height = Raylib.GetMonitorHeight(monitordisplay);

StickIdle.Width = 350;
StickIdle.Height = 350;

StickRun.Width = 350;
StickRun.Height = 350;

StickRunL.Width = 350;
StickRunL.Height = 350;

StickJump.Width = 350;
StickJump.Height = 350;

Rocket.Width = 400;
Rocket.Height = 400;


int currentRoom = 0;


while (!Raylib.WindowShouldClose())
{


  Raylib.BeginDrawing();

  Raylib.ClearBackground(Color.GREEN);




  if (currentRoom == 0) // ROOM 0**********************************************************************************************************
  {
    Raylib.DrawTexture(startBackground, 0, 0, Color.WHITE);
    Raylib.DrawText("Press Alt + Enter to toggle fullscreen", 100, 100, 30, Color.WHITE);

    if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER) && (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT_ALT) || Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT_ALT)))
    {

      // Check what display were on
      if (Raylib.IsWindowFullscreen())
      {
        // If we are fullscreen, go back to previous size
        Raylib.SetWindowSize(screenWidth, screenHeight);
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
  }             //*************************************************************************************************************


  else if (currentRoom == 1)  //ROOM 1**************************************************************************************************************
  {
    // Kod för rum 1

    Raylib.DrawTexture(stationBackground, 0, 0, Color.WHITE);
    Raylib.DrawTexture(Rocket, 1500, 600, Color.WHITE);


    if (stickCondition == "idle")
    {

      Raylib.DrawTexture(StickIdle, stickx, sticky, Color.WHITE);

    }

    else if (stickCondition == "runL")
    {
      Raylib.DrawTexture(StickRunL, stickx, sticky, Color.WHITE);
      stickx -= 2;
    }

    else if (stickCondition == "runR")
    {
      Raylib.DrawTexture(StickRun, stickx, sticky, Color.WHITE);
      stickx += 2;
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

    if (stickx >= 1400) {

      Raylib.DrawText("Press [E] to enter your rocket", 900 , 200, 50, Color.GREEN);

    }

    if (stickx >= 1400 && Raylib.IsKeyPressed(KeyboardKey.KEY_E)) {

      currentRoom = 2;

    }

  }

  else if (currentRoom == 2)
  {
    Raylib.ClearBackground(Color.BLUE);
    Raylib.DrawTexture(rocketTakeoff, 0, 0, Color.WHITE);
    
    frames++;    //increase the frames int by 1 every frame

    if(frames==60) {
                   time++;     //increase time every 60 frames, so each time this goes up by one, a second has passed
                   frames = 0;
          } 

    if(time >= 3){
      Raylib.DrawText("Press [ENTER] to continue", 300, 200, 70, Color.GREEN);

      if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER)){
        currentRoom = 3;
      }
    }
    
  }

  else if (currentRoom == 3)
  {
    Raylib.ClearBackground(Color.BLUE);

  }

  else if (currentRoom == 4)
  {
    Raylib.ClearBackground(Color.BLUE);
      
      //Room 4 code
  }

  Raylib.EndDrawing();
}