using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Yen.Content;

namespace Yen
{
    public sealed class Engine : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private readonly IContentRepository _contentRepository;
        private readonly ISceneFactory _sceneFactory;
        private IScene _scene;

        public Engine(IContentCollection contentCollection, ISceneFactory initialScene)
        {
            if (contentCollection is null) throw new ArgumentNullException(nameof(contentCollection));
            if (initialScene is null) throw new ArgumentNullException(nameof(initialScene));

            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _contentRepository = new ContentRepository(contentCollection);
            _sceneFactory = initialScene;
        }

        protected override void Initialize()
        {
            _scene = _sceneFactory.Create();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _scene.Register(new RegisterContext(_contentRepository));
            _contentRepository.Load(new LoadContext(Content));
            _scene.OnLoad(new OnLoadContext(GraphicsDevice, _contentRepository));
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            _scene.Update(new UpdateContext(gameTime));
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _scene.Draw(new DrawContext(gameTime, GraphicsDevice));
            base.Draw(gameTime);
        }
    }
}
