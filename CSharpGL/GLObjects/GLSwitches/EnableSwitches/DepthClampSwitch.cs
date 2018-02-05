namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public class DepthClampSwitch : EnableSwitch
    {
        // Activator needs a non-parameter constructor.
        /// <summary>
        /// 
        /// </summary>
        public DepthClampSwitch() : this(true) { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="enableCapacity">true for enable, false for disable</param>
        public DepthClampSwitch(bool enableCapacity)
            : base(GL.GL_DEPTH_CLAMP, enableCapacity)
        { }

        /// <summary>
        ///
        /// </summary>
        public override string ToString()
        {
            if (this.EnableCapacity)
            { return "OpenGL.Enable(GL_DEPTH_CLAMP);"; }
            else
            { return "OpenGL.Disable(GL_DEPTH_CLAMP);"; }
        }
    }
}