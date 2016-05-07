using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class PrimitiveRestartSwitch : GLSwitch
    {

        public PrimitiveRestartSwitch(OneIndexBufferPtr indexBufferPtr)
        {
            if (indexBufferPtr == null)
            { throw new ArgumentException(); }

            switch (indexBufferPtr.Type)
            {
                case IndexElementType.UnsignedByte:
                    this.RestartIndex = byte.MaxValue;
                    break;
                case IndexElementType.UnsignedShort:
                    this.RestartIndex = ushort.MaxValue;
                    break;
                case IndexElementType.UnsignedInt:
                    this.RestartIndex = uint.MaxValue;
                    break;
                default:
                    break;
            }
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
