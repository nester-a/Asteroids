using MyNewAsteroids.Properties;
using MyNewAsteroids.Scenes;
using System;
using System.Drawing;

namespace MyNewAsteroids.GameObjects
{
    class Ship : SpaceObject
    {
        public int Energy { get; private set; } = 100;
        public int DestroyAsteroidsCount { get; private set; } = 0;
        public static EventHandler DieEvent;
        public static Random random = new Random();

        public Ship(Point _position, Point _direction) : base(_position, _direction)
        {
            Size = new Size(128, 63);
        }
        public override void Draw()
        {
            GameScene.Buffer.Graphics.DrawImage(new Bitmap(Resources.spaceship, new Size(Size.Width, Size.Height)), Position.X, Position.Y);
        }
        public override void Update()
        {
            if (Position.X > 800)
            {
                Position.X = -800;
                Position.Y = random.Next(1, GameScene.Height - Size.Height);
            }
            Position.X += 50;
        }
        public void Up()
        {
            if (Position.Y - Size.Height < 0) Position.Y = 0;
            if (Position.Y > 0) Position.Y -= Size.Height;
        }
        public void Down()
        {
            if (Position.Y + Size.Height > GameScene.Height - 63) Position.Y = GameScene.Height - 63;

            else if (Position.Y < GameScene.Height - 63) Position.Y += Size.Height;
        }
        public void DamageShip(int damage)
        {
            Energy -= damage;
        }

        public void HealShip(int heal)
        {
            if (Energy + heal > 100)
                Energy = 100;
            else
                Energy += heal;
        }
        public void Die()
        {
            DieEvent?.Invoke(this, new EventArgs());
        }
        public void IncreaseCount()
        {
            DestroyAsteroidsCount++;
        }
    }
}
