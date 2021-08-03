using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yen
{
    public sealed class GameObject : IGameObject
    {
        public GameObject(Vector2 position, IList<IComponent> compontents)
        {
            Position = position;
            Components = compontents;
        }

        public Vector2 Position { get; private set; }

        public IList<IComponent> Components { get; private set; }

        public void Update(UpdateContext context)
        {
            foreach (var component in Components)
            {
                component.Update(context, this);
            }
        }

        public async Task Load(LoadContext context)
        {
            var tasks = Components.Select(x => x.OnLoad(context, this));
            await Task.WhenAll(tasks);
        }
    }
}
