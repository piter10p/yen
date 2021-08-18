using System;
using System.Collections.Generic;
using System.Linq;

namespace Yen.Scenes
{
    public abstract class AbstractSceneFactory : ISceneFactory
    {
        private List<IGameObjectFactory> _gameObjectFactories = new List<IGameObjectFactory>();

        public AbstractSceneFactory(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }

        public IScene Create(Guid sceneId)
        {
            var gameObjects = _gameObjectFactories.Select(x => x.Create()).ToList();
            return new Scene(sceneId, gameObjects);
        }

        protected void AddGameObject(IGameObjectFactory gameObjectFactory)
        {
            if (gameObjectFactory is null) throw new ArgumentNullException(nameof(gameObjectFactory));

            _gameObjectFactories.Add(gameObjectFactory);
        }
    }
}
