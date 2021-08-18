using System;

namespace Yen.Exceptions.GraphicsComponents
{
    public sealed class FrameIndexOutOfRangeException : YenException
    {
        public FrameIndexOutOfRangeException(Guid animationName, int frameIndex, int framesCount)
            : base($"Frame index '{frameIndex}' is out of '{animationName}' animation range: '{framesCount}'.")
        {
        }
    }
}
