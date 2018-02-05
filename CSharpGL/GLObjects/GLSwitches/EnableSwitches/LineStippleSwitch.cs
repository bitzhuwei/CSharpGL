using System.ComponentModel;

namespace CSharpGL
{
    /// <summary>
    /// Dashed line.
    /// </summary>
    public class LineStippleSwitch : EnableSwitch
    {
        // Activator needs a non-parameter constructor.
        /// <summary>
        /// Dashed line.
        /// </summary>
        public LineStippleSwitch() : this(1, 0x0F0F) { }

        /// <summary>
        /// Dashed line.
        /// </summary>
        /// <param name="factor">factor in 'void glLineStipple(int factor, ushort pattern);'.</param>
        /// <param name="pattern">pattern in 'void glLineStipple(int factor, ushort pattern);'.</param>
        /// <param name="enableCapacity">Enable() or Disable() this capacity?</param>
        public LineStippleSwitch(int factor, ushort pattern, bool enableCapacity = true)
            : base(GL.GL_LINE_STIPPLE, enableCapacity)
        {
            this.Factor = factor;
            this.Pattern = pattern;
        }

        /// <summary>
        ///
        /// </summary>
        public override string ToString()
        {
            if (this.EnableCapacity)
            {
                return string.Format("Enabled glLineStipple({0}, 0x{1:X4});", this.Factor, this.Pattern);
            }
            else
            {
                return string.Format("Disabled glLineStipple({0}, 0x{1:X4});", this.Factor, this.Pattern);
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
                GL.Instance.LineStipple(this.Factor, this.Pattern);
            }
        }

        /// <summary>
        /// factor in 'void glLineStipple(int factor, ushort pattern);'.
        /// </summary>
        [Description("factor in 'void glLineStipple(int factor, ushort pattern);'")]
        public int Factor { get; set; }

        /// <summary>
        /// pattern in 'void glLineStipple(int factor, ushort pattern);'.
        /// </summary>
        [Description("It's supported to udpate this value with hexadecimal format(such as 0x0101).")]
        public ushort Pattern { get; set; }
    }
}