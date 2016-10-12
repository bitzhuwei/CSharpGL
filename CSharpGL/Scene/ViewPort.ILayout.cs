using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    public partial class ViewPort
    {
        /// <summary>
        /// triggered before layout in <see cref="ILayout&lt;T&gt;"/>.Layout().
        /// </summary>
        public event EventHandler<CancelEventArgs> BeforeLayout;

        /// <summary>
        /// triggered after layout in <see cref="ILayout&lt;T&gt;"/>.Layout().
        /// </summary>
        public event EventHandler AfterLayout;

        bool ILayoutEvent.DoBeforeLayout()
        {
            bool cancelTreeLayout = false;
            EventHandler<CancelEventArgs> BeforeLayout = this.BeforeLayout;
            if (BeforeLayout != null)
            {
                CancelEventArgs arg = new CancelEventArgs();
                BeforeLayout(this, arg);
                cancelTreeLayout = arg.Cancel;
            }
            return cancelTreeLayout;
        }

        void ILayoutEvent.DoAfterLayout()
        {
            EventHandler AfterLayout = this.AfterLayout;
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
        public ViewPort Self { get { return this; } }

        /// <summary>
        ///
        /// </summary>
        [Category(strTreeNode)]
        [Description("Parent UI Renderer.")]
        public ViewPort Parent { get; set; }

        //ChildList<UIRenderer> children;

        /// <summary>
        ///
        /// </summary>
        [Category(strTreeNode)]
        [Editor(typeof(IListEditor<ViewPort>), typeof(UITypeEditor))]
        [Description("Children UI Renderers.")]
        public ChildList<ViewPort> Children { get; private set; }
    }
}