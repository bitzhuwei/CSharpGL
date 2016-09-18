using System.Drawing;

namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public class BezierCurveDemo : RendererBase
    {
        static private vec3[] points = new vec3[]{
             new vec3(-4.0f, 0.0f, 0.0f),
             new vec3(-6.0f, 4.0f, 0.0f),
             new vec3(6.0f, -4.0f, 0.0f),
             new vec3(4.0f, 0.0f, 0.0f),
        };

        private static vec3 lengths;

        static BezierCurveDemo()
        {
            BoundingBox box = points.Move2Center();
            lengths = box.MaxPosition - box.MinPosition;
        }

        /// <summary>
        ///
        /// </summary>
        public PointSizeSwitch PointSize { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public Color PointColor { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool RenderControlPoints { get; set; }

        /// <summary>
        ///
        /// </summary>
        public LineWidthSwitch CurveWidth { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public Color CurveColor { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool RenderCurve { get; set; }

        /// <summary>
        ///
        /// </summary>
        public BezierCurveDemo()
        {
            this.Lengths = lengths;
            this.PointSize = new PointSizeSwitch(10.0f);
            this.CurveWidth = new LineWidthSwitch(3.0f);
            this.PointColor = Color.Aqua;
            this.CurveColor = Color.Red;
            this.RenderControlPoints = true;
            this.RenderCurve = true;
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
            //设置贝塞尔曲线，这个函数其实只需要调用一次，可以放在SetupRC中设置
            OpenGL.Map1f(OpenGL.GL_MAP1_VERTEX_3, //生成的数据类型
             0.0f, //u值的下界
              100.0f, //u值的上界
               3, //顶点在数据中的间隔，x,y,z所以间隔是3
                controlPoints.Length, //u方向上的阶，即控制点的个数
                 controlPoints.Header//指向控制点数据的指针
                 );
            controlPoints.Dispose();
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
                OpenGL.Begin(OpenGL.GL_LINE_STRIP);
                //OpenGL.Begin(OpenGL.GL_TRIANGLES);
                for (int i = 0; i <= 100; i++)
                {
                    OpenGL.EvalCoord1f((float)i);
                }
                OpenGL.End();
                this.CurveWidth.Off();
            }

            if (this.RenderControlPoints)
            {
                //画控制点
                vec4 color = this.PointColor.ToVec4();
                OpenGL.Color(color.x, color.y, color.z, color.w);
                this.PointSize.On();
                OpenGL.Begin(OpenGL.GL_POINTS);
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