using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// OpenGL is a specification of 3D graphics library.
    /// <para>
    /// <see cref="GL"/> represents functions suppproted in OpenGL32.dll/openGL32.so/... and all extended functions.
    /// </para>
    /// </summary>
    public abstract partial class GL
    {
        /// <summary>
        /// The only insstance of the OpenGL implementation on current operation system.
        /// </summary>
        public static GL Instance { get; private set; }

        /// <summary>
        /// OpenGL is a specification of 3D graphics library.
        /// <para>
        /// <see cref="GL"/> represents functions suppproted in OpenGL32.dll/openGL32.so/... and all extended functions.
        /// </para>
        /// </summary>
        protected GL()
        {
            if (GL.Instance != null)
            {
                if (GL.Instance.GetType().FullName != this.GetType().FullName)
                {
                    throw new Exception(string.Format("GL instance({0}) already exists! Call it using static property \'GL.Instance\'", GL.Instance));
                }
            }
            else
            {
                GL.Instance = this;
            }
        }

        /// <summary>
        /// Gets current render context.
        /// </summary>
        /// <returns></returns>
        public abstract IntPtr GetCurrentContext();
    }
}
