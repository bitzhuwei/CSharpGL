namespace CSharpGL
{
    public partial class SceneElement
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
            VertexShaderAttribute[] vbos = this.vertexShaderAttributes;
            if (vbos != null)
            {
                foreach (var item in vbos)
                {
                    item.Buffer.Dispose();
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