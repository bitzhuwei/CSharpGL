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

        /// <summary>
        /// 
        /// </summary>
        public void Scissor()
        {
            GL.Instance.Scissor(this.absLeft, this.absBottom, this.Width, this.Height);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Viewport()
        {
            GL.Instance.Viewport(this.absLeft, this.absBottom, this.Width, this.Height);
        }


        #region IGUIRenderable 成员

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;
        /// <summary>
        /// 
        /// </summary>
        public ThreeFlags EnableRendering
        {
            get { return this.enableRendering; }
            set { this.enableRendering = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        public abstract void RenderBeforeChildren(GUIRenderEventArgs arg);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        public abstract void RenderAfterChildren(GUIRenderEventArgs arg);

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