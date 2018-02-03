using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// Renders a <see cref="GLControl"/>.
    /// </summary>
    public abstract partial class GLControl
    {
        #region IGUIRenderable 成员

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;
        /// <summary>
        /// 
        /// </summary>
        [Category(strGLControl)]
        [Description("Render this control or not?")]
        public ThreeFlags EnableGUIRendering
        {
            get { return this.enableRendering; }
            set { this.enableRendering = value; }
        }

        /// <summary>
        /// Render back ground or not?
        /// </summary>
        [Category(strGLControl)]
        [Description("Render back ground or not?")]
        public bool RenderBackground { get; set; }

        private vec4 backgroundColor = new vec4(1, 0, 0, 1);
        /// <summary>
        /// Rendder background in what color?
        /// </summary>
        [Category(strGLControl)]
        [Description("Rendder background in what color?")]
        public vec4 BackgroundColor
        {
            get { return backgroundColor; }
            set { backgroundColor = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        public virtual void RenderGUIBeforeChildren(GUIRenderEventArgs arg)
        {
            GL.Instance.Enable(GL.GL_SCISSOR_TEST);
            GL.Instance.Scissor(this.absLeft, this.absBottom, this.width, this.height);
            GL.Instance.Viewport(this.absLeft, this.absBottom, this.width, this.height);

            if (this.RenderBackground)
            {
                vec4 color = this.BackgroundColor;
                GL.Instance.ClearColor(color.x, color.y, color.z, color.w);
                GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        public virtual void RenderGUIAfterChildren(GUIRenderEventArgs arg) { }

        #endregion


        #region Initialize()

        private static object synObj = new object();

        //private bool initializing = false;

        ///// <summary>
        ///// in initializing process.
        ///// </summary>
        //public bool Initializing
        //{
        //    get { return initializing; }
        //}

        private bool isInitialized = false;

        /// <summary>
        /// Already initialized.
        /// </summary>
        [Category(strGLControl)]
        [Description("Is this node initialized or not?")]
        public bool IsInitialized { get { return isInitialized; } }

        /// <summary>
        /// Initialize all stuff related to OpenGL.
        /// </summary>
        public void Initialize()
        {
            if (!isInitialized)
            {
                lock (synObj)
                {
                    if (!isInitialized)
                    {
                        //initializing = true;
                        DoInitialize();
                        //initializing = false;
                        isInitialized = true;
                    }
                }
            }
        }

        /// <summary>
        /// This method should only be invoked once.
        /// </summary>
        protected virtual void DoInitialize() { }

        #endregion Initialize()
    }
}