using System.Collections.Generic;
using System.Drawing;

namespace CSharpGL
{
    /// <summary>
    /// This is a 1D evaluator, i.e a bezier curve.
    /// </summary>
    public class Evaluator2DRenderer : EvaluatorRenderer
    {

        private float minU = 0;
        private float maxU = 100;
        private float minV = 0;
        private float maxV = 100;

        /// <summary>
        /// 
        /// </summary>
        public PolygonMode MeshMode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int MinPercent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int MaxPercent { get; set; }

        /// <summary>
        /// This is a 1D evaluator, i.e a bezier curve.
        /// </summary>
        public Evaluator2DRenderer(IList<vec3> controlPoints, vec3 lengths)
            : base(controlPoints, lengths)
        {
            this.MinPercent = 0;
            this.MaxPercent = 100;
        }

        /// <summary>
        /// </summary>

        protected override void DoInitialize()
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
            controlPoints.Dispose();
            //OpenGL.Enable(OpenGL.GL_MAP2_VERTEX_3);
            //从0到10映射一个包含10个点的网格
            OpenGL.MapGrid2f(10, 0.0f, 10.0f, 10, 0.0f, 10.0f);
        }

        /// <summary>
        /// </summary>
        /// <param name="arg"></param>
        protected override void DoRender(RenderEventArgs arg)
        {
            //  Set the projection matrix.(projection and view matrix actually.)
            OpenGL.MatrixMode(OpenGL.GL_PROJECTION);
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
                this.MinPercent, this.MaxPercent, this.MinPercent, this.MaxPercent);

            this.CurveWidth.Off();
        }

    }
}