namespace CSharpGL
{
    /// <summary>
    /// This function sets what defines a front face. Counter ClockWise by default.
    /// <para>作用是控制多边形的正面是如何决定的。在默认情况下，mode是GL_CCW。</para>
    /// </summary>
    public class FrontFaceState : GLState
    {
        private int[] originalPolygonMode = new int[1];

        // Activator needs a non-parameter constructor.
        /// <summary>
        /// This function sets what defines a front face. Counter ClockWise by default.
        /// <para>作用是控制多边形的正面是如何决定的。在默认情况下，mode是GL_CCW。</para>
        /// </summary>
        public FrontFaceState() : this(FrontFaceMode.CCW) { }

        /// <summary>
        /// This function sets what defines a front face. Counter ClockWise by default.
        /// <para>作用是控制多边形的正面是如何决定的。在默认情况下，mode是GL_CCW。</para>
        /// </summary>
        /// <param name="mode"></param>
        public FrontFaceState(FrontFaceMode mode)
        {
            this.Mode = mode;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("glFrontFace({0})", Mode);
        }

        private uint lastMode;

        /// <summary>
        ///
        /// </summary>
        protected override void StateOn()
        {
            GL.Instance.GetIntegerv((uint)GetTarget.FrontFace, originalPolygonMode);

            this.lastMode = (uint)this.Mode;
            if (this.lastMode != originalPolygonMode[0])
            {
                GL.Instance.FrontFace(this.lastMode);
            }
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOff()
        {
            if (this.lastMode != originalPolygonMode[0])
            {
                GL.Instance.FrontFace((uint)originalPolygonMode[0]);
            }
        }

        /// <summary>
        ///
        /// </summary>
        public FrontFaceMode Mode { get; set; }
    }
}