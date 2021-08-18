using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using Yen.Content;
using Yen.Exceptions.Scenes;

namespace Yen.Scenes
{
    public class ScenesManager : IScenesLoader, IScenesUpdater
    {
        private readonly Dictionary<Guid, ISceneFactory> _sceneFactories;
        private readonly List<IScene> _scenes = new List<IScene>();

        public ScenesManager(
            IScenesFactoriesSource scenesFactoriesSource,
            IContentRepository contentRepository,
            ContentManager contentManager,
            GraphicsDevice graphicsDevice)
        {
            _contentRepository = contentRepository;
            _contentManager = contentManager;
            _graphicsDevice = graphicsDevice;
            _sceneFactories = scenesFactoriesSource.Factories.ToDictionary(k => k.Id, v => v);
        }

        private readonly IContentRepository _contentRepository;
        private readonly ContentManager _contentManager;
        private readonly GraphicsDevice _graphicsDevice;

        public Guid LoadScene(Guid factoryId, int layer)
        {
            if (!_sceneFactories.ContainsKey(factoryId))
                throw new SceneFactoryNotRegisteredException(factoryId);

            var scene = _sceneFactories[factoryId].Create(Guid.NewGuid());
            LoadSceneInternal(scene);

            _scenes.Add(scene);
            _scenes.Sort(LayerComparasion);

            return scene.Id;
        }

        public void UnloadScene(Guid sceneId)
        {
            if (!_scenes.Any(x => x.Id == sceneId))
                throw new SceneNotLoadedException(sceneId);

            var scene = _scenes.First(x => x.Id == sceneId);
            _scenes.Remove(scene);
        }

        public void Update(UpdateContext context)
        {
            foreach (var s in _scenes)
            {
                s.Update(context);
            }
        }

        public void Draw(DrawContext context)
        {
            foreach(var s in _scenes)
            {
                s.Draw(context);
            }
        }

        private static int LayerComparasion(IScene x, IScene y)
        {
            if (x.Layer == y.Layer) return 0;
            if (x.Layer > y.Layer) return 1;
            return -1;
        }

        private void LoadSceneInternal(IScene scene)
        {
            var registrationContext = new RegistrationContext(_contentRepository);
            var loadContext = new LoadContext(_contentManager);
            var onLoadContext = new OnLoadContext(_graphicsDevice, _contentRepository);

            scene.Register(registrationContext);
            registrationContext.ContentRepository.Load(loadContext);
            scene.OnLoad(onLoadContext);
        }
    }
}
