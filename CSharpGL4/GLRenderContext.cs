using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// Window-system-specific functions create and delete graphics contexts.
    /// </summary>
    public abstract partial class GLRenderContext : IDisposable
    {
        /// <summary>
        /// render context.
        /// </summary>
        public abstract IntPtr RenderContextHandle { get; }

        /// <summary>
        /// device context.
        /// </summary>
        public abstract IntPtr DeviceContextHandle { get; }

        /// <summary>
        /// 
        /// </summary>
        public abstract void MakeCurrent();

    }
}
