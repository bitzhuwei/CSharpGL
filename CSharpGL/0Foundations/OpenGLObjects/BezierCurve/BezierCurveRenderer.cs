using System.Collections.Generic;
using System.ComponentModel;

namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public partial class BezierCurveRenderer : BezierRenderer, IColorCodedPicking
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BezierCurveRenderer"/> class.
        /// </summary>
        public BezierCurveRenderer(IList<vec3> controlPoints)
        {
            var points = new UnmanagedArray<vec3>(controlPoints.Count);
            unsafe
            {
                var array = (vec3*)points.Header.ToPointer();
                for (int i = 0; i < points.Length; i++)
                {
                    array[i] = controlPoints[i];
                }
            }
            this.ControlPoints = points;
        }

        protected override void DoInitialize()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        protected override void DoRender(RenderEventArgs arg)
        {
            //	Create the evaluator.
            OpenGL.Map1f(OpenGL.GL_MAP1_VERTEX_3,//	Use and produce 3D points.
                0,								//	Low order value of 'u'.
                1,								//	High order value of 'u'.
                3,								//	Size (bytes) of a control point.
                ControlPoints.Length,			//	Order (i.e degree plus one).
                ControlPoints.Header);	//	The control points.

            //	Enable the type of evaluator we wish to use.
            OpenGL.Enable(OpenGL.GL_MAP1_VERTEX_3);

            //	Beging drawing a line strip.
            OpenGL.Begin(OpenGL.GL_LINE_STRIP);

            //	Now draw it.
            for (int i = 0; i <= segments; i++)
            { OpenGL.EvalCoord1f((float)i / segments); }

            OpenGL.End();

            //	Draw the control points.
        }

        /// <summary>
        /// The segments.
        /// </summary>
        private int segments = 30;

        /// <summary>
        /// Gets or sets the segments.
        /// </summary>
        /// <value>
        /// The segments.
        /// </value>
        [Description("The number of segments."), Category("Evaluator")]
        public int Segments
        {
            get { return segments; }
            set { segments = value; }
        }

    }
}