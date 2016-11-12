namespace CSharpGL
{
    public partial class Renderer
    {
        /// <summary>
        ///
        /// </summary>
        protected override void DisposeUnmanagedResources()
        {
            VertexArrayObject vao = this.vertexArrayObject;
            if (vao != null)
            {
                vao.Dispose();
            }
            VertexBuffer[] vbos = this.vertexAttributeBuffers;
            if (vbos != null)
            {
                foreach (VertexBuffer item in vbos)
                {
                    item.Dispose();
                }
            }
            IndexBuffer indexBuffer = this.indexBuffer;
            if (indexBuffer != null)
            {
                indexBuffer.Dispose();
            }
            ShaderProgram program = this.Program;
            if (program != null)
            {
                program.Dispose();
            }
        }
    }
}