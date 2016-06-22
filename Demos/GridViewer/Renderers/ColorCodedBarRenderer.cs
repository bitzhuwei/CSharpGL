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
    class ColorCodedBarRenderer : UIRenderer
    {
        public CodedColor[] CodedColors { get; private set; }

        public Renderer RectRenderer { get; private set; }

        public Renderer LineRenderer { get; private set; }

        public Renderer[] ValueRenderers { get; private set; }

        public ColorCodedBarRenderer(CodedColor[] codedColors,
            AnchorStyles anchor, Padding margin,
            System.Drawing.Size size, int zNear, int zFar)
            : base(anchor, margin, size, zNear, zFar)
        {
            if (codedColors == null || codedColors.Length < 1)
            {
                throw new ArgumentException();
            }

            this.CodedColors = codedColors;
            {
                var shaderCodes = new ShaderCode[2];
                shaderCodes[0] = new ShaderCode(File.ReadAllText(
                    @"shaders\CodedColorBarRect.vert"), ShaderType.VertexShader);
                shaderCodes[1] = new ShaderCode(File.ReadAllText(
                    @"shaders\CodedColorBarRect.frag"), ShaderType.FragmentShader);
                var map = new PropertyNameMap();
                map.Add("in_Position", CodedColorBarRect.strPosition);
                map.Add("in_Coord", CodedColorBarRect.strCoord);
                var model = new CodedColorBarRect(codedColors);
                this.RectRenderer = new Renderer(model, shaderCodes, map);
            }
            this.ValueRenderers = new Renderer[codedColors.Length];
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
                bitmap.Dispose();
                rectRenderer.SetUniform("codedColorSampler", new samplerValue(
                     BindTextureTarget.Texture1D, sampler.Id, OpenGL.GL_TEXTURE0));
            }

            Renderer lineRenderer = this.LineRenderer;
            if (lineRenderer != null) { lineRenderer.Initialize(); }

            Renderer[] valueRenderers = this.ValueRenderers;
            for (int i = 0; i < valueRenderers.Length; i++)
            {
                if (valueRenderers[i] != null)
                { valueRenderers[i].Initialize(); }
            }
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            Renderer rectRenderer = this.RectRenderer;
            if (rectRenderer != null)
            {
                mat4 projection = this.GetOrthoProjection();
                mat4 view = glm.lookAt(new vec3(0, 0, 1), new vec3(0, 0, 0), new vec3(0, 1, 0));
                float length = Math.Max(this.Size.Width, this.Size.Height);
                mat4 model = glm.scale(mat4.identity(), new vec3(length, length, length));
                rectRenderer.SetUniform("mvp", projection * view * model);
                rectRenderer.Render(arg);
            }

            Renderer lineRenderer = this.LineRenderer;
            if (lineRenderer != null) { lineRenderer.Render(arg); }

            Renderer[] valueRenderers = this.ValueRenderers;
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

            Renderer[] valueRenderers = this.ValueRenderers;
            for (int i = 0; i < valueRenderers.Length; i++)
            {
                if (valueRenderers[i] != null)
                { valueRenderers[i].Dispose(); }
            }
        }

    }
}
