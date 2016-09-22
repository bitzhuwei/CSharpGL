namespace CSharpGL
{
    /// <summary>
    /// Specify a cuboid that marks a model's edges.
    /// </summary>
    public class LegacyBoundingBoxRenderer : RendererBase, IBoundingBox, IModelSpace
    {
        /// <summary>
        /// Specify a cuboid that marks a model's edges.
        /// </summary>
        public LegacyBoundingBoxRenderer()
            : this(new vec3(-0.5f, -0.5f, -0.5f), new vec3(0.5f, 0.5f, 0.5f))
        { }

        /// <summary>
        /// Specify a cuboid that marks a model's edges.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public LegacyBoundingBoxRenderer(vec3 min, vec3 max)
        {
            this.MinPosition = min;
            this.MaxPosition = max;

            this.Scale = new vec3(1, 1, 1);
            this.RotationAxis = new vec3(0, 1, 0);

            this.Lengths = max - min;
        }

        #region IBoundingBox 成员

        /// <summary>
        /// Maximum position of this cuboid.
        /// </summary>
        public vec3 MaxPosition { get; set; }

        /// <summary>
        /// Minimum position of this cuboid.
        /// </summary>
        public vec3 MinPosition { get; set; }

        #endregion IBoundingBox 成员

        /// <summary>
        ///
        /// </summary>
        protected override void DoInitialize()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        protected override void DoRender(RenderEventArgs arg)
        {
            this.RotationAngleDegree += 3.0f;
            OpenGL.LoadIdentity();
            this.LegacyTransform();

            OpenGL.Begin(DrawMode.Quads);
            OpenGL.Color(1.0f, 0, 0);
            OpenGL.Vertex3f(MinPosition.x, MinPosition.y, MinPosition.z);
            OpenGL.Color(0, 1.0f, 0);
            OpenGL.Vertex3f(MaxPosition.x, MinPosition.y, MinPosition.z);
            OpenGL.Color(0, 0, 1.0f);
            OpenGL.Vertex3f(MaxPosition.x, MinPosition.y, MaxPosition.z);
            OpenGL.Color(1.0f, 1.0f, 1.0f);
            OpenGL.Vertex3f(MinPosition.x, MinPosition.y, MaxPosition.z);
            OpenGL.End();

            OpenGL.Begin(DrawMode.LineLoop);
            OpenGL.Color(1.0f, 0, 0);
            OpenGL.Vertex3f(MinPosition.x, MaxPosition.y, MinPosition.z);
            OpenGL.Color(0, 1.0f, 0);
            OpenGL.Vertex3f(MaxPosition.x, MaxPosition.y, MinPosition.z);
            OpenGL.Color(0, 0, 1.0f);
            OpenGL.Vertex3f(MaxPosition.x, MaxPosition.y, MaxPosition.z);
            OpenGL.Color(1.0f, 1.0f, 1.0f);
            OpenGL.Vertex3f(MinPosition.x, MaxPosition.y, MaxPosition.z);
            OpenGL.End();

            OpenGL.Begin(DrawMode.Lines);
            OpenGL.Color(1.0f, 0, 0);
            OpenGL.Vertex3f(MinPosition.x, MinPosition.y, MinPosition.z);
            OpenGL.Vertex3f(MinPosition.x, MaxPosition.y, MinPosition.z);
            OpenGL.Color(0, 1.0f, 0);
            OpenGL.Vertex3f(MaxPosition.x, MinPosition.y, MinPosition.z);
            OpenGL.Vertex3f(MaxPosition.x, MaxPosition.y, MinPosition.z);
            OpenGL.Color(0, 0, 1.0f);
            OpenGL.Vertex3f(MaxPosition.x, MinPosition.y, MaxPosition.z);
            OpenGL.Vertex3f(MaxPosition.x, MaxPosition.y, MaxPosition.z);
            OpenGL.Color(1.0f, 1.0f, 1.0f);
            OpenGL.Vertex3f(MinPosition.x, MinPosition.y, MaxPosition.z);
            OpenGL.Vertex3f(MinPosition.x, MaxPosition.y, MaxPosition.z);
            OpenGL.End();
        }
    }
}