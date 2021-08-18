using Microsoft.Extensions.DependencyInjection;
using System;
using Yen.Content;
using Yen.Scenes;
using Yen.TestGame.Scenes;

namespace Yen.TestGame
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using var game = new Engine(services =>
            {
                services
                    .AddSingleton<IContentSource, ContentSource>()
                    .AddSingleton<IScenesFactoriesSource, ScenesFactoriesSource>();
            });
            game.Run();
        }
    }
}
