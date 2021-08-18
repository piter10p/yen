using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Yen.Exceptions.AbstractGameObjectFactory;

namespace Yen
{
    public abstract class AbstractGameObjectFactory : IGameObjectFactory
    {
        private readonly Dictionary<Type, IComponent> _components = new Dictionary<Type, IComponent>();
        private Vector2 _initialPosition = Vector2.Zero;

        public IGameObject Create()
        {
            return new GameObject(
                _initialPosition,
                _components.Values);
        }

        protected void AddComponent(IComponent component)
        {
            if (component is null) throw new ArgumentNullException(nameof(component));

            var componentType = component.GetType();

            if (_components.ContainsKey(componentType))
                throw new ComponentDeclaredException(componentType.Name);

            _components.Add(componentType, component);
        }

        protected void SetInitialPosition(Vector2 initialPosition)
        {
            _initialPosition = initialPosition;
        }
    }
}
