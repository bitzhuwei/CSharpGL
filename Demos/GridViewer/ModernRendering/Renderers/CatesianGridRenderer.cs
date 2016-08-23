using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridViewer
{
    public partial class CatesianGridRenderer : GridViewRenderer
    {
        private Texture codedColorSampler;

        public static CatesianGridRenderer Create(vec3 originalWorldPosition, CatesianGrid grid, Texture codedColorSampler)
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\HexahedronGrid.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\HexahedronGrid.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("in_Position", CatesianGrid.strPosition);
            map.Add("in_uv", CatesianGrid.strColor);
            var renderer = new CatesianGridRenderer(originalWorldPosition, grid, shaderCodes, map, codedColorSampler);
            renderer.lengths = grid.DataSource.SourceActiveBounds.Max - grid.DataSource.SourceActiveBounds.Min;
            renderer.ModelMatrix = glm.translate(mat4.identity(), -grid.DataSource.Position);
            return renderer;
        }

        private CatesianGridRenderer(vec3 originalWorldPosition, CatesianGrid catesianGrid, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, Texture codedColorSampler, params GLSwitch[] switches)
            : base(originalWorldPosition, catesianGrid, shaderCodes, propertyNameMap, switches)
        {
            this.codedColorSampler = codedColorSampler;
        }


        protected override void DoInitialize()
        {
            base.DoInitialize();

            this.SetUniform("colorCodeSampler", new samplerValue(
                BindTextureTarget.Texture1D, this.codedColorSampler.Id, OpenGL.GL_TEXTURE0));
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            this.SetUniform("projectionMatrix", arg.Camera.GetProjectionMat4());
            this.SetUniform("viewMatrix", arg.Camera.GetViewMat4());
            this.SetUniform("modelMatrix", this.ModelMatrix);

            base.DoRender(arg);
        }

        private vec3 lengths;
        public override float XLength { get { return lengths.x; } }

        public override float YLength { get { return lengths.y; } }

        public override float ZLength { get { return lengths.z; } }
    }
}
