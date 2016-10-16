using System.Drawing;

namespace CSharpGL
{
    //
    //        2-------------------3
    //      / .                  /|
    //     /  .                 / |
    //    /   .                /  |
    //   /    .               /   |
    //  /     .              /    |
    // 6--------------------7     |
    // |      .             |     |
    // |      0 . . . . . . |. . .1
    // |     .              |    /
    // |    .               |   /
    // |   .                |  /
    // |  .                 | /
    // | .                  |/
    // 4 -------------------5
    //
    /// <summary>
    /// Renders a bounding box.
    /// </summary>
    public class BoundingBoxRenderer : Renderer, IBoundingBox
    {
        /// <summary>
        /// get a bounding box renderer.
        /// </summary>
        /// <param name="lengths">bounding box's length at x, y, z direction.</param>
        /// <returns></returns>
        public static BoundingBoxRenderer Create(vec3 lengths)
        {
            var model = new BoundingBoxModel(lengths);
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
                @"Resources\BoundingBox.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
                @"Resources\BoundingBox.frag"), ShaderType.FragmentShader);
            var map = new AttributeMap();
            map.Add("in_Position", BoundingBoxModel.strPosition);
            var result = new BoundingBoxRenderer(model, shaderCodes, map, new PolygonModeSwitch(PolygonMode.Line), new PolygonOffsetFillSwitch());
            result.ModelSize = lengths;
            return result;
        }

        /// <summary>
        /// Rendering something using GLSL shader and VBO(VAO).
        /// </summary>
        /// <param name="model">model data that can be transfermed into OpenGL Buffer's pointer.</param>
        /// <param name="shaderCodes">All shader codes needed for this renderer.</param>
        /// <param name="attributeMap">Mapping relations between 'in' variables in vertex shader in <paramref name="shaderCodes"/> and buffers in <paramref name="model"/>.</param>
        ///<param name="switches">OpenGL switches.</param>
        private BoundingBoxRenderer(IBufferable model, ShaderCode[] shaderCodes,
            AttributeMap attributeMap, params GLSwitch[] switches)
            : base(model, shaderCodes, attributeMap, switches)
        {
            this.BoundingBoxColor = Color.White;
        }

        private UpdatingRecord boundingBoxColorRecord = new UpdatingRecord();
        private vec3 boundingBoxColor;

        /// <summary>
        ///
        /// </summary>
        public Color BoundingBoxColor
        {
            get { return boundingBoxColor.ToColor(); }
            set
            {
                vec3 color = value.ToVec3();
                if (color != boundingBoxColor)
                {
                    boundingBoxColor = color;
                    boundingBoxColorRecord.Mark();
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        protected override void DoRender(RenderEventArgs arg)
        {
            if (this.boundingBoxColorRecord.IsMarked())
            {
                this.SetUniform("boundingBoxColor", this.boundingBoxColor);
                this.boundingBoxColorRecord.CancelMark();
            }

            this.SetUniform("projectionMatrix", arg.Camera.GetProjectionMatrix());
            this.SetUniform("viewMatrix", arg.Camera.GetViewMatrix());
            mat4 model;
            if (this.GeUpdatedModelMatrix(out model))
            {
                this.SetUniform("modelMatrix", model);
            }

            base.DoRender(arg);
        }

        /// <summary>
        /// max position in world space.
        /// </summary>
        public vec3 MaxPosition
        {
            get
            {
                // NOTE: make sure this.ModelMatrix don't rotate.
                return new vec3(this.GetModelMatrix() * new vec4(this.ModelSize / 2, 1.0f));
            }
        }

        /// <summary>
        /// min position in world space.
        /// </summary>
        public vec3 MinPosition
        {
            get
            {
                // NOTE: make sure this.ModelMatrix don't rotate.
                return new vec3(this.GetModelMatrix() * new vec4(-this.ModelSize / 2, 1.0f));
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} min:{1}, max:{2}", base.ToString(), this.MinPosition, this.MaxPosition);
        }
    }
}