using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// Cached delegates' types.
    /// </summary>
    public static class GLDelegates
    {
        public delegate void void_uint(uint a);
        public static readonly Type typeof_void_uint = typeof(void_uint);

        public delegate void void_void();
        public static readonly Type typeof_void_void = typeof(void_void);
    }
}
