using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Yen
{
    public interface IGameObject
    {
        Vector2 Position { get; }
        IList<IComponent> Components { get; }
        void Update(UpdateContext context);
        Task Load(LoadContext context);
    }
}
