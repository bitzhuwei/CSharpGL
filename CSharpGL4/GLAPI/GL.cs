using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private static GL _instance;
        /// <summary>
        /// 
        /// </summary>
        public static GL Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new Exception("GL instance not initialized! Please call GL.Init(GL gl); before anything else!");
                }

                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        public static void Register(GL instance)
        {
            GL.Instance = instance;
        }

        /// <summary>
        /// Gets current render context.
        /// </summary>
        /// <returns></returns>
        public abstract IntPtr GetCurrentContext();
    }
}
