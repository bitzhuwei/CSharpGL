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
    //TODO: post a blog about two ways of using CameraManipulater.
    /// <summary>
    /// Manipulate camera or model.
    /// </summary>
    public abstract class Manipulater
    {
        /// <summary>
        /// start to manipulate specified <paramref name="camera"/>.
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="canvas"></param>
        public abstract void Bind(ICamera camera, GLCanvas canvas);

        /// <summary>
        /// stop to manipulate specified <paramref name="camera"/>.
        /// </summary>
        public abstract void Unbind();

    }
}
