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
        private uint[] output_image = new uint[1];
        private uint[] output_image_buffer = new uint[1];
        static ShaderCode[] staticShaderCodes;
        static PropertyNameMap map;
        static SimpleComputeRenderer()
        {
            staticShaderCodes = new ShaderCode[2];
            staticShaderCodes[0] = new ShaderCode(File.ReadAllText(@"04SimpleCompute\compute.vert"), ShaderType.VertexShader);
            staticShaderCodes[1] = new ShaderCode(File.ReadAllText(@"04SimpleCompute\compute.frag"), ShaderType.FragmentShader);
            map = new PropertyNameMap();
            map.Add(SimpleCompute.strPosition, "position");
        }
        public SimpleComputeRenderer()
            : base(new SimpleCompute(), staticShaderCodes, map)
        { }

        protected override void DoInitialize()
        {
            {
                // Initialize our compute program
                var computeProgram = new ShaderProgram();
                var shaderCode = new ShaderCode(File.ReadAllText(@"04SimpleCompute\compute.comp"), ShaderType.ComputeShader);
                Shader shader = shaderCode.CreateShader();
                computeProgram.Create(shader);
                shader.Delete();
                this.computeProgram = computeProgram;
            }
            {
                // Initialize our resetProgram 
                var resetProgram = new ShaderProgram();
                var shaderCode = new ShaderCode(File.ReadAllText(@"04SimpleCompute\computeReset.comp"), ShaderType.ComputeShader);
                Shader shader = shaderCode.CreateShader();
                resetProgram.Create(shader);
                shader.Delete();
                this.resetProgram = resetProgram;
            }
            {
                // This is the texture that the compute program will write into
                OpenGL.GenTextures(1, output_image);
                OpenGL.BindTexture(OpenGL.GL_TEXTURE_2D, output_image[0]);
                OpenGL.TexStorage2D(TexStorage2DTarget.Texture2D, 8, OpenGL.GL_RGBA32F, 256, 256);
                OpenGL.BindTexture(OpenGL.GL_TEXTURE_2D, 0);
            }
            {
                this.GroupX = 1;
                this.GroupY = 1;
                this.GroupZ = 1;
            }
            base.DoInitialize();
            this.SetUniform("output_image", new samplerValue(
                BindTextureTarget.Texture2D, this.output_image[0], OpenGL.GL_TEXTURE0));

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

        protected override void DoRender(RenderEventArg arg)
        {
            // reset image
            resetProgram.Bind();
            OpenGL.GetDelegateFor<OpenGL.glBindImageTexture>()(0, output_image[0], 0, false, 0, OpenGL.GL_WRITE_ONLY, OpenGL.GL_RGBA32F);
            OpenGL.GetDelegateFor<OpenGL.glDispatchCompute>()(maxX, maxY, maxZ);
            resetProgram.Unbind();

            // Activate the compute program and bind the output texture image
            computeProgram.Bind();
            OpenGL.GetDelegateFor<OpenGL.glBindImageTexture>()(0, output_image[0], 0, false, 0, OpenGL.GL_WRITE_ONLY, OpenGL.GL_RGBA32F);
            OpenGL.GetDelegateFor<OpenGL.glDispatchCompute>()(GroupX, GroupY, GroupZ);
            computeProgram.Unbind();

            mat4 model = mat4.identity();
            mat4 view = arg.Camera.GetViewMat4();
            mat4 projection = arg.Camera.GetProjectionMat4();
            this.SetUniform("modelMatrix", model);
            this.SetUniform("viewMatrix", view);
            this.SetUniform("projectionMatrix", projection);

            base.DoRender(arg);
        }

        protected override void DisposeUnmanagedResources()
        {
            resetProgram.Delete();
            computeProgram.Delete();
            OpenGL.DeleteTextures(1, output_image);
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
                            buffer.Alloc(vertsData.Length);
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