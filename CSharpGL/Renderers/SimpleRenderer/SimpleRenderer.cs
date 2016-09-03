using System;

namespace CSharpGL
{
    /// <summary>
    /// Renders a simple model embeded in CSharpGL.
    /// </summary>
    public partial class SimpleRenderer : Renderer
    {
        /// <summary>
        /// 
        /// </summary>
        public enum ModelTypes
        {
            /// <summary>
            /// 
            /// </summary>
            Axis,
            /// <summary>
            /// 
            /// </summary>
            Tetrahedron,
            /// <summary>
            /// 
            /// </summary>
            Cube,
            /// <summary>
            /// 
            /// </summary>
            Sphere,
            /// <summary>
            /// 
            /// </summary>
            Teapot,
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public static SimpleRenderer Create(ModelTypes modelType)
        {
            ShaderCode[] shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(ManifestResourceLoader.LoadTextFile(@"Resources\Simple.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(ManifestResourceLoader.LoadTextFile(@"Resources\Simple.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("in_Position", "position");
            map.Add("in_Color", "color");
            IBufferable model = null;
            vec3 lengths = new vec3();
            switch (modelType)
            {
                case ModelTypes.Axis:
                    var axis = new Axis();
                    lengths = axis.Lengths;
                    model = axis;
                    break;

                case ModelTypes.Tetrahedron:
                    var tetra = new Tetrahedron();
                    lengths = tetra.Lengths;
                    model = tetra;
                    break;

                case ModelTypes.Cube:
                    var cube = new Cube();
                    lengths = cube.Lengths;
                    model = cube;
                    break;

                case ModelTypes.Sphere:
                    var sphere = new Sphere();
                    lengths = sphere.Lengths;
                    model = sphere;
                    break;

                case ModelTypes.Teapot:
                    var teapot = new Teapot();
                    lengths = teapot.Lengths;
                    model = teapot;
                    break;

                default:
                    throw new NotImplementedException();
            }
            var tetrahedron = new SimpleRenderer(model, shaderCodes, map);
            tetrahedron.Lengths = lengths;
            return tetrahedron;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="model"></param>
        /// <param name="shaderCodes"></param>
        /// <param name="propertyNameMap"></param>
        /// <param name="switches"></param>
        public SimpleRenderer(IBufferable model, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, params GLSwitch[] switches)
            : base(model, shaderCodes, propertyNameMap, switches)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        protected override void DoRender(RenderEventArgs arg)
        {
            if (this.modelMatrixRecord.IsMarked())
            {
                this.SetUniform("modelMatrix", this.GetModelMatrix());
                this.modelMatrixRecord.CancelMark();
            }
            mat4 projection = arg.Camera.GetProjectionMatrix();
            mat4 view = arg.Camera.GetViewMatrix();
            this.SetUniform("projectionMatrix", projection);
            this.SetUniform("viewMatrix", view);

            base.DoRender(arg);
        }
    }
}