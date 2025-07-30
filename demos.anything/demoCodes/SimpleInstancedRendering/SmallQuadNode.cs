using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CSharpGL;

namespace SimpleInstancedRendering {
    partial class SmallQuadNode : ModernNode, IRenderable {
        private const string vertexCode = @"#version 330 core
in vec2 inPosition;
in vec3 inColor;

out vec3 passColor;

uniform vec2 offsets[100];

void main()
{
    vec2 offset = offsets[gl_InstanceID];
    gl_Position = vec4(inPosition + offset, 0.0, 1.0);
    passColor = inColor;
}";

        private const string fragmentCode = @"#version 330 core
out vec4 outColor;

in vec3 passColor;

void main()
{
    outColor = vec4(passColor, 1.0);
}";

        public static SmallQuadNode Create() {
            var model = new SmallQuadModel();
            var program = GLProgram.Create(vertexCode, fragmentCode); Debug.Assert(program != null);
            var map = new AttributeMap();
            map.Add("inPosition", SmallQuadModel.strPosition);
            map.Add("inColor", SmallQuadModel.strColor);
            var builder = new RenderMethodBuilder(program, map);
            var node = new SmallQuadNode(model, builder);
            node.Initialize();

            return node;
        }

        private SmallQuadNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders) {
        }
        protected override void DoInitialize() {
            base.DoInitialize();

            GLProgram program = this.RenderUnit.Methods[0].Program;
            var translations = new vec2[100];
            int index = 0;
            float offset = 0.1f;
            for (int y = -10; y < 10; y += 2) {
                for (int x = -10; x < 10; x += 2) {
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
        public ThreeFlags EnableRendering {
            get { return this.enableRendering; }
            set { this.enableRendering = value; }
        }

        public void RenderBeforeChildren(RenderEventArgs arg) {
            RenderMethod method = this.RenderUnit.Methods[0];
            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
        }
    }
}
