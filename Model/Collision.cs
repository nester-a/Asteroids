using System.Drawing;

namespace MyNewAsteroids.Model
{
    public interface ICollision
    {
        Rectangle Rectangle { get; }
        bool Collision(ICollision _object);
    }
}
