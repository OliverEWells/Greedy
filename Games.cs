using Raylib_cs;
using System.Numerics;

namespace Helloworld
{
    static class Program
    {
        public static void Main()
        {

            var ScreenHeight = 480;
            var ScreenWidth = 800;
            var Objects = new List<GameObject>();
            var Random = new Random();

            //Player initial position
            //Player movement speed
            int MovementSpeed = 10;
            var player_speed = new Vector2(0, 0);

            double counter = 0;

            var player = new Player(Color.GOLD, "^", 40);

            player.Position = new Vector2(ScreenWidth/2, ScreenHeight - 30);
            Objects.Add(player);

            string rocks_letter = "G";
            string gems_letter = "O";

            var score_placement = new Vector2(50,50);
            var Score_counter = new Score(Color.ORANGE, 40, "score_counter");
            Score_counter.Position = score_placement;
            Objects.Add(Score_counter);

            

            Raylib.InitWindow(ScreenWidth, ScreenHeight, "FallingGame");
            Raylib.SetTargetFPS(60);

            while (!Raylib.WindowShouldClose())
            {
                // Add a new random object to the screen every iteration of our game loop
                var whichType = Random.Next(2);

                // Generate a random velocity for this object
                var randomY = Random.Next(-2, 2);
                var randomX = Random.Next(0, ScreenWidth);
                int fallspeed = 3;
                //Player
                player.Velocity = new Vector2(0, 0);

                // Each object will start about the center of the screen
                var position = new Vector2(randomX, 0);

                

                //Counter
                counter += 1;

                if(counter%50 == 0) {
                    Console.WriteLine(counter);
                    Console.WriteLine(randomX);
                    switch (whichType) {
                    case 0:
                        Console.WriteLine("Creating a gem");
                        var gem = new Gems(Color.RED, gems_letter, 20, "gem");
                        gem.Fontsize = 20;
                        gem.Position = position;
                        gem.Velocity = new Vector2(0, fallspeed);
                        Objects.Add(gem);
                        break;
                    case 1:
                        Console.WriteLine("Creating a rock");
                        var rock = new Rocks(Color.DARKPURPLE, rocks_letter, 100, "rock");
                        rock.Fontsize = 20;
                        rock.Position = position;
                        rock.Velocity = new Vector2(0, fallspeed);
                        Objects.Add(rock);
                        break;
                    default:
                        break;
                }






                //Player Movement
                


                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)) {
                    player.Velocity = new Vector2(MovementSpeed, 0);
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)) {
                    player.Velocity = new Vector2(-MovementSpeed, 0);
                }

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);

                // Draw all of the objects in their current location
                foreach (var obj in Objects) {
                    obj.Draw();
                }

                Raylib.EndDrawing();

                var player_box = player.collision_box();

                int old_score = Score_counter.score;

                int index = 10000;

                foreach (var obj in Objects)
                {

                    Rectangle box = obj.collision_box();
                    
                    if (Raylib.CheckCollisionRecs(box, player_box))
                    {
                        if (obj.Name == "rock"){
                            Score_counter.AlterPoints(false);
                            Console.WriteLine("Ouch!");
                            index = Objects.IndexOf(obj);
                        }
                        else if (obj.Name == "gem")
                        {
                            Score_counter.AlterPoints(true);
                            Console.WriteLine("Yummy gem");
                            index = Objects.IndexOf(obj);
                        }
                        
                    }
                }

                if (old_score != Score_counter.score){
                            Objects.RemoveAt(index);
                        }

                // Move all of the objects to their next location
                foreach (var obj in Objects) {
                    obj.Move();

                }
            

            }

            Raylib.CloseWindow();
        }
    }
}
