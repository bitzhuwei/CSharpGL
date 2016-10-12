using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    public partial class PercentViewPort
    {
        /// <summary>
        /// triggered after layout in <see cref="ILayout&lt;T&gt;"/>.Layout().
        /// <para>This view port will not perform layout if no event assigned.</para>
        /// </summary>
        public event EventHandler Layout;

        bool ILayoutEvent.DoBeforeLayout()
        {
            bool cancelTreeLayout = false;
            return cancelTreeLayout;
        }

        void ILayoutEvent.DoAfterLayout()
        {
            EventHandler AfterLayout = this.Layout;
            if (AfterLayout != null)
            {
                AfterLayout(this, EventArgs.Empty);
            }
        }

        /// <summary>
        ///
        /// </summary>
        protected const string strILayout = "ILayout";

        /// <summary>
        ///
        /// </summary>
        [Category(strILayout)]
        public System.Windows.Forms.AnchorStyles Anchor { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Category(strILayout)]
        public System.Windows.Forms.Padding Margin { get; set; }

        private System.Drawing.Point location;
        private bool locationUpdated = false;

        /// <summary>
        ///
        /// </summary>
        [Category(strILayout)]
        [ReadOnly(true)]
        public System.Drawing.Point Location
        {
            get { return location; }
            set
            {
                if (location != value)
                {
                    location = value;
                    locationUpdated = true;
                }
            }
        }

        private System.Drawing.Size size;
        private bool sizeUpdated = false;

        /// <summary>
        ///
        /// </summary>
        [Category(strILayout)]
        public System.Drawing.Size Size
        {
            get { return size; }
            set
            {
                if (value != size)
                {
                    size = value;
                    sizeUpdated = true;
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        [Browsable(false)]
        [Category(strILayout)]
        public System.Drawing.Size ParentLastSize { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Category(strILayout)]
        public int zNear { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Category(strILayout)]
        public int zFar { get; set; }

        private const string strTreeNode = "TreeNode";

        /// <summary>
        ///
        /// </summary>
        [Category(strTreeNode)]
        [Description("Self.")]
        public PercentViewPort Self { get { return this; } }

        /// <summary>
        ///
        /// </summary>
        [Category(strTreeNode)]
        [Description("Parent UI Renderer.")]
        public PercentViewPort Parent { get; set; }

        //ChildList<UIRenderer> children;

        /// <summary>
        ///
        /// </summary>
        [Category(strTreeNode)]
        [Editor(typeof(IListEditor<PercentViewPort>), typeof(UITypeEditor))]
        [Description("Children UI Renderers.")]
        public ChildList<PercentViewPort> Children { get; private set; }
    }
}