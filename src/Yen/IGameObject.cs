using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Yen
{
    public interface IGameObject
    {
        Vector2 Position { get; }
        IList<ILogicComponent> LogicComponents { get; }
        IList<IGraphicsComponent> GraphicsComponents { get; }
        void Update(UpdateContext context);
        void Draw(DrawContext context);
        void Load(LoadContext context);
    }
}
