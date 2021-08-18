using Microsoft.Xna.Framework.Graphics;
using System;

namespace Yen.Content.Contents
{
    public interface IAnimation : IContent
    {
        string FramesPath { get; }
        int FramesCount { get; }
        TimeSpan FrameDisplayDelay { get; }
        Texture2D[] Frames { get; }
    }
}
