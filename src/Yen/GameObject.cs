using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Yen
{
    public sealed class GameObject : IGameObject
    {
        public GameObject(Vector2 position, IList<ILogicComponent> logicCompontents, IList<IGraphicsComponent> graphicsComponents)
        {
            Position = position;
            LogicComponents = logicCompontents;
            GraphicsComponents = graphicsComponents;
        }

        public Vector2 Position { get; private set; }

        public IList<ILogicComponent> LogicComponents { get; private set; }
        public IList<IGraphicsComponent> GraphicsComponents { get; private set; }

        public void Update(UpdateContext context)
        {
            foreach (var component in LogicComponents)
            {
                component.Update(context, this);
            }
        }

        public void Draw(DrawContext context)
        {
            foreach(var component in GraphicsComponents)
            {
                component.Draw(context, this);
            }
        }

        public void Load(LoadContext context)
        {
            foreach(var component in LogicComponents)
            {
                component.OnLoad(context, this);
            }

            foreach(var component in GraphicsComponents)
            {
                component.OnLoad(context, this);
            }
        }
    }
}
