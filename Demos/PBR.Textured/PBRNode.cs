using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;
using System.Drawing;

namespace PBR.Textured {
    partial class PBRNode : ModernNode, IRenderable {
        public static PBRNode Create(IBufferSource model, vec3 size, string position, string texCoord, string normal, string tangent) {
            //var model = new NormalMappingModel();
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var array = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add("aPos", position);
            //map.Add("aTexCoords", texCoord);
            map.Add("aNormal", normal);
            //map.Add("inTangent", tangent);
            var builder = new RenderMethodBuilder(array, map);
            var node = new PBRNode(model, builder);
            node.ModelSize = size;
            node.Initialize();

            return node;
        }

        private PBRNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders) {
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

        private vec3 albedo = new vec3(0.5f, 0.0f, 0.0f);
        public vec3 Albedo {
            get { return albedo; }
            set { albedo = value; }
        }
        public float Metallic { get; set; }
        public float Roughness { get; set; }
        private float ao = 1.0f;
        public float AO {
            get { return ao; }
            set { ao = value; }
        }

        // lights
        // ------
        vec3[] lightPositions = {
            new vec3(-10.0f,  10.0f, 10.0f),
            new vec3( 10.0f,  10.0f, 10.0f),
            new vec3(-10.0f, -10.0f, 10.0f),
            new vec3( 10.0f, -10.0f, 10.0f),
        };
        vec3[] lightColors = {
            new vec3(300.0f, 300.0f, 300.0f),
            new vec3(300.0f, 300.0f, 300.0f),
            new vec3(300.0f, 300.0f, 300.0f),
            new vec3(300.0f, 300.0f, 300.0f)
        };

        public void RenderBeforeChildren(RenderEventArgs arg) {
            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            mat4 normal = glm.transpose(glm.inverse(view * model));

            RenderMethod method = this.RenderUnit.Methods[0];
            ShaderProgram program = method.Program;
            program.SetUniform("projection", projection);
            program.SetUniform("view", view);
            program.SetUniform("model", model);
            program.SetUniform("albedo", Albedo);
            program.SetUniform("metallic", Metallic);
            program.SetUniform("roughness", Roughness);
            program.SetUniform("ao", AO);
            program.SetUniform("lightPositions", lightPositions);
            program.SetUniform("lightColors", lightColors);
            program.SetUniform("camPos", camera.Position);

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
            // nothing to do.
        }
    }
}
