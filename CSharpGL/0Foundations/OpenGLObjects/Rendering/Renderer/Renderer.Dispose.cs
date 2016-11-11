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
            VertexAttributeBuffer[] vbos = this.vertexAttributeBufferPtrs;
            if (vbos != null)
            {
                foreach (VertexAttributeBuffer item in vbos)
                {
                    item.Dispose();
                }
            }
            IndexBuffer indexBufferPtr = this.indexBufferPtr;
            if (indexBufferPtr != null)
            {
                indexBufferPtr.Dispose();
            }
            ShaderProgram program = this.Program;
            if (program != null)
            {
                program.Dispose();
            }
        }
    }
}