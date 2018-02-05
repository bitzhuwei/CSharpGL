using System.ComponentModel;

namespace CSharpGL
{
    /// <summary>
    /// specify the logic operation.
    /// </summary>
    public class LogicOpSwitch : EnableSwitch
    {
        // Activator needs a non-parameter constructor.
        /// <summary>
        /// specify the alpha logic operation.
        /// </summary>
        public LogicOpSwitch() : this(LogicOperationCode.Copy, true) { }

        /// <summary>
        /// specify the alpha logic operation.
        /// </summary>
        /// <param name="opCode"></param>
        /// <param name="enableCapacity"></param>
        public LogicOpSwitch(LogicOperationCode opCode, bool enableCapacity = true)
            : base(GL.GL_COLOR_LOGIC_OP, enableCapacity)
        {
            this.OpCode = opCode;
        }

        /// <summary>
        ///
        /// </summary>
        public override string ToString()
        {
            if (this.EnableCapacity)
            {
                return string.Format("glLogicOp({0});", this.OpCode);
            }
            else
            {
                return string.Format("Disabled glLogicOp({0});", this.OpCode);
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
                GL.Instance.LogicOp((uint)this.OpCode);
            }
        }

        /// <summary>
        /// Specifies the operation code. The initial value is GL_COPY.
        /// </summary>
        [Description("Specifies the operation code. The initial value is GL_COPY.")]
        public LogicOperationCode OpCode { get; set; }

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
        /// s &amp; (^d).
        /// </summary>
        AndReverse = GL.GL_AND_REVERSE,

        /// <summary>
        /// s | (^d).
        /// </summary>
        OrReverse = GL.GL_OR_REVERSE,

        /// <summary>
        /// s &amp; d.
        /// </summary>
        And = GL.GL_AND,

        /// <summary>
        /// s | d.
        /// </summary>
        Or = GL.GL_OR,

        /// <summary>
        /// ^(s &amp; d).
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
        /// (^s) &amp; d.
        /// </summary>
        AndInverted = GL.GL_AND_INVERTED,

        /// <summary>
        /// (^s) | d.
        /// </summary>
        OrInverted = GL.GL_OR_INVERTED,
    }
}