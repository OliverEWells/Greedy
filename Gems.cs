using Raylib_cs;
using System.Numerics;

namespace Helloworld;

class Gems: Freefall{
    public int Fontsize {get; set;}
    public string String {get; set;}
    public Gems(Color color, string text, int fontsize, string name): base(color){
        Fontsize = fontsize;
        String = text;
        Name = name;
    }
    public override void Draw()
    {
        Raylib.DrawText(String,(int)Position.X, (int)Position.Y, (int)Fontsize, Color);
    }
    
    public override Rectangle collision_box(){
        return new Rectangle((int)Position.X, (int)Position.Y, (int)Fontsize, (int)Fontsize);
    }

}