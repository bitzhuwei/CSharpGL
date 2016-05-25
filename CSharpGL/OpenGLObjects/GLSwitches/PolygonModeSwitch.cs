using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class PolygonModeSwitch : GLSwitch
    {

        private PolygonModes originalFrontMode;
        private PolygonModes originalBackMode;
        private PolygonModeFaces lastFace;

        public PolygonModeSwitch() : this(PolygonModeFaces.FrontAndBack, PolygonModes.Filled) { }

        public PolygonModeSwitch(PolygonModes mode) : this(PolygonModeFaces.FrontAndBack, mode) { }

        public PolygonModeSwitch(PolygonModeFaces faces, PolygonModes mode)
        {
            var originalPolygonMode = new int[2];
            GL.GetInteger(GetTarget.PolygonMode, originalPolygonMode);

            this.Init(faces, mode, (PolygonModes)originalPolygonMode[0], (PolygonModes)originalPolygonMode[1]);
        }

        public PolygonModeSwitch(PolygonModeFaces faces, PolygonModes mode,
          PolygonModes originalFrontMode, PolygonModes originalBackMode)
        {
            this.Init(faces, mode, originalFrontMode, originalBackMode);
        }

        private void Init(PolygonModeFaces faces, PolygonModes mode,
            PolygonModes originalFrontMode, PolygonModes originalBackMode)
        {
            this.Faces = faces; this.Mode = mode;
            this.originalFrontMode = originalFrontMode;
            this.originalBackMode = originalBackMode;
        }

        public override string ToString()
        {
            return string.Format("Polygon Mode: {0}", Mode);
        }

        protected override void SwitchOn()
        {
            this.lastFace = this.Faces;
            GL.PolygonMode(this.lastFace, Mode);
        }

        protected override void SwitchOff()
        {
            switch (this.lastFace)
            {
                case PolygonModeFaces.Front:
                    GL.PolygonMode(PolygonModeFaces.Front, this.originalFrontMode);
                    break;
                case PolygonModeFaces.Back:
                    GL.PolygonMode(PolygonModeFaces.Back, this.originalBackMode);
                    break;
                case PolygonModeFaces.FrontAndBack:
                    if (this.originalFrontMode == this.originalBackMode)
                    {
                        GL.PolygonMode(PolygonModeFaces.FrontAndBack, this.originalFrontMode);
                    }
                    else
                    {
                        GL.PolygonMode(PolygonModeFaces.Front, this.originalFrontMode);
                        GL.PolygonMode(PolygonModeFaces.Back, this.originalBackMode);
                    }
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public PolygonModeFaces Faces { get; set; }
        public PolygonModes Mode { get; set; }
    }

}
