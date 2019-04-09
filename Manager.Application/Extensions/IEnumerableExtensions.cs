using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manager.Application.Extensions
{
    public static class IEnumerableExtensions
    {
        public static bool HasAny<T>(this IEnumerable<T> list) where T : class
        {
            return list != null && list.Any();
        }
    }
}
