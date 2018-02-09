using System.ComponentModel;

namespace CSharpGL
{
    /// <summary>
    /// specify pixel arithmetic.
    /// </summary>
    public class BlendFuncSwitch : EnableSwitch
    {
        // Activator needs a non-parameter constructor.
        /// <summary>
        /// specify pixel arithmetic.
        /// </summary>
        public BlendFuncSwitch() : this(BlendSrcFactor.One, BlendDestFactor.Zero) { }

        /// <summary>
        /// specify pixel arithmetic.
        /// </summary>
        /// <param name="sourceFactor">Specifies how the red, green, blue, and alpha source blending factors are computedThe initial value is GL_ONE.</param>
        /// <param name="destFactor">Specifies how the red, green, blue, and alpha destination blending factors are computed. The initial value is GL_ZERO.</param>
        /// <param name="enableCapacity"></param>
        public BlendFuncSwitch(BlendSrcFactor sourceFactor, BlendDestFactor destFactor, bool enableCapacity = true)
            : base(GL.GL_BLEND, enableCapacity)
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
                return string.Format("glBlendFunc({0}, {1});",
                    this.SourceFactor, this.DestFactor);
            }
            else
            {
                return string.Format("Disabled glBlendFunc({0}, {1});",
                    this.SourceFactor, this.DestFactor);
            }
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOn()
        {
            base.StateOn();

            if (this.enableCapacityWhenStateOn)
            {
                GL.Instance.BlendFunc((uint)this.SourceFactor, (uint)this.DestFactor);
            }
        }

        /// <summary>
        /// Specifies how the red, green, blue, and alpha source blending factors are computed. The initial value is GL_ONE.
        /// </summary>
        [Description("Specifies how the red, green, blue, and alpha source blending factors are computed. The initial value is GL_ONE.")]
        public BlendSrcFactor SourceFactor { get; set; }

        /// <summary>
        /// Specifies how the red, green, blue, and alpha destination blending factors are computed. The initial value is GL_ZERO.
        /// </summary>
        [Description("Specifies how the red, green, blue, and alpha destination blending factors are computed. The initial value is GL_ZERO.")]
        public BlendDestFactor DestFactor { get; set; }

    }
}