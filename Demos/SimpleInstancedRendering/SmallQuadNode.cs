using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace SimpleInstancedRendering
{
    partial class SmallQuadNode : ModernNode, IRenderable
    {
        private const string vertexCode = @"#version 330 core
layout (location = 0) in vec2 aPos;
layout (location = 1) in vec3 aColor;

out vec3 fColor;

uniform vec2 offsets[100];

void main()
{
    vec2 offset = offsets[gl_InstanceID];
    gl_Position = vec4(aPos + offset, 0.0, 1.0);
    fColor = aColor;
}";

        private const string fragmentCode = @"#version 330 core
out vec4 FragColor;

in vec3 fColor;

void main()
{
    FragColor = vec4(fColor, 1.0);
}";

        public static SmallQuadNode Create()
        {
            var model = new SmallQuadModel();
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var array = new ShaderArray(vs, fs);
            var map = new PropertyMap();
            map.Add("aPos", SmallQuadModel.strPosition);
            map.Add("aColor", SmallQuadModel.strColor);
            var builder = new RenderMethodBuilder(array, map);
            var node = new SmallQuadNode(model, builder);
            node.Initialize();

            return node;
        }

        private SmallQuadNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        {
        }
        protected override void DoInitialize()
        {
            base.DoInitialize();

            ShaderProgram program = this.RenderUnit.Methods[0].Program;
            var translations = new vec2[100];
            int index = 0;
            float offset = 0.1f;
            for (int y = -10; y < 10; y += 2)
            {
                for (int x = -10; x < 10; x += 2)
                {
                    var item = new vec2((float)x / 10.0f + offset, (float)y / 10.0f + offset);
                    translations[index++] = item;
                }
            }
            program.SetUniform("offsets", translations);
        }

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children | ThreeFlags.AfterChildren;
        /// <summary>
        /// Render before/after children? Render children? 
        /// RenderAction cares about this property. Other actions, maybe, maybe not, your choice.
        /// </summary>
        public ThreeFlags EnableRendering
        {
            get { return this.enableRendering; }
            set { this.enableRendering = value; }
        }

        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            RenderMethod method = this.RenderUnit.Methods[0];
            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }
    }
}
