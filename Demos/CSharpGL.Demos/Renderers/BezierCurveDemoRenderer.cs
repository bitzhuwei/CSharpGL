using System.Drawing;

namespace CSharpGL.Demos
{
    /// <summary>
    ///
    /// </summary>
    [DemoRenderer]
    public class BezierCurveDemoRenderer : RendererBase
    {
        static private vec3[] points = new vec3[]{
             new vec3(-4.0f, 0.0f, 0.0f),
             new vec3(-6.0f, 4.0f, 0.0f),
             new vec3(6.0f, -4.0f, 0.0f),
             new vec3(4.0f, 0.0f, 0.0f),
        };

        //private static vec3 lengths;
        private Evaluator1DRenderer evaluator1DRenderer;

        //static BezierCurveDemoRenderer()
        //{
        //    BoundingBox box = points.Move2Center();
        //    lengths = box.MaxPosition - box.MinPosition;
        //}

        public PointSizeSwitch PointSize { get; private set; }

        public Color PointColor { get; set; }

        public DrawMode PointDrawMode { get; set; }

        public bool RenderControlPoints { get; set; }

        /// <summary>
        ///
        /// </summary>
        public BezierCurveDemoRenderer()
        {
            //this.Lengths = lengths;
            this.PointSize = new PointSizeSwitch(10.0f);
            this.PointColor = Color.Aqua;
            this.PointDrawMode = DrawMode.Points;
            this.RenderControlPoints = true;
            this.evaluator1DRenderer = new Evaluator1DRenderer(points);//, lengths);
        }

        /// <summary>
        /// TODO: dispose this ...
        /// </summary>

        protected override void DoInitialize()
        {
            this.evaluator1DRenderer.Initialize();
        }

        /// <summary>
        ///
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

            if (this.RenderControlPoints)
            {
                //画控制点
                vec4 color = this.PointColor.ToVec4();
                OpenGL.Color(color.x, color.y, color.z, color.w);
                this.PointSize.On();
                OpenGL.Begin(this.PointDrawMode);
                for (int i = 0; i < points.Length; ++i)
                {
                    OpenGL.Vertex(points[i].x, points[i].y, points[i].z);
                }
                OpenGL.End();
                this.PointSize.Off();
            }

            this.evaluator1DRenderer.Render(arg);
        }
    }
}