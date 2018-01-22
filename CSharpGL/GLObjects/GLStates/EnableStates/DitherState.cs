namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public class DitherState : EnableState
    {
        // Activator needs a non-parameter constructor.
        /// <summary>
        /// 
        /// </summary>
        public DitherState() : this(true) { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="enableCapacity">true for enable, false for disable</param>
        public DitherState(bool enableCapacity)
            : base(GL.GL_DITHER, enableCapacity)
        { }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (this.EnableCapacity)
            { return "OpenGL.Enable(GL_DITHER);"; }
            else
            { return "OpenGL.Disable(GL_DITHER);"; }
        }
    }
}