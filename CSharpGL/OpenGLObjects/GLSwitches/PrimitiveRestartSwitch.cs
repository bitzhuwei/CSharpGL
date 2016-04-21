using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class PrimitiveRestartSwitch : GLSwitch
    {

        public PrimitiveRestartSwitch() : this(uint.MaxValue) { }

        public PrimitiveRestartSwitch(uint restartIndex)
        {
            this.RestartIndex = restartIndex;
        }

        public override string ToString()
        {
            return string.Format("Restart Index: {0}", RestartIndex);
        }

        public override void On()
        {
            GL.Enable(GL.GL_PRIMITIVE_RESTART);
            GL.GetDelegateFor<GL.glPrimitiveRestartIndex>()(RestartIndex);
        }

        public override void Off()
        {
            GL.Disable(GL.GL_PRIMITIVE_RESTART);
        }

        public uint RestartIndex { get; set; }
    }

}
