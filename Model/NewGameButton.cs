using MyNewAsteroids.Properties;
using MyNewAsteroids.Scenes;
using System.Drawing;

namespace MyNewAsteroids.Model
{
    public class NewGameButton : MyButton
    {
        public NewGameButton(Point _position, Size _size) : base(_position, _size)
        {
            isSelected = true;
            Name = "NewGame";
        }
        public override void Draw()
        {
            if (isSelected)
            {
                MenuScene.Buffer.Graphics.DrawImage(new Bitmap(Resources.buttonNewGameSelected, new Size(Size.Width, Size.Height)), Position.X, Position.Y);
            }
            else
            {
                MenuScene.Buffer.Graphics.DrawImage(new Bitmap(Resources.buttonNewGame, new Size(Size.Width, Size.Height)), Position.X, Position.Y);
            }
        }
    }
}
