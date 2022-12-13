using Raylib_cs;
using System.Numerics;


namespace Helloworld;


    class Freefall: ColoredObject{

        public Freefall(Color color): base(color){

        }
        public void fall(){
            Vector2 NewPosition = Position;
            NewPosition.X += 0;
            NewPosition.Y += Velocity.Y;
            Position = NewPosition;
        }
        public bool land(int ScreenHeight){
            if (Position.Y == ScreenHeight){
                return true;
            }
            else{
                return false;
            } //this is for when we delete the item
        }
    }
