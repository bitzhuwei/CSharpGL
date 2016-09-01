using System;

namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public class PrimitiveRestartSwitch : EnableSwitch
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="indexBufferPtr"></param>
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

                case IndexElementType.UnsighedShort:
                    this.RestartIndex = ushort.MaxValue;
                    break;

                case IndexElementType.UnsignedInt:
                    this.RestartIndex = uint.MaxValue;
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Restart Index: {0}", RestartIndex);
        }

        private static OpenGL.glPrimitiveRestartIndex glPrimitiveRestartIndex;

        /// <summary>
        ///
        /// </summary>
        protected override void SwitchOn()
        {
            base.SwitchOn();

            if (this.enableCapacityWhenSwitchOn)
            {
                if (glPrimitiveRestartIndex == null)
                { glPrimitiveRestartIndex = OpenGL.GetDelegateFor<OpenGL.glPrimitiveRestartIndex>(); }

                glPrimitiveRestartIndex(RestartIndex);
            }
        }

        /// <summary>
        ///
        /// </summary>
        public uint RestartIndex { get; set; }
    }
}