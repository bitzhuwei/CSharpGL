using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Render a Ground(two triangles) with single color in modern opengl.
    /// </summary>
    public class DepthGroundNode : PickableNode, IShadowMapping
    {
        private const string inPosition = "inPosition";
        private const string mvpMatrix = "mvpMatrix";

        private const string vertexCode =
            @"#version 330

uniform mat4 " + mvpMatrix + @";

in vec4 " + inPosition + @";

void main(void)
{
	gl_Position = mvpMatrix * inPosition;
}
";
        // this fragment shader is not needed.
        //        private const string fragmentCode =
        //            @"#version 330 core
        //
        //uniform vec4 " + color + @";
        //
        //out vec4 out_Color;
        //
        //void main(void) {
        //    out_Color = color;
        //}
        //";
        /// <summary>
        /// 
        /// </summary>
        public vec4 Color { get; set; }

        /// <summary>
        /// Render propeller in modern opengl.
        /// </summary>
        /// <returns></returns>
        public static DepthGroundNode Create()
        {
            RenderMethodBuilder shadowmapBuilder;
            {
                var vs = new VertexShader(vertexCode);
                var provider = new ShaderArray(vs);
                var map = new AttributeMap();
                map.Add(inPosition, GroundModel.strPosition);
                shadowmapBuilder = new RenderMethodBuilder(provider, map);
            }
            var node = new DepthGroundNode(new GroundModel(), GroundModel.strPosition, shadowmapBuilder);
            node.Initialize();

            return node;
        }

        /// <summary>
        /// Render propeller in legacy opengl.
        /// </summary>
        private DepthGroundNode(GroundModel model, string positionNameInIBufferable, params RenderMethodBuilder[] builders)
            : base(model, positionNameInIBufferable, builders)
        {
            this.ModelSize = model.ModelSize;
            this.Color = new vec4(1, 1, 1, 1);
        }

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #region IShadowMapping 成员

        private bool enableShadowMapping = true;

        public bool EnableShadowMapping
        {
            get { return enableShadowMapping; }
            set { enableShadowMapping = value; }
        }

        public void CastShadow(ShdowMappingEventArgs arg)
        {
            if (!this.IsInitialized) { this.Initialize(); }

            LightBase light = arg.CurrentLight;
            mat4 projection = light.GetProjectionMatrix();
            mat4 view = light.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            var method = this.RenderUnit.Methods[0]; // shadowmapBuilder
            ShaderProgram program = method.Program;
            program.SetUniform(mvpMatrix, projection * view * model);

            method.Render();
        }

        #endregion

        class GroundModel : IBufferSource
        {
            public vec3 ModelSize { get; private set; }

            public GroundModel()
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

            public IDrawCommand GetDrawCommand()
            {
                if (this.indexBuffer == null)
                {
                    this.indexBuffer = ZeroIndexBuffer.Create(DrawMode.Quads, 0, positions.Length);
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
                new vec3(+xLength, 0, +zLength),//  0
                new vec3(+xLength, 0, -zLength),//  1
                new vec3(-xLength, 0, -zLength),//  2
                new vec3(-xLength, 0, +zLength),//  3
            };
        }

    }
}