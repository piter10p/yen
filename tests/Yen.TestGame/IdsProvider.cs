using System;

namespace Yen.TestGame
{
    public static class IdsProvider
    {
        public static class Contents
        {
            public static class Animations
            {
                public static Guid Smile = Guid.NewGuid();
            }
        }
        
        public static class ScenesFabrics
        {
            public static Guid TestScene = Guid.NewGuid();
        }
    }
}
