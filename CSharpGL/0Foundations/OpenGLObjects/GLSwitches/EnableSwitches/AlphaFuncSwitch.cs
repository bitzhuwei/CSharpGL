using System.ComponentModel;

namespace CSharpGL
{
    /// <summary>
    /// specify the alpha test function.
    /// </summary>
    public class AlphaFuncSwitch : EnableSwitch
    {
        /// <summary>
        /// specify the alpha test function.
        /// </summary>
        public AlphaFuncSwitch()
            : this(AlphaTestFunction.Always, 0)// this is default values in OpenGL.
        { }

        /// <summary>
        /// specify the alpha test function.
        /// </summary>
        /// <param name="alphaTestFunc"></param>
        /// <param name="alphaTestReferenceValue"></param>
        public AlphaFuncSwitch(AlphaTestFunction alphaTestFunc, float alphaTestReferenceValue)
            : base(OpenGL.GL_ALPHA_TEST, true)
        {
            this.AlphaTestFunc = alphaTestFunc;
            this.AlphaTestReferenceValue = alphaTestReferenceValue;
        }

        /// <summary>
        ///
        /// </summary>
        public override string ToString()
        {
            if (this.EnableCapacity)
            {
                return string.Format("glAlphaFunc({0} {1});",
                    this.AlphaTestFunc, this.AlphaTestReferenceValue);
            }
            else
            {
                return string.Format("Disabled glAlphaFunc({0} {1});",
                    this.AlphaTestFunc, this.AlphaTestReferenceValue);
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
                OpenGL.AlphaFunc((uint)this.AlphaTestFunc, this.AlphaTestReferenceValue);
            }
        }

        /// <summary>
        /// Specifies the alpha comparison function. The initial value is GL_ALWAYS.
        /// </summary>
        [Description("Specifies the alpha comparison function. The initial value is GL_ALWAYS.")]
        public AlphaTestFunction AlphaTestFunc { get; set; }

        /// <summary>
        /// Specifies the reference value that incoming alpha values are compared to. This value is clamped to the range [0, 1], where 0 represents the lowest possible alpha value and 1 the highest possible value. The initial reference value is 0.
        /// </summary>
        [Description("Specifies the reference value that incoming alpha values are compared to. This value is clamped to the range [0, 1], where 0 represents the lowest possible alpha value and 1 the highest possible value. The initial reference value is 0.")]
        public float AlphaTestReferenceValue { get; set; }
    }

    /// <summary>
    /// The alpha function
    /// </summary>
    public enum AlphaTestFunction : uint
    {
        /// <summary>
        /// Never passes.
        /// </summary>
        Never = OpenGL.GL_NEVER,

        /// <summary>
        /// Passes if the incoming alpha value is less than the reference value.
        /// </summary>
        Less = OpenGL.GL_LESS,

        /// <summary>
        /// Passes if the incoming alpha value is equal to the reference value.
        /// </summary>
        Equal = OpenGL.GL_EQUAL,

        /// <summary>
        /// Passes if the incoming alpha value is less than or equal to the reference value.
        /// </summary>
        LessThanOrEqual = OpenGL.GL_LEQUAL,

        /// <summary>
        /// Passes if the incoming alpha value is greater than the reference value.
        /// </summary>
        Great = OpenGL.GL_GREATER,

        /// <summary>
        /// Passes if the incoming alpha value is not equal to the reference value.
        /// </summary>
        NotEqual = OpenGL.GL_NOTEQUAL,

        /// <summary>
        /// Passes if the incoming alpha value is greater than or equal to the reference value.
        /// </summary>
        GreaterThanOrEqual = OpenGL.GL_GEQUAL,

        /// <summary>
        /// Always passes (initial value).
        /// </summary>
        Always = OpenGL.GL_ALWAYS,
    }
}