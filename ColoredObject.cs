using Raylib_cs;
using System.Numerics;

namespace Helloworld;

class ColoredObject: GameObject {

    

    public Color Color { get; set; }

    public ColoredObject(Color color) {
        Color = color;
    }
}
