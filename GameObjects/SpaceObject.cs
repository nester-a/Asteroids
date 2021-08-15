using MyNewAsteroids.Model;
using System.Drawing;

namespace MyNewAsteroids.GameObjects
{
    abstract class SpaceObject : ICollision
    {
        protected Point Position;
        protected Point Direction;
        protected Size Size;
        public Rectangle Rectangle => new Rectangle(Position, Size);

        public SpaceObject(Point _position, Point _direction, Size _size)
        {
            Position = _position;
            Direction = _direction;
            Size = _size;
        }
        public SpaceObject(Point _position, Point _direction)
        {
            Position = _position;
            Direction = _direction;
        }

        public abstract void Draw();
        public abstract void Update();
        public virtual void ChangeDirection() { }

        public bool Collision(ICollision _object)
        {
            return _object.Rectangle.IntersectsWith(this.Rectangle);
        }
    }
}
