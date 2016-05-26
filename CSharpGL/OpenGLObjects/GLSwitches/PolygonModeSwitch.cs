using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class PolygonModeSwitch : GLSwitch
    {

        int[] originalPolygonMode = new int[2];

        public PolygonModeSwitch() : this(PolygonModes.Filled) { }

        public PolygonModeSwitch(PolygonModes mode)
        {
            this.Mode = mode;
        }

        public override string ToString()
        {
            return string.Format("Polygon Mode: {0}", Mode);
        }

        protected override void SwitchOn()
        {
            OpenGL.GetInteger(GetTarget.PolygonMode, originalPolygonMode);

            OpenGL.PolygonMode(PolygonModeFaces.FrontAndBack, Mode);

        }

        protected override void SwitchOff()
        {
            if (originalPolygonMode[0] == originalPolygonMode[1])
            {
                OpenGL.PolygonMode(PolygonModeFaces.FrontAndBack, (PolygonModes)(originalPolygonMode[0]));
            }
            else
            {
                //TODO: not tested yet
                OpenGL.PolygonMode(PolygonModeFaces.Front, (PolygonModes)originalPolygonMode[0]);
                OpenGL.PolygonMode(PolygonModeFaces.Back, (PolygonModes)originalPolygonMode[1]);

            }
        }

        public PolygonModes Mode { get; set; }
    }

}
