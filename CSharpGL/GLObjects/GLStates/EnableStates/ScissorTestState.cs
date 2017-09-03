namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public class ScissorTestState : EnableState
    {
        /// <summary>
        ///
        /// </summary>
        public ScissorTestState()
            : base(GL.GL_SCISSOR_TEST, true)
        {
            this.Init();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="enableCapacity">Enable() or Disable() this capacity?</param>
        public ScissorTestState(bool enableCapacity)
            : base(GL.GL_SCISSOR_TEST, enableCapacity)
        {
            this.Init();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public ScissorTestState(int x, int y, int width, int height)
            : base(GL.GL_SCISSOR_TEST, true)
        {
            this.Init();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="enableCapacity">Enable() or Disable() this capacity?</param>
        public ScissorTestState(int x, int y, int width, int height, bool enableCapacity)
            : base(GL.GL_SCISSOR_TEST, enableCapacity)
        {
            this.Init();
        }

        private void Init()
        {
            var viewport = new int[4];
            GL.Instance.GetIntegerv((uint)GetTarget.Viewport, viewport);
            this.X = viewport[0]; this.Y = viewport[1];
            this.Width = viewport[2]; this.Height = viewport[3];
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