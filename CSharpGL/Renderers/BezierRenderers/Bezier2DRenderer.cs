using System.Collections.Generic;

namespace CSharpGL
{
    /// <summary>
    /// Rendering a 1D evaluator(a bezier surface) and its control points.
    /// </summary>
    public partial class Bezier2DRenderer : PointsRenderer
    {
        /// <summary>
        /// Creates a renderer that renders a 1D evaluator(a bezier surface) and its control points.
        /// </summary>
        /// <param name="controlPoints"></param>
        /// <returns></returns>
        public static Bezier2DRenderer Create(IList<vec3> controlPoints)
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(ManifestResourceLoader.LoadTextFile(@"Resources\Points.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(ManifestResourceLoader.LoadTextFile(@"Resources\Points.frag"), ShaderType.FragmentShader);
            var map = new CSharpGL.PropertyNameMap();
            map.Add("in_Position", Points.strposition);
            var model = new Points(controlPoints);
            var renderer = new Bezier2DRenderer(controlPoints, model, shaderCodes, map, Points.strposition);
            renderer.Lengths = model.Lengths;
            renderer.WorldPosition = model.WorldPosition;
            renderer.switchList.Add(new PointSizeSwitch(10));

            return renderer;
        }

        /// <summary>
        /// Rendering a 1D evaluator(a bezier curve) and its control points.
        /// </summary>
        /// <param name="controlPoints"></param>
        /// <param name="bufferable"></param>
        /// <param name="shaderCodes"></param>
        /// <param name="propertyNameMap"></param>
        /// <param name="positionNameInIBufferable"></param>
        /// <param name="switches"></param>
        private Bezier2DRenderer(IList<vec3> controlPoints, Points bufferable, CSharpGL.ShaderCode[] shaderCodes, CSharpGL.PropertyNameMap propertyNameMap, string positionNameInIBufferable, params GLSwitch[] switches) :
            base(bufferable, shaderCodes, propertyNameMap, positionNameInIBufferable, switches)
        {
            this.EvaluatorRenderer = new Evaluator2DRenderer(controlPoints);//, lengths);
        }

        /// <summary>
        /// Rendering a 2D evaluator(a bezier surface).
        /// </summary>
        public Evaluator2DRenderer EvaluatorRenderer { get; private set; }

        /// <summary>
        ///
        /// </summary>
        protected override void DoInitialize()
        {
            base.DoInitialize();

            this.EvaluatorRenderer.Initialize();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        protected override void DoRender(RenderEventArgs arg)
        {
            this.EvaluatorRenderer.Render(arg);

            base.DoRender(arg);
        }

    }
}