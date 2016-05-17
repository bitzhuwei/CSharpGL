using System;

namespace System.Numerics
{
    internal static class HashCodeHelper
    {
        internal static int CombineHashCodes(int h1, int h2)
        {
            return (h1 << 5) + h1 ^ h2;
        }
    }
}
