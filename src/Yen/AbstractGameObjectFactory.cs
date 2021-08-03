using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Yen.Exceptions.AbstractGameObjectFactory;

namespace Yen
{
    public abstract class AbstractGameObjectFactory : IGameObjectFactory
    {
        private Dictionary<Type, ILogicComponent> _logicCompontents = new Dictionary<Type, ILogicComponent>();
        private Dictionary<Type, IGraphicsComponent> _graphicsComponents = new Dictionary<Type, IGraphicsComponent>();
        private Vector2 _initialPosition = Vector2.Zero;

        public IGameObject Create()
        {
            return new GameObject(
                _initialPosition,
                _logicCompontents.Values.ToList(),
                _graphicsComponents.Values.ToList());
        }

        protected void AddComponent(ILogicComponent component)
        {
            if (component is null) throw new ArgumentNullException(nameof(component));

            var componentType = component.GetType();

            if(_logicCompontents.ContainsKey(componentType))
                throw new ComponentDeclaredException(componentType.Name);

            _logicCompontents.Add(componentType, component);
        }

        protected void AddComponent(IGraphicsComponent component)
        {
            if (component is null) throw new ArgumentNullException(nameof(component));

            var componentType = component.GetType();

            if (_graphicsComponents.ContainsKey(componentType))
                throw new ComponentDeclaredException(componentType.Name);

            _graphicsComponents.Add(componentType, component);
        }

        protected void SetInitialPosition(Vector2 initialPosition)
        {
            _initialPosition = initialPosition;
        }
    }
}
