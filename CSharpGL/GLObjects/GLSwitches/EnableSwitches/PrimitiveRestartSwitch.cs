namespace CSharpGL {
    /// <summary>
    ///
    /// </summary>
    public unsafe class PrimitiveRestartSwitch : EnableSwitch {
        // Activator needs a non-parameter constructor.
        /// <summary>
        /// 
        /// </summary>
        public PrimitiveRestartSwitch()
            : base(GL.GL_PRIMITIVE_RESTART, false) {
            this.RestartIndex = uint.MaxValue;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="indexElementType"></param>
        /// <param name="enableCapacity"></param>
        public PrimitiveRestartSwitch(IndexBuffer.ElementType indexElementType, bool enableCapacity = true)
            : base(GL.GL_PRIMITIVE_RESTART, enableCapacity) {
            switch (indexElementType) {
            case IndexBuffer.ElementType.UByte:
            this.RestartIndex = byte.MaxValue;
            break;

            case IndexBuffer.ElementType.UShort:
            this.RestartIndex = ushort.MaxValue;
            break;

            case IndexBuffer.ElementType.UInt:
            this.RestartIndex = uint.MaxValue;
            break;

            default:
            throw new NotSupportedException(indexElementType.ToString());
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return string.Format("Restart Index: {0}", RestartIndex);
        }

        //private static GLDelegates.void_uint glPrimitiveRestartIndex;

        /// <summary>
        ///
        /// </summary>
        protected override void StateOn() {
            base.StateOn();

            if (this.enableCapacityWhenStateOn) {
                //if (glPrimitiveRestartIndex == null) { glPrimitiveRestartIndex = gl.glGetDelegateFor("glPrimitiveRestartIndex", GLDelegates.typeof_void_uint) as GLDelegates.void_uint; }

                var gl = GL.current; if (gl == null) { return; }
                gl.glPrimitiveRestartIndex(RestartIndex);
            }
        }

        /// <summary>
        ///
        /// </summary>
        public uint RestartIndex { get; private set; }
    }
}