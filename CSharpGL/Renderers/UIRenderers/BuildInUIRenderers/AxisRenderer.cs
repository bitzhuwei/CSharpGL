using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    class AxisRenderer : Renderer
    {
        private int partCount;

        private IndexBufferPtr originalIndexBufferPtr;
        private IndexBufferPtr[] whiteLineIndexBufferPtrs = new IndexBufferPtr[3];
        private LineWidthSwitch lineWidthSwitch;

        public LineWidthSwitch LineWidthSwitch
        {
            get { return lineWidthSwitch; }
        }

        public static AxisRenderer Create(int partCount = 24)
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
@"Resources.UIAxis.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
@"Resources.UIAxis.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("in_Position", "position");
            map.Add("in_Color", "color");
            var model = new Axis(partCount);
            var renderer = new AxisRenderer(model, shaderCodes, map, partCount);
            renderer.lineWidthSwitch = new LineWidthSwitch(1);

            return renderer;
        }

        private AxisRenderer(IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, int partCount, params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, switches)
        {
            this.partCount = partCount;
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            this.originalIndexBufferPtr = this.indexBufferPtr;
            for (int i = 0; i < this.whiteLineIndexBufferPtrs.Length; i++)
            {
                using (var buffer = new ZeroIndexBuffer(DrawMode.LineLoop,
                    (1 + (partCount + 1)) + i * (3 + 2 * partCount),
                    ((partCount))))
                {
                    this.whiteLineIndexBufferPtrs[i] = buffer.GetBufferPtr() as IndexBufferPtr;
                }
            }
        }

        protected override void DoRender(RenderEventArg arg)
        {
            this.SetUniform("renderWireframe", false);
            this.indexBufferPtr = this.originalIndexBufferPtr;
            base.DoRender(arg);

            this.SetUniform("renderWireframe", true);
            this.lineWidthSwitch.On();
            for (int i = 0; i < this.whiteLineIndexBufferPtrs.Length; i++)
            {
                this.indexBufferPtr = this.whiteLineIndexBufferPtrs[i];
                base.DoRender(arg);
            }
            this.lineWidthSwitch.Off();
        }
    }
}
