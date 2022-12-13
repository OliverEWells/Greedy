using Raylib_cs;
using System.Numerics;

namespace Helloworld;


class GameObject {
    public Vector2 Position { get; set; } = new Vector2(0, 0);
    public Vector2 Velocity { get; set; } = new Vector2(0, 0);



    public string Name { get; set; }

    virtual public void Draw() {
        // Base game objects do not have anything to draw
        
    }

    virtual public Rectangle collision_box() {
        // Base game objects do not have anything to draw
        return new Rectangle(1, 1, 1, 1);
    }

    public void Move() {
        Vector2 NewPosition = this.Position;
        NewPosition.X += Velocity.X;
        NewPosition.Y += Velocity.Y;
        this.Position = NewPosition;
    }
}