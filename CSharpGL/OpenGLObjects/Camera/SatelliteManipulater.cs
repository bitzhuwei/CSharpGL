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
    /// Rotates a camera on a sphere, whose center is camera's Target.
    /// <para>Just like a satellite moves around a fixed star.</para>
    /// </summary>
    public class SatelliteManipulater : CameraManipulater
    {

        public override void Bind(ICamera camera, Control canvas)
        {
            throw new NotImplementedException();
        }

        public override void Unbind()
        {
            throw new NotImplementedException();
        }
    }
}
