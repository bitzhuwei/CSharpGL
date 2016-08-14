using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// 用OpenGL初始化和渲染一个元素。
    /// 只做初始化和渲染这两件事。
    /// <para>Initialize and render something.</para>
    /// </summary>
    //[Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public abstract class RendererBase : IRenderable, IDisposable
    {

        /// <summary>
        /// Render this or not.
        /// </summary>
        [Description("Render this or not.")]
        public bool Enabled { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 为便于调试而设置的ID值，没有应用意义。
        /// <para>Only for debugging.</para>
        /// </summary>
        public int ID { get; private set; }

        private static int idCounter = 0;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[{0}]: [{1}]", this.ID, this.Name);
        }

        /// <summary>
        /// 用OpenGL初始化和渲染一个元素。
        /// 只做初始化和渲染这两件事。
        /// <para>Initialize and render something.</para>
        /// </summary>
        public RendererBase()
        {
            this.Enabled = true;
            this.ID = idCounter++;
            this.Name = string.Format("{0}: {1}", this.ID, this.GetType().Name);
        }

        //private bool initializing = false;

        ///// <summary>
        ///// in initializing process.
        ///// </summary>
        //public bool Initializing
        //{
        //    get { return initializing; }
        //}

        private bool initialized = false;
        /// <summary>
        /// Already initialized.
        /// </summary>
        public bool Initialized
        {
            get { return initialized; }
        }

        /// <summary>
        /// Initialize all stuff related to OpenGL.
        /// </summary>
        public void Initialize()
        {
            if (!initialized)
            {
                //initializing = true;
                DoInitialize();
                //initializing = false;
                initialized = true;
            }
        }

        /// <summary>
        /// This method should only be invoked once.
        /// </summary>
        protected abstract void DoInitialize();

        /// <summary>
        /// Render something.
        /// </summary>
        /// <param name="arg"></param>
        public void Render(RenderEventArg arg)
        {
            if (this.Enabled)
            {
                if (!initialized) { Initialize(); }

                DoRender(arg);
            }
        }

        /// <summary>
        /// Render something.
        /// </summary>
        /// <param name="arg"></param>
        protected abstract void DoRender(RenderEventArg arg);


        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        } // end sub

        /// <summary>
        /// Destruct instance of the class.
        /// </summary>
        ~RendererBase()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Backing field to track whether Dispose has been called.
        /// </summary>
        private bool disposedValue = false;

        /// <summary>
        /// Dispose managed and unmanaged resources of this instance.
        /// </summary>
        /// <param name="disposing">If disposing equals true, managed and unmanaged resources can be disposed. If disposing equals false, only unmanaged resources can be disposed. </param>
        private void Dispose(bool disposing)
        {

            if (this.disposedValue == false)
            {
                if (disposing)
                {
                    // Dispose managed resources.
                    DisposeManagedResources();
                } // end if

                // Dispose unmanaged resources.
                DisposeUnmanagedResources();
            } // end if

            this.disposedValue = true;
        } // end sub

        #endregion

        /// <summary>
        /// 释放.net托管资源。
        /// <para>Dispose reources managed by .NET.</para>
        /// </summary>
        protected virtual void DisposeManagedResources() { }

        /// <summary>
        /// 释放.net非托管资源，例如释放OpenGL相关的资源（Buffer、纹理等）。
        /// <para>Dispose resources not managed by .NET(OpenGL buffers, textures, etc.).</para>
        /// </summary>
        protected virtual void DisposeUnmanagedResources() { }

    }

}
