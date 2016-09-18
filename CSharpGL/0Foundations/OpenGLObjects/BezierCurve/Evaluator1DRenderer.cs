using System.Collections.Generic;
using System.Drawing;

namespace CSharpGL
{
    /// <summary>
    /// This is a 1D evaluator, i.e a bezier curve.
    /// </summary>
    public class Evaluator1DRenderer : EvaluatorRenderer
    {

        private float minU = 0;
        private float maxU = 100;

        /// <summary>
        /// 
        /// </summary>
        public DrawMode CurveDrawMode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float MinPercent { get; set; }

        private float granularity = 1.0f;

        /// <summary>
        /// 
        /// </summary>
        public float Granularity
        {
            get { return granularity; }
            set
            {
                if (value < 0.01f)
                { granularity = 0.01f; }
                else
                { granularity = value; }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public float MaxPercent { get; set; }

        /// <summary>
        /// This is a 1D evaluator, i.e a bezier curve.
        /// </summary>
        public Evaluator1DRenderer(IList<vec3> controlPoints, vec3 lengths)
            : base(controlPoints, lengths)
        {
            this.CurveDrawMode = DrawMode.LineStrip;
            this.MinPercent = 0;
            this.MaxPercent = 100;
            this.Granularity = 1.0f;
        }

        /// <summary>
        /// </summary>
        protected override void DoInitialize()
        {
            OpenGL.Map1f(OpenGL.GL_MAP1_VERTEX_3, //生成的数据类型
                minU, //u值的下界
                maxU, //u值的上界
                3, //顶点在数据中的间隔，x,y,z所以间隔是3
                controlPoints.Length, //u方向上的阶，即控制点的个数
                controlPoints.Header//指向控制点数据的指针
                );
            controlPoints.Dispose();
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

            //必须在绘制顶点之前开启
            OpenGL.Enable(OpenGL.GL_MAP1_VERTEX_3);

            vec4 color = this.CurveColor.ToVec4();
            OpenGL.Color(color.x, color.y, color.z, color.w);
            this.CurveWidth.On();
            //使用画线的方式来连接点
            OpenGL.Begin(this.CurveDrawMode);
            //OpenGL.Begin(OpenGL.GL_TRIANGLES);
            float granularity = this.Granularity;
            for (float i = this.MinPercent; i <= this.MaxPercent; i += granularity)
            {
                OpenGL.EvalCoord1f((float)i);
            }
            OpenGL.End();
            this.CurveWidth.Off();
        }
    }
}