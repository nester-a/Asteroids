using MyNewAsteroids.Properties;
using MyNewAsteroids.Scenes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNewAsteroids.Model
{
    class RecordsButton : MyButton
    {
        public RecordsButton(Point _position, Size _size) : base(_position, _size)
        {
            isSelected = false;
            Name = "Records";
        }
        public override void Draw()
        {
            if (isSelected)
            {
                MenuScene.Buffer.Graphics.DrawImage(new Bitmap(Resources.buttonRecordSelected, new Size(Size.Width, Size.Height)), Position.X, Position.Y);
            }
            else
            {
                MenuScene.Buffer.Graphics.DrawImage(new Bitmap(Resources.buttonRecord, new Size(Size.Width, Size.Height)), Position.X, Position.Y);
            }
        }
    }
}
