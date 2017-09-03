using System.ComponentModel;

namespace CSharpGL
{
    /// <summary>
    /// specify a logical pixel operation for rendering.
    /// </summary>
    public class LogicOperationState : EnableState
    {
        /// <summary>
        /// specify a logical pixel operation for rendering.
        /// </summary>
        public LogicOperationState() : this(LogicOp.Copy) { }

        /// <summary>
        /// specify a logical pixel operation for rendering.
        /// </summary>
        /// <param name="operation"></param>
        public LogicOperationState(LogicOp operation) : this(operation, true) { }

        /// <summary>
        /// specify a logical pixel operation for rendering.
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="enableCapacity">Enable() or Disable() this capacity?</param>
        public LogicOperationState(LogicOp operation, bool enableCapacity)
            : base(GL.GL_COLOR_LOGIC_OP, enableCapacity)
        {
            this.Operation = operation;
        }

        /// <summary>
        ///
        /// </summary>
        public override string ToString()
        {
            if (this.EnableCapacity)
            {
                return string.Format("Enabled glLogicOp({0});", this.Operation);
            }
            else
            {
                return string.Format("Disabled glLogicOp({0});", this.Operation);
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
                GL.Instance.LogicOp((uint)this.Operation);
            }
        }

        /// <summary>
        /// Specifies a symbolic constant that selects a logical operation.
        /// </summary>
        [Description("Specifies a symbolic constant that selects a logical operation.")]
        public LogicOp Operation { get; set; }
    }

    /// <summary>
    /// The Logic Op
    /// </summary>
    public enum LogicOp : uint
    {
        /// <summary>
        ///
        /// </summary>
        Clear = GL.GL_CLEAR,

        /// <summary>
        ///
        /// </summary>
        And = GL.GL_AND,

        /// <summary>
        ///
        /// </summary>
        AndReverse = GL.GL_AND_REVERSE,

        /// <summary>
        ///
        /// </summary>
        Copy = GL.GL_COPY,

        /// <summary>
        ///
        /// </summary>
        AndInverted = GL.GL_AND_INVERTED,

        /// <summary>
        ///
        /// </summary>
        NoOp = GL.GL_NOOP,

        /// <summary>
        ///
        /// </summary>
        XOr = GL.GL_XOR,

        /// <summary>
        ///
        /// </summary>
        Or = GL.GL_OR,

        /// <summary>
        ///
        /// </summary>
        NOr = GL.GL_NOR,

        /// <summary>
        ///
        /// </summary>
        Equiv = GL.GL_EQUIV,

        /// <summary>
        ///
        /// </summary>
        Invert = GL.GL_INVERT,

        /// <summary>
        ///
        /// </summary>
        OrReverse = GL.GL_OR_REVERSE,

        /// <summary>
        ///
        /// </summary>
        CopyInverted = GL.GL_COPY_INVERTED,

        /// <summary>
        ///
        /// </summary>
        OrInverted = GL.GL_OR_INVERTED,

        /// <summary>
        ///
        /// </summary>
        NAnd = GL.GL_NAND,

        /// <summary>
        ///
        /// </summary>
        /// <summary>
        ///
        /// </summary>
        Set = GL.GL_SET,
    }
}