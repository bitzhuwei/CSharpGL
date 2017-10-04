using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;
using System.Drawing;

namespace Normal
{
    /// <summary>
    /// 
    /// </summary>
    public partial class NormalNode : PickableNode
    {
        private const string vPosition = "vPosition";
        private const string vNormal = "vNormal";
        private const string projectionMatrix = "projectionMatrix";
        private const string viewMatrix = "viewMatrix";
        private const string modelMatrix = "modelMatrix";
        private const string normalMatrix = "normalMatrix";
        private const string diffuseColor = "diffuseColor";
        private const string vertexColor = "vertexColor";
        private const string pointerColor = "pointerColor";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="position"></param>
        /// <param name="normal"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static NormalNode Create(IBufferSource model, string position, string normal, vec3 size)
        {
            var builders = new RenderMethodBuilder[2];
            {
                // render model
                var vs = new VertexShader(vertexShader, vPosition, vNormal);
                var fs = new FragmentShader(fragmentShader);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add(vPosition, position);
                map.Add(vNormal, normal);
                builders[0] = new RenderMethodBuilder(provider, map);
            }
            {
                // render normal
                var vs = new VertexShader(normalVertex, vPosition, vNormal);
                var gs = new GeometryShader(normalGeometry);
                var fs = new FragmentShader(normalFragment);
                var provider = new ShaderArray(vs, gs, fs);
                var map = new AttributeMap();
                map.Add(vPosition, position);
                map.Add(vNormal, normal);
                builders[1] = new RenderMethodBuilder(provider, map);
            }

            var node = new NormalNode(model, position, builders);
            node.ModelSize = size;

            node.Initialize();

            return node;
        }

        private NormalNode(IBufferSource model, string positionNameInIBufferSource, params RenderMethodBuilder[] builders)
            : base(model, positionNameInIBufferSource, builders)
        {
            this.RenderModel = true;
            this.RenderNormal = true;
        }

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            ICamera camera = arg.CameraStack.Peek();
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            mat4 normal = glm.transpose(glm.inverse(view * model));

            if (this.RenderModel)
            {
                RenderMethod unit = this.RenderUnit.Methods[0];
                ShaderProgram program = unit.Program;
                program.SetUniform(projectionMatrix, projection);
                program.SetUniform(viewMatrix, view);
                program.SetUniform(modelMatrix, model);
                program.SetUniform(normalMatrix, normal);

                unit.Render();
            }

            if (this.RenderNormal)
            {
                RenderMethod unit = this.RenderUnit.Methods[1];
                ShaderProgram program = unit.Program;
                program.SetUniform(projectionMatrix, projection);
                program.SetUniform(viewMatrix, view);
                program.SetUniform(modelMatrix, model);

                unit.Render();
            }
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        public vec3 DiffuseColor
        {
            get
            {
                vec3 value = new vec3();
                if (this.RenderUnit != null && this.RenderUnit.Methods.Length > 0)
                {
                    RenderMethod unit = this.RenderUnit.Methods[0];
                    ShaderProgram program = unit.Program;
                    program.GetUniformValue(diffuseColor, out value);
                }

                return value;
            }
            set
            {
                if (this.RenderUnit != null && this.RenderUnit.Methods.Length > 0)
                {
                    RenderMethod unit = this.RenderUnit.Methods[0];
                    ShaderProgram program = unit.Program;
                    program.SetUniform(diffuseColor, value);
                }
            }
        }

        public vec3 VertexColor
        {
            get
            {
                vec3 value = new vec3();
                if (this.RenderUnit != null && this.RenderUnit.Methods.Length > 0)
                {
                    RenderMethod unit = this.RenderUnit.Methods[1];
                    ShaderProgram program = unit.Program;
                    program.GetUniformValue(vertexColor, out value);
                }

                return value;
            }
            set
            {
                if (this.RenderUnit != null && this.RenderUnit.Methods.Length > 0)
                {
                    RenderMethod unit = this.RenderUnit.Methods[1];
                    ShaderProgram program = unit.Program;
                    program.SetUniform(vertexColor, value);
                }
            }
        }

        public vec3 PointerColor
        {
            get
            {
                vec3 value = new vec3();
                if (this.RenderUnit != null && this.RenderUnit.Methods.Length > 0)
                {
                    RenderMethod unit = this.RenderUnit.Methods[1];
                    ShaderProgram program = unit.Program;
                    program.GetUniformValue(pointerColor, out value);
                }

                return value;
            }
            set
            {
                if (this.RenderUnit != null && this.RenderUnit.Methods.Length > 0)
                {
                    RenderMethod unit = this.RenderUnit.Methods[1];
                    ShaderProgram program = unit.Program;
                    program.SetUniform(pointerColor, value);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool RenderModel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool RenderNormal { get; set; }
    }
}
