using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Skybox
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
    gl_Position = mvpMatrix * vec4(inPosition, 1.0); 
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static SkyboxNode Create()
        {
            var vs = new VertexShader(vertexCode, inPosition);
            var fs = new FragmentShader(fragmentCode);
            var provider = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add(inPosition, Skybox.strPosition);
            var builder = new RenderUnitBuilder(provider, map);
            var model = new Skybox();
            var node = new SkyboxNode(model, Skybox.strPosition, builder);
            node.Initialize();

            return node;
        }

        private SkyboxNode(Skybox model, string positionNameInIBufferSource, params RenderUnitBuilder[] builders)
            : base(model, positionNameInIBufferSource, builders)
        {
            this.ModelSize = model.ModelSize;
            this.texture = GetCubemapTexture();
        }

        private Texture GetCubemapTexture()
        {
            var totalBmp = new Bitmap(@"cubemaps_skybox.png");
            var dataProvider = GetCubemapDataProvider(totalBmp);
            var storage = new CubemapTexImage2D((int)GL.GL_RGBA, totalBmp.Width / 4, totalBmp.Height / 3, 0, GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, dataProvider);
            var texture = new Texture(TextureTarget.TextureCubeMap, storage);
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE));
            texture.Initialize();

            return texture;
        }

        private CubemapDataProvider GetCubemapDataProvider(Bitmap totalBmp)
        {
            int width = totalBmp.Width / 4, height = totalBmp.Height / 3;
            var top = new Bitmap(width, height);
            using (var g = Graphics.FromImage(top))
            {
                g.DrawImage(totalBmp, new Rectangle(0, 0, width, height), new Rectangle(width, 0, width, height), GraphicsUnit.Pixel);
            }
            var left = new Bitmap(width, height);
            using (var g = Graphics.FromImage(left))
            {
                g.DrawImage(totalBmp, new Rectangle(0, 0, width, height), new Rectangle(0, height, width, height), GraphicsUnit.Pixel);
            }
            var front = new Bitmap(width, height);
            using (var g = Graphics.FromImage(front))
            {
                g.DrawImage(totalBmp, new Rectangle(0, 0, width, height), new Rectangle(width, height, width, height), GraphicsUnit.Pixel);
            }
            var right = new Bitmap(width, height);
            using (var g = Graphics.FromImage(right))
            {
                g.DrawImage(totalBmp, new Rectangle(0, 0, width, height), new Rectangle(width * 2, height, width, height), GraphicsUnit.Pixel);
            }
            var back = new Bitmap(width, height);
            using (var g = Graphics.FromImage(back))
            {
                g.DrawImage(totalBmp, new Rectangle(0, 0, width, height), new Rectangle(width * 3, height, width, height), GraphicsUnit.Pixel);
            }
            var bottom = new Bitmap(width, height);
            using (var g = Graphics.FromImage(bottom))
            {
                g.DrawImage(totalBmp, new Rectangle(0, 0, width, height), new Rectangle(width, height * 2, width, height), GraphicsUnit.Pixel);
            }

            var flip = RotateFlipType.Rotate180FlipY;
            right.RotateFlip(flip); left.RotateFlip(flip);
            top.RotateFlip(flip); bottom.RotateFlip(flip);
            back.RotateFlip(flip); front.RotateFlip(flip);

            right.Save("right.png"); left.Save("left.png");
            top.Save("top.png"); bottom.Save("bottom.png");
            back.Save("back.png"); front.Save("front.png");
            var result = new CubemapDataProvider(right, left, top, bottom, back, front);
            return result;
        }

        public override void RenderBeforeChildren(CSharpGL.RenderEventArgs arg)
        {
            if (!this.IsInitialized) { this.Initialize(); }

            ICamera camera = arg.CameraStack.Peek();
            mat4 projectionMatrix = camera.GetProjectionMatrix();
            mat4 viewMatrix = camera.GetViewMatrix();
            mat4 modelMatrix = this.GetModelMatrix();

            RenderUnit unit = this.RenderUnits[0];
            ShaderProgram program = unit.Program;
            program.SetUniform(mvpMatrix, projectionMatrix * viewMatrix * modelMatrix);
            program.SetUniform(skybox, this.texture);

            unit.Render();
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
                    this.indexBuffer = ZeroIndexBuffer.Create(DrawMode.Quads, 0, positions.Length);
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
				new vec3(-xLength, -yLength, +zLength),//  0
				new vec3(+xLength, -yLength, +zLength),//  1
				new vec3(+xLength, +yLength, +zLength),//  2
				new vec3(-xLength, +yLength, +zLength),//  3

				new vec3(+xLength, -yLength, +zLength),//  4
				new vec3(+xLength, -yLength, -zLength),//  5
				new vec3(+xLength, +yLength, -zLength),//  6
				new vec3(+xLength, +yLength, +zLength),//  7
				
				new vec3(-xLength, +yLength, +zLength),//  8
				new vec3(+xLength, +yLength, +zLength),//  9
				new vec3(+xLength, +yLength, -zLength),// 10
				new vec3(-xLength, +yLength, -zLength),// 11
				
				new vec3(+xLength, -yLength, -zLength),// 12
				new vec3(-xLength, -yLength, -zLength),// 13
				new vec3(-xLength, +yLength, -zLength),// 14
				new vec3(+xLength, +yLength, -zLength),// 15
				
				new vec3(-xLength, -yLength, -zLength),// 16
				new vec3(-xLength, -yLength, +zLength),// 17
				new vec3(-xLength, +yLength, +zLength),// 18
				new vec3(-xLength, +yLength, -zLength),// 19
				
				new vec3(+xLength, -yLength, -zLength),// 20
				new vec3(+xLength, -yLength, +zLength),// 21
				new vec3(-xLength, -yLength, +zLength),// 22
				new vec3(-xLength, -yLength, -zLength),// 23
			};

        }
    }
}