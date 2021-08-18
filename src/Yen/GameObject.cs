using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Yen.Extensions;

namespace Yen
{
    public sealed class GameObject : IGameObject
    {
        public GameObject(
            Vector2 position,
            IEnumerable<IComponent> components)
        {
            Position = position;
            _components = components.ToArray();

            _graphicsComponents = FilterComponents<IGraphicsComponent>(_components);
            _logicComponents = FilterComponents<ILogicComponent>(_components);
            _loadableComponents = FilterComponents<ILoadableComponent>(_components);
        }

        public Vector2 Position { get; private set; }
        public IEnumerable<IComponent> Components => _components;

        private readonly IComponent[] _components;
        private readonly IGraphicsComponent[] _graphicsComponents;
        private readonly ILogicComponent[] _logicComponents;
        private readonly ILoadableComponent[] _loadableComponents;

        public void Update(UpdateContext context)
        {
            foreach (var component in _logicComponents)
            {
                component.Update(context, this);
            }
        }

        public void Draw(DrawContext context)
        {
            foreach(var component in _graphicsComponents)
            {
                component.Draw(context, this);
            }
        }

        public void Register(RegisterContext context)
        {
            foreach (var component in _loadableComponents)
            {
                context.ContentRepository.AddUsages(component.RequiredContentsIds);
            }
        }

        public void OnLoad(OnLoadContext context)
        {
            foreach (var component in _loadableComponents)
            {
                component.OnLoad(context, this);
            }
        }

        private static T[] FilterComponents<T>(IComponent[] components)
            => components.OfType<T>().ToArray();
    }
}
