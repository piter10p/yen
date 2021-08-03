using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task Load(LoadContext context)
        {
            var tasks = GameObjects.Select(x => x.Load(context));
            await Task.WhenAll(tasks);
        }
    }
}
