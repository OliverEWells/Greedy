using Raylib_cs;
using System.Numerics;

namespace Helloworld;
class Player: ColoredObject{
	
    public int Fontsize {get; set;}

    public string String {get; set;}
    public Player(Color color, string text, int fontsize): base(color) {
        Fontsize = fontsize;
        String = text;
    }
    public override void Draw()
    {
        Raylib.DrawText(String,(int)Position.X, (int)Position.Y, (int)Fontsize, Color.GOLD);
    }

    public override Rectangle collision_box(){
        return new Rectangle((int)Position.X, (int)Position.Y, (int)Fontsize, (int)Fontsize);
    }
}


