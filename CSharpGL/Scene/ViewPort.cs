using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;

namespace CSharpGL
{
    // http://www.cnblogs.com/bitzhuwei/p/CSharpGL-35-render-scene-to-multiple-view-port.html
    /// <summary>
    /// Render scene to an area of canvas.
    /// </summary>
    public partial class ViewPort : ILayout<ViewPort>, ILayoutEvent
    {
        private const string viewport = "View Port";

        private ViewportSwitch viewportSwitch;
        private ScissorTestSwitch scissorTestSwitch;

        private bool enabled = true;

        /// <summary>
        /// Does this viewport and all its children take part in rendering?
        /// </summary>
        [Category(viewport)]
        [Description("Does this viewport and all its children take part in rendering?")]
        public virtual bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

        private bool visiable = true;

        /// <summary>
        /// Does this viewport take part in rendering?
        /// </summary>
        [Category(viewport)]
        [Description("Does this viewport take part in rendering?")]
        public virtual bool Visiable
        {
            get { return visiable; }
            set { visiable = value; }
        }

        /// <summary>
        /// Camera used to look at scene when rendering in this view port.
        /// </summary>
        [Category(viewport)]
        [Description("camera of the view port.")]
        [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
        public ICamera Camera { get; private set; }

        /// <summary>
        /// background color in this view port's area.
        /// </summary>
        [Category(viewport)]
        [Description("background color.")]
        public Color ClearColor { get; set; }

        /// <summary>
        /// Rectangle area of this view port.
        /// </summary>
        [Category(viewport)]
        [Description("Rectangle area of this view port.")]
        public Rectangle Rect { get { return new Rectangle(this.location, this.size); } }

        /// <summary>
        /// Indicates whether speicifed <paramref name="point"/>(Left Down is (0, 0)) is in this view port's area.
        /// </summary>
        /// <param name="point">point's position in OpenGL coordinate(Left Down is (0, 0)).</param>
        /// <returns></returns>
        public bool Contains(Point point)
        {
            return this.Rect.Contains(point);
        }

        /// <summary>
        /// Render scene to an area of canvas.
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="anchor"></param>
        /// <param name="margin"></param>
        /// <param name="size"></param>
        public ViewPort(ICamera camera,
            System.Windows.Forms.AnchorStyles anchor, System.Windows.Forms.Padding margin,
            System.Drawing.Size size)
        {
            this.Children = new ChildList<ViewPort>(this);// new ILayoutList(this);

            this.Camera = camera;
            this.Anchor = anchor;
            this.Margin = margin;
            this.Size = size;
        }

        private bool isInitialized = false;

        /// <summary>
        ///
        /// </summary>
        private void Initialize()
        {
            if (!this.isInitialized)
            {
                this.viewportSwitch = new ViewportSwitch();
                this.scissorTestSwitch = new ScissorTestSwitch();
                this.isInitialized = true;
            }
        }

        /// <summary>
        /// limit rendering area.
        /// </summary>
        public void On()
        {
            if (!this.isInitialized) { this.Initialize(); }

            if (this.locationUpdated)
            {
                this.viewportSwitch.X = this.Location.X;
                this.viewportSwitch.Y = this.Location.Y;
                this.scissorTestSwitch.X = this.Location.X;
                this.scissorTestSwitch.Y = this.Location.Y;
                this.locationUpdated = false;
            }
            if (this.sizeUpdated)
            {
                this.viewportSwitch.Width = this.Size.Width;
                this.viewportSwitch.Height = this.Size.Height;
                this.scissorTestSwitch.Width = this.Size.Width;
                this.scissorTestSwitch.Height = this.Size.Height;
                this.sizeUpdated = false;
            }

            this.viewportSwitch.On();
            this.scissorTestSwitch.On();
        }

        /// <summary>
        /// cancel limitation.
        /// </summary>
        public void Off()
        {
            if (!this.isInitialized) { this.Initialize(); }

            this.scissorTestSwitch.Off();
            this.viewportSwitch.Off();
        }
    }
}