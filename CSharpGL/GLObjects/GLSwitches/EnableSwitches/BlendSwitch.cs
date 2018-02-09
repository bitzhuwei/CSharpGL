using System.ComponentModel;

namespace CSharpGL
{
    /// <summary>
    /// specify pixel arithmetic for RGB and alpha components separately.
    /// </summary>
    public class BlendSwitch : EnableSwitch
    {
        private static readonly GLDelegates.void_uint_uint glBlendEquationSeparate;
        private static readonly GLDelegates.void_uint_uint_uint_uint glBlendFuncSeparate;

        static BlendSwitch()
        {
            glBlendEquationSeparate = GL.Instance.GetDelegateFor("glBlendEquationSeparate", GLDelegates.typeof_void_uint_uint) as GLDelegates.void_uint_uint;
            glBlendFuncSeparate = GL.Instance.GetDelegateFor("glBlendFuncSeparate", GLDelegates.typeof_void_uint_uint_uint_uint) as GLDelegates.void_uint_uint_uint_uint;
        }

        // Activator needs a non-parameter constructor.
        /// <summary>
        /// specify pixel arithmetic for RGB and alpha components separately.
        /// </summary>
        public BlendSwitch() : this(BlendEquationMode.Add, BlendEquationMode.Add, BlendingSourceFactor.One, BlendingDestinationFactor.Zero, BlendingSourceFactor.One, BlendingDestinationFactor.Zero) { }

        /// <summary>
        /// specify pixel arithmetic for RGB and alpha components separately.
        /// </summary>
        /// <param name="rgbMode">set the RGB blend equation.</param>
        /// <param name="alphaMode">set the Alpha blend equation.</param>
        /// <param name="sourceFactor">Specifies how the red, green and blue source blending factors are computedThe initial value is GL_ONE.</param>
        /// <param name="destFactor">Specifies how the red, green and blue alpha destination blending factors are computed. The initial value is GL_ZERO.</param>
        /// <param name="sourceAlphaFactor">Specifies how the alpha source blending factors are computedThe initial value is GL_ONE.</param>
        /// <param name="destAlphaFactor">Specifies how the alpha destination blending factors are computed. The initial value is GL_ZERO.</param>
        /// <param name="enableCapacity"></param>
        public BlendSwitch(BlendEquationMode rgbMode, BlendEquationMode alphaMode, BlendingSourceFactor sourceFactor, BlendingDestinationFactor destFactor, BlendingSourceFactor sourceAlphaFactor, BlendingDestinationFactor destAlphaFactor, bool enableCapacity = true)
            : base(GL.GL_BLEND, enableCapacity)
        {
            this.RGBMode = rgbMode;
            this.AlphaMode = alphaMode;
            this.SourceFactor = sourceFactor;
            this.DestFactor = destFactor;
            this.SourceAlphaFactor = sourceAlphaFactor;
            this.DestAlphaFactor = destAlphaFactor;
        }

        /// <summary>
        ///
        /// </summary>
        public override string ToString()
        {
            if (this.EnableCapacity)
            {
                return string.Format("glBlendFuncSeparate({0}, {1}, {2}, {3});",
                    this.SourceFactor, this.DestFactor,
                    this.SourceAlphaFactor, this.DestAlphaFactor);
            }
            else
            {
                return string.Format("Disabled glBlendFuncSeparate({0}, {1}, {2}, {3});",
                    this.SourceFactor, this.DestFactor,
                    this.SourceAlphaFactor, this.DestAlphaFactor);
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
                glBlendEquationSeparate((uint)this.RGBMode, (uint)this.AlphaMode);
                glBlendFuncSeparate((uint)this.SourceFactor, (uint)this.DestFactor, (uint)this.SourceAlphaFactor, (uint)this.DestAlphaFactor);
            }
        }

        /// <summary>
        /// set the RGB blend equation.
        /// </summary>
        [Description("set the RGBA blend equation.")]
        public BlendEquationMode RGBMode { get; set; }

        /// <summary>
        /// set the Alpha blend equation.
        /// </summary>
        [Description("set the Alpha blend equation.")]
        public BlendEquationMode AlphaMode { get; set; }

        /// <summary>
        /// Specifies how the red, green, blue, and alpha source blending factors are computed. The initial value is GL_ONE.
        /// </summary>
        [Description("Specifies how the red, green and blue source blending factors are computed. The initial value is GL_ONE.")]
        public BlendingSourceFactor SourceFactor { get; set; }

        /// <summary>
        /// Specifies how the red, green, blue, and alpha source blending factors are computed. The initial value is GL_ONE.
        /// </summary>
        [Description("Specifies how the alpha source blending factors are computed. The initial value is GL_ONE.")]
        public BlendingSourceFactor SourceAlphaFactor { get; set; }

        /// <summary>
        /// Specifies how the red, green, blue, and alpha destination blending factors are computed. The initial value is GL_ZERO.
        /// </summary>
        [Description("Specifies how the red, green and blue destination blending factors are computed. The initial value is GL_ZERO.")]
        public BlendingDestinationFactor DestFactor { get; set; }

        /// <summary>
        /// Specifies how the red, green, blue, and alpha destination blending factors are computed. The initial value is GL_ZERO.
        /// </summary>
        [Description("Specifies how the alpha destination blending factors are computed. The initial value is GL_ZERO.")]
        public BlendingDestinationFactor DestAlphaFactor { get; set; }

    }
}