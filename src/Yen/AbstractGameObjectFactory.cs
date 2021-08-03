using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Yen.Exceptions.AbstractGameObjectFactory;

namespace Yen
{
    public abstract class AbstractGameObjectFactory : IGameObjectFactory
    {
        private Dictionary<Type, IComponent> _compontents = new Dictionary<Type, IComponent>();
        private Vector2 _initialPosition = Vector2.Zero;

        public IGameObject Create()
        {
            return new GameObject(_initialPosition, _compontents.Values.ToList());
        }

        protected void AddComponent(IComponent component)
        {
            if (component is null) throw new ArgumentNullException(nameof(component));

            var componentType = component.GetType();

            if(_compontents.ContainsKey(componentType))
                throw new ComponentDeclaredException(componentType.Name);

            _compontents.Add(componentType, component);
        }

        protected void SetInitialPosition(Vector2 initialPosition)
        {
            _initialPosition = initialPosition;
        }
    }
}
