using MyNewAsteroids.Properties;
using MyNewAsteroids.Scenes;
using System.Drawing;

namespace MyNewAsteroids.GameObjects
{
    class Background
    {
        protected Point Position;
        protected Size Size;

        public Background(Point _position, Size _size)
        {
            Position = _position;
            Size = _size;
        }
        public void Draw()
        {
            GameScene.Buffer.Graphics.DrawImage(new Bitmap(Resources.bg1, new Size(Size.Height, Size.Width)), Position.X, Position.Y);
        }
    }
}
