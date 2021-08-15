using System.Drawing;
using MyNewAsteroids.Scenes;
using MyNewAsteroids.Properties;

namespace MyNewAsteroids.GameObjects
{
    class Asteroid : SpaceObject
    {
        public Asteroid(Point _position, Point _direction, Size _size) : base (_position, _direction, _size)
        {

        }
        public override void Draw()
        {
            GameScene.Buffer.Graphics.DrawImage(new Bitmap(Resources.asteroid, new Size(Size.Width, Size.Height)), Position.X, Position.Y);
        }

        public override void Update()
        {
            Position.X += Direction.X;
            Position.Y += Direction.Y;

            if (Position.X < 0) Direction.X = -Direction.X;
            if (Position.X > GameScene.Width - Size.Width) Direction.X = -Direction.X;
            if (Position.Y < 0) Direction.Y = -Direction.Y;
            if (Position.Y > GameScene.Height - Size.Height) Direction.Y = -Direction.Y;
        }
    }
}
