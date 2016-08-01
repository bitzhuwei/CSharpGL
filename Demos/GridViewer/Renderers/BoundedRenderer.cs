using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;


namespace GridViewer
{
    public partial class BoundedRenderer : RendererBase
    {
        private sampler1D codedColorSampler;
        /// <summary>
        /// Gets bounding box's renderer.
        /// </summary>
        public BoundingBoxRenderer BoxRenderer { get; private set; }

        /// <summary>
        /// Gets scientific model's renderer.
        /// </summary>
        public Renderer ScientificRenderer { get; private set; }

        public BoundedRenderer(Renderer scientificRenderer, vec3 lengths, sampler1D codedColorSampler)
        {
            if (scientificRenderer == null || codedColorSampler == null)
            { throw new ArgumentNullException(); }

            this.BoxRenderer = BoundingBoxRenderer.Create(lengths);
            this.ScientificRenderer = scientificRenderer;
            this.codedColorSampler = codedColorSampler;
        }

        protected override void DoInitialize()
        {
            Renderer boundingBox = this.BoxRenderer;
            if (boundingBox != null) { boundingBox.Initialize(); }

            Renderer scientific = this.ScientificRenderer;
            if (scientific != null)
            {
                scientific.Initialize();
                //var sampler1D = new sampler1D();
                //var bitmap = new Bitmap(@"Images\simColorCode.jpg");
                //sampler1D.Initialize(bitmap);
                //bitmap.Dispose();
                scientific.SetUniform("colorCodeSampler", new samplerValue(
                     BindTextureTarget.Texture1D, this.codedColorSampler.Id, OpenGL.GL_TEXTURE0));
                //BindTextureTarget.Texture1D, sampler1D.Id, OpenGL.GL_TEXTURE0));
            }
        }

        protected override void DoRender(RenderEventArg arg)
        {
            mat4 projection = arg.Camera.GetProjectionMat4();
            mat4 view = arg.Camera.GetViewMat4();

            Renderer boundingBox = this.BoxRenderer;
            if (boundingBox != null) { boundingBox.Render(arg); }

            Renderer renderer = this.ScientificRenderer;
            if (renderer != null) { renderer.Render(arg); }
        }

        protected override void DisposeUnmanagedResources()
        {
            BoundingBoxRenderer boundingBox = this.BoxRenderer;
            if (boundingBox != null) { boundingBox.Dispose(); }

            Renderer scientific = this.ScientificRenderer;
            if (scientific != null) { scientific.Dispose(); }
        }

    }
}
