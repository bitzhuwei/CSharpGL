using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class PrimitiveRestartSwitch : EnableSwitch
    {

        public PrimitiveRestartSwitch(OneIndexBufferPtr indexBufferPtr)
            : base(OpenGL.GL_PRIMITIVE_RESTART, true)
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

        protected override void SwitchOn()
        {
            base.SwitchOn();

            if (this.EnableCap)
            {
                OpenGL.GetDelegateFor<OpenGL.glPrimitiveRestartIndex>()(RestartIndex);
            }
        }

        public uint RestartIndex { get; set; }
    }

}
