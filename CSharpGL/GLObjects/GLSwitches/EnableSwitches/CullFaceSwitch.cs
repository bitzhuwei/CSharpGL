namespace CSharpGL
{
    // https://www.khronos.org/opengles/sdk/docs/man/xhtml/glCullFace.xml
    /// <summary>
    /// Cull front/back face?
    /// </summary>
    public class CullFaceSwitch : EnableSwitch
    {
        // Activator needs a non-parameter constructor.
        /// <summary>
        /// Cull back face.
        /// </summary>
        public CullFaceSwitch() : this(CullFaceMode.Back) { }

        /// <summary>
        /// Cull front/back face?
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="enableCapacity">Enable() or Disable() this capacity?</param>
        public CullFaceSwitch(CullFaceMode mode, bool enableCapacity = true)
            : base(GL.GL_CULL_FACE, enableCapacity)
        {
            this.Mode = mode;
        }

        /// <summary>
        ///
        /// </summary>
        public override string ToString()
        {
            if (this.EnableCapacity)
            {
                return string.Format("Enabled glCullFace({0});", this.Mode);
            }
            else
            {
                return string.Format("Disabled glCullFace({0});", this.Mode);
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
                GL.Instance.CullFace(this.mode);
            }
        }

        /// <summary>
        /// Specifies whether front- or back-facing polygons are candidates for culling. Symbolic constants GL_FRONT, GL_BACK, and GL_FRONT_AND_BACK are accepted. The initial value is GL_BACK.
        /// </summary>
        private uint mode = GL.GL_BACK;

        /// <summary>
        /// Cull front/back face?
        /// </summary>
        public CullFaceMode Mode
        {
            get { return (CullFaceMode)mode; }
            set { mode = (uint)value; }
        }
    }

    /// <summary>
    /// Cull front/back face?
    /// </summary>
    public enum CullFaceMode : uint
    {
        /// <summary>
        /// Cull front face.
        /// </summary>
        Front = GL.GL_FRONT,

        /// <summary>
        /// Cull back face.
        /// </summary>
        Back = GL.GL_BACK,

        /// <summary>
        /// Cull both front and back face.
        /// </summary>
        FrontAndBack = GL.GL_FRONT_AND_BACK,
    }
}