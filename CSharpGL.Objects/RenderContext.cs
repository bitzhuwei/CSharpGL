using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpGL.Objects
{
    /// <summary>
    /// OpenGL Render Context.
    /// </summary>
    public abstract class RenderContext : IRenderContext
    {
        /// <summary>
        /// 每个线程最多有1个<see cref="RenderContext"/>。
        /// </summary>
        internal static readonly Dictionary<Thread, RenderContext> renderContextDict = new Dictionary<Thread, RenderContext>();

        protected GLVersion requestedOpenGLVersion;
        protected GLVersion createdOpenGLVersion;

        #region IRenderContext 成员

        public virtual bool Create(GLVersion openGLVersion, int width, int height, int bitDepth, object parameter)
        {
            //  Set the width, height and bit depth.
            Width = width;
            Height = height;
            BitDepth = bitDepth;

            //  For now, assume we're going to be able to create the requested OpenGL version.
            requestedOpenGLVersion = openGLVersion;
            createdOpenGLVersion = openGLVersion;

            return true;
        }

        public void Destroy()
        {
            //  If we have a render context, destroy it.
            IntPtr handle = this.RenderContextHandle;
            if (handle != IntPtr.Zero)
            {
                this.RenderContextHandle = IntPtr.Zero;
                Win32.wglDeleteContext(handle);
            }
        }

        public void SetDimensions(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public abstract void MakeCurrent();

        public abstract void Blit(IntPtr hdc);

        public IntPtr RenderContextHandle { get; protected set; }

        public IntPtr DeviceContextHandle { get; protected set; }

        public int Width { get; protected set; }

        public int Height { get; protected set; }

        public int BitDepth { get; protected set; }

        public bool GDIDrawingEnabled { get; protected set; }

        #endregion

        #region IDisposable 成员

        public void Dispose()
        {
            this.Destroy();
        }

        #endregion
    }
}
