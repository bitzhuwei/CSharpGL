namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public class PrimitiveRestartSwitch : EnableSwitch
    {
        // Activator needs a non-parameter constructor.
        /// <summary>
        /// 
        /// </summary>
        public PrimitiveRestartSwitch()
            : base(GL.GL_PRIMITIVE_RESTART, false)
        {
            this.RestartIndex = uint.MaxValue;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="indexElementType"></param>
        /// <param name="enableCapacity"></param>
        public PrimitiveRestartSwitch(IndexBufferElementType indexElementType, bool enableCapacity = true)
            : base(GL.GL_PRIMITIVE_RESTART, enableCapacity)
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
                    throw new NotDealWithNewEnumItemException(typeof(IndexBufferElementType));
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

        private static GLDelegates.void_uint glPrimitiveRestartIndex;

        /// <summary>
        ///
        /// </summary>
        protected override void StateOn()
        {
            base.StateOn();

            if (this.enableCapacityWhenStateOn)
            {
                if (glPrimitiveRestartIndex == null)
                { glPrimitiveRestartIndex = GL.Instance.GetDelegateFor("glPrimitiveRestartIndex", GLDelegates.typeof_void_uint) as GLDelegates.void_uint; }

                glPrimitiveRestartIndex(RestartIndex);
            }
        }

        /// <summary>
        ///
        /// </summary>
        public uint RestartIndex { get; private set; }
    }
}