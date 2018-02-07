using System.ComponentModel;

namespace CSharpGL
{
    /// <summary>
    /// set the RGBA blend equation.
    /// </summary>
    public class BlendEquationSwitch : EnableSwitch
    {
		private static readonly GLDelegates.void_uint glBlendEquation;
        static BlendEquationSwitch()
        {
            glBlendEquation = GL.Instance.GetDelegateFor("glBlendEquation", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
        }

        // Activator needs a non-parameter constructor.
        /// <summary>
        /// set the RGBA blend equation.
        /// </summary>
        public BlendEquationSwitch() : this(BlendEquationMode.Add) { }

        /// <summary>
        /// set the RGBA blend equation.
        /// </summary>
        /// <param name="mode">set the RGBA blend equation.</param>
        /// <param name="enableCapacity"></param>
        public BlendEquationSwitch(BlendEquationMode mode, bool enableCapacity = true)
            : base(GL.GL_BLEND, enableCapacity)
        {
            this.Mode = mode;
        }

        /// <summary>
        ///
        /// </summary>
        public override string ToString()
        {
            if (this.EnableCapacity)
            {
                return string.Format("glBlendEquation((uint){0});", this.Mode);
            }
            else
            {
                return string.Format("Disabled glBlendEquation((uint){0});", this.Mode);
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
                glBlendEquation((uint)this.Mode);
			}
        }

        /// <summary>
        /// set the RGBA blend equation.
        /// </summary>
        [Description("set the RGBA blend equation.")]
        public BlendEquationMode Mode { get; set; }

    }
}