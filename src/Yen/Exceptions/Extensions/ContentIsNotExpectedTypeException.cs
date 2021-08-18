using System;

namespace Yen.Exceptions.Extensions
{
    public class ContentIsNotExpectedTypeException : YenException
    {
        public ContentIsNotExpectedTypeException(Type expectedType, Type actualType)
            : base($"Content type ('{actualType.Name}') is not expected: '{expectedType.Name}'.")
        {
            ExpectedType = expectedType;
            ActualType = actualType;
        }

        public Type ExpectedType { get; }
        public Type ActualType { get; }
    }
}
