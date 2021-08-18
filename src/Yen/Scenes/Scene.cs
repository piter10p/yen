using System;
using System.Collections.Generic;

namespace Yen.Scenes
{
    public sealed class Scene : IScene
    {
        public Scene(
            Guid id,
            IList<IGameObject> gameObjects)
        {
            Id = id;
            GameObjects = gameObjects;
        }

        public Guid Id { get; }
        public int Layer { get; }

        public IList<IGameObject> GameObjects { get; }

        public void Update(UpdateContext context)
        {
            foreach (var obj in GameObjects)
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

        public void Register(RegistrationContext context)
        {
            foreach (var obj in GameObjects)
            {
                obj.Register(context);
            }
        }

        public void Deregister(RegistrationContext context)
        {
            foreach (var obj in GameObjects)
            {
                obj.Deregister(context);
            }
        }

        public void OnLoad(OnLoadContext context)
        {
            foreach (var obj in GameObjects)
            {
                obj.OnLoad(context);
            }
        }
    }
}
