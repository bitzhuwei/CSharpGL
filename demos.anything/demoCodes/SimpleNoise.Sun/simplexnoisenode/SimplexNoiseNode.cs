using CSharpGL;
using System.Diagnostics;
using System.IO;

namespace SimpleNoise.Sun {
    partial class SimplexNoiseNode : PickableNode, IRenderable {
        public static SimplexNoiseNode Create() {
            var model = new Sphere(1, 180, 360);
            RenderMethodBuilder renderBuilder;
            {
                var program = GLProgram.Create(renderVert, renderFrag); Debug.Assert(program != null);
                var map = new AttributeMap();
                map.Add("inPosition", Sphere.strPosition);
                renderBuilder = new RenderMethodBuilder(program, map);
            }
            var node = new SimplexNoiseNode(model, Sphere.strPosition, renderBuilder);
            node.ModelSize = model.Size;
            node.Initialize();

            return node;
        }

        private SimplexNoiseNode(IBufferSource model, string positionNameInIBufferSource, params RenderMethodBuilder[] builders)
            : base(model, positionNameInIBufferSource, builders) {
        }

    }
}