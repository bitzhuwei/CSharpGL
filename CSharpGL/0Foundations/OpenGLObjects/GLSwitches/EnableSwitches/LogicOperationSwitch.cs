using System.ComponentModel;

namespace CSharpGL
{
    /// <summary>
    /// specify a logical pixel operation for rendering.
    /// </summary>
    public class LogicOperationSwitch : EnableSwitch
    {
        /// <summary>
        /// specify a logical pixel operation for rendering.
        /// </summary>
        public LogicOperationSwitch() : this(LogicOp.Copy) { }

        /// <summary>
        /// specify a logical pixel operation for rendering.
        /// </summary>
        /// <param name="operation"></param>
        public LogicOperationSwitch(LogicOp operation) : this(operation, true) { }

        /// <summary>
        /// specify a logical pixel operation for rendering.
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="enableCapacity">Enable() or Disable() this capacity?</param>
        public LogicOperationSwitch(LogicOp operation, bool enableCapacity)
            : base(OpenGL.GL_COLOR_LOGIC_OP, enableCapacity)
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
        protected override void SwitchOn()
        {
            base.SwitchOn();

            if (this.enableCapacityWhenSwitchOn)
            {
                OpenGL.LogicOp((uint)this.Operation);
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
        Clear = OpenGL.GL_CLEAR,

        /// <summary>
        ///
        /// </summary>
        And = OpenGL.GL_AND,

        /// <summary>
        ///
        /// </summary>
        AndReverse = OpenGL.GL_AND_REVERSE,

        /// <summary>
        ///
        /// </summary>
        Copy = OpenGL.GL_COPY,

        /// <summary>
        ///
        /// </summary>
        AndInverted = OpenGL.GL_AND_INVERTED,

        /// <summary>
        ///
        /// </summary>
        NoOp = OpenGL.GL_NOOP,

        /// <summary>
        ///
        /// </summary>
        XOr = OpenGL.GL_XOR,

        /// <summary>
        ///
        /// </summary>
        Or = OpenGL.GL_OR,

        /// <summary>
        ///
        /// </summary>
        NOr = OpenGL.GL_NOR,

        /// <summary>
        ///
        /// </summary>
        Equiv = OpenGL.GL_EQUIV,

        /// <summary>
        ///
        /// </summary>
        Invert = OpenGL.GL_INVERT,

        /// <summary>
        ///
        /// </summary>
        OrReverse = OpenGL.GL_OR_REVERSE,

        /// <summary>
        ///
        /// </summary>
        CopyInverted = OpenGL.GL_COPY_INVERTED,

        /// <summary>
        ///
        /// </summary>
        OrInverted = OpenGL.GL_OR_INVERTED,

        /// <summary>
        ///
        /// </summary>
        NAnd = OpenGL.GL_NAND,

        /// <summary>
        ///
        /// </summary>
        /// <summary>
        ///
        /// </summary>
        Set = OpenGL.GL_SET,
    }
}