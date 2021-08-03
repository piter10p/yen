using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using Yen.Exceptions.GraphicsComponents;

namespace Yen.GraphicsComponents
{
    public class AnimatedGraphicsComponent : IGraphicsComponent
    {
        private IList<IAnimation> _animations;
        private IAnimation _activeAnimation;
        private Color _color;

        private TimeSpan _lastFrameChangeTimeSpan = TimeSpan.Zero;
        private int _frameIndex = 0;
        private bool _paused = false;
        private bool _ended = false;
        private bool _playForward = true;
        private AnimationPlayMode _animationPlayMode;

        private SpriteBatch _spriteBatch;

        public AnimatedGraphicsComponent(
            IList<IAnimation> animations,
            Color color,
            AnimationPlayMode animationPlayMode)
        {
            _animations = animations ?? throw new ArgumentNullException(nameof(animations));
            _activeAnimation = _animations.FirstOrDefault();
            _color = color;
            _animationPlayMode = animationPlayMode;
        }

        public void Draw(DrawContext context, IGameObject obj)
        {
            if (_activeAnimation is null)
                throw new NoActiveAnimationException();

            if (!_activeAnimation.Loaded)
                throw new AnimationNotLoadedException(_activeAnimation.Name);

            _lastFrameChangeTimeSpan += context.GameTime.ElapsedGameTime;

            UpdateFrameIndex();
            UpdateFrame(obj);
        }

        public void OnLoad(LoadContext loadContext, IGameObject obj)
        {
            _spriteBatch = new SpriteBatch(loadContext.GraphicsDevice);

            foreach (var animation in _animations)
            {
                if (!animation.Loaded)
                    animation.Load(loadContext);
            }
        }

        public void PlayAnimation(string animationName, AnimationPlayMode animationPlayMode, int startFrame = 0)
        {
            if (string.IsNullOrWhiteSpace(animationName)) throw new ArgumentException($"'{nameof(animationName)}' cannot be null or whitespace.", nameof(animationName));

            var animation = _animations.FirstOrDefault(x => x.Name == animationName)
                ?? throw new AnimationNotKnownException(animationName);

            if (startFrame >= animation.FramesCount)
                throw new FrameIndexOutOfRangeException(animationName, startFrame, animation.FramesCount);

            _activeAnimation = animation;
            _frameIndex = startFrame;
            _animationPlayMode = animationPlayMode;
            _lastFrameChangeTimeSpan = TimeSpan.Zero;
            _paused = false;
            _ended = false;
            _playForward = true;
        }

        public void Pause()
        {
            _paused = true;
        }

        public void Play()
        {
            _paused = false;
        }

        private void UpdateFrameIndex()
        {
            if (_paused || _ended)
                return;

            if (_lastFrameChangeTimeSpan >= _activeAnimation.FrameDisplayDelay)
            {
                if(_playForward)
                {
                    if (_frameIndex >= _activeAnimation.FramesCount - 1)
                    {
                        switch (_animationPlayMode)
                        {
                            case AnimationPlayMode.Once:
                                _ended = true;
                                break;

                            case AnimationPlayMode.Looped:
                                _frameIndex = 0;
                                break;

                            case AnimationPlayMode.PingPong:
                                _frameIndex--;
                                _playForward = false;
                                break;
                        }
                    }
                    else
                        _frameIndex++;
                }
                else
                {
                    if (_frameIndex == 0)
                    {
                        _frameIndex++;
                        _playForward = true;
                    }
                    else
                        _frameIndex--;
                }

                _lastFrameChangeTimeSpan = TimeSpan.Zero;
            }
        }

        private void UpdateFrame(IGameObject gameObject)
        {
            var frame = _activeAnimation.Frames[_frameIndex];
            _spriteBatch.Begin();
            _spriteBatch.Draw(frame, gameObject.Position, _color);
            _spriteBatch.End();
        }
    }
}
