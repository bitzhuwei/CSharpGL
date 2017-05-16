namespace CSharpGL
{
    /// <summary>
    /// https://www.khronos.org/opengles/sdk/docs/man/xhtml/glCullFace.xml
    /// </summary>
    public class CullFaceState : EnableState
    {
        /// <summary>
        ///
        /// </summary>
        public CullFaceState()
            : base(GL.GL_CULL_FACE, true)
        {
            this.Init(CullFaceMode.Back);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="enableCapacity">Enable() or Disable() this capacity?</param>
        public CullFaceState(bool enableCapacity)
            : base(GL.GL_CULL_FACE, enableCapacity)
        {
            this.Init(CullFaceMode.Back);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="mode"></param>
        public CullFaceState(CullFaceMode mode)
            : base(GL.GL_CULL_FACE, true)
        {
            this.Init(mode);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="enableCapacity">Enable() or Disable() this capacity?</param>
        public CullFaceState(CullFaceMode mode, bool enableCapacity)
            : base(GL.GL_CULL_FACE, enableCapacity)
        {
            this.Init(mode);
        }

        private void Init(CullFaceMode mode)
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
        /// https://www.khronos.org/opengles/sdk/docs/man/xhtml/glCullFace.xml
        /// </summary>
        public CullFaceMode Mode
        {
            get { return (CullFaceMode)mode; }
            set { mode = (uint)value; }
        }
    }

    /// <summary>
    /// Display front/back faces?
    /// </summary>
    public enum CullFaceMode : uint
    {
        /// <summary>
        /// Display front faces only.
        /// </summary>
        Front = GL.GL_FRONT,

        /// <summary>
        /// Display back faces only.
        /// </summary>
        Back = GL.GL_BACK,

        /// <summary>
        /// Display both front and back faces.
        /// </summary>
        FrontAndBack = GL.GL_FRONT_AND_BACK,
    }
}