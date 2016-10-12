namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public partial class SceneRootViewPort : ViewPort
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="anchor"></param>
        /// <param name="margin"></param>
        /// <param name="size"></param>
        public SceneRootViewPort(ICamera camera,
            System.Windows.Forms.AnchorStyles anchor, System.Windows.Forms.Padding margin,
            System.Drawing.Size size)
            : base(camera, anchor, margin, size)
        {
            this.Visiable = false;
        }
    }
}