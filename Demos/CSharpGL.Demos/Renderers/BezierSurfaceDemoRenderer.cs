using System.Drawing;

namespace CSharpGL.Demos
{
    /// <summary>
    ///
    /// </summary>
    [DemoRenderer]
    public class BezierSurfaceDemoRenderer : RendererBase
    {
        private float minU = 0;
        private float maxU = 100;
        private float minV = 0;
        private float maxV = 100;

        static private vec3[] points = new vec3[]{
            new vec3(  -4.0f, 0.0f, 4.0f),
            new vec3(-2.0f, 4.0f, 4.0f),
            new vec3( 4.0f, 0.0f, 4.0f ),
            new vec3(  -4.0f, 0.0f, 0.0f),
            new vec3(-2.0f, 4.0f, 0.0f),
            new vec3( 4.0f, 0.0f, 0.0f),
            new vec3(  -4.0f, 0.0f, -4.0f),
            new vec3(-2.0f, 4.0f, -4.0f),
            new vec3( 4.0f, 0.0f, -4.0f)
        };

        private static vec3 lengths;

        static BezierSurfaceDemoRenderer()
        {
            BoundingBox box = points.Move2Center();
            lengths = box.MaxPosition - box.MinPosition;
        }

        public PointSizeSwitch PointSize { get; private set; }

        public Color PointColor { get; set; }

        public DrawMode ControLPointDrawMode { get; set; }

        public bool RenderControlPoints { get; set; }

        public LineWidthSwitch CurveWidth { get; private set; }

        public Color CurveColor { get; set; }

        public PolygonMode MeshMode { get; set; }

        public bool RenderCurve { get; set; }

        public int MinPercent { get; set; }

        public int MaxPercent { get; set; }

        /// <summary>
        ///
        /// </summary>
        public BezierSurfaceDemoRenderer()
        {
            this.Lengths = lengths;
            this.PointSize = new PointSizeSwitch(10.0f);
            this.CurveWidth = new LineWidthSwitch(3.0f);
            this.PointColor = Color.Aqua;
            this.CurveColor = Color.Red;
            this.ControLPointDrawMode = DrawMode.Points;
            this.RenderControlPoints = true;
            this.MeshMode = PolygonMode.Line;
            this.RenderCurve = true;
            this.MinPercent = 0;
            this.MaxPercent = 100;
        }

        /// <summary>
        /// TODO: dispose this ...
        /// </summary>

        protected override void DoInitialize()
        {
            UnmanagedArray<vec3> controlPoints = new UnmanagedArray<vec3>(points.Length);
            unsafe
            {
                var array = (vec3*)controlPoints.Header.ToPointer();
                for (int i = 0; i < points.Length; i++)
                {
                    array[i] = points[i];
                }
            }
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
            //启用求值器
            OpenGL.Enable(OpenGL.GL_MAP2_VERTEX_3);
            //从0到10映射一个包含10个点的网格
            OpenGL.MapGrid2f(10, 0.0f, 10.0f, 10, 0.0f, 10.0f);
        }

        /// <summary>
        ///
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

            if (this.RenderCurve)
            {
                //必须在绘制顶点之前开启
                OpenGL.Enable(OpenGL.GL_MAP1_VERTEX_3);

                vec4 color = this.CurveColor.ToVec4();
                OpenGL.Color(color.x, color.y, color.z, color.w);
                this.CurveWidth.On();
                //使用画线的方式来连接点
                // 计算网格  
                OpenGL.EvalMesh2(
                    (uint)this.MeshMode,
                    this.MinPercent, this.MaxPercent, this.MinPercent, this.MaxPercent);

                this.CurveWidth.Off();
            }

            if (this.RenderControlPoints)
            {
                //画控制点
                vec4 color = this.PointColor.ToVec4();
                OpenGL.Color(color.x, color.y, color.z, color.w);
                this.PointSize.On();
                OpenGL.Begin(this.ControLPointDrawMode);
                for (int i = 0; i < points.Length; ++i)
                {
                    OpenGL.Vertex(points[i].x, points[i].y, points[i].z);
                }
                OpenGL.End();
                this.PointSize.Off();
            }
        }
    }
}