using System.Collections.Generic;

namespace Yen
{
    public sealed class Scene : IScene
    {
        public Scene(IList<IGameObject> gameObjects)
        {
            GameObjects = gameObjects;
        }

        public IList<IGameObject> GameObjects { get; }

        public void Update(UpdateContext context)
        {
            foreach(var obj in GameObjects)
            {
                obj.Update(context);
            }
        }

        public void Draw(DrawContext context)
        {
            foreach (var obj in GameObjects)
            {
                obj.Draw(context);
            }
        }

        public void Load(LoadContext context)
        {
            foreach(var obj in GameObjects)
            {
                obj.Load(context);
            }
        }
    }
}
