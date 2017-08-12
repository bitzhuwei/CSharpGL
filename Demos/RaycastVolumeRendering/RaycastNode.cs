using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RaycastVolumeRendering
{
    public partial class RaycastNode : PickableNode
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static RaycastNode Create()
        {
            var model = new RaycastModel();
            RenderUnitBuilder backfaceBuilder, raycastingBuilder;
            {
                var vs = new VertexShader(backfaceVert, "position", "boundingBox");
                var fs = new FragmentShader(backfaceFrag);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("position", RaycastModel.strposition);
                map.Add("boundingBox", RaycastModel.strcolor);
                backfaceBuilder = new RenderUnitBuilder(provider, map, new CullFaceState(CullFaceMode.Front, true));
            }
            {
                var vs = new VertexShader(raycastingVert, "position", "boundingBox");
                var fs = new FragmentShader(raycastingFrag);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("position", RaycastModel.strposition);
                map.Add("boundingBox", RaycastModel.strcolor);
                raycastingBuilder = new RenderUnitBuilder(provider, map, new CullFaceState(CullFaceMode.Back, true));
            }

            var node = new RaycastNode(model, RaycastModel.strposition, backfaceBuilder, raycastingBuilder);
            node.Initialize();

            return node;
        }

        private RaycastNode(IBufferSource model, string positionNameInIBufferSource, params RenderUnitBuilder[] builders)
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
