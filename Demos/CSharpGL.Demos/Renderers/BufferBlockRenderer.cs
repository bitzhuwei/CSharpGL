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
            renderer.Lengths = new vec3(2, 2, 2);// model.Lengths;

            return renderer;
        }

        private GroundRenderer groundRenderer;

        //private ShaderStorageBufferPtr shaderStorageBufferPtr;
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
            using (var buffer = new ShaderStorageBuffer<vec4>(BufferUsage.StaticDraw))
            {
                buffer.Alloc(vertexCount);
                unsafe
                {
                    var array = (vec4*)buffer.Header.ToPointer();
                    array[0] = new vec4(0, 0, 1, 1);
                    array[1] = new vec4(1, 0, 0, 1);
                    array[2] = new vec4(-1, 0, 0, 1);
                    array[3] = new vec4(0, 1, 0, 1);
                }
                var bufferPtr = buffer.GetBufferPtr() as ShaderStorageBufferPtr;
                bufferPtr.Binding(this.Program, "PositionBuffer", 0);
                bufferPtr.Unbind();
                //this.shaderStorageBufferPtr = bufferPtr;
            }
            using (var buffer = new ShaderStorageBuffer<vec4>(BufferUsage.StaticDraw))
            {
                buffer.Alloc(vertexCount);
                unsafe
                {
                    var array = (vec4*)buffer.Header.ToPointer();
                    array[0] = new vec4(+1, +0, +0, 0);
                    array[1] = new vec4(+0, +1, +0, 0);
                    array[2] = new vec4(+0, +0, +1, 0);
                    array[3] = new vec4(+1, +1, +1, 0);
                    //array[0] = new vec3(new vec3(0, 0, 0));
                    //array[1] = new vec3(new vec3(1, 1, +1));
                    //array[2] = new vec3(new vec3(0, +1, 0));
                }
                var bufferPtr = buffer.GetBufferPtr() as ShaderStorageBufferPtr;
                bufferPtr.Binding(this.Program, "ColorBuffer", 1);
                bufferPtr.Unbind();
                //this.shaderStorageBufferPtr = bufferPtr;
            }

            this.groundRenderer.Initialize();
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            mat4 projection = arg.Camera.GetProjectionMatrix();
            mat4 view = arg.Camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            this.SetUniform("projectionMatrix", projection);
            this.SetUniform("viewMatrix", view);
            this.SetUniform("modelMatrix", model);

            base.DoRender(arg);

            this.groundRenderer.Render(arg);
        }
    }

    internal class BufferBlockModel : IBufferable
    {
        private IndexBufferPtr indexBufferPtr;

        public VertexAttributeBufferPtr GetVertexAttributeBufferPtr(string bufferName, string varNameInShader)
        {
            return null;
        }

        public IndexBufferPtr GetIndexBufferPtr()
        {
            if (indexBufferPtr == null)
            {
                using (var buffer = new OneIndexBuffer(IndexElementType.UInt, DrawMode.Triangles, BufferUsage.StaticDraw))
                {
                    buffer.Alloc(3 * 3);
                    unsafe
                    {
                        var array = (uint*)buffer.Header.ToPointer();
                        array[0] = 0; array[1] = 1; array[2] = 3;
                        array[3] = 0; array[4] = 3; array[5] = 2;
                        array[6] = 1; array[7] = 3; array[8] = 2;
                    }

                    indexBufferPtr = buffer.GetBufferPtr();
                }
            }

            return indexBufferPtr;
        }

        public bool UsesZeroIndexBuffer()
        {
            return false;
        }
    }
}