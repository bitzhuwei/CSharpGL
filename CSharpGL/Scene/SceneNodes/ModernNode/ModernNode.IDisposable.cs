namespace CSharpGL
{
    public partial class ModernNode
    {
        /// <summary>
        ///
        /// </summary>
        protected override void DisposeUnmanagedResources()
        {
            this.RenderUnit.Dispose();
        }
    }
}