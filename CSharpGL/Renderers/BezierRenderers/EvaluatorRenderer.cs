using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CSharpGL
{
    /// <summary>
    /// This is an abstract evaluator i.e a bezier curve or surface.
    /// </summary>
    public abstract class EvaluatorRenderer : RendererBase
    {
        /// <summary>
        ///
        /// </summary>
        protected unsafe UnmanagedArray<vec3> controlPoints;

        /// <summary>
        ///
        /// </summary>
        public LineWidthSwitch CurveWidth { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public Color CurveColor { get; set; }

        /// <summary>
        /// This is a 1D evaluator, i.e a bezier curve.
        /// </summary>
        public EvaluatorRenderer(IList<vec3> controlPoints)//, vec3 lengths)
        {
            vec3[] points = controlPoints.ToArray();
            BoundingBox box = points.Move2Center();
            var array = new UnmanagedArray<vec3>(points.Length);
            unsafe
            {
                var pointer = (vec3*)array.Header.ToPointer();
                for (int i = 0; i < array.Length; i++)
                {
                    pointer[i] = points[i];
                }
            }
            this.controlPoints = array;
            this.Lengths = box.MaxPosition - box.MinPosition;
            // TODO: not needed. Why?
            //this.WorldPosition = box.MaxPosition / 2 + box.MinPosition / 2;

            this.CurveWidth = new LineWidthSwitch(3.0f);
            this.CurveColor = Color.Red;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="controlPoints"></param>
        public abstract void Setup(UnmanagedArray<vec3> controlPoints);
    }
}