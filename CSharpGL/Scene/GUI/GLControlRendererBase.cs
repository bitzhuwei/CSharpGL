using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// Renders a <see cref="GLControl"/>.
    /// </summary>
    public abstract partial class GLControlRendererBase : IDisposable
    {
        private const string strGLControlRendererBase = "GLControlRendererBase";

        /// <summary>
        /// 为便于调试而设置的ID值，没有应用意义。
        /// <para>for debugging purpose only.</para>
        /// </summary>
        [Category(strGLControlRendererBase)]
        [Description("为便于调试而设置的ID值，没有应用意义。(for debugging purpose only.)")]
        public int Id { get; private set; }

        private static int idCounter = 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        public abstract void Render(GLControl control);

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[{0}]: [{1}]", this.Id, this.GetType().Name);
        }

        /// <summary>
        /// 用OpenGL初始化和渲染一个模型。
        /// <para>Initialize and render something with OpenGL.</para>
        /// </summary>
        public GLControlRendererBase()
        {
            this.Id = idCounter++;
        }

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
        [Category(strGLControlRendererBase)]
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