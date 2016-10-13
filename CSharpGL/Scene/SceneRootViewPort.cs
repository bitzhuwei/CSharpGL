using System.ComponentModel;
namespace CSharpGL
{
    /// <summary>
    /// Root view port that should never take part in rendering.
    /// </summary>
    public partial class SceneRootViewPort : ViewPort
    {
        /// <summary>
        /// Root view port that should never take part in rendering.
        /// </summary>
        /// <param name="anchor"></param>
        /// <param name="margin"></param>
        /// <param name="size"></param>
        public SceneRootViewPort(
            System.Windows.Forms.AnchorStyles anchor, System.Windows.Forms.Padding margin,
            System.Drawing.Size size)
            : base(null, anchor, margin, size)
        {
        }

        /// <summary>
        /// Does this viewport take part in rendering?
        /// </summary>
        [Category("Scene Root View Port")]
        [Description("Does this viewport take part in rendering?")]
        public override bool Visiable
        {
            get
            {
                return false;
            }
            set
            {
            }
        }
    }
}