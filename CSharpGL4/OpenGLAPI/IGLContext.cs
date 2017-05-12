using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public interface IGLContext : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        IntPtr RenderContext { get; }

        /// <summary>
        /// 
        /// </summary>
        IntPtr DeviceContext { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="glMethod"></param>
        /// <returns></returns>
        Delegate GetDelegateFor(Delegate glMethod);
    }
}
