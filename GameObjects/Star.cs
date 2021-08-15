using MyNewAsteroids.Properties;
using MyNewAsteroids.Scenes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNewAsteroids.GameObjects
{
    class Star : SpaceObject
    {
        public Star(Point _position, Point _direction, Size _size) : base(_position, _direction, _size) { }
        static Random random = new Random();

        public override void Draw()
        {
            GameScene.Buffer.Graphics.DrawImage(new Bitmap(Resources.star_1, new Size(Size.Width, Size.Height)), Position.X, Position.Y);
        }
        public override void Update()
        {
            if (Position.X < 0)
            {
                Position.X = GameScene.Width;
                Position.Y = random.Next(1, GameScene.Height + 1);
            }
            Position.X -= 50;
        }
    }
}
