namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public class PrimitiveRestartState : EnableState
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="indexElementType"></param>
        public PrimitiveRestartState(IndexBufferElementType indexElementType)
            : base(OpenGL.GL_PRIMITIVE_RESTART, true)
        {
            switch (indexElementType)
            {
                case IndexBufferElementType.UByte:
                    this.RestartIndex = byte.MaxValue;
                    break;

                case IndexBufferElementType.UShort:
                    this.RestartIndex = ushort.MaxValue;
                    break;

                case IndexBufferElementType.UInt:
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
        protected override void StateOn()
        {
            base.StateOn();

            if (this.enableCapacityWhenStateOn)
            {
                if (glPrimitiveRestartIndex == null)
                { glPrimitiveRestartIndex = OpenGL.GetDelegateFor<OpenGL.glPrimitiveRestartIndex>(); }

                glPrimitiveRestartIndex(RestartIndex);
            }
        }

        /// <summary>
        ///
        /// </summary>
        public uint RestartIndex { get; private set; }
    }
}