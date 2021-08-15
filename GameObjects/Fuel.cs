using MyNewAsteroids.Properties;
using MyNewAsteroids.Scenes;
using System.Drawing;

namespace MyNewAsteroids.GameObjects
{
    class Fuel : SpaceObject
    {
        public Fuel(Point _position, Point _direction) : base(_position, _direction)
        {
            Size = new Size(40, 59);
        }

        public override void Draw()
        {
            GameScene.Buffer.Graphics.DrawImage(new Bitmap(Resources.fuel, new Size(Size.Width, Size.Height)), Position.X, Position.Y);
        }

        public override void Update()
        {
            Position.X = Position.X + Direction.X;
            Position.Y = Position.Y + Direction.Y;

            if (Position.X < 0) Direction.X = -Direction.X;
            if (Position.X > GameScene.Width - Size.Width) Direction.X = -Direction.X;
            if (Position.Y < 0) Direction.Y = -Direction.Y;
            if (Position.Y > GameScene.Height - Size.Height) Direction.Y = -Direction.Y;
        }
    }
}
