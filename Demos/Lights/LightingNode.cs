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
        private const string vPosition = "vPosition";
        private const string vNormal = "vNormal";
        private const string MVP = "MVP";
        private const string MV = "MV";
        private const string N = "N";
        private const string lightPosition = "lightPosition"; // TODO: we assume light's color is white(vec3(1, 1, 1))
        private const string lightDirection = "lightDirection"; // TODO: we assume light's color is white(vec3(1, 1, 1))
        private const string spotDirection = "spotDirection"; // TODO: we assume light's color is white(vec3(1, 1, 1))
        private const string spotCutoff = "spotCutoff";
        private const string spotExponent = "spotExponent";
        private const string diffuseColor = "diffuseColor";
        private const string constantAttenuation = "constantAttenuation";
        private const string linearAttenuation = "linearAttenuation";
        private const string quadraticAttenuation = "quadraticAttenuation";
        private const string ambientColor = "ambientColor";

        const int pointLightIndex = 0;
        class Tuple { public readonly string vs, fs; public Tuple(string vs, string fs) { this.vs = vs; this.fs = fs; } }
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
            var shaders = new List<Tuple>();
            shaders.Add(new Tuple(pointLightVert, pointLightFrag));
            shaders.Add(new Tuple(directionalLightVert, directionalLightFrag));
            shaders.Add(new Tuple(spotLightVert, spotLightFrag));
            foreach (var item in shaders)
            {
                var vs = new VertexShader(item.vs, vPosition, vNormal);
                var fs = new FragmentShader(item.fs);
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

        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
        }
    }
}
