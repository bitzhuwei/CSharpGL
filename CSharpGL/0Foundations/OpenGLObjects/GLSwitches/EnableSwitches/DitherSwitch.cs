namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public class DitherSwitch : EnableSwitch
    {
        /// <summary>
        ///
        /// </summary>
        public DitherSwitch()
            : base(OpenGL.GL_DITHER, true)
        { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="enableCapacity">true for enable, false for disable</param>
        public DitherSwitch(bool enableCapacity)
            : base(OpenGL.GL_DITHER, enableCapacity)
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