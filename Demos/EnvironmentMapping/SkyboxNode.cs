using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace EnvironmentMapping
{
    class SkyboxNode : PickableNode
    {
        private const string inPosition = "inPosition";
        private const string mvpMatrix = "mvpMatrix";
        private const string skybox = "skybox";
        private const string vertexCode = @"#version 330 core

layout(location = 0) in vec3 " + inPosition + @";

uniform mat4 " + mvpMatrix + @";

out vec3 texCoord;

void main()
{
    vec4 position = mvpMatrix * vec4(inPosition, 1.0); 
    gl_Position = position.xyww;
    texCoord = inPosition;
}
";
        private const string fragmentCode = @"#version 330 core

uniform samplerCube " + skybox + @";

in vec3 texCoord;

out vec4 color;

void main()
{
    color = texture(skybox, texCoord);
}
";
        private Texture texture;

        public Texture SkyboxTexture
        {
            get { return texture; }
            set { texture = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="totalBmp"></param>
        /// <returns></returns>
        public static SkyboxNode Create(Bitmap[] bitmaps)
        {
            var vs = new VertexShader(vertexCode, inPosition);
            var fs = new FragmentShader(fragmentCode);
            var provider = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add(inPosition, Skybox.strPosition);
            var cullface = new CullFaceState(CullFaceMode.Back);// display back faces only.
            var builder = new RenderMethodBuilder(provider, map, cullface);
            var model = new Skybox();
            var node = new SkyboxNode(model, Skybox.strPosition, bitmaps, builder);
            node.EnablePicking = TwoFlags.Children;// sky box should not take part in picking.
            node.Initialize();

            return node;
        }

        private SkyboxNode(Skybox model, string positionNameInIBufferSource, Bitmap[] bitmaps, params RenderMethodBuilder[] builders)
            : base(model, positionNameInIBufferSource, builders)
        {
            this.ModelSize = model.ModelSize;
            this.texture = GetCubemapTexture(bitmaps);
        }

        private Texture GetCubemapTexture(Bitmap[] bitmaps)
        {
            var dataProvider = new CubemapDataProvider(
                bitmaps[0], bitmaps[1], bitmaps[2], bitmaps[3], bitmaps[4], bitmaps[5]);
            var storage = new CubemapTexImage2D(GL.GL_RGBA, bitmaps[0].Width, bitmaps[0].Height, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, dataProvider);
            var texture = new Texture(storage,
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE));
            texture.Initialize();

            return texture;
        }

        public override void RenderBeforeChildren(CSharpGL.RenderEventArgs arg)
        {
            if (!this.IsInitialized) { this.Initialize(); }

            ICamera camera = arg.CameraStack.Peek();
            mat4 projectionMatrix = camera.GetProjectionMatrix();
            mat4 viewMatrix = camera.GetViewMatrix();
            mat4 modelMatrix = this.GetModelMatrix();

            RenderMethod method = this.RenderUnit.Methods[0];
            ShaderProgram program = method.Program;
            program.SetUniform(mvpMatrix, projectionMatrix * viewMatrix * modelMatrix);
            program.SetUniform(skybox, this.texture);

            method.Render();
        }

        public override void RenderAfterChildren(CSharpGL.RenderEventArgs arg)
        {
        }


        class Skybox : IBufferSource
        {
            public vec3 ModelSize { get; private set; }

            public Skybox()
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
                    this.indexBuffer = ZeroIndexBuffer.Create(DrawMode.Triangles, 0, positions.Length);
                }

                return this.indexBuffer;
            }

            #endregion

            private const float xLength = 1;
            private const float yLength = 1;
            private const float zLength = 1;
            /// <summary>
            /// six quads' vertexes.
            /// </summary>
            private static readonly vec3[] positions = new vec3[]
			{
				new vec3(-xLength,  yLength, -zLength),
				new vec3(-xLength, -yLength, -zLength),
				new vec3( xLength, -yLength, -zLength),
				new vec3( xLength, -yLength, -zLength),
				new vec3( xLength,  yLength, -zLength),
				new vec3(-xLength,  yLength, -zLength),

				new vec3(-xLength, -yLength,  zLength),
				new vec3(-xLength, -yLength, -zLength),
				new vec3(-xLength,  yLength, -zLength),
				new vec3(-xLength,  yLength, -zLength),
				new vec3(-xLength,  yLength,  zLength),
				new vec3(-xLength, -yLength,  zLength),

				new vec3( xLength, -yLength, -zLength),
				new vec3( xLength, -yLength,  zLength),
				new vec3( xLength,  yLength,  zLength),
				new vec3( xLength,  yLength,  zLength),
				new vec3( xLength,  yLength, -zLength),
				new vec3( xLength, -yLength, -zLength),

				new vec3(-xLength, -yLength,  zLength),
				new vec3(-xLength,  yLength,  zLength),
				new vec3( xLength,  yLength,  zLength),
				new vec3( xLength,  yLength,  zLength),
				new vec3( xLength, -yLength,  zLength),
				new vec3(-xLength, -yLength,  zLength),

				new vec3(-xLength,  yLength, -zLength),
				new vec3( xLength,  yLength, -zLength),
				new vec3( xLength,  yLength,  zLength),
				new vec3( xLength,  yLength,  zLength),
				new vec3(-xLength,  yLength,  zLength),
				new vec3(-xLength,  yLength, -zLength),

				new vec3(-xLength, -yLength, -zLength),
				new vec3(-xLength, -yLength,  zLength),
				new vec3( xLength, -yLength, -zLength),
				new vec3( xLength, -yLength, -zLength),
				new vec3(-xLength, -yLength,  zLength),
				new vec3( xLength, -yLength,  zLength),
			};

        }
    }
}