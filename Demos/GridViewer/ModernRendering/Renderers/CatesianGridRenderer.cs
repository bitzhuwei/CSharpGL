using CSharpGL;
using System.IO;

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
            var map = new AttributeMap();
            map.Add("in_Position", CatesianGrid.strPosition);
            map.Add("in_uv", CatesianGrid.strColor);
            var renderer = new CatesianGridRenderer(originalWorldPosition, grid, shaderCodes, map, codedColorSampler);
            renderer.Lengths = (grid.DataSource.SourceActiveBounds.MaxPosition - grid.DataSource.SourceActiveBounds.MinPosition).Abs();
            renderer.WorldPosition = -grid.DataSource.Position;
            return renderer;
        }

        private CatesianGridRenderer(vec3 originalWorldPosition, CatesianGrid catesianGrid, ShaderCode[] shaderCodes,
            AttributeMap attributeMap, Texture codedColorSampler, params GLSwitch[] switches)
            : base(originalWorldPosition, catesianGrid, shaderCodes, attributeMap, switches)
        {
            this.codedColorSampler = codedColorSampler;
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            this.SetUniform("colorCodeSampler", new samplerValue(
                TextureTarget.Texture1D, this.codedColorSampler.Id, 0));
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            this.SetUniform("projectionMatrix", arg.Camera.GetProjectionMatrix());
            this.SetUniform("viewMatrix", arg.Camera.GetViewMatrix());
            if (this.modelMatrixRecord.IsMarked())
            {
                this.SetUniform("modelMatrix", this.GetModelMatrix());
                this.modelMatrixRecord.CancelMark();
            }

            base.DoRender(arg);
        }
    }
}