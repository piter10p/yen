using System;
using System.Collections.Generic;
using Yen.Exceptions.Content;

namespace Yen.Extensions
{
    public static class DictionaryExtensions
    {
        public static void CheckIsContentRegistered<TValue>(this IDictionary<Guid, TValue> dictionary, Guid id)
        {
            if (!dictionary.ContainsKey(id))
                throw new ContentsNotRegisteredException(new[] { id });
        }

        public static void CheckIsContentRegistered<TValue>(this IDictionary<Guid, TValue> dictionary, ISet<Guid> ids)
        {
            if (!dictionary.ContainsAllKeys(ids))
                throw new ContentsNotRegisteredException(ids);
        }

        public static bool ContainsAllKeys<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, ISet<TKey> keys)
        {
            foreach (var k in keys)
            {
                if (!dictionary.ContainsKey(k))
                    return false;
            }

            return true;
        }
    }
}
