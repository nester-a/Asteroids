using MyNewAsteroids.Properties;
using MyNewAsteroids.Scenes;
using System;
using System.Drawing;

namespace MyNewAsteroids.GameObjects
{
    class Planet : SpaceObject
    {
        private int index;
        private static Random random = new Random();

        public Planet(Point _position, Point _direction) : base(_position, _direction)
        {
            index = random.Next(1, 7);
        }

        public override void Draw()
        {
            switch (index)
            {
                case 1:
                    GameScene.Buffer.Graphics.DrawImage(new Bitmap(Resources.planet_1, new Size(357, 391)), Position.X, Position.Y);
                    break;
                case 2:
                    GameScene.Buffer.Graphics.DrawImage(new Bitmap(Resources.planet_2, new Size(267, 150)), Position.X, Position.Y);
                    break;
                case 3:
                    GameScene.Buffer.Graphics.DrawImage(new Bitmap(Resources.planet_3, new Size(433, 248)), Position.X, Position.Y);
                    break;
                case 4:
                    GameScene.Buffer.Graphics.DrawImage(new Bitmap(Resources.planet_4, new Size(249, 255)), Position.X, Position.Y);
                    break;
                case 5:
                    GameScene.Buffer.Graphics.DrawImage(new Bitmap(Resources.planet_5, new Size(352, 365)), Position.X, Position.Y);
                    break;
                case 6:
                    GameScene.Buffer.Graphics.DrawImage(new Bitmap(Resources.planet_6, new Size(256, 263)), Position.X, Position.Y);
                    break;
            }
        }
        public override void Update()
        {
            if (Position.X < -500)
            {
                index = random.Next(1, 7);
                Position.X = GameScene.Width;
                Position.Y = random.Next(1, GameScene.Height - Size.Height);
            }
            Position.X -= 10;
        }
    }
}
