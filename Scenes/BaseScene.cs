using MyNewAsteroids.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyNewAsteroids.Scenes
{
    public abstract class BaseScene : IScene, IDisposable
    {
        protected BufferedGraphicsContext Context;
        protected Form Form;
        public static BufferedGraphics Buffer;

        public static int Width { get; set; }
        public static int Height { get; set; }

        public virtual void Init(Form _form)
        {
            Form = _form;
            Context = BufferedGraphicsManager.Current;
            Graphics g;
            g = Form.CreateGraphics();

            Width = Form.ClientSize.Width;

            Height = Form.ClientSize.Height;

            Buffer = Context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Form.KeyDown += SceneKeyDown;
        }

        public virtual void SceneKeyDown(object sender, KeyEventArgs e) { }
        public virtual void Draw() { }
        public void Dispose()
        {
            Form.KeyDown -= SceneKeyDown;
        }
    }
}
