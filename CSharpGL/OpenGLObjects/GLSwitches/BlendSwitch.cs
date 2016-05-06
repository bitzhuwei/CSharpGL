using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class BlendSwitch : GLSwitch
    {

        byte originalEnabled;

        public BlendSwitch() : this(BlendingSourceFactor.SourceAlpha, BlendingDestinationFactor.OneMinusSourceAlpha) { }

        public BlendSwitch(BlendingSourceFactor sourceFactor, BlendingDestinationFactor destFactor)
        {
            this.SourceFactor = sourceFactor;
            this.DestFactor = destFactor;
        }

        public override string ToString()
        {
            return string.Format("Blend: {0} {1}",
                this.SourceFactor, this.DestFactor);
        }

        public override void On()
        {
            this.originalEnabled = GL.IsEnabled(GL.GL_BLEND);

            if (this.originalEnabled == 0)
            { GL.Enable(GL.GL_BLEND); }

            GL.BlendFunc(this.SourceFactor, this.DestFactor);
        }

        public override void Off()
        {
            if (this.originalEnabled == 0)
            { GL.Disable(GL.GL_BLEND); }
        }

        public BlendingSourceFactor SourceFactor { get; set; }
        public BlendingDestinationFactor DestFactor { get; set; }
    }

}
