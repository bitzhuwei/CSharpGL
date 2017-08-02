using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace OrderIndependentTransparency
{
    public partial class OITNode : PickableNode
    {
        private const string vPosition = "vPosition";
        private const string vNormal = "vNormal";

        const int buildLists = 0;
        const int resolveLists = 1;
        public static OITNode Create(IBufferSource model, string position, string normal, vec3 size)
        {
            var builders = new RenderUnitBuilder[2];
            {
                var vs = new VertexShader(buildListsVert, vPosition, vNormal);
                var fs = new FragmentShader(buildListsFrag);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add(vPosition, position);
                map.Add(vNormal, normal);
                builders[buildLists] = new RenderUnitBuilder(provider, map);
            }
            {
                var vs = new VertexShader(resolveListsVert, vPosition, vNormal);
                var fs = new FragmentShader(resolveListsFrag);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add(vPosition, position);
                map.Add(vNormal, normal);
                builders[resolveLists] = new RenderUnitBuilder(provider, map);
            }
            var node = new OITNode(model, position, builders);
            node.ModelSize = size;
            node.Children.Add(new LegacyBoundingBoxNode(size));

            node.Initialize();

            return node;
        }

        private OITNode(IBufferSource model, string positionNameInIBufferSource, params RenderUnitBuilder[] builders)
            : base(model, positionNameInIBufferSource, builders)
        {
        }

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            throw new NotImplementedException();
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
            throw new NotImplementedException();
        }
    }
}
