using CSharpGL;
using System;
using System.IO;

namespace DrvSimu
{
    internal class CrossRenderer : Renderer
    {
        private Texture spriteTexture;

        public static CrossRenderer Create()
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"PointSprite.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"PointSprite.frag"), ShaderType.FragmentShader);
            var map = new AttributeMap();
            map.Add("position", PointSpriteModel.strposition);
            var model = new PointSpriteModel();
            var renderer = new CrossRenderer(model, shaderCodes, map, new PointSpriteSwitch());

            return renderer;
        }

        public CrossRenderer(IBufferable model, ShaderCode[] shaderCodes,
            AttributeMap attributeMap, params GLSwitch[] switches)
            : base(model, shaderCodes, attributeMap, switches)
        {
        }

        protected override void DoInitialize()
        {
            {
                // This is the texture that the compute program will write into
                var bitmap = new System.Drawing.Bitmap(@"PointSprite.png");
                var texture = new Texture(TextureTarget.Texture2D, bitmap, new SamplerParameters());
                texture.Initialize();
                bitmap.Dispose();
                this.spriteTexture = texture;
            }
            base.DoInitialize();
            this.SetUniform("spriteTexture", this.spriteTexture);
            //this.SetUniform("factor", 100.0f);
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            mat4 model = mat4.identity();
            mat4 view = arg.Camera.GetViewMatrix();
            mat4 projection = arg.Camera.GetProjectionMatrix();
            this.SetUniform("mvp", projection * view * model);

            OpenGL.Clear(ClearBufferMask.DepthBufferBit);
            base.DoRender(arg);
        }

        protected override void DisposeUnmanagedResources()
        {
            base.DisposeUnmanagedResources();

            this.spriteTexture.Dispose();
        }

        private class PointSpriteModel : IBufferable
        {
            public const string strposition = "position";
            private VertexAttributeBufferPtr positionBufferPtr = null;
            private IndexBufferPtr indexBufferPtr = null;
            private float factor = 1;

            public VertexAttributeBufferPtr GetVertexAttributeBufferPtr(string bufferName, string varNameInShader)
            {
                if (bufferName == strposition)
                {
                    if (positionBufferPtr == null)
                    {
                        using (var buffer = new VertexAttributeBuffer<vec3>(
                            varNameInShader, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw))
                        {
                            buffer.Alloc(1);
                            unsafe
                            {
                                var array = (vec3*)buffer.Header.ToPointer();
                                array[0] = new vec3(0, 0, 0);
                            }

                            positionBufferPtr = buffer.GetBufferPtr();
                        }
                    }

                    return positionBufferPtr;
                }
                else
                {
                    throw new ArgumentException();
                }
            }

            public IndexBufferPtr GetIndexBufferPtr()
            {
                if (indexBufferPtr == null)
                {
                    using (var buffer = new ZeroIndexBuffer(
                      DrawMode.Points, 0, 1))
                    {
                        indexBufferPtr = buffer.GetBufferPtr();
                    }
                }

                return indexBufferPtr;
            }

            /// <summary>
            /// Uses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer"/>.
            /// </summary>
            /// <returns></returns>
            public bool UsesZeroIndexBuffer() { return true; }
        }

        internal void UpdateTexture(string filename)
        {
            // This is the texture that the compute program will write into
            var bitmap = new System.Drawing.Bitmap(filename);
            var texture = new Texture(TextureTarget.Texture2D, bitmap, new SamplerParameters());
            texture.Initialize();
            bitmap.Dispose();
            Texture old = this.spriteTexture;
            this.spriteTexture = texture;
            this.SetUniform("sprite_texture", texture);

            old.Dispose();
        }

        public void SetPoint(vec3 point)
        {
            VertexAttributeBufferPtr positionBufferPtr = this.Model.GetVertexAttributeBufferPtr(PointSpriteModel.strposition, string.Empty);
            IntPtr pointer = positionBufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
            unsafe
            {
                var array = (vec3*)pointer.ToPointer();
                array[0] = point;
            }
            positionBufferPtr.UnmapBuffer();
        }
    }
}