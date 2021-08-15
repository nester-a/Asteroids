using System.Drawing;

namespace MyNewAsteroids.Model
{
    public abstract class MyButton
    {
        protected Point Position;
        protected Size Size;
        public string Name { get; protected set; }

        public bool isSelected { get; protected set; }

        public MyButton(Point _position, Size _size)
        {
            Position = _position;
            Size = _size;
        }
        public abstract void Draw();
        public void ChangeSelection()
        {
            if (isSelected)
            {
                isSelected = false;
            }
            else
            {
                isSelected = true;
            }
        }
    }
}
