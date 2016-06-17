using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL
{
    /// <summary>
    /// 用鼠标旋转模型。
    /// </summary>
    public abstract class CameraManipulater
    {

        private ICamera camera;

        public abstract void Bind(ICamera camera, Control canvas);

        public abstract void Unbind();

    }
}
