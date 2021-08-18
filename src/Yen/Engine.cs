using Microsoft.Extensions.DependencyInjection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using Yen.Content;
using Yen.Scenes;

namespace Yen
{
    public sealed class Engine : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private readonly Action<IServiceCollection> _servicesFactory;
        private IServiceProvider _serviceProvider;

        public Engine(Action<IServiceCollection> servicesFactory)
        {
            if (servicesFactory is null) throw new ArgumentNullException(nameof(servicesFactory));

            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _servicesFactory = servicesFactory;
        }

        protected override void Initialize()
        {
            _serviceProvider = CreateServiceProvider(_servicesFactory);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            var factory = _serviceProvider.GetRequiredService<IScenesFactoriesSource>().Factories.FirstOrDefault();

            if (!(factory is null))
            {
                _serviceProvider.GetRequiredService<IScenesLoader>().LoadScene(factory.Id, 0);
            }

            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            _serviceProvider.GetRequiredService<IScenesUpdater>().Update(new UpdateContext(gameTime));
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _serviceProvider.GetRequiredService<IScenesUpdater>().Draw(new DrawContext(
                gameTime,
                GraphicsDevice));
            base.Draw(gameTime);
        }

        private IServiceProvider CreateServiceProvider(Action<IServiceCollection> servicesFactory)
        {
            var services = new ServiceCollection();
            servicesFactory(services);

            services
               .AddSingleton(GraphicsDevice)
               .AddSingleton(Content)
               .AddSingleton<IContentRepository, ContentRepository>()
               .AddSingleton<ScenesManager>()
               .AddSingleton<IScenesLoader>(x => x.GetRequiredService<ScenesManager>())
               .AddSingleton<IScenesUpdater>(x => x.GetRequiredService<ScenesManager>());

            return services.BuildServiceProvider();
        }
    }
}
