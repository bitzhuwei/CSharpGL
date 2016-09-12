namespace CSharpGL
{
    public partial class ComputeRenderer
    {
        /// <summary>
        ///
        /// </summary>
        protected override void DisposeUnmanagedResources()
        {
            if (this.Program != null)
            {
                this.Program.Delete();
            }
        }
    }
}