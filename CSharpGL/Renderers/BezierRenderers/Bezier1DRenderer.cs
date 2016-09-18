using System.Collections.Generic;

namespace CSharpGL
{
    /// <summary>
    /// Rendering a 1D evaluator(a bezier curve) and its control points.
    /// </summary>
    public partial class Bezier1DRenderer : PointsRenderer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="controlPoints"></param>
        /// <returns></returns>
        public static new Bezier1DRenderer Create(IList<vec3> controlPoints)
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(ManifestResourceLoader.LoadTextFile(@"Resources\Points.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(ManifestResourceLoader.LoadTextFile(@"Resources\Points.frag"), ShaderType.FragmentShader);
            var map = new CSharpGL.PropertyNameMap();
            map.Add("in_Position", Points.strposition);
            var model = new Points(controlPoints);
            var renderer = new Bezier1DRenderer(controlPoints, model, shaderCodes, map, Points.strposition);
            renderer.Lengths = model.Lengths;
            renderer.WorldPosition = model.WorldPosition;
            renderer.switchList.Add(new PointSizeSwitch(10));

            return renderer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="controlPoints"></param>
        /// <param name="bufferable"></param>
        /// <param name="shaderCodes"></param>
        /// <param name="propertyNameMap"></param>
        /// <param name="positionNameInIBufferable"></param>
        /// <param name="switches"></param>
        private Bezier1DRenderer(IList<vec3> controlPoints, Points bufferable, CSharpGL.ShaderCode[] shaderCodes, CSharpGL.PropertyNameMap propertyNameMap, string positionNameInIBufferable, params GLSwitch[] switches) :
            base(bufferable, shaderCodes, propertyNameMap, positionNameInIBufferable, switches)
        {
            this.Evaluator1DRenderer = new Evaluator1DRenderer(controlPoints);//, lengths);
        }

        /// <summary>
        /// Rendering a 1D evaluator(a bezier curve).
        /// </summary>
        public Evaluator1DRenderer Evaluator1DRenderer { get; private set; }

        /// <summary>
        ///
        /// </summary>
        protected override void DoInitialize()
        {
            this.Evaluator1DRenderer.Initialize();

            base.DoInitialize();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        protected override void DoRender(RenderEventArgs arg)
        {
            this.Evaluator1DRenderer.Render(arg);

            base.DoRender(arg);
        }

    }
}