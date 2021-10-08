using System;
using System.Collections.Generic;
using System.Linq;

namespace Yen.UnitTests.Mocks
{
    public class MethodCounter
    {
        private List<DateTime> _calls = new List<DateTime>();

        public void Call()
        {
            _calls.Add(DateTime.UtcNow);
        }

        public int CallsCount => _calls.Count;
        public DateTime? LastCallDateTimeUtc => _calls.LastOrDefault();
    }
}
