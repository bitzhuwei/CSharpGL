namespace CSharpGL
{
    public partial class PickableRenderer
    {
        /// <summary>
        ///
        /// </summary>
        protected override void DisposeUnmanagedResources()
        {
            // dispose picking resources
            InnerPickableRenderer renderer = this.innerPickableRenderer;
            renderer.Dispose();

            base.DisposeUnmanagedResources();
        }
    }
}