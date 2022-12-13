using Raylib_cs;
using System.Numerics;

namespace Helloworld{


class Rocks: Freefall{
    public int Fontsize {get; set; }
    public string String {get; set;}
    public Rocks(Color color, string text, int textsize, string name): base(color) {
        Fontsize = Fontsize;
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
}