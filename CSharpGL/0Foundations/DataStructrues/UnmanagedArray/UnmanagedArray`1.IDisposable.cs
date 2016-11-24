namespace CSharpGL
{
    public sealed unsafe partial class UnmanagedArray<T>
    {
        /// <summary>
        /// How many <see cref="UnmanagedArray&lt;T&gt;"/> objects allocated?
        /// <para>Only used for debugging.</para>
        /// </summary>
        private static int thisTypeAllocatedCount = 0;

        /// <summary>
        /// How many <see cref="UnmanagedArray&lt;T&gt;"/> objects released?
        /// <para>Only used for debugging.</para>
        /// </summary>
        private static int thisTypeDisposedCount = 0;

        /// <summary>
        /// Dispose unmanaged resources
        /// </summary>
        protected override void DisposeUnmanagedResources()
        {
            base.DisposeUnmanagedResources();

            UnmanagedArray<T>.thisTypeDisposedCount++;
        }
    }
}