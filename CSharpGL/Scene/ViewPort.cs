using System.Drawing;
namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public partial class ViewPort : ILayout<ViewPort>, ILayoutEvent
    {
        private ViewportSwitch viewportSwitch;
        private ScissorTestSwitch scissorTestSwitch;

        private bool enabled = true;

        /// <summary>
        /// Does this viewport take part in rendering?
        /// </summary>
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public ICamera Camera { get; private set; }

        /// <summary>
        ///
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
        ///
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
        ///
        /// </summary>
        public void Off()
        {
            if (!this.isInitialized) { this.Initialize(); }

            this.scissorTestSwitch.Off();
            this.viewportSwitch.Off();
        }

        public virtual void Render(RenderModes renderMode, bool autoClear, GeometryType pickingGeometryType, Scene scene)
        {
            this.On();
            scene.Render(renderMode, autoClear, pickingGeometryType);
            this.Off();
        }
    }
}