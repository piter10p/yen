using System;
using System.Collections.Generic;

namespace Yen.Exceptions.Content
{
    public class ContentsNotRegisteredException : YenException
    {
        public ContentsNotRegisteredException(IEnumerable<Guid> ids) : base($"Contents not registered. Ids: '{string.Join(",", ids)}'.")
        {
        }
    }
}
