using Microsoft.Xna.Framework;
using System.Threading.Tasks;

namespace Yen
{
    public interface IComponent
    {
        Task OnLoad(LoadContext context, IGameObject obj);
        void Update(UpdateContext context, IGameObject obj);
    }
}
