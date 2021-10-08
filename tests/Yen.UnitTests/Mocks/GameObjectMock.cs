using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Yen.UnitTests.Mocks
{
    public class GameObjectMock : IGameObject
    {
        public GameObjectMock(
            Vector2? position = null,
            IComponent[] components = null)
        {
            Position = position ?? Vector2.Zero;
            Components = components ?? Array.Empty<IComponent>();
        }

        public Vector2 Position { get; private set; }

        public IEnumerable<IComponent> Components { get; private set; }

        public MethodCounter DeregisterCounter { get; } = new MethodCounter();
        public MethodCounter RegisterCounter { get; } = new MethodCounter();
        public MethodCounter DrawCounter { get; } = new MethodCounter();
        public MethodCounter UpdateCounter { get; } = new MethodCounter();
        public MethodCounter OnloadCounter { get; } = new MethodCounter();

        public void Deregister(RegistrationContext context)
        {
            DeregisterCounter.Call();
        }

        public void Draw(DrawContext context)
        {
            DrawCounter.Call();
        }

        public void OnLoad(OnLoadContext context)
        {
            OnloadCounter.Call();
        }

        public void Register(RegistrationContext context)
        {
            RegisterCounter.Call();
        }

        public void Update(UpdateContext context)
        {
            UpdateCounter.Call();
        }
    }
}
