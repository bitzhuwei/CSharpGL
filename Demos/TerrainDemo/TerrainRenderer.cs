using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrainDemo
{
    class TerrainRenderer : Renderer
    {
        public static TerrainRenderer GetRenderer(IList<vec3> positions)
        {
            BoundingBox boundingBox = positions.Move2Center();

            IBufferable model = new TerrainModel(positions);
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\Terrain.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\Terrain.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("in_Position", TerrainModel.strPosition);
            var renderer = new TerrainRenderer(model, shaderCodes, map, boundingBox,
                new PointSizeSwitch(10));
            return renderer;
        }

        private TerrainRenderer(IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, BoundingBox boundingBox, params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, switches)
        {
            this.BoundingBox = boundingBox;
            this.PointColor = Color.Green;
        }

        protected override void DoRender(RenderEventArg arg)
        {
            mat4 projection = arg.Camera.GetProjectionMat4();
            mat4 view = arg.Camera.GetViewMat4();
            mat4 model = glm.translate(mat4.identity(), this.BoundingBox.GetCenter());
            this.SetUniform("MVP", projection * view * model);
            this.SetUniform("color", this.PointColor.ToVec4());

            base.DoRender(arg);
        }

        public BoundingBox BoundingBox { get; set; }

        public Color PointColor { get; set; }
    }
}
