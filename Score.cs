// The idea is whatever code is in charge of identifying collisions will 
// deliver a boolean indicating what kind of collision has occured and
// make the appropriate changes to the score.
using Raylib_cs;
using System.Numerics;

namespace Helloworld;

class Score: ColoredObject{


public int score = 0;
public void AlterPoints(bool info){
    if (info == true){
        score += 25;
    }
    else if (info == false){
        score -= 10;
    }
    }

public int Fontsize {get; set;}



public Score(Color color, int fontsize, string name): base(color){
        Fontsize = fontsize;
        Name = name;
    }


public override void Draw()
    {
        Raylib.DrawText(score.ToString(),(int)Position.X, (int)Position.Y, (int)Fontsize, Color);
    }
public override Rectangle collision_box(){
        return new Rectangle((int)Position.X, (int)Position.Y, (int)Fontsize, (int)Fontsize);
    }
}