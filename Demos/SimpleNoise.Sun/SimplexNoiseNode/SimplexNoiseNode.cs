using CSharpGL;
using System.IO;

namespace SimpleNoise.Sun
{
    partial class SimplexNoiseNode : PickableNode, IRenderable
    {
        public static SimplexNoiseNode Create()
        {
            var model = new Sphere(1, 180, 360);
            RenderMethodBuilder renderBuilder;
            {
                var vs = new VertexShader(renderVert);
                var fs = new FragmentShader(renderFrag);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("in_Position", Sphere.strPosition);
                renderBuilder = new RenderMethodBuilder(provider, map);
            }
            var node = new SimplexNoiseNode(model, Sphere.strPosition, renderBuilder);
            node.ModelSize = model.Size;
            node.Initialize();

            return node;
        }

        private SimplexNoiseNode(IBufferSource model, string positionNameInIBufferSource, params RenderMethodBuilder[] builders)
            : base(model, positionNameInIBufferSource, builders)
        {
        }

    }
}