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
            renderer.Lengths = (grid.DataSource.SourceActiveBounds.MaxPosition - grid.DataSource.SourceActiveBounds.MinPosition).Abs();
            renderer.WorldPosition = -grid.DataSource.Position;
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
            this.SetUniform("projectionMatrix", arg.Camera.GetProjectionMatrix());
            this.SetUniform("viewMatrix", arg.Camera.GetViewMatrix());
            if (this.modelMatrixRecord.IsMarked())
            {
                this.SetUniform("modelMatrix", this.GetMatrix());
                this.modelMatrixRecord.CancelMark();
            }

            base.DoRender(arg);
        }

    }
}
