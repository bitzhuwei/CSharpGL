using CSharpGL;
using System.IO;

namespace SimpleNoise.Sun
{
    partial class SimplexNoiseNode : PickableNode
    {
        public static SimplexNoiseNode Create()
        {
            var model = new Sphere(1, 180, 360);
            RenderUnitBuilder renderBuilder;
            {
                var vs = new VertexShader(renderVert, "in_Position");
                var fs = new FragmentShader(renderFrag);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("in_Position", Sphere.strPosition);
                renderBuilder = new RenderUnitBuilder(provider, map);
            }
            var node = new SimplexNoiseNode(model, Sphere.strPosition, renderBuilder);
            node.ModelSize = model.Size;
            node.Initialize();

            return node;
        }

        private SimplexNoiseNode(IBufferSource model, string positionNameInIBufferSource, params RenderUnitBuilder[] builders)
            : base(model, positionNameInIBufferSource, builders)
        {
        }

    }
}