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
            VertexAttributeBufferPtr[] vbos = this.vertexAttributeBufferPtrs;
            if (vbos != null)
            {
                foreach (VertexAttributeBufferPtr item in vbos)
                {
                    item.Dispose();
                }
            }
            IndexBufferPtr indexBufferPtr = this.indexBufferPtr;
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