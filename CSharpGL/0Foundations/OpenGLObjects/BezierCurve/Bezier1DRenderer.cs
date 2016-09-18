using System.Collections.Generic;
using System.ComponentModel;

namespace CSharpGL
{
    /// <summary>
    /// Rendering a 1D evaluator(a bezier curve) and its control points.
    /// </summary>
    public partial class Bezier1DRenderer : RendererBase, IColorCodedPicking
    {
        /// <summary>
        /// Rendering a 1D evaluator(a bezier curve) and its control points.
        /// </summary>
        /// <param name="controlPoints"></param>
        /// <param name="lengths"></param>
        public Bezier1DRenderer(IList<vec3> controlPoints, vec3 lengths)
        {
            this.Evaluator1DRenderer = new Evaluator1DRenderer(controlPoints, lengths);
            var points = new Points(controlPoints);
            this.ControlPointsRenderer = PointsRenderer.Create(points);
            this.Lengths = points.Lengths;
        }

        /// <summary>
        /// Rendering a 1D evaluator(a bezier curve).
        /// </summary>
        public Evaluator1DRenderer Evaluator1DRenderer { get; private set; }

        /// <summary>
        /// Rendering a 1D evaluator's control points.
        /// </summary>
        public PointsRenderer ControlPointsRenderer { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected override void DoInitialize()
        {
            this.Evaluator1DRenderer.Initialize();
            this.ControlPointsRenderer.Initialize();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        protected override void DoRender(RenderEventArgs arg)
        {
            this.Evaluator1DRenderer.Render(arg);
            this.ControlPointsRenderer.Render(arg);
        }

        /// <summary>
        /// 
        /// </summary>
        public override vec3 WorldPosition
        {
            get
            {
                PointsRenderer controlPointsRenderer = this.ControlPointsRenderer;
                if (controlPointsRenderer != null) { return controlPointsRenderer.WorldPosition; }
                else { return new vec3(0, 0, 0); }
            }
            set
            {
                PointsRenderer controlPointsRenderer = this.ControlPointsRenderer;
                if (controlPointsRenderer != null) { controlPointsRenderer.WorldPosition = value; }
                Evaluator1DRenderer evaluator1DRenderer = this.Evaluator1DRenderer;
                if (evaluator1DRenderer != null) { evaluator1DRenderer.WorldPosition = value; }
            }
        }
    }
}