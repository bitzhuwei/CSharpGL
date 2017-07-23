namespace CSharpGL
{
    public partial class ModernNode
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
        }
    }
}