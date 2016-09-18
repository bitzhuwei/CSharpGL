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
        public BezierCurveDemo()
        {
            this.Lengths = lengths;
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

            //this.LegacyTransform();
            //必须在绘制顶点之前开启
            OpenGL.Enable(OpenGL.GL_MAP1_VERTEX_3);

            OpenGL.Color(1.0f, 0, 0, 1.0f);
            //使用画线的方式来连接点
            OpenGL.Begin(OpenGL.GL_LINE_STRIP);
            //OpenGL.Begin(OpenGL.GL_TRIANGLES);
            for (int i = 0; i <= 100; i++)
            {
                OpenGL.EvalCoord1f((float)i);
            }
            OpenGL.End();
            ////画控制点
            //OpenGL.PointSize(2.5f);
            //OpenGL.Begin(OpenGL.GL_POINTS);
            //unsafe
            //{
            //    var array = (vec3*)controlPoints.Header.ToPointer();
            //    for (int i = 0; i < numOfPoints; ++i)
            //    {
            //        OpenGL.Vertex(array[i].x, array[i].y, array[i].z);
            //    }
            //}
            //OpenGL.End();
        }
    }
}