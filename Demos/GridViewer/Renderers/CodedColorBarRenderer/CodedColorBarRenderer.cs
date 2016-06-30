using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridViewer
{
    class CodedColorBarRenderer : RendererBase
    {
        public sampler1D CodedColorSampler { get; private set; }

        public CodedColor[] CodedColors { get; private set; }

        public Renderer RectRenderer { get; private set; }

        public Renderer LineRenderer { get; private set; }

        public CodedColorValueRenderer[] ValueRenderers { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codedColors"></param>
        /// <param name="maxValueLength"></param>
        public CodedColorBarRenderer(CodedColor[] codedColors, int maxCharCount = 100)
        {
            if (codedColors == null || codedColors.Length < 1)
            {
                throw new ArgumentException();
            }

            this.CodedColors = codedColors;
            {
                var shaderCodes = new ShaderCode[2];
                shaderCodes[0] = new ShaderCode(File.ReadAllText(
                    @"shaders\ColorCodedBarRect.vert"), ShaderType.VertexShader);
                shaderCodes[1] = new ShaderCode(File.ReadAllText(
                    @"shaders\ColorCodedBarRect.frag"), ShaderType.FragmentShader);
                var map = new PropertyNameMap();
                map.Add("in_Position", CodedColorBarRect.strPosition);
                map.Add("in_Coord", CodedColorBarRect.strCoord);
                var model = new CodedColorBarRect(codedColors);
                this.RectRenderer = new Renderer(model, shaderCodes, map);
            }
            {
                var shaderCodes = new ShaderCode[2];
                shaderCodes[0] = new ShaderCode(File.ReadAllText(
                    @"shaders\ColorCodedBarLine.vert"), ShaderType.VertexShader);
                shaderCodes[1] = new ShaderCode(File.ReadAllText(
                    @"shaders\ColorCodedBarLine.frag"), ShaderType.FragmentShader);
                var map = new PropertyNameMap();
                map.Add("in_Position", CodedColorBarLine.strPosition);
                var model = new CodedColorBarLine(codedColors);
                this.LineRenderer = new Renderer(model, shaderCodes, map);
            }
            {
                this.ValueRenderers = new CodedColorValueRenderer[codedColors.Length];
                var shaderCodes = new ShaderCode[2];
                shaderCodes[0] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
@"Resources.TextModel.vert",1), ShaderType.VertexShader);
                shaderCodes[1] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
@"Resources.TextModel.frag",1), ShaderType.FragmentShader);
                var map = new PropertyNameMap();
                map.Add("position", "position");
                map.Add("uv", "uv");
                for (int i = 0; i < this.ValueRenderers.Length; i++)
                {
                    var valueModel = new TextModel(maxCharCount);
                    this.ValueRenderers[i] = new CodedColorValueRenderer(valueModel, shaderCodes, map);
                }
            }
        }

        protected override void DoInitialize()
        {
            Renderer rectRenderer = this.RectRenderer;
            if (rectRenderer != null)
            {
                rectRenderer.Initialize();
                Bitmap bitmap = this.CodedColors.GetBitmap(1024);
                var sampler = new sampler1D();
                sampler.Initialize(bitmap);
                this.CodedColorSampler = sampler;
                bitmap.Dispose();
                rectRenderer.SetUniform("codedColorSampler", new samplerValue(
                     BindTextureTarget.Texture1D, sampler.Id, OpenGL.GL_TEXTURE0));
            }

            Renderer lineRenderer = this.LineRenderer;
            if (lineRenderer != null) { lineRenderer.Initialize(); }

            CodedColorValueRenderer[] valueRenderers = this.ValueRenderers;
            for (int i = 0; i < valueRenderers.Length; i++)
            {
                if (valueRenderers[i] != null)
                {
                    valueRenderers[i].Initialize();
                    valueRenderers[i].Text = string.Format("{0}", this.CodedColors[i].Value);
                }
            }
        }

        protected override void DoRender(RenderEventArg arg)
        {
            Renderer rectRenderer = this.RectRenderer;
            if (rectRenderer != null)
            {
                rectRenderer.Render(arg);
            }

            Renderer lineRenderer = this.LineRenderer;
            if (lineRenderer != null) { lineRenderer.Render(arg); }

            CodedColorValueRenderer[] valueRenderers = this.ValueRenderers;
            for (int i = 0; i < valueRenderers.Length; i++)
            {
                if (valueRenderers[i] != null)
                { valueRenderers[i].Render(arg); }
            }
        }

        protected override void DisposeUnmanagedResources()
        {
            Renderer rectRenderer = this.RectRenderer;
            if (rectRenderer != null) { rectRenderer.Dispose(); }

            Renderer lineRenderer = this.LineRenderer;
            if (lineRenderer != null) { lineRenderer.Dispose(); }

            CodedColorValueRenderer[] valueRenderers = this.ValueRenderers;
            for (int i = 0; i < valueRenderers.Length; i++)
            {
                if (valueRenderers[i] != null)
                { valueRenderers[i].Dispose(); }
            }
        }

    }
}
