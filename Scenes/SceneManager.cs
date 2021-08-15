using MyNewAsteroids.Model;
using System.Windows.Forms;

namespace MyNewAsteroids.Scenes
{
    class SceneManager
    {
        private static SceneManager sceneManager;
        private BaseScene scene;

        public static SceneManager Get()
        {
            if (sceneManager == null)
            {
                sceneManager = new SceneManager();
            }
            return sceneManager;
        }
        public IScene Init<T>(Form form) where T : BaseScene, new()
        {
            if (scene != null)
            {
                scene.Dispose();
            }

            scene = new T();
            scene.Init(form);
            return scene;
        }
    }
}
