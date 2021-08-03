using System;
using System.Linq;

namespace Yen.Extensions
{
    public static class GameObjectExtensions
    {
        public static T GetComponent<T>(this IGameObject obj) where T : IGraphicsComponent
        {
            if (obj is null) throw new ArgumentNullException(nameof(obj));

            return (T)obj.LogicComponents.FirstOrDefault(x => x.GetType() == typeof(T));
        }
    }
}
