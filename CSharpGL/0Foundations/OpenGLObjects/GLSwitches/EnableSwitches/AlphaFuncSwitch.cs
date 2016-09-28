namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public class AlphaFuncSwitch : EnableSwitch
    {
        /// <summary>
        ///
        /// </summary>
        public AlphaFuncSwitch()
            : this(AlphaTestFunction.Always, 0)// this is default values in OpenGL.
        { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sourceFactor"></param>
        /// <param name="destFactor"></param>
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
        ///
        /// </summary>
        public AlphaTestFunction AlphaTestFunc { get; set; }

        /// <summary>
        ///
        /// </summary>
        public float AlphaTestReferenceValue { get; set; }
    }

    /// <summary>
    /// The alpha function
    /// </summary>
    public enum AlphaTestFunction : uint
    {
        /// <summary>
        /// 
        /// </summary>
        Never = OpenGL.GL_NEVER,
        /// <summary>
        /// 
        /// </summary>
        Less = OpenGL.GL_LESS,
        /// <summary>
        /// 
        /// </summary>
        Equal = OpenGL.GL_EQUAL,
        /// <summary>
        /// 
        /// </summary>
        LessThanOrEqual = OpenGL.GL_LEQUAL,
        /// <summary>
        /// 
        /// </summary>
        Great = OpenGL.GL_GREATER,
        /// <summary>
        /// 
        /// </summary>
        NotEqual = OpenGL.GL_NOTEQUAL,
        /// <summary>
        /// 
        /// </summary>
        GreaterThanOrEqual = OpenGL.GL_GEQUAL,
        /// <summary>
        /// 
        /// </summary>
        Always = OpenGL.GL_ALWAYS,
    }
}