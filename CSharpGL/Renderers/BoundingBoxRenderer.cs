using CSharpGL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// Renders a bouding box.
    /// </summary>
    public class BoundingBoxRenderer : Renderer, IBoundingBox
    {
        /// <summary>
        /// get a bounding box renderer.
        /// </summary>
        /// <param name="max">bouding box's max position</param>
        /// <param name="min">bouding box's min position</param>
        /// <returns></returns>
        public static BoundingBoxRenderer GetBoundingBoxRenderer(vec3 max, vec3 min)
        {
            var bufferable = new BoundingBoxModel();
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
                @"Resources\BoundingBox.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
                @"Resources\BoundingBox.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("in_Position", BoundingBoxModel.strPosition);
            var result = new BoundingBoxRenderer(bufferable, shaderCodes, map, new PolygonModeSwitch(PolygonModes.Lines), new PolygonOffsetFillSwitch());
            result.MaxPosition = max;
            result.MinPosition = min;

            return result;
        }

        /// <summary>
        /// Rendering something using GLSL shader and VBO(VAO).
        /// </summary>
        /// <param name="bufferable">model data that can be transfermed into OpenGL Buffer's pointer.</param>
        /// <param name="shaderCodes">All shader codes needed for this renderer.</param>
        /// <param name="propertyNameMap">Mapping relations between 'in' variables in vertex shader in <paramref name="shaderCodes"/> and buffers in <paramref name="bufferable"/>.</param>
        ///<param name="switches">OpenGL switches.</param>
        private BoundingBoxRenderer(IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, switches)
        {
            this.BoundingBoxColor = new vec3(1, 1, 1);
        }

        /// <summary>
        /// 
        /// </summary>
        public vec3 BoundingBoxColor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        protected override void DoRender(RenderEventArg arg)
        {
            mat4 projection = arg.Camera.GetProjectionMat4();
            mat4 view = arg.Camera.GetViewMat4();
            this.SetUniform("projectionMatrix", projection);
            this.SetUniform("viewMatrix", view);
            mat4 model = glm.translate(mat4.identity(), this.GetCenter());
            model = glm.scale(model, this.MaxPosition - this.MinPosition);
            this.SetUniform("modelMatrix", model);
            this.SetUniform("boundingBoxColor", this.BoundingBoxColor);

            base.DoRender(arg);
        }

        /// <summary>
        /// 
        /// </summary>
        public vec3 MaxPosition { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public vec3 MinPosition { get; set; }

    }
}
