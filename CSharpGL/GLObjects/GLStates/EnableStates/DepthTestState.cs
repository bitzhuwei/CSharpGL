namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public class DepthTestState : EnableState
    {
        /// <summary>
        ///
        /// </summary>
        public DepthTestState()
            : base(GL.GL_DEPTH_TEST, true)
        { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="enableCapacity">true for enable, false for disable</param>
        public DepthTestState(bool enableCapacity)
            : base(GL.GL_DEPTH_TEST, enableCapacity)
        { }

        /// <summary>
        ///
        /// </summary>
        public override string ToString()
        {
            if (this.EnableCapacity)
            { return "OpenGL.Enable(GL_DEPTH_TEST);"; }
            else
            { return "OpenGL.Disable(GL_DEPTH_TEST);"; }
        }
    }
}