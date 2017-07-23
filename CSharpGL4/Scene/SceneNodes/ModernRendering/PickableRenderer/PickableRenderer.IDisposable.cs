namespace CSharpGL
{
    public partial class PickableRenderer
    {
        /// <summary>
        ///
        /// </summary>
        protected override void DisposeUnmanagedResources()
        {
            foreach (var item in this.renderUnits)
            {
                item.Dispose();
            }

            this.PickingRenderUnit.Dispose();
        }
    }
}