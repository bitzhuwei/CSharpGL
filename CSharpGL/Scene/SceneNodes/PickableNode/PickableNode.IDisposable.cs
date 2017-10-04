namespace CSharpGL
{
    public partial class PickableNode
    {
        /// <summary>
        ///
        /// </summary>
        protected override void DisposeUnmanagedResources()
        {
            this.RenderUnit.Dispose();
            this.PickingRenderUnit.Dispose();
        }
    }
}