namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public class BezierCurveRenderer : RendererBase
    {
        private unsafe UnmanagedArray<vec3> controlPoints;
        private int numOfPoints;

        /// <summary>
        ///
        /// </summary>
        /// <param name="numOfPoints"></param>
        /// <param name="controlPoints"></param>
        public BezierCurveRenderer(int numOfPoints, UnmanagedArray<vec3> controlPoints)
        {
            this.numOfPoints = numOfPoints;
            this.controlPoints = controlPoints;
        }

        /// <summary>
        ///
        /// </summary>
        protected override void DoInitialize()
        {
            //设置贝塞尔曲线，这个函数其实只需要调用一次，可以放在SetupRC中设置
            OpenGL.Map1f(OpenGL.GL_MAP1_VERTEX_3, //生成的数据类型
             0.0f, //u值的下界
              100.0f, //u值的上界
               3, //顶点在数据中的间隔，x,y,z所以间隔是3
                numOfPoints, //u方向上的阶，即控制点的个数
                 controlPoints.Header//指向控制点数据的指针
                 );
            //必须在绘制顶点之前开启
            OpenGL.Enable(OpenGL.GL_MAP1_VERTEX_3);
            //使用画线的方式来连接点
            OpenGL.Begin(OpenGL.GL_LINE_STRIP);
            for (int i = 0; i <= 100; i++)
            {
                OpenGL.EvalCoord1f((float)i);
            }
            OpenGL.End();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        protected override void DoRender(RenderEventArgs arg)
        {
            OpenGL.LoadIdentity();

            mat4 projection = arg.Camera.GetProjectionMatrix();
            mat4 view = arg.Camera.GetViewMatrix();
            float width = arg.CanvasRect.Width;
            float height = arg.CanvasRect.Height;

            //  Set the projection matrix.
            OpenGL.MatrixMode(OpenGL.GL_PROJECTION);

            //  Load the identity.
            OpenGL.LoadIdentity();
            ////  Create a perspective transformation.
            //OpenGL.gluPerspective(60.0f, width / height, 0.01, 100.0);
            mat4 projectionMatrix = glm.perspective(glm.radians(60.0f), width / height, 0.01f, 100.0f);
            OpenGL.MultMatrixf((projection * view).ToArray());

            //  Set the modelview matrix.
            OpenGL.MatrixMode(OpenGL.GL_MODELVIEW);
            //this.LegacyTransform();
            OpenGL.Color(1.0f, 0, 0, 1.0f);

            //画控制点
            OpenGL.PointSize(2.5f);
            OpenGL.Begin(OpenGL.GL_LINES);
            unsafe
            {
                var array = (vec3*)controlPoints.Header.ToPointer();
                for (int i = 0; i < numOfPoints; ++i)
                {
                    OpenGL.Vertex(array[i].x, array[i].y, array[i].z);
                }
            }
            OpenGL.End();
        }
    }
}