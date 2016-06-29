using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace CSharpGL
{
    /// <summary>
    /// Manipulate camera.
    /// </summary>
    public abstract class CameraManipulater
    {
        /// <summary>
        /// start to manipulate specified <paramref name="camera"/>.
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="canvas"></param>
        public abstract void Bind(ICamera camera, Control canvas);

        /// <summary>
        /// stop to manipulate specified <paramref name="camera"/>.
        /// </summary>
        public abstract void Unbind();

    }
}
