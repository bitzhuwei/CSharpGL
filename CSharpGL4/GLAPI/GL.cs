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
    public partial class GL
    {
        protected GL() { }
        private static readonly GL _instance = new GL();

        public static GL Instance
        {
            get
            {
                return _instance.GetInstance();
            }
        }

        protected virtual GL GetInstance() { return _instance; }
    }
}
