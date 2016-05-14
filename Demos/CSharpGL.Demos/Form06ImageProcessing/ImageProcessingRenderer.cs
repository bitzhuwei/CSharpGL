using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Demos
{

    class ImageProcessingRenderer : RendererBase
    {
        private ShaderProgram computeProgram;
        private uint[] input_image = new uint[1];
        private uint[] intermediate_image = new uint[1];
        private uint[] output_image = new uint[1];
        private PickableRenderer renderer;

        protected override void DoInitialize()
        {
            {
                var computeProgram = new ShaderProgram();
                var shaderCode = new ShaderCode(File.ReadAllText(@"Form06ImageProcessing\ImageProcessing.comp"), ShaderType.ComputeShader);
                var shader = shaderCode.CreateShader();
                computeProgram.Create(shader);
                shader.Delete();
                this.computeProgram = computeProgram;
            }
            {
                sampler2D texture = new sampler2D();
                texture.Initialize(new System.Drawing.Bitmap(@"Form06ImageProcessing\teapot.png"));
                this.input_image[0] = texture.Id;
            }
            {
                GL.GenTextures(1, intermediate_image);
                GL.BindTexture(GL.GL_TEXTURE_2D, intermediate_image[0]);
                GL.TexStorage2D(TexStorage2DTarget.Texture2D, 8, GL.GL_RGBA32F, 512, 512);

                // This is the texture that the compute program will write into
                GL.GenTextures(1, output_image);
                GL.BindTexture(GL.GL_TEXTURE_2D, output_image[0]);
                GL.TexStorage2D(TexStorage2DTarget.Texture2D, 8, GL.GL_RGBA32F, 512, 512);
            }
            {
                var bufferable = new ImageProcessingModel();
                ShaderCode[] simpleShader = new ShaderCode[2];
                simpleShader[0] = new ShaderCode(File.ReadAllText(@"Form06ImageProcessing\ImageProcessing.vert"), ShaderType.VertexShader);
                simpleShader[1] = new ShaderCode(File.ReadAllText(@"Form06ImageProcessing\ImageProcessing.frag"), ShaderType.FragmentShader);
                var propertyNameMap = new PropertyNameMap();
                propertyNameMap.Add("vert", "position");
                propertyNameMap.Add("uv", "uv");
                var pickableRenderer = PickableRendererFactory.GetRenderer(
                    bufferable, simpleShader, propertyNameMap, "position");
                pickableRenderer.Name = string.Format("Pickable: [ImageProcessingRenderer]");
                pickableRenderer.Initialize();
                pickableRenderer.SetUniformValue("output_image", new samplerValue(this.input_image[0], GL.GL_TEXTURE0));
                this.renderer = pickableRenderer;
            }

        }


        protected override void DoRender(RenderEventArgs arg)
        {
            // Activate the compute program and bind the output texture image
            //computeProgram.Bind();
            //GL.GetDelegateFor<GL.glBindImageTexture>()(0, input_image[0], 0, false, 0, GL.GL_READ_ONLY, GL.GL_RGBA32F);
            //GL.GetDelegateFor<GL.glBindImageTexture>()(1, intermediate_image[0], 0, false, 0, GL.GL_WRITE_ONLY, GL.GL_RGBA32F);
            //// Dispatch
            //GL.GetDelegateFor<GL.glDispatchCompute>()(512, 1, 1);

            //GL.GetDelegateFor<GL.glMemoryBarrier>()(GL.GL_SHADER_IMAGE_ACCESS_BARRIER_BIT);

            //GL.GetDelegateFor<GL.glBindImageTexture>()(0, intermediate_image[0], 0, false, 0, GL.GL_READ_ONLY, GL.GL_RGBA32F);
            //GL.GetDelegateFor<GL.glBindImageTexture>()(1, output_image[0], 0, false, 0, GL.GL_WRITE_ONLY, GL.GL_RGBA32F);
            //// Dispatch
            //GL.GetDelegateFor<GL.glDispatchCompute>()(512, 1, 1);

            //// Now bind the texture for rendering _from_
            //GL.GetDelegateFor<GL.glActiveTexture>()(GL.GL_TEXTURE0);
            //GL.BindTexture(GL.GL_TEXTURE_2D, output_image[0]);

            mat4 view = arg.Camera.GetViewMat4();
            mat4 projection = arg.Camera.GetProjectionMat4();
            this.renderer.SetUniformValue("mvp", projection * view);
            this.renderer.Render(arg);
        }

        protected override void DisposeUnmanagedResources()
        {
            computeProgram.Delete();
            GL.DeleteTextures(1, input_image);
            GL.DeleteTextures(1, intermediate_image);
            GL.DeleteTextures(1, output_image);
            this.renderer.Dispose();
        }

        class ImageProcessingModel : IBufferable
        {
            public const string strposition = "position";
            public const string struv = "uv";
            PropertyBufferPtr positionBufferPtr;
            PropertyBufferPtr uvBufferPtr;
            ZeroIndexBufferPtr indexBufferPtr;

            public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
            {
                if (bufferName == strposition)
                {
                    if (positionBufferPtr == null)
                    {
                        using (var buffer = new PropertyBuffer<vec3>(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw))
                        {
                            buffer.Alloc(4);
                            unsafe
                            {
                                var array = (vec3*)buffer.FirstElement();
                                array[0] = new vec3(-1.0f, -1.0f, 0.5f);
                                array[1] = new vec3(1.0f, -1.0f, 0.5f);
                                array[2] = new vec3(1.0f, 1.0f, 0.5f);
                                array[3] = new vec3(-1.0f, 1.0f, 0.5f);
                            }
                            positionBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
                        }
                    }
                    return positionBufferPtr;
                }
                else if (bufferName == struv)
                {
                    if (uvBufferPtr == null)
                    {
                        using (var buffer = new PropertyBuffer<vec2>(varNameInShader, 2, GL.GL_FLOAT, BufferUsage.StaticDraw))
                        {
                            buffer.Alloc(4);
                            unsafe
                            {
                                var array = (vec2*)buffer.FirstElement();
                                array[0] = new vec2(0, 0);
                                array[1] = new vec2(0, 1);
                                array[2] = new vec2(1, 1);
                                array[3] = new vec2(1, 0);
                            }
                            uvBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
                        }
                    }
                    return uvBufferPtr;
                }
                else
                { throw new NotImplementedException(); }
            }

            public IndexBufferPtr GetIndex()
            {
                if (indexBufferPtr == null)
                {
                    using (var buffer = new ZeroIndexBuffer(DrawMode.TriangleFan, 0, 4))
                    {
                        indexBufferPtr = buffer.GetBufferPtr() as ZeroIndexBufferPtr;
                    }
                }
                return indexBufferPtr;
            }
        }
    }
}