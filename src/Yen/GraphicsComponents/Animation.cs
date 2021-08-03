using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Yen.Exceptions.GraphicsComponents;

namespace Yen.GraphicsComponents
{
    public class Animation : IAnimation
    {
        private Texture2D[] _frames = null;

        public Animation(
            string name,
            string framesPath,
            int framesCount,
            TimeSpan framesDisplayDelay)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));
            if (string.IsNullOrWhiteSpace(framesPath)) throw new ArgumentException($"'{nameof(framesPath)}' cannot be null or whitespace.", nameof(framesPath));
            if (framesCount <= 0) throw new ArgumentException($"'{nameof(framesPath)}' must be positive number.", nameof(framesCount));

            Name = name;
            FramesPath = framesPath;
            FramesCount = framesCount;
            FrameDisplayDelay = framesDisplayDelay;
        }

        public string Name { get; }
        public string FramesPath { get; }
        public int FramesCount { get; }
        public TimeSpan FrameDisplayDelay { get; }
        public bool Loaded { get; private set; } = false;
        public Texture2D[] Frames
            => Loaded ? _frames : throw new AnimationNotLoadedException(Name);

        public void Load(LoadContext context)
        {
            if (Loaded)
                throw new AnimationLoadedAlreadyException(Name);

            var frames = new List<Texture2D>();

            try
            {
                for (var i = 0; i < FramesCount; i++)
                {
                    var path = $"{FramesPath}/{i}";
                    var frame = context.ContentManager.Load<Texture2D>(path);
                    frames.Add(frame);
                }
            }
            catch(Exception e)
            {
                throw new AnimationLoadingException(Name, e);
            }

            _frames = frames.ToArray();
            Loaded = true;
        }
    }
}
