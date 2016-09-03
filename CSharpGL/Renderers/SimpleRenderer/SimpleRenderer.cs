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
            switch (modelType)
            {
                case ModelTypes.Axis:
                    model = new Axis();
                    break;

                case ModelTypes.Tetrahedron:
                    model = new Tetrahedron();
                    break;

                case ModelTypes.Cube:
                    model = new Cube();
                    break;

                case ModelTypes.Sphere:
                    model = new Sphere();
                    break;

                case ModelTypes.Teapot:
                    model = new Teapot();
                    break;

                default:
                    throw new NotImplementedException();
            }
            var tetrahedron = new SimpleRenderer(model, shaderCodes, map);

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
                this.SetUniform("modelMatrix", this.WorldPosition);
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