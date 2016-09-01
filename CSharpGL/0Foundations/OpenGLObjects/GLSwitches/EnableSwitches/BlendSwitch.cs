namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public class BlendSwitch : EnableSwitch
    {
        /// <summary>
        ///
        /// </summary>
        public BlendSwitch() : this(BlendingSourceFactor.One, BlendingDestinationFactor.DestinationAlpha) { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sourceFactor"></param>
        /// <param name="destFactor"></param>
        public BlendSwitch(BlendingSourceFactor sourceFactor, BlendingDestinationFactor destFactor)
            : base(OpenGL.GL_BLEND, true)
        {
            this.SourceFactor = sourceFactor;
            this.DestFactor = destFactor;
        }

        /// <summary>
        ///
        /// </summary>
        public override string ToString()
        {
            if (this.EnableCapacity)
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

        /// <summary>
        ///
        /// </summary>
        protected override void SwitchOn()
        {
            base.SwitchOn();

            if (this.enableCapacityWhenSwitchOn)
            {
                OpenGL.BlendFunc(this.SourceFactor, this.DestFactor);
            }
        }

        /// <summary>
        ///
        /// </summary>
        public BlendingSourceFactor SourceFactor { get; set; }

        /// <summary>
        ///
        /// </summary>
        public BlendingDestinationFactor DestFactor { get; set; }
    }
}