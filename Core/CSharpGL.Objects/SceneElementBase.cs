using CSharpGL.Objects.Shaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects
{
    /// <summary>
    /// 用OpenGL初始化和渲染一个元素。
    /// 只做初始化和渲染这两件事。
    /// 渲染前后有事件event可以配置。
    /// </summary>
    public abstract class SceneElementBase : IRenderable, IDisposable
    {
        /// <summary>
        /// 为便于调试而设置的ID值，没有应用意义。
        /// </summary>
        public int ID { get; protected set; }

        public static int idCounter = 0;

        public override string ToString()
        {
            return string.Format("element: {0}，{1}", this.ID, this.GetType());
        }

        /// <summary>
        /// 用OPENGL渲染一个元素。
        /// </summary>
        public SceneElementBase()
        {
            this.ID = idCounter++;
        }

        protected bool initialized = false;

        /// <summary>
        /// 初始化此Element，此方法应且只应执行1次。
        /// </summary>
        public void Initialize()
        {
            if (!initialized)
            {
                DoInitialize();

                initialized = true;
            }
        }

        /// <summary>
        /// 初始化此Element，此方法应且只应执行1次。
        /// </summary>
        protected abstract void DoInitialize();

        /// <summary>
        /// 渲染
        /// </summary>
        /// <param name="renderMode"></param>
        public void Render(RenderEventArgs e)
        {
            if (!initialized) { Initialize(); }

            EventHandler<RenderEventArgs> beforeRendering = this.BeforeRendering;
            if (beforeRendering != null)
            {
                beforeRendering(this, e);
            }

            DoRender(e);

            EventHandler<RenderEventArgs> afterRendering = this.AfterRendering;
            if (afterRendering != null)
            {
                afterRendering(this, e);
            }
        }

        /// <summary>
        /// 执行渲染操作
        /// </summary>
        /// <param name="renderMode"></param>
        protected abstract void DoRender(RenderEventArgs e);

        /// <summary>
        /// 在渲染前进行某些准备（更新camera矩阵信息等）
        /// </summary>
        public event EventHandler<RenderEventArgs> BeforeRendering;

        /// <summary>
        /// 在渲染后进行某些善后（恢复OpenGL状态等）
        /// </summary>
        public event EventHandler<RenderEventArgs> AfterRendering;



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
        ~SceneElementBase()
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
        protected void Dispose(bool disposing)
        {

            if (this.disposedValue == false)
            {
                if (disposing)
                {
                    // Dispose managed resources.
                    CleanManagedRes();
                } // end if

                // Dispose unmanaged resources.
                CleanUnmanagedRes();
            } // end if

            this.disposedValue = true;
        } // end sub

        #endregion

        protected virtual void CleanUnmanagedRes()
        {
            // do something like this if needed before opengl context is destroyed.
            //var buffers = new uint[] { this.vertexsBufferObject, this.colorsBufferObject, this.visiblesBufferObject };
            //GL.DeleteBuffers(buffers.Length, buffers);
            //GL.DeleteVertexArrays(1, new uint[] { this.vertexArrayObject });
        }

        protected virtual void CleanManagedRes()
        {
        }
    }

}
