namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public class ScissorTestSwitch : EnableSwitch
    {
        // Activator needs a non-parameter constructor.
        /// <summary>
        /// 
        /// </summary>
        public ScissorTestSwitch() : this(0, 0, 0, 0, false) { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="enableCapacity">Enable() or Disable() this capacity?</param>
        public ScissorTestSwitch(int x, int y, int width, int height, bool enableCapacity = true)
            : base(GL.GL_SCISSOR_TEST, enableCapacity)
        {
            this.X = x; this.Y = y; this.Width = width; this.Height = height;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (this.EnableCapacity)
            {
                return string.Format("Enabled glScissor({0}, {1}, {2}, {3});",
                    X, Y, Width, Height);
            }
            else
            {
                return string.Format("Disabled glScissor({0}, {1}, {2}, {3});",
                    X, Y, Width, Height);
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
                GL.Instance.Scissor(this.X, this.Y, this.Width, this.Height);
            }
        }

        /// <summary>
        ///
        /// </summary>
        public int X { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int Height { get; set; }
    }
}