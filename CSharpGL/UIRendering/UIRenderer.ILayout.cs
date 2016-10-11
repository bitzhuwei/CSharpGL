using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// Renderer  that supports UI layout.
    /// 支持2D UI布局的渲染器
    /// </summary>
    public partial class UIRenderer
    {
        /// <summary>
        /// 
        /// </summary>
        public LayoutManager<UIRenderer> LayoutManager { get; private set; }

        /// <summary>
        /// triggered before layout in <see cref="ILayout&lt;T&gt;"/>.Layout().
        /// </summary>
        public event EventHandler BeforeLayout
        {
            add { this.LayoutManager.BeforeLayout += value; }
            remove { this.LayoutManager.BeforeLayout -= value; }
        }

        /// <summary>
        /// triggered after layout in <see cref="ILayout&lt;T&gt;"/>.Layout().
        /// </summary>
        public event EventHandler AfterLayout
        {
            add { this.LayoutManager.AfterLayout += value; }
            remove { this.LayoutManager.AfterLayout -= value; }
        }


        void ILayoutEvent.DoBeforeLayout()
        {
            ILayoutEvent innerEvent = this.LayoutManager;
            innerEvent.DoBeforeLayout();
        }

        void ILayoutEvent.DoAfterLayout()
        {
            ILayoutEvent innerEvent = this.LayoutManager;
            innerEvent.DoAfterLayout();
        }

        /// <summary>
        ///
        /// </summary>
        protected const string strILayout = "ILayout";

        /// <summary>
        ///
        /// </summary>
        [Category(strILayout)]
        public System.Windows.Forms.AnchorStyles Anchor
        {
            get { return this.LayoutManager.Anchor; }
            set { this.LayoutManager.Anchor = value; }
        }

        /// <summary>
        ///
        /// </summary>
        [Category(strILayout)]
        public System.Windows.Forms.Padding Margin
        {
            get { return this.LayoutManager.Margin; }
            set { this.LayoutManager.Margin = value; }
        }

        private bool locationUpdated
        {
            get { return this.LayoutManager.locationUpdated; }
            set { this.LayoutManager.locationUpdated = value; }
        }

        /// <summary>
        ///
        /// </summary>
        [Category(strILayout)]
        [ReadOnly(true)]
        public System.Drawing.Point Location
        {
            get { return this.LayoutManager.Location; }
            set { this.LayoutManager.Location = value; }
        }

        private System.Drawing.Size size;
        private bool sizeUpdated
        {
            get { return this.LayoutManager.sizeUpdated; }
            set { this.LayoutManager.sizeUpdated = value; }
        }

        /// <summary>
        ///
        /// </summary>
        [Category(strILayout)]
        public System.Drawing.Size Size
        {
            get { return this.LayoutManager.Size; }
            set { this.LayoutManager.Size = value; }
        }

        /// <summary>
        ///
        /// </summary>
        [Browsable(false)]
        [Category(strILayout)]
        public System.Drawing.Size ParentLastSize
        {
            get { return this.LayoutManager.ParentLastSize; }
            set { this.LayoutManager.ParentLastSize = value; }
        }

        /// <summary>
        ///
        /// </summary>
        [Category(strILayout)]
        public int zNear
        {
            get { return this.LayoutManager.zNear; }
            set { this.LayoutManager.zNear = value; }
        }

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
        public UIRenderer Self { get { return this; } }

        /// <summary>
        ///
        /// </summary>
        [Category(strTreeNode)]
        [Description("Parent UI Renderer.")]
        public UIRenderer Parent
        {
            get { return this.LayoutManager.Parent.Owner; }
            set { this.LayoutManager.Parent.Owner = value; }
        }

        //ChildList<UIRenderer> children;

        /// <summary>
        ///
        /// </summary>
        [Category(strTreeNode)]
        [Editor(typeof(IListEditor<UIRenderer>), typeof(UITypeEditor))]
        [Description("Children UI Renderers.")]
        public ChildList<UIRenderer> Children
        {
            get
            {
                var list = new ChildList<UIRenderer>();
                foreach (var item in this.LayoutManager.Children)
                {
                    list.Add(item.Owner);
                }
                return list;
            }
        }
    }
}