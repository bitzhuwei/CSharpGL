using CSharpGL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace GridViewer
{
    public class BoudingBoxRenderer : Renderer, IBoundingBox
    {

        /// <summary>
        /// get a bounding box renderer.
        /// </summary>
        /// <param name="lengths">bounding box's length at x, y, z axis.</param>
        /// <returns></returns>
        public static BoudingBoxRenderer GetBoundingBoxRenderer(vec3 lengths)
        {
            var bufferable = new BoundingBoxModel(lengths);
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(
                @"Resources\BoundingBox.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(
                @"Resources\BoundingBox.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("in_Position", BoundingBoxModel.strPosition);
            var result = new BoudingBoxRenderer(bufferable, shaderCodes, map, new PolygonModeSwitch(PolygonModes.Lines), new PolygonOffsetFillSwitch());

            return result;
        }

        /// <summary>
        /// Rendering something using GLSL shader and VBO(VAO).
        /// </summary>
        /// <param name="bufferable">model data that can be transfermed into OpenGL Buffer's pointer.</param>
        /// <param name="shaderCodes">All shader codes needed for this renderer.</param>
        /// <param name="propertyNameMap">Mapping relations between 'in' variables in vertex shader in <see cref="shaderCodes"/> and buffers in <see cref="bufferable"/>.</param>
        ///<param name="switches">OpenGL switches.</param>
        private BoudingBoxRenderer(IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, switches)
        {
            this.BoundingBoxColor = new vec3(1, 1, 1);
        }

        public vec3 BoundingBoxColor { get; set; }

        protected override void DoRender(RenderEventArg arg)
        {
            mat4 projection = arg.Camera.GetProjectionMat4();
            mat4 view = arg.Camera.GetViewMat4();
            this.SetUniform("projectionMatrix", projection);
            this.SetUniform("viewMatrix", view);
            this.SetUniform("modelMatrix", glm.translate(mat4.identity(), this.WorldPosition));
            this.SetUniform("boundingBoxColor", this.BoundingBoxColor);

            base.DoRender(arg);
        }

        public vec3 MaxPosition { get; set; }

        public vec3 MinPosition { get; set; }

        public vec3 WorldPosition { get { return MaxPosition / 2 + MinPosition / 2; } }
    }
}
