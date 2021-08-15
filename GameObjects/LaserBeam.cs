using MyNewAsteroids.Properties;
using MyNewAsteroids.Scenes;
using System.Drawing;

namespace MyNewAsteroids.GameObjects
{
    class LaserBeam : SpaceObject
    {
        public LaserBeam(Point _position, Point _direction, Size _size) : base(_position, _direction, _size)
        {

        }
        public override void Draw()
        {
            GameScene.Buffer.Graphics.DrawImage(new Bitmap(Resources.laserBeam, new Size(Size.Height, Size.Width)), Position.X, Position.Y);
        }

        public override void Update()
        {
            Position.X += 100;
        }
    }
}
