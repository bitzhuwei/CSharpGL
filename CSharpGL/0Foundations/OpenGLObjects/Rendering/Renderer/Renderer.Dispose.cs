namespace CSharpGL
{
    public partial class Renderer
    {
        /// <summary>
        ///
        /// </summary>
        protected override void DisposeUnmanagedResources()
        {
            if (this.vertexArrayObject != null)
            {
                this.vertexArrayObject.Dispose();
            }
            if (this.vertexAttributeBufferPtrs != null)
            {
                foreach (var item in this.vertexAttributeBufferPtrs) { item.Dispose(); }
            }
            if (this.indexBufferPtr != null)
            {
                this.indexBufferPtr.Dispose();
            }
            if (this.Program != null)
            {
                this.Program.Dispose();
            }
        }
    }
}