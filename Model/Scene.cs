using System.Windows.Forms;

namespace MyNewAsteroids.Model
{
    public interface IScene
    {
        void Init(Form _form);
        void Draw();
    }
}
