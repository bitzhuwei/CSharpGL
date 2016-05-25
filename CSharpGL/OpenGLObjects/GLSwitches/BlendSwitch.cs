using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class BlendSwitch : EnableSwitch
    {

        public BlendSwitch() : this(BlendingSourceFactor.SourceAlpha, BlendingDestinationFactor.OneMinusSourceAlpha) { }

        public BlendSwitch(BlendingSourceFactor sourceFactor, BlendingDestinationFactor destFactor)
            : base(OpenGL.GL_BLEND, true)
        {
            this.SourceFactor = sourceFactor;
            this.DestFactor = destFactor;
        }

        public override string ToString()
        {
            if (this.EnableCap)
            {
                return string.Format("Blend: {0} {1}",
                    this.SourceFactor, this.DestFactor);
            }
            else
            {
                return string.Format("Disabled Blend: {0} {1}",
                    this.SourceFactor, this.DestFactor);
            }
        }

        protected override void SwitchOn()
        {
            base.SwitchOn();

            if (this.EnableCap)
            {
                OpenGL.BlendFunc(this.SourceFactor, this.DestFactor);
            }
        }

        public BlendingSourceFactor SourceFactor { get; set; }
        public BlendingDestinationFactor DestFactor { get; set; }
    }

}
