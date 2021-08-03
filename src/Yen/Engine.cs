using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Yen
{
    public sealed class Engine : Game
    {
        private GraphicsDeviceManager _graphics;

        private ISceneFactory _sceneFactory;
        private IScene _scene;

        public Engine(ISceneFactory initialScene)
        {
            if (initialScene is null) throw new ArgumentNullException(nameof(initialScene));

            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _sceneFactory = initialScene;
        }

        protected override void Initialize()
        {
            _scene = _sceneFactory.Create();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _scene.Load(new LoadContext(Content, GraphicsDevice));
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            _scene.Update(new UpdateContext(gameTime, Content));
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
