using System.ComponentModel;

namespace CSharpGL
{
    /// <summary>
    /// specify pixel arithmetic.
    /// </summary>
    public class BlendSwitch : EnableSwitch
    {
        /// <summary>
        /// specify pixel arithmetic.
        /// </summary>
        public BlendSwitch() : this(BlendingSourceFactor.One, BlendingDestinationFactor.Zero) { }

        /// <summary>
        /// specify pixel arithmetic.
        /// </summary>
        /// <param name="sourceFactor">Specifies how the red, green, blue, and alpha source blending factors are computedThe initial value is GL_ONE.</param>
        /// <param name="destFactor">Specifies how the red, green, blue, and alpha destination blending factors are computed. The initial value is GL_ZERO.</param>
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
        /// Specifies how the red, green, blue, and alpha source blending factors are computed. The initial value is GL_ONE.
        /// </summary>
        [Description("Specifies how the red, green, blue, and alpha source blending factors are computed. The initial value is GL_ONE.")]
        public BlendingSourceFactor SourceFactor { get; set; }

        /// <summary>
        /// Specifies how the red, green, blue, and alpha destination blending factors are computed. The initial value is GL_ZERO.
        /// </summary>
        [Description("Specifies how the red, green, blue, and alpha destination blending factors are computed. The initial value is GL_ZERO.")]
        public BlendingDestinationFactor DestFactor { get; set; }
    }
}