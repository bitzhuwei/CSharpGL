using CSharpGL;
using System.Collections.Generic;
using System.IO;

namespace FeasibilityTest
{
    internal class PointsRenderer : PickableRenderer
    {
        public static PointsRenderer Create(List<vec3> pointList)
        {
            BoundingBox box = pointList.Move2Center();
            var model = new PointsModel(pointList);
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"Points.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"Points.frag"), ShaderType.FragmentShader);
            var map = new AttributeMap();
            map.Add("in_Position", PointsModel.strPosition);
            var renderer = new PointsRenderer(model, shaderCodes, map, PointsModel.strPosition);
            //renderer.WorldPosition = box.MaxPosition / 2 + box.MinPosition / 2;
            renderer.ModelSize = box.MaxPosition - box.MinPosition;
            return renderer;
        }

        private PointsRenderer(IBufferable model, ShaderCode[] shaderCodes,
            AttributeMap attributeMap, string positionNameInIBufferable,
            params GLSwitch[] switches)
            : base(model, shaderCodes, attributeMap, positionNameInIBufferable, switches)
        { }

        protected override void DoRender(RenderEventArgs arg)
        {
            mat4 projection = arg.Camera.GetProjectionMatrix();
            mat4 view = arg.Camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix().Value;
            this.SetUniform("projectionMatrix", projection);
            this.SetUniform("viewMatrix", view);
            this.SetUniform("modelMatrix", model);

            base.DoRender(arg);
        }
    }
}