using System.Collections.Generic;
using System.Threading.Tasks;

namespace Yen
{
    public interface IScene
    {
        IList<IGameObject> GameObjects { get; }
        void Update(UpdateContext context);
        Task Load(LoadContext context);
    }
}
