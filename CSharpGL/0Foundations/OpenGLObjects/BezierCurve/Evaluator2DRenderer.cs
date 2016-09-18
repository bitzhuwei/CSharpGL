using System.Collections.Generic;

namespace CSharpGL
{
    /// <summary>
    /// This is a 1D evaluator, i.e a bezier curve.
    /// </summary>
    public class Evaluator2DRenderer : EvaluatorRenderer
    {
        private const int minU = 0;
        private const int maxU = 100;
        private const int minV = 0;
        private const int maxV = 100;

        /// <summary>
        ///
        /// </summary>
        public PolygonMode MeshMode { get; set; }

        /// <summary>
        ///
        /// </summary>
        public ivec2 MinPercent { get; set; }

        /// <summary>
        ///
        /// </summary>
        public ivec2 MaxPercent { get; set; }

        /// <summary>
        /// This is a 1D evaluator, i.e a bezier curve.
        /// </summary>
        public Evaluator2DRenderer(IList<vec3> controlPoints, vec3 lengths)
            : base(controlPoints, lengths)
        {
            this.MeshMode = PolygonMode.Line;
            this.MinPercent = new ivec2(minU, minV);
            this.MaxPercent = new ivec2(maxU, maxV);
        }

        /// <summary>
        /// </summary>

        protected override void DoInitialize()
        {
            Setup(this.controlPoints);

            controlPoints.Dispose();
        }

        /// <summary>
        /// </summary>
        /// <param name="arg"></param>
        protected override void DoRender(RenderEventArgs arg)
        {
            //  Set the projection matrix.(projection and view matrix actually.)
            OpenGL.MatrixMode(OpenGL.GL_PROJECTION);
            OpenGL.LoadIdentity();
            arg.Camera.LegacyProjection();

            //  Set the modelview matrix.(just model matrix actually.)
            OpenGL.MatrixMode(OpenGL.GL_MODELVIEW);
            OpenGL.LoadIdentity();
            this.LegacyTransform();

            vec4 color = this.CurveColor.ToVec4();
            OpenGL.Color(color.x, color.y, color.z, color.w);
            this.CurveWidth.On();

            //启用求值器
            //必须在绘制顶点之前开启
            OpenGL.Enable(OpenGL.GL_MAP2_VERTEX_3);
            OpenGL.Enable(OpenGL.GL_AUTO_NORMAL);
            // 计算网格
            OpenGL.EvalMesh2(
                (uint)this.MeshMode,
                this.MinPercent.x, this.MaxPercent.x, this.MinPercent.y, this.MaxPercent.y);

            this.CurveWidth.Off();
        }

        /// <summary>
        ///
        /// </summary>
        private void Setup(UnmanagedArray<vec3> controlPoints)
        {
            OpenGL.Map2f(OpenGL.GL_MAP2_VERTEX_3, //生成的数据类型
                   minU, // u的下界
                   maxU, //u的上界
                   3, //数据中点的间隔
                   3, //u方向上的阶
                   minV, //v的下界
                   maxV, //v的上界
                   9, // 控制点之间的间隔
                   3, // v方向上的阶
                   controlPoints.Header); //控制点数组
            //OpenGL.Enable(OpenGL.GL_MAP2_VERTEX_3);
            //从0到10映射一个包含10个点的网格
            OpenGL.MapGrid2f(10, 0.0f, 10.0f, 10, 0.0f, 10.0f);
        }
    }
}