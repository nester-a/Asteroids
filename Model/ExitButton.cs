using MyNewAsteroids.Properties;
using MyNewAsteroids.Scenes;
using System.Drawing;

namespace MyNewAsteroids.Model
{
    class ExitButton : MyButton
    {
        public ExitButton(Point _position, Size _size) : base(_position, _size)
        {
            isSelected = false;
            Name = "Exit";
        }
        public override void Draw()
        {
            if (isSelected)
            {
                MenuScene.Buffer.Graphics.DrawImage(new Bitmap(Resources.buttonExitSelected, new Size(Size.Width, Size.Height)), Position.X, Position.Y);
            }
            else
            {
                MenuScene.Buffer.Graphics.DrawImage(new Bitmap(Resources.buttonExit, new Size(Size.Width, Size.Height)), Position.X, Position.Y);
            }
        }
    }
}
