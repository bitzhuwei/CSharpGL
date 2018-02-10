using System.ComponentModel;

namespace CSharpGL
{
    /// <summary>
    /// specify pixel arithmetic for RGB and alpha components separately.
    /// </summary>
    public class BlendSwitch : EnableSwitch
    {
        private static readonly GLDelegates.void_uint glBlendEquation;
        private static readonly GLDelegates.void_uint_uint glBlendEquationSeparate;
        private static readonly GLDelegates.void_uint_uint_uint_uint glBlendFuncSeparate;

        static BlendSwitch()
        {
            glBlendEquation = GL.Instance.GetDelegateFor("glBlendEquation", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
            glBlendEquationSeparate = GL.Instance.GetDelegateFor("glBlendEquationSeparate", GLDelegates.typeof_void_uint_uint) as GLDelegates.void_uint_uint;
            glBlendFuncSeparate = GL.Instance.GetDelegateFor("glBlendFuncSeparate", GLDelegates.typeof_void_uint_uint_uint_uint) as GLDelegates.void_uint_uint_uint_uint;
        }

        // Activator needs a non-parameter constructor.
        /// <summary>
        /// specify pixel arithmetic for RGB and alpha components separately.
        /// </summary>
        public BlendSwitch() : this(BlendEquationMode.Add, BlendEquationMode.Add, BlendSrcFactor.One, BlendDestFactor.Zero, BlendSrcFactor.One, BlendDestFactor.Zero) { }


        /// <summary>
        /// specify pixel arithmetic for RGB and alpha components separately.
        /// </summary>
        /// <param name="rgbMode">set the RGB blend equation.</param>
        /// <param name="alphaMode">set the Alpha blend equation.</param>
        /// <param name="srcFactor">Specifies how the red, green, blue and alpha source blending factors are computed. The initial value is GL_ONE.</param>
        /// <param name="destFactor">Specifies how the red, green blue and alpha destination blending factors are computed. The initial value is GL_ZERO.</param>
        /// <param name="enableCapacity"></param>
        public BlendSwitch(BlendEquationMode rgbMode, BlendEquationMode alphaMode, BlendSrcFactor srcFactor, BlendDestFactor destFactor, bool enableCapacity = true)
            : this(rgbMode, alphaMode, srcFactor, destFactor, srcFactor, destFactor, enableCapacity)
        { }

        /// <summary>
        /// specify pixel arithmetic for RGB and alpha components separately.
        /// </summary>
        /// <param name="mode">set the blend equation.</param>
        /// <param name="rgbSrcFactor">Specifies how the red, green and blue source blending factors are computedThe initial value is GL_ONE.</param>
        /// <param name="rgbDestFactor">Specifies how the red, green and blue destination blending factors are computed. The initial value is GL_ZERO.</param>
        /// <param name="alphaSrcFactor">Specifies how the alpha source blending factors are computed. The initial value is GL_ONE.</param>
        /// <param name="alphaDestFactor">Specifies how the alpha destination blending factors are computed. The initial value is GL_ZERO.</param>
        /// <param name="enableCapacity"></param>
        public BlendSwitch(BlendEquationMode mode, BlendSrcFactor rgbSrcFactor, BlendDestFactor rgbDestFactor, BlendSrcFactor alphaSrcFactor, BlendDestFactor alphaDestFactor, bool enableCapacity = true)
            : this(mode, mode, rgbSrcFactor, rgbDestFactor, alphaSrcFactor, alphaDestFactor, enableCapacity)
        { }

        /// <summary>
        /// specify pixel arithmetic for RGB and alpha components separately.
        /// </summary>
        /// <param name="mode">set the blend equation.</param>
        /// <param name="srcFactor">Specifies how the red, green, blue and alpha source blending factors are computed. The initial value is GL_ONE.</param>
        /// <param name="destFactor">Specifies how the red, green blue and alpha destination blending factors are computed. The initial value is GL_ZERO.</param>
        /// <param name="enableCapacity"></param>
        public BlendSwitch(BlendEquationMode mode, BlendSrcFactor srcFactor, BlendDestFactor destFactor, bool enableCapacity = true)
            : this(mode, mode, srcFactor, destFactor, srcFactor, destFactor, enableCapacity)
        { }

        /// <summary>
        /// specify pixel arithmetic for RGB and alpha components separately.
        /// </summary>
        /// <param name="rgbMode">set the RGB blend equation.</param>
        /// <param name="alphaMode">set the Alpha blend equation.</param>
        /// <param name="rgbSrcFactor">Specifies how the red, green and blue source blending factors are computedThe initial value is GL_ONE.</param>
        /// <param name="rgbDestFactor">Specifies how the red, green and blue destination blending factors are computed. The initial value is GL_ZERO.</param>
        /// <param name="alphaSrcFactor">Specifies how the alpha source blending factors are computed. The initial value is GL_ONE.</param>
        /// <param name="alphaDestFactor">Specifies how the alpha destination blending factors are computed. The initial value is GL_ZERO.</param>
        /// <param name="enableCapacity"></param>
        public BlendSwitch(BlendEquationMode rgbMode, BlendEquationMode alphaMode, BlendSrcFactor rgbSrcFactor, BlendDestFactor rgbDestFactor, BlendSrcFactor alphaSrcFactor, BlendDestFactor alphaDestFactor, bool enableCapacity = true)
            : base(GL.GL_BLEND, enableCapacity)
        {
            this.RGBMode = rgbMode;
            this.AlphaMode = alphaMode;
            this.RGBSrcFactor = rgbSrcFactor;
            this.RGBDestFactor = rgbDestFactor;
            this.AlphaSrcFactor = alphaSrcFactor;
            this.AlphaDestFactor = alphaDestFactor;
        }

        /// <summary>
        ///
        /// </summary>
        public override string ToString()
        {
            if (this.EnableCapacity)
            {
                return string.Format("glBlendFuncSeparate({0}, {1}, {2}, {3});",
                    this.RGBSrcFactor, this.RGBDestFactor,
                    this.AlphaSrcFactor, this.AlphaDestFactor);
            }
            else
            {
                return string.Format("Disabled glBlendFuncSeparate({0}, {1}, {2}, {3});",
                    this.RGBSrcFactor, this.RGBDestFactor,
                    this.AlphaSrcFactor, this.AlphaDestFactor);
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
                if (this.rgbMode == this.alphaMode)
                { glBlendEquation(this.rgbMode); }
                else
                { glBlendEquationSeparate(this.rgbMode, this.alphaMode); }

                if (this.rgbSrcFactor == this.alphaSrcFactor && this.rgbDestFactor == this.alphaDestFactor)
                { GL.Instance.BlendFunc(this.rgbSrcFactor, this.rgbDestFactor); }
                else
                { glBlendFuncSeparate(this.rgbSrcFactor, this.rgbDestFactor, this.alphaSrcFactor, this.alphaDestFactor); }
            }
        }

        private uint rgbMode;
        /// <summary>
        /// set the RGB blend equation.
        /// </summary>
        [Description("set the RGBA blend equation.")]
        public BlendEquationMode RGBMode { get { return (BlendEquationMode)this.rgbMode; } set { this.rgbMode = (uint)value; } }

        private uint alphaMode;
        /// <summary>
        /// set the Alpha blend equation.
        /// </summary>
        [Description("set the Alpha blend equation.")]
        public BlendEquationMode AlphaMode { get { return (BlendEquationMode)this.alphaMode; } set { this.alphaMode = (uint)value; } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        public void SetMode(BlendEquationMode mode)
        {
            this.rgbMode = (uint)mode;
            this.alphaMode = (uint)mode;
        }

        private uint rgbSrcFactor;
        /// <summary>
        /// Specifies how the red, green, blue, and alpha source blending factors are computed. The initial value is GL_ONE.
        /// </summary>
        [Description("Specifies how the red, green and blue source blending factors are computed. The initial value is GL_ONE.")]
        public BlendSrcFactor RGBSrcFactor { get { return (BlendSrcFactor)this.rgbSrcFactor; } set { this.rgbSrcFactor = (uint)value; } }

        private uint alphaSrcFactor;
        /// <summary>
        /// Specifies how the red, green, blue, and alpha source blending factors are computed. The initial value is GL_ONE.
        /// </summary>
        [Description("Specifies how the alpha source blending factors are computed. The initial value is GL_ONE.")]
        public BlendSrcFactor AlphaSrcFactor { get { return (BlendSrcFactor)this.alphaSrcFactor; } set { this.alphaSrcFactor = (uint)value; } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="srcFactor"></param>
        public void SetSrcFactor(BlendSrcFactor srcFactor)
        {
            this.rgbSrcFactor = (uint)srcFactor;
            this.alphaSrcFactor = (uint)srcFactor;
        }

        private uint rgbDestFactor;
        /// <summary>
        /// Specifies how the red, green, blue, and alpha destination blending factors are computed. The initial value is GL_ZERO.
        /// </summary>
        [Description("Specifies how the red, green and blue destination blending factors are computed. The initial value is GL_ZERO.")]
        public BlendDestFactor RGBDestFactor { get { return (BlendDestFactor)this.rgbDestFactor; } set { this.rgbDestFactor = (uint)value; } }

        private uint alphaDestFactor;
        /// <summary>
        /// Specifies how the red, green, blue, and alpha destination blending factors are computed. The initial value is GL_ZERO.
        /// </summary>
        [Description("Specifies how the alpha destination blending factors are computed. The initial value is GL_ZERO.")]
        public BlendDestFactor AlphaDestFactor { get { return (BlendDestFactor)this.alphaDestFactor; } set { this.alphaDestFactor = (uint)value; } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="destFactor"></param>
        public void SetDestFactor(BlendDestFactor destFactor)
        {
            this.rgbDestFactor = (uint)destFactor;
            this.alphaDestFactor = (uint)destFactor;
        }

    }
}