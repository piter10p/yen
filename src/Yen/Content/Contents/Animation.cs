using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Yen.Exceptions.Content.Contents;

namespace Yen.Content.Contents
{
    public class Animation : IAnimation
    {
        private Texture2D[] _frames = null;

        public Animation(
            string id,
            string framesPath,
            int framesCount,
            TimeSpan framesDisplayDelay)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException($"'{nameof(id)}' cannot be null or whitespace.", nameof(id));
            if (string.IsNullOrWhiteSpace(framesPath)) throw new ArgumentException($"'{nameof(framesPath)}' cannot be null or whitespace.", nameof(framesPath));
            if (framesCount <= 0) throw new ArgumentException($"'{nameof(framesPath)}' must be positive number.", nameof(framesCount));

            Id = id;
            FramesPath = framesPath;
            FramesCount = framesCount;
            FrameDisplayDelay = framesDisplayDelay;
        }

        public string Id { get; }
        public string FramesPath { get; }
        public int FramesCount { get; }
        public TimeSpan FrameDisplayDelay { get; }
        public bool Loaded => !(_frames is null);
        public Texture2D[] Frames
            => Loaded ? _frames : throw new ContentNotLoadedException(Id);

        public void Load(LoadContext context)
        {
            if (Loaded)
                throw new ContentLoadedAlreadyException(Id);

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
            catch (Exception e)
            {
                throw new ContentLoadingException(Id, e);
            }

            _frames = frames.ToArray();
        }

        public void Unload()
        {
            if (!Loaded)
                throw new ContentNotLoadedException(Id);

            foreach (var f in _frames)
            {
                if (!f.IsDisposed)
                    f.Dispose();
            }

            _frames = null;
        }
    }
}
