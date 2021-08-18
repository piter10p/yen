using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using Yen.Content.Contents;
using Yen.Exceptions.GraphicsComponents;
using Yen.Extensions;

namespace Yen.GraphicsComponents
{
    public class AnimatedGraphicsComponent : IGraphicsComponent, ILoadableComponent
    {
        private readonly ISet<Guid> _animationIds;
        private List<IAnimation> _animations;
        private IAnimation _activeAnimation;
        private Color _color;

        private TimeSpan _lastFrameChangeTimeSpan = TimeSpan.Zero;
        private int _frameIndex = 0;
        private bool _paused = false;
        private bool _ended = false;
        private bool _playForward = true;
        private AnimationPlayMode _animationPlayMode;

        private SpriteBatch _spriteBatch;

        public ISet<Guid> RequiredContentsIds => _animationIds;

        public AnimatedGraphicsComponent(
            ISet<Guid> animationIds,
            Color color,
            AnimationPlayMode animationPlayMode)
        {
            if (!animationIds.Any()) throw new NoAnimationsSpecifiedException();

            _animationIds = animationIds;
            _color = color;
            _animationPlayMode = animationPlayMode;
        }

        public void Draw(DrawContext context, IGameObject obj)
        {
            if (_activeAnimation is null)
                throw new NoActiveAnimationException();

            _lastFrameChangeTimeSpan += context.GameTime.ElapsedGameTime;

            UpdateFrameIndex();
            UpdateFrame(obj);
        }

        public void PlayAnimation(Guid animationId, AnimationPlayMode animationPlayMode, int startFrame = 0)
        {
            if (!_animationIds.Contains(animationId))
                throw new AnimationNotKnownException(animationId);

            var animation = _animations.First(x => x.Id == animationId);

            if (startFrame >= animation.FramesCount)
                throw new FrameIndexOutOfRangeException(animationId, startFrame, animation.FramesCount);

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

        public void OnLoad(OnLoadContext context, IGameObject obj)
        {
            _spriteBatch = new SpriteBatch(context.GraphicsDevice);

            var animations = new List<IAnimation>();

            foreach (var id in _animationIds)
            {
                var animation = context.ContentRepository.GetContent(id).As<IAnimation>();
                animations.Add(animation);
            }

            _animations = animations;
            _activeAnimation = animations.First();
        }
    }
}
