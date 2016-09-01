using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


namespace CSharpGL.Demos
{

    class SimpleComputeRenderer : Renderer
    {
        private ShaderProgram computeProgram;
        private ShaderProgram resetProgram;
        //private uint[] output_image = new uint[1];
        private Texture outputImage;
        private uint[] output_image_buffer = new uint[1];

        public static SimpleComputeRenderer Create()
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\compute.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\compute.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("position", SimpleCompute.strPosition);
            return new SimpleComputeRenderer(new SimpleCompute(), shaderCodes, map);
        }

        private SimpleComputeRenderer(IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, switches)
        { }

        protected override void DoInitialize()
        {
            {
                // Initialize our compute program
                var computeProgram = new ShaderProgram();
                var shaderCode = new ShaderCode(File.ReadAllText(@"shaders\compute.comp"), ShaderType.ComputeShader);
                Shader shader = shaderCode.CreateShader();
                computeProgram.Initialize(shader);
                shader.Delete();
                this.computeProgram = computeProgram;
            }
            {
                // Initialize our resetProgram 
                var resetProgram = new ShaderProgram();
                var shaderCode = new ShaderCode(File.ReadAllText(@"shaders\computeReset.comp"), ShaderType.ComputeShader);
                Shader shader = shaderCode.CreateShader();
                resetProgram.Initialize(shader);
                shader.Delete();
                this.resetProgram = resetProgram;
            }
            {
                // This is the texture that the compute program will write into
                var texture = new Texture(BindTextureTarget.Texture2D,
                    new TexStorageImageBuilder(8, OpenGL.GL_RGBA32F, 256, 256),
                    new NullSampler());
                texture.Initialize();
                this.outputImage = texture;
            }
            {
                this.GroupX = 1;
                this.GroupY = 1;
                this.GroupZ = 1;
            }
            base.DoInitialize();

            this.SetUniform("output_image", this.outputImage.ToSamplerValue());
        }

        private uint maxX;
        private uint maxY;
        private uint maxZ;
        private uint groupX;

        public uint GroupX
        {
            get { return groupX; }
            set { groupX = value; if (maxX < value) { maxX = value; } }
        }
        private uint groupY;

        public uint GroupY
        {
            get { return groupY; }
            set { groupY = value; if (maxY < value) { maxY = value; } }
        }
        private uint groupZ;

        public uint GroupZ
        {
            get { return groupZ; }
            set { groupZ = value; if (maxZ < value) { maxZ = value; } }
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            // reset image
            resetProgram.Bind();
            OpenGL.BindImageTexture(0, outputImage.Id, 0, false, 0, OpenGL.GL_WRITE_ONLY, OpenGL.GL_RGBA32F);
            OpenGL.GetDelegateFor<OpenGL.glDispatchCompute>()(maxX, maxY, maxZ);
            resetProgram.Unbind();

            // Activate the compute program and bind the output texture image
            computeProgram.Bind();
            OpenGL.BindImageTexture(0, outputImage.Id, 0, false, 0, OpenGL.GL_WRITE_ONLY, OpenGL.GL_RGBA32F);
            OpenGL.GetDelegateFor<OpenGL.glDispatchCompute>()(GroupX, GroupY, GroupZ);
            computeProgram.Unbind();

            mat4 model = mat4.identity();
            mat4 view = arg.Camera.GetViewMatrix();
            mat4 projection = arg.Camera.GetProjectionMatrix();
            this.SetUniform("modelMatrix", model);
            this.SetUniform("viewMatrix", view);
            this.SetUniform("projectionMatrix", projection);

            base.DoRender(arg);
        }

        protected override void DisposeUnmanagedResources()
        {
            resetProgram.Delete();
            computeProgram.Delete();
            this.outputImage.Dispose();
        }

        class SimpleCompute : IBufferable
        {

            static readonly vec3[] vertsData = new vec3[]
        {
            new vec3(-1.0f, -1.0f, 0.5f),
            new vec3(1.0f, -1.0f, 0.5f),
            new vec3(1.0f,  1.0f, 0.5f),
            new vec3(-1.0f,  1.0f, 0.5f),
        };

            public const string strPosition = "position";
            private PropertyBufferPtr positionBufferPtr = null;
            private IndexBufferPtr indexBufferPtr;

            public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
            {
                if (bufferName == strPosition)
                {
                    if (positionBufferPtr == null)
                    {
                        using (var buffer = new PropertyBuffer<vec3>(
                            varNameInShader, 3, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                        {
                            buffer.Create(vertsData.Length);
                            unsafe
                            {
                                var array = (vec3*)buffer.Header.ToPointer();
                                for (int i = 0; i < vertsData.Length; i++)
                                {
                                    array[i] = vertsData[i];
                                }
                            }

                            positionBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
                        }
                    }

                    return positionBufferPtr;
                }
                else
                {
                    throw new ArgumentException();
                }
            }

            public IndexBufferPtr GetIndex()
            {
                if (indexBufferPtr == null)
                {
                    using (var buffer = new ZeroIndexBuffer(
                      DrawMode.TriangleFan, 0, vertsData.Length))
                    {
                        indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;
                    }
                }

                return indexBufferPtr;
            }
        }
    }
}