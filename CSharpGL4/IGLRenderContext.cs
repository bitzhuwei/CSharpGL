using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Window-system-specific functions create and delete graphics contexts.
    /// </summary>
    public interface IGLRenderContext : IDisposable
    {
        /// <summary>
        /// render context.
        /// </summary>
        IntPtr RenderContextHandle { get; }

        /// <summary>
        /// device context.
        /// </summary>
        IntPtr DeviceContextHandle { get; }

        /// <summary>
        /// 
        /// </summary>
        void MakeCurrent();

    }
}
