using System.ComponentModel;

namespace CSharpGL
{
    /// <summary>
    /// specify the logic operation.
    /// </summary>
    public class LogicOpState : EnableState
    {
        /// <summary>
        /// specify the alpha test function.
        /// </summary>
        public LogicOpState()
            : this(AlphaTestFunction.Always, 0)// this is default values in OpenGL.
        { }

        /// <summary>
        /// specify the alpha test function.
        /// </summary>
        /// <param name="alphaTestFunc"></param>
        /// <param name="alphaTestReferenceValue"></param>
        public LogicOpState(AlphaTestFunction alphaTestFunc, float alphaTestReferenceValue)
            : base(GL.GL_ALPHA_TEST, true)
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
        protected override void StateOn()
        {
            base.StateOn();

            if (this.enableCapacityWhenStateOn)
            {
                GL.Instance.AlphaFunc((uint)this.AlphaTestFunc, this.AlphaTestReferenceValue);
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
    /// logic operations about source(new fragment color) and destination(current fragment color).
    /// </summary>
    public enum LogicOperationCode : uint
    {
        /// <summary>
        /// s.
        /// </summary>
        Copy = GL.GL_COPY,

        /// <summary>
        /// 0.
        /// </summary>
        Clear = GL.GL_CLEAR,

        /// <summary>
        /// d.
        /// </summary>
        NoOp = GL.GL_NOOP,

        /// <summary>
        /// 1.
        /// </summary>
        Set = GL.GL_SET,

        /// <summary>
        /// ^s.
        /// </summary>
        CopyInverted = GL.GL_COPY_INVERTED,

        /// <summary>
        /// ^d.
        /// </summary>
        Invert = GL.GL_INVERT,

        /// <summary>
        /// s & (^d).
        /// </summary>
        AndReverse = GL.GL_AND_REVERSE,

        /// <summary>
        /// s | (^d).
        /// </summary>
        OrReverse = GL.GL_OR_REVERSE,

        /// <summary>
        /// s & d.
        /// </summary>
        And = GL.GL_AND,

        /// <summary>
        /// s | d.
        /// </summary>
        Or = GL.GL_OR,

        /// <summary>
        /// ^(s & d).
        /// </summary>
        NotAnd = GL.GL_NAND,

        /// <summary>
        /// ^(s | d).
        /// </summary>
        NotOr = GL.GL_NOR,

        /// <summary>
        /// s XOR d.
        /// </summary>
        XOr = GL.GL_XOR,

        /// <summary>
        /// ^(s XOR d).
        /// </summary>
        EquIV = GL.GL_EQUIV,

        /// <summary>
        /// (^s) & d.
        /// </summary>
        AndInverted = GL.GL_AND_INVERTED,

        /// <summary>
        /// (^s) | d.
        /// </summary>
        OrInverted = GL.GL_OR_INVERTED,
    }
}