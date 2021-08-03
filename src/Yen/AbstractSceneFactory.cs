using System;
using System.Collections.Generic;
using System.Linq;

namespace Yen
{
    public abstract class AbstractSceneFactory : ISceneFactory
    {
        private List<IGameObjectFactory> _gameObjectFactories = new List<IGameObjectFactory>();

        public IScene Create()
        {
            var gameObjects = _gameObjectFactories.Select(x => x.Create()).ToList();
            return new Scene(gameObjects);
        }

        protected void AddGameObject(IGameObjectFactory gameObjectFactory)
        {
            if (gameObjectFactory is null) throw new ArgumentNullException(nameof(gameObjectFactory));

            _gameObjectFactories.Add(gameObjectFactory);
        }
    }
}
