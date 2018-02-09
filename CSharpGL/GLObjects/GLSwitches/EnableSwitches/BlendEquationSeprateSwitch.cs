using System.ComponentModel;

namespace CSharpGL
{
    /// <summary>
    /// set the RGBA blend equation.
    /// </summary>
    public class BlendEquationSeprateSwitch : EnableSwitch
    {
        private static readonly GLDelegates.void_uint_uint glBlendEquationSeparate;
        static BlendEquationSeprateSwitch()
        {
            glBlendEquationSeparate = GL.Instance.GetDelegateFor("glBlendEquationSeparate", GLDelegates.typeof_void_uint_uint) as GLDelegates.void_uint_uint;
        }

        // Activator needs a non-parameter constructor.
        /// <summary>
        /// set the RGBA blend equation.
        /// </summary>
        public BlendEquationSeprateSwitch() : this(BlendEquationMode.Add, BlendEquationMode.Add) { }

        /// <summary>
        /// set the RGBA blend equation.
        /// </summary>
        /// <param name="rgbMode">set the RGB blend equation.</param>
        /// <param name="alphaMode">set the Alpha blend equation.</param>
        /// <param name="enableCapacity"></param>
        public BlendEquationSeprateSwitch(BlendEquationMode rgbMode, BlendEquationMode alphaMode, bool enableCapacity = true)
            : base(GL.GL_BLEND, enableCapacity)
        {
            this.RGBMode = rgbMode;
            this.AlphaMode = alphaMode;
        }

        /// <summary>
        ///
        /// </summary>
        public override string ToString()
        {
            if (this.EnableCapacity)
            {
                return string.Format("glBlendEquationSeparate((uint){0}, (uint){1});", this.RGBMode, this.AlphaMode);
            }
            else
            {
                return string.Format("Disabled glBlendEquationSeparate((uint){0}, (uint){1});", this.RGBMode, this.AlphaMode);
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

    }
}