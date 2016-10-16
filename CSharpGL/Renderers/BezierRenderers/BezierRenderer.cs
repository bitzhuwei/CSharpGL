using System.Collections.Generic;

namespace CSharpGL
{
    /// <summary>
    /// Rendering a evaluator(a bezier curve or surface) and its control points.
    /// </summary>
    public partial class BezierRenderer : PointsRenderer
    {
        /// <summary>
        /// Creates a renderer that renders a evaluator(a bezier curve or surface) and its control points.
        /// </summary>
        /// <param name="controlPoints"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static BezierRenderer Create(IList<vec3> controlPoints, BezierType type)
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(ManifestResourceLoader.LoadTextFile(@"Resources\Points.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(ManifestResourceLoader.LoadTextFile(@"Resources\Points.frag"), ShaderType.FragmentShader);
            var map = new CSharpGL.AttributeMap();
            map.Add("in_Position", Points.strposition);
            var model = new Points(controlPoints);
            var renderer = new BezierRenderer(controlPoints, type, model, shaderCodes, map, Points.strposition);
            renderer.ModelSize = model.Lengths;
            renderer.SetWorldPosition(model.WorldPosition);
            renderer.switchList.Add(new PointSizeSwitch(10));

            return renderer;
        }

        /// <summary>
        /// Rendering a evaluator(a bezier curve or surface) and its control points.
        /// </summary>
        /// <param name="controlPoints"></param>
        /// <param name="type"></param>
        /// <param name="model"></param>
        /// <param name="shaderCodes"></param>
        /// <param name="attributeMap"></param>
        /// <param name="positionNameInIBufferable"></param>
        /// <param name="switches"></param>
        private BezierRenderer(IList<vec3> controlPoints, BezierType type, Points model, CSharpGL.ShaderCode[] shaderCodes, CSharpGL.AttributeMap attributeMap, string positionNameInIBufferable, params GLSwitch[] switches) :
            base(model, shaderCodes, attributeMap, positionNameInIBufferable, switches)
        {
            switch (type)
            {
                case BezierType.Curve:
                    this.Evaluator = new Evaluator1DRenderer(controlPoints);//, lengths);
                    break;

                case BezierType.Surface:
                    this.Evaluator = new Evaluator2DRenderer(controlPoints);//, lengths);
                    break;

                default:
                    throw new System.NotImplementedException();
            }
        }

        /// <summary>
        /// Rendering a evaluator(a bezier curve or surface).
        /// </summary>
        public EvaluatorRenderer Evaluator { get; private set; }

        /// <summary>
        ///
        /// </summary>
        protected override void DoInitialize()
        {
            base.DoInitialize();

            this.Evaluator.Initialize();
            //this.UpdateEvaluator();
        }

        //private bool needsUpdating = false;
        private long worldPositionTicks;
        private long scaleTicks;
        private long rotateAngleTicks;
        private long rotateAxisTicks;
        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        protected override void DoRender(RenderEventArgs arg)
        {
            long ticks = this.WorldPosition.UpdateTicks;
            if (ticks != this.worldPositionTicks)
            {
                this.UpdateEvaluator();
                this.worldPositionTicks = ticks;
            }
            // else if()

            this.Evaluator.Render(arg);

            base.DoRender(arg);
        }

        /// <summary>
        ///
        /// </summary>
        public override float RotationAngleDegree
        {
            get
            {
                return base.RotationAngleDegree;
            }
            set
            {
                if (base.RotationAngleDegree != value)
                {
                    //this.needsUpdating = true;
                }
                base.RotationAngleDegree = value;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public override vec3 RotationAxis
        {
            get
            {
                return base.RotationAxis;
            }
            set
            {
                if (base.RotationAxis != value)
                {
                    //this.needsUpdating = true;
                }
                base.RotationAxis = value;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public override vec3 Scale
        {
            get
            {
                return base.Scale;
            }
            set
            {
                if (base.Scale != value)
                {
                    //this.needsUpdating = true;
                }
                base.Scale = value;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} Evaluator: {1}", base.ToString(), this.Evaluator);
        }
    }
}