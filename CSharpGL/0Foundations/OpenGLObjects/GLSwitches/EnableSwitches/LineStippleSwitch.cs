namespace CSharpGL
{
    /// <summary>
    /// Dashed line.
    /// </summary>
    public class LineStippleSwitch : EnableSwitch
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="mode"></param>
        public LineStippleSwitch(int factor, ushort pattern)
            : base(OpenGL.GL_LINE_STIPPLE, true)
        {
            this.Init(factor, pattern);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="factor"></param>
        /// <param name="pattern"></param>
        /// <param name="enableCapacity">Enable() or Disable() this capacity?</param>
        public LineStippleSwitch(int factor, ushort pattern, bool enableCapacity)
            : base(OpenGL.GL_LINE_STIPPLE, enableCapacity)
        {
            this.Init(factor, pattern);
        }

        private void Init(int factor, ushort pattern)
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
                return string.Format("Enabled glLineStipple({0}, 0x{1});", this.Factor, this.Pattern.ToString("X"));
            }
            else
            {
                return string.Format("Disabled glLineStipple({0}, 0x{1});", this.Factor, this.Pattern.ToString("X"));
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
                OpenGL.LineStipple(this.Factor, this.Pattern);
            }
        }

        /// <summary>
        ///
        /// </summary>
        public int Factor { get; set; }

        /// <summary>
        ///
        /// </summary>
        public ushort Pattern { get; set; }
    }
}