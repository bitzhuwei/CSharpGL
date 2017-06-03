using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;

namespace CSharpGL
{
    // http://www.cnblogs.com/bitzhuwei/p/CSharpGL-35-render-scene-to-multiple-view-port.html
    /// <summary>
    /// Render scene to an area of canvas.
    /// </summary>
    public partial class ViewPort : ILayout<ViewPort>, ILayoutEvent
    {
        private const string viewport = "View Port";

        private ViewportState viewportState;
        private ScissorTestState scissorTestState;

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
            this.Children = new TreeNodeChildren(this);// new ILayoutList(this);

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
                this.viewportState = new ViewportState();
                this.scissorTestState = new ScissorTestState();
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
                this.viewportState.X = this.Location.X;
                this.viewportState.Y = this.Location.Y;
                this.scissorTestState.X = this.Location.X;
                this.scissorTestState.Y = this.Location.Y;
                this.locationUpdated = false;
            }
            if (this.sizeUpdated)
            {
                this.viewportState.Width = this.Size.Width;
                this.viewportState.Height = this.Size.Height;
                this.scissorTestState.Width = this.Size.Width;
                this.scissorTestState.Height = this.Size.Height;
                this.sizeUpdated = false;
            }

            this.viewportState.On();
            this.scissorTestState.On();
        }

        /// <summary>
        /// cancel limitation.
        /// </summary>
        public void Off()
        {
            if (!this.isInitialized) { this.Initialize(); }

            this.scissorTestState.Off();
            this.viewportState.Off();
        }

        /// <summary>
        /// render scene in this view port.
        /// </summary>
        /// <param name="scene"></param>
        /// <param name="clientRectangle"></param>
        /// <param name="pickingGeometryType"></param>
        public virtual void Render(Scene scene, Rectangle clientRectangle, PickingGeometryType pickingGeometryType)
        {
            this.On();// limit rendering area.

            if (pickingGeometryType == PickingGeometryType.None)
            {
                RenderNormally(scene, clientRectangle);
            }
            else
            {
                RenderColorCoded(scene, clientRectangle, pickingGeometryType);
            }

            this.Off();// cancel limitation.
        }

        private void RenderColorCoded(Scene scene, Rectangle clientRectangle, PickingGeometryType pickingGeometryType)
        {
            var color = new vec4(1, 1, 1, 1);
            OpenGL.glClearColor(color.x, color.y, color.z, color.w);

            OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);

            var arg = new RenderEventArgs(scene.FirstCamera, clientRectangle, pickingGeometryType);
            // render objects.
            // Render all PickableRenderers for color-coded picking.
            List<IPickable> pickableRendererList = scene.Render4Picking(arg);

            //// render regular UI.
            //this.RootUI.Render(arg);

            //// render cursor.
            //UICursor cursor = this.Cursor;
            //if (cursor != null && cursor.Enabled)
            //{
            //    cursor.UpdatePosition(mousePosition);
            //    this.rootCursor.Render(arg);
            //}
        }

        private void RenderNormally(Scene scene, Rectangle clientRectangle)
        {
            var arg = new RenderEventArgs(scene.FirstCamera, clientRectangle, PickingGeometryType.None);

            vec4 color = this.ClearColor.ToVec4();
            OpenGL.glClearColor(color.x, color.y, color.z, color.w);

            OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);

            // render objects.
            SceneObject obj = scene.RootObject;
            this.RenderObject(obj, arg);

            // render regular UI.
            scene.RootUI.Render(arg);

            //// render cursor.
            //UICursor cursor = this.Cursor;
            //if (cursor != null && cursor.Enabled)
            //{
            //    cursor.UpdatePosition(mousePosition);
            //    this.rootCursor.Render(arg);
            //}
        }

        /// <summary>
        /// render object recursively.
        /// </summary>
        /// <param name="sceneObject"></param>
        /// <param name="arg"></param>
        private void RenderObject(SceneObject sceneObject, RenderEventArgs arg)
        {
            if (sceneObject.RenderingEnabled)
            {
                //sceneObject.DoBeforeRendering();
                GLState[] switchArray = sceneObject.GroupStateList.ToArray();
                for (int i = 0; i < switchArray.Length; i++)
                {
                    switchArray[i].On();
                }
                sceneObject.Render(arg);
                ITreeNode[] array = sceneObject.Children.ToArray();
                foreach (ITreeNode child in array)
                {
                    RenderObject(child as SceneObject, arg);
                }
                //sceneObject.DoAfterRendering();
                for (int i = switchArray.Length - 1; i >= 0; i--)
                {
                    switchArray[i].Off();
                }
            }
        }
    }
}