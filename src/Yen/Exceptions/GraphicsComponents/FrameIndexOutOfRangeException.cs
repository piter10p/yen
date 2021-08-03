namespace Yen.Exceptions.GraphicsComponents
{
    public sealed class FrameIndexOutOfRangeException : YenException
    {
        public FrameIndexOutOfRangeException(string animationName, int frameIndex, int framesCount)
            : base($"Frame index '{frameIndex}' is out of '{animationName}' animation range: '{framesCount}'.")
        {
        }
    }
}
