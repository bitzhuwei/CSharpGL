using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class PolygonModeSwitch : GLSwitch
    {

        int[] originalPolygonMode = new int[1];

        public PolygonModeSwitch() : this(PolygonModes.Filled) { }

        public PolygonModeSwitch(PolygonModes mode)
        {
            this.Mode = mode;
        }

        public override string ToString()
        {
            return string.Format("Polygon Mode: {0}", Mode);
        }

        public override void On()
        {
            GL.GetInteger(GetTarget.PolygonMode, originalPolygonMode);

            GL.PolygonMode(PolygonModeFaces.FrontAndBack, Mode);
        }

        public override void Off()
        {
            GL.PolygonMode(PolygonModeFaces.FrontAndBack, (PolygonModes)(originalPolygonMode[0]));
        }

        public PolygonModes Mode { get; set; }
    }

}
