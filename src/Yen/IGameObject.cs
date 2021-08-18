using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Yen
{
    public interface IGameObject
    {
        Vector2 Position { get; }
        IEnumerable<IComponent> Components { get; }
        void Update(UpdateContext context);
        void Draw(DrawContext context);
        void Register(RegisterContext context);
        void OnLoad(OnLoadContext context);
    }
}
