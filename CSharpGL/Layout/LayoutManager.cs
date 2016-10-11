using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Manages how specified owner layout.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LayoutManager<T> : ILayout<LayoutManager<T>>, ILayoutEvent
    {
        /// <summary>
        /// 
        /// </summary>
        public T Owner { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="anchor"></param>
        /// <param name="margin"></param>
        /// <param name="size"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public LayoutManager(T owner, System.Windows.Forms.AnchorStyles anchor, System.Windows.Forms.Padding margin,
            System.Drawing.Size size, int zNear, int zFar)
        {
            this.Owner = owner;

            this.Children = new ChildList<LayoutManager<T>>(this);

            this.Anchor = anchor; this.Margin = margin;
            this.Size = size; this.zNear = zNear; this.zFar = zFar;
        }
        /// <summary>
        /// triggered before layout in <see cref="ILayout&lt;T&gt;"/>.Layout().
        /// </summary>
        public event EventHandler BeforeLayout;

        /// <summary>
        /// triggered after layout in <see cref="ILayout&lt;T&gt;"/>.Layout().
        /// </summary>
        public event EventHandler AfterLayout;

        void ILayoutEvent.DoBeforeLayout()
        {
            EventHandler BeforeLayout = this.BeforeLayout;
            if (BeforeLayout != null)
            {
                BeforeLayout(this, null);
            }
        }

        void ILayoutEvent.DoAfterLayout()
        {
            EventHandler AfterLayout = this.AfterLayout;
            if (AfterLayout != null)
            {
                AfterLayout(this, null);
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
        /// <summary>
        /// 
        /// </summary>
        public bool locationUpdated = false;

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
        /// <summary>
        /// 
        /// </summary>
        public bool sizeUpdated = false;

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
        public LayoutManager<T> Self { get { return this; } }

        /// <summary>
        ///
        /// </summary>
        [Category(strTreeNode)]
        [Description("Parent Layout Manager.")]
        public LayoutManager<T> Parent { get; set; }

        //ChildList<UIRenderer> children;

        /// <summary>
        ///
        /// </summary>
        [Category(strTreeNode)]
        [Editor(typeof(IListEditor<UIRenderer>), typeof(UITypeEditor))]
        [Description("Children Layout Managers.")]
        public ChildList<LayoutManager<T>> Children { get; private set; }
    }
}
