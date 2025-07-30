using System;

namespace bitzhuwei.Compiler {
    /// <summary>
    /// used in <see cref="ElseIf"/> and <see cref="ElseIf2"/>
    /// </summary>
    [Flags]
    public enum Acts : byte {
        /// <summary>
        /// no act
        /// </summary>
        None = 0,
        /// <summary>
        /// Begin(context);
        /// </summary>
        Begin = 1,
        /// <summary>
        /// Extend(context, int Vt);
        /// </summary>
        Extend = 2,
        /// <summary>
        /// Accept(context, int Vt);
        /// </summary>
        Accept = 4,
        /// <summary>
        /// Extend(context, int[] Vts);
        /// </summary>
        Extend2 = 8,
        /// <summary>
        /// Accept(context,int[] Vts);
        /// </summary>
        Accept2 = 16,
        /// <summary>
        /// Extend(context,IfVt[] ifVts);
        /// </summary>
        Extend3 = 32,
        /// <summary>
        /// Accept(context,IfVt[] ifVts);
        /// </summary>
        Accept3 = 64,
    }
}

