using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace Lights
{
    /// <summary>
    /// 
    /// </summary>
    public partial class LightingNode : PickableNode
    {
        const int pointLightIndex = 0;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="position"></param>
        /// <param name="normal"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static LightingNode Create(IBufferSource model, string position, string normal, vec3 size)
        {
            var builders = new List<RenderUnitBuilder>();
            {
                var vs = new VertexShader(pointLightVert, vPosition, vNormal);
                var fs = new FragmentShader(pointLightFrag);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add(vPosition, position);
                map.Add(vNormal, normal);
                builders.Add(new RenderUnitBuilder(provider, map));
            }

            var node = new LightingNode(model, position, builders.ToArray());
            node.ModelSize = size;

            node.Initialize();

            return node;
        }

        private LightingNode(IBufferSource model, string positionNameInIBufferSource, params RenderUnitBuilder[] builders)
            : base(model, positionNameInIBufferSource, builders)
        { }

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
