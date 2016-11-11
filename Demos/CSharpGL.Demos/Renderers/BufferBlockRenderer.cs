using System;
using System.IO;

namespace CSharpGL.Demos
{
    /// <summary>
    /// Demo of how to use uniform block and uniform buffer object.
    /// </summary>
    [DemoRenderer]
    internal class BufferBlockRenderer : Renderer
    {
        public static BufferBlockRenderer Create()
        {
            //var model = new Teapot();
            //var model = new ZeroAttributeModel(DrawMode.Triangles, 0, vertexCount);
            var model = new BufferBlockModel();
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\BufferBlockRenderer\BufferBlock.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\BufferBlockRenderer\BufferBlock.frag"), ShaderType.FragmentShader);
            var map = new AttributeMap();// no vertex attribute.
            var renderer = new BufferBlockRenderer(model, shaderCodes, map);
            renderer.ModelSize = new vec3(2, 2, 2);// model.Lengths;

            return renderer;
        }

        private GroundRenderer groundRenderer;

        //private ShaderStorageBuffer shaderStorageBuffer;
        private const int vertexCount = 4;

        private BufferBlockRenderer(IBufferable model, ShaderCode[] shaderCodes,
            AttributeMap attributeMap, params GLSwitch[] switches)
            : base(model, shaderCodes, attributeMap, switches)
        {
            var groundRenderer = GroundRenderer.Create(new GroundModel(20));
            groundRenderer.Scale = new vec3(10, 10, 10);
            this.groundRenderer = groundRenderer;
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();
            {
                ShaderStorageBuffer bufferPtr = ShaderStorageBuffer.Create(typeof(vec4), BufferUsage.StaticDraw, vertexCount);
                IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                unsafe
                {
                    var array = (vec4*)pointer;
                    array[0] = new vec4(0, 0, 1, 1);
                    array[1] = new vec4(1, 0, 0, 1);
                    array[2] = new vec4(-1, 0, 0, 1);
                    array[3] = new vec4(0, 1, 0, 1);
                }
                bufferPtr.UnmapBuffer();
                bufferPtr.Binding(this.Program, "PositionBuffer", 0);
                bufferPtr.Unbind();
                //this.shaderStorageBuffer = bufferPtr;
            }
            {
                ShaderStorageBuffer bufferPtr = ShaderStorageBuffer.Create(typeof(vec4), BufferUsage.StaticDraw, vertexCount);
                IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                unsafe
                {
                    var array = (vec4*)pointer;
                    array[0] = new vec4(+1, +0, +0, 0);
                    array[1] = new vec4(+0, +1, +0, 0);
                    array[2] = new vec4(+0, +0, +1, 0);
                    array[3] = new vec4(+1, +1, +1, 0);
                }
                bufferPtr.Binding(this.Program, "ColorBuffer", 1);
                bufferPtr.Unbind();
                //this.shaderStorageBuffer = bufferPtr;
            }

            this.groundRenderer.Initialize();
        }

        private long modelTicks;

        protected override void DoRender(RenderEventArgs arg)
        {
            mat4 projection = arg.Camera.GetProjectionMatrix();
            mat4 view = arg.Camera.GetViewMatrix();
            this.SetUniform("projectionMatrix", projection);
            this.SetUniform("viewMatrix", view);
            MarkableStruct<mat4> model = this.GetModelMatrix();
            if (this.modelTicks != model.UpdateTicks)
            {
                this.SetUniform("modelMatrix", model.Value);
                this.modelTicks = model.UpdateTicks;
            }

            base.DoRender(arg);

            this.groundRenderer.Render(arg);
        }
    }

    internal class BufferBlockModel : IBufferable
    {
        private IndexBuffer indexBuffer;

        public VertexAttributeBuffer GetVertexAttributeBuffer(string bufferName, string varNameInShader)
        {
            return null;
        }

        public IndexBuffer GetIndexBuffer()
        {
            if (this.indexBuffer == null)
            {
                OneIndexBuffer bufferPtr = OneIndexBuffer.Create(BufferUsage.StaticDraw, DrawMode.Triangles, IndexElementType.UInt, 3 * 3);
                unsafe
                {
                    IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                    var array = (uint*)pointer;
                    array[0] = 0; array[1] = 1; array[2] = 3;
                    array[3] = 0; array[4] = 3; array[5] = 2;
                    array[6] = 1; array[7] = 3; array[8] = 2;
                    bufferPtr.UnmapBuffer();
                }
                this.indexBuffer = bufferPtr;
            }

            return this.indexBuffer;
        }

        public bool UsesZeroIndexBuffer()
        {
            return false;
        }
    }
}