using System;
using System.Linq;

namespace Yen.Extensions
{
    public static class GameObjectExtensions
    {
        public static T GetComponentOrDefault<T>(this IGameObject obj) where T : IGraphicsComponent
        {
            if (obj is null) throw new ArgumentNullException(nameof(obj));

            return (T)obj.Components.FirstOrDefault(x => x.GetType() == typeof(T));
        }
    }
}
