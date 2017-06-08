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

            this.ModelSize = max - min;
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
            this.RotationAngleDegree += 6.0f;// 6°
            GL.Instance.LoadIdentity();
            this.LegacyTransform();

            GL.Instance.Begin((uint)DrawMode.Quads);
            GL.Instance.Color3f(1.0f, 0, 0);
            GL.Instance.Vertex3f(MinPosition.x, MinPosition.y, MinPosition.z);
            GL.Instance.Color3f(0, 1.0f, 0);
            GL.Instance.Vertex3f(MaxPosition.x, MinPosition.y, MinPosition.z);
            GL.Instance.Color3f(0, 0, 1.0f);
            GL.Instance.Vertex3f(MaxPosition.x, MinPosition.y, MaxPosition.z);
            GL.Instance.Color3f(1.0f, 1.0f, 1.0f);
            GL.Instance.Vertex3f(MinPosition.x, MinPosition.y, MaxPosition.z);
            GL.Instance.End();

            GL.Instance.Begin((uint)DrawMode.LineLoop);
            GL.Instance.Color3f(1.0f, 0, 0);
            GL.Instance.Vertex3f(MinPosition.x, MaxPosition.y, MinPosition.z);
            GL.Instance.Color3f(0, 1.0f, 0);
            GL.Instance.Vertex3f(MaxPosition.x, MaxPosition.y, MinPosition.z);
            GL.Instance.Color3f(0, 0, 1.0f);
            GL.Instance.Vertex3f(MaxPosition.x, MaxPosition.y, MaxPosition.z);
            GL.Instance.Color3f(1.0f, 1.0f, 1.0f);
            GL.Instance.Vertex3f(MinPosition.x, MaxPosition.y, MaxPosition.z);
            GL.Instance.End();

            GL.Instance.Begin((uint)DrawMode.Lines);
            GL.Instance.Color3f(1.0f, 0, 0);
            GL.Instance.Vertex3f(MinPosition.x, MinPosition.y, MinPosition.z);
            GL.Instance.Vertex3f(MinPosition.x, MaxPosition.y, MinPosition.z);
            GL.Instance.Color3f(0, 1.0f, 0);
            GL.Instance.Vertex3f(MaxPosition.x, MinPosition.y, MinPosition.z);
            GL.Instance.Vertex3f(MaxPosition.x, MaxPosition.y, MinPosition.z);
            GL.Instance.Color3f(0, 0, 1.0f);
            GL.Instance.Vertex3f(MaxPosition.x, MinPosition.y, MaxPosition.z);
            GL.Instance.Vertex3f(MaxPosition.x, MaxPosition.y, MaxPosition.z);
            GL.Instance.Color3f(1.0f, 1.0f, 1.0f);
            GL.Instance.Vertex3f(MinPosition.x, MinPosition.y, MaxPosition.z);
            GL.Instance.Vertex3f(MinPosition.x, MaxPosition.y, MaxPosition.z);
            GL.Instance.End();
        }
    }
}