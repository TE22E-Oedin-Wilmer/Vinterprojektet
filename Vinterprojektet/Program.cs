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

int rocketFx = -100;
int rocketFy = 300;

Random generator = new();

int Meteor1x = generator.Next(2000, 5000);
int Meteor1y = generator.Next(0, 1080);

int Meteor2x = generator.Next(2000, 5000);
int Meteor2y = generator.Next(0, 1080);

int Meteor3x = generator.Next(2000, 5000);
int Meteor3y = generator.Next(0, 1080);

int PixelSpaceX = 0;

string stickCondition;

stickCondition = "idle";

Texture2D startBackground = Raylib.LoadTexture("SpaceGameStart.png");

Texture2D stationBackground = Raylib.LoadTexture("SpaceStation.png");

Texture2D rocketTakeoff = Raylib.LoadTexture("RocketTakeoff.png");

Texture2D spaceBattleBground = Raylib.LoadTexture("LongPixel Space.png");

Texture2D sidewayRocket = Raylib.LoadTexture("SidewayRocketWfire.png");

Texture2D endBackground = Raylib.LoadTexture("SpaceGameEnd.png");

Texture2D StickIdle = Raylib.LoadTexture("StickIdle1.png");

Texture2D StickRun = Raylib.LoadTexture("StickRun1.png");

Texture2D StickRunL = Raylib.LoadTexture("StickRunL1.png");

Texture2D StickJump = Raylib.LoadTexture("StickJump1.png");

Texture2D Rocket = Raylib.LoadTexture("RelPixelRoket.png");

Texture2D Meteor1 = Raylib.LoadTexture("MeteorPixel.png");

Texture2D Meteor2 = Raylib.LoadTexture("MeteorPixel.png");

Texture2D Meteor3 = Raylib.LoadTexture("MeteorPixel.png");



startBackground.Width = Raylib.GetMonitorWidth(monitordisplay);
startBackground.Height = Raylib.GetMonitorHeight(monitordisplay);

stationBackground.Width = Raylib.GetMonitorWidth(monitordisplay);
stationBackground.Height = Raylib.GetMonitorHeight(monitordisplay);

rocketTakeoff.Width = Raylib.GetMonitorWidth(monitordisplay);
rocketTakeoff.Height = Raylib.GetMonitorHeight(monitordisplay);

spaceBattleBground.Width = 9999;
spaceBattleBground.Height = Raylib.GetMonitorHeight(monitordisplay);


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

sidewayRocket.Width = 600;
sidewayRocket.Height = 450;

Meteor1.Width = 150;
Meteor1.Height = 150;

Meteor2.Width = 100;
Meteor2.Height = 100;

Meteor3.Width = 50;
Meteor3.Height = 50;



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

  } //************************************************************************************************************
  
  else if (currentRoom == 2) //ROOM 2 *****************************************************************************
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
    
  } //**************************************************************************************************************

  else if (currentRoom == 3) //ROOM 3 *********************************************************************************
  {
    Raylib.ClearBackground(Color.BLUE);
    Raylib.DrawTexture(spaceBattleBground, PixelSpaceX, 0, Color.WHITE);
  

    Meteor1x -= 20;
    Meteor2x -= 25;
    Meteor3x -= 30;

 
    PixelSpaceX -= 10;

    if (PixelSpaceX <= -7000){
      PixelSpaceX = -100;
    }

    Raylib.DrawTexture(Meteor1, Meteor1x, Meteor1y, Color.WHITE);
    Raylib.DrawTexture(Meteor2, Meteor2x, Meteor2y, Color.WHITE);
    Raylib.DrawTexture(Meteor3, Meteor3x, Meteor3y, Color.WHITE);

    Raylib.DrawTexture(sidewayRocket, rocketFx, rocketFy, Color.WHITE);

    if (rocketFx <= 100){

      rocketFx += 10;

    }

    if (Meteor1x <= -100){
    Meteor1x = generator.Next(2000, 5000);
    Meteor1y = generator.Next(0, 1080);
    }

    if (Meteor2x <= -100){
    Meteor2x = generator.Next(2000, 5000);
    Meteor2y = generator.Next(0, 1080);
    }

    if (Meteor3x <= -100){
    Meteor3x = generator.Next(2000, 5000);
    Meteor3y = generator.Next(0, 1080);
    }

    if (Raylib.IsKeyDown(KeyboardKey.KEY_W)){      
      rocketFy -= 15;
    }

    else if (Raylib.IsKeyDown(KeyboardKey.KEY_S)){      
      rocketFy += 15;
    }

    // if (Meteor1x <= 701 && Meteor1x >= 99 && Meteor1y + 151 >= rocketFy -1 && Meteor1y + 151 <= ){
    //   currentRoom = 4;
    // }


  } // *************************************************************************************************************

  else if (currentRoom == 4)
  {
    Raylib.ClearBackground(Color.BLUE);
      
      //Room 4 code
  }

  Raylib.EndDrawing();
}