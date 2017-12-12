using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;
using System.ComponentModel;

namespace StencilTest
{
    partial class OutlineCubeNode : PickableNode
    {
        private const string inPosition = "inPosition";
        private const string projectionMatrix = "projectionMatrix";
        private const string viewMatrix = "viewMatrix";
        private const string modelMatrix = "modelMatrix";
        private const string color = "color";
        private const string vertexCode =
            @"#version 150 core

in vec3 " + inPosition + @";

uniform mat4 " + projectionMatrix + @";
uniform mat4 " + viewMatrix + @";
uniform mat4 " + modelMatrix + @";

void main(void) {
	gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(inPosition, 1.0);
}
";
        private const string fragmentCode =
            @"#version 150 core

uniform vec4 " + color + @";

out vec4 out_Color;

void main(void) {
    out_Color = color;
}
";
        /// <summary>
        /// 
        /// </summary>
        public vec4 Color { get; set; }

        /// <summary>
        /// Render propeller in modern opengl.
        /// </summary>
        /// <returns></returns>
        public static OutlineCubeNode Create()
        {
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var provider = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add(inPosition, CubeModel.strPosition);
            var builder = new RenderMethodBuilder(provider, map);
            var node = new OutlineCubeNode(new CubeModel(), CubeModel.strPosition, builder);
            node.Initialize();

            return node;
        }

        /// <summary>
        /// Render propeller in legacy opengl.
        /// </summary>
        private OutlineCubeNode(CubeModel model, string positionNameInIBufferSource, params RenderMethodBuilder[] builders)
            : base(model, positionNameInIBufferSource, builders)
        {
            this.ModelSize = model.ModelSize;
            this.Color = new vec4(1, 1, 1, 1);
        }

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            if (!this.IsInitialized) { this.Initialize(); }

            if (DisplayOutline)
            {
                // render object and prepare stencil buffer.
                GL.Instance.Enable(GL.GL_STENCIL_TEST);
                GL.Instance.ClearStencil(0);
                GL.Instance.Clear(GL.GL_STENCIL_BUFFER_BIT);
                GL.Instance.StencilFunc(GL.GL_ALWAYS, 1, 0xFF);
                GL.Instance.StencilOp(GL.GL_KEEP, GL.GL_KEEP, GL.GL_REPLACE);
                GL.Instance.StencilMask(0xFF);

                ICamera camera = arg.CameraStack.Peek();
                mat4 projection = camera.GetProjectionMatrix();
                mat4 view = camera.GetViewMatrix();
                mat4 model = this.GetModelMatrix();

                var method = this.RenderUnit.Methods[0]; // the only render unit in this node.
                ShaderProgram program = method.Program;
                program.SetUniform(projectionMatrix, projection);
                program.SetUniform(viewMatrix, view);
                program.SetUniform(modelMatrix, model);
                program.SetUniform(color, this.Color);
                method.Render();

                // render outline.
                GL.Instance.StencilFunc(GL.GL_NOTEQUAL, 1, 0xFF);
                GL.Instance.StencilOp(GL.GL_KEEP, GL.GL_KEEP, GL.GL_KEEP);
                GL.Instance.StencilMask(0x00);
                GL.Instance.DepthMask(false);

                mat4 parentMat = mat4.identity();
                var parent = this.Parent;
                if (parent != null) { parentMat = parent.GetModelMatrix(); }
                mat4 matrix = glm.translate(mat4.identity(), this.WorldPosition);
                matrix = glm.scale(matrix, this.Scale * 1.1f);
                matrix = glm.rotate(matrix, this.RotationAngle, this.RotationAxis);
                program.SetUniform(projectionMatrix, projection);
                program.SetUniform(viewMatrix, view);
                program.SetUniform(modelMatrix, parentMat * matrix);
                program.SetUniform(color, new vec4(0.04f, 0.28f, 0.26f, 1.0f));
                method.Render();
                GL.Instance.DepthMask(true);

                GL.Instance.Disable(GL.GL_STENCIL_TEST);

                //// render original object.
                //GL.Instance.DepthMask(true);
                //program.SetUniform(modelMatrix, model);
                //program.SetUniform(color, this.Color);
                //method.Render();
            }
            else
            {
                ICamera camera = arg.CameraStack.Peek();
                mat4 projection = camera.GetProjectionMatrix();
                mat4 view = camera.GetViewMatrix();
                mat4 model = this.GetModelMatrix();

                var method = this.RenderUnit.Methods[0]; // the only render unit in this node.
                ShaderProgram program = method.Program;
                program.SetUniform(projectionMatrix, projection);
                program.SetUniform(viewMatrix, view);
                program.SetUniform(modelMatrix, model);
                program.SetUniform(color, this.Color);
                method.Render();
            }
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        [Browsable(false)]
        public bool DisplayOutline { get; set; }
    }

    class CubeModel : IBufferSource
    {
        public vec3 ModelSize { get; private set; }

        public CubeModel()
        {
            this.ModelSize = new vec3(xLength * 2, yLength * 2, zLength * 2);
        }

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;

        private IndexBuffer indexBuffer;

        #region IBufferable 成员

        public VertexBuffer GetVertexAttributeBuffer(string bufferName)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = positions.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                return this.positionBuffer;
            }

            throw new NotImplementedException();
        }

        public IndexBuffer GetIndexBuffer()
        {
            if (this.indexBuffer == null)
            {
                this.indexBuffer = ZeroIndexBuffer.Create(DrawMode.TriangleStrip, 0, positions.Length);
            }

            return this.indexBuffer;
        }

        #endregion

        private const float xLength = 0.5f;
        private const float yLength = 0.5f;
        private const float zLength = 0.5f;
        /// <summary>
        /// four vertexes.
        /// </summary>
        private static readonly vec3[] positions = new vec3[]
        {
            new vec3(+xLength, +yLength, +zLength),//  0
            new vec3(+xLength, -yLength, +zLength),//  1
            new vec3(+xLength, +yLength, -zLength),//  2
            new vec3(+xLength, -yLength, -zLength),//  3
            new vec3(-xLength, -yLength, -zLength),//  4
            new vec3(+xLength, -yLength, +zLength),//  5
            new vec3(-xLength, -yLength, +zLength),//  6
            new vec3(+xLength, +yLength, +zLength),//  7
            new vec3(-xLength, +yLength, +zLength),//  8
            new vec3(+xLength, +yLength, -zLength),//  9
            new vec3(-xLength, +yLength, -zLength),// 10
            new vec3(-xLength, -yLength, -zLength),// 11
            new vec3(-xLength, +yLength, +zLength),// 12
            new vec3(-xLength, -yLength, +zLength),// 13
        };
    }
}
