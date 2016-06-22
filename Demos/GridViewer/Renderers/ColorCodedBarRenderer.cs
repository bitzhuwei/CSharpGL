using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridViewer
{
    class ColorCodedBarRenderer : RendererBase
    {
        public CodedColor[] CodedColors { get; private set; }

        public Renderer RectRenderer { get; private set; }

        public Renderer LineRenderer { get; private set; }

        public Renderer[] ValueRenderers { get; private set; }

        public ColorCodedBarRenderer(CodedColor[] codedColors)
        {
            this.CodedColors = codedColors;
            this.ValueRenderers = new Renderer[codedColors.Length];
        }

        protected override void DoInitialize()
        {
            throw new NotImplementedException();
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            throw new NotImplementedException();
        }

        protected override void DisposeUnmanagedResources()
        {
            throw new NotImplementedException();
        }

    }
}
