namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public class StencilTestSwitch : EnableSwitch
    {
        // Activator needs a non-parameter constructor.
        /// <summary>
        /// 
        /// </summary>
        public StencilTestSwitch() : this(true) { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="enableCapacity">true for enable, false for disable</param>
        public StencilTestSwitch(bool enableCapacity)
            : base(GL.GL_STENCIL_TEST, enableCapacity)
        { }

        /// <summary>
        ///
        /// </summary>
        public override string ToString()
        {
            if (this.EnableCapacity)
            { return "OpenGL.Enable(GL_STENCIL_TEST);"; }
            else
            { return "OpenGL.Disable(GL_STENCIL_TEST);"; }
        }
    }
}