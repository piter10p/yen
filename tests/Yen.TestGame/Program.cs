using System;
using Yen.TestGame.Scenes;

namespace Yen.TestGame
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using var game = new Engine(new TestSceneFactory());
            game.Run();
        }
    }
}
