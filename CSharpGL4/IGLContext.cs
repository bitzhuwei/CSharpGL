using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// OpenGL context.
    /// </summary>
    public interface IGLContext : IDisposable
    {
        /// <summary>
        /// render context.
        /// </summary>
        IntPtr RenderContext { get; }

        /// <summary>
        /// device context.
        /// </summary>
        IntPtr DeviceContext { get; }

        /// <summary>
        /// Gets extended OpenGL method.
        /// </summary>
        /// <param name="functionName"></param>
        /// <param name="delegateType"></param>
        /// <returns></returns>
        Delegate GetDelegateFor(string functionName, Type delegateType);
    }
}
