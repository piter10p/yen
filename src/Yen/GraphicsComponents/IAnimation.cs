using Microsoft.Xna.Framework.Graphics;
using System;

namespace Yen.GraphicsComponents
{
    public interface IAnimation
    {
        string Name { get; }
        string FramesPath { get; }
        int FramesCount { get; }
        TimeSpan FrameDisplayDelay { get; }
        bool Loaded { get; }
        Texture2D[] Frames { get; }
        void Load(LoadContext context);
    }
}
