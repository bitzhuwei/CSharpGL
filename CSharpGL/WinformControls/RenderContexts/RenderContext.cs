using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public abstract class RenderContext : IDisposable
    {
        /// <summary>
        /// Creates the render context provider. Must also create the OpenGL extensions.
        /// </summary>
        /// <param name="openGLVersion">The desired OpenGL version.</param>
        /// <param name="gl">The OpenGL context.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="bitDepth">The bit depth.</param>
        /// <param name="parameter">The extra parameter.</param>
        /// <returns></returns>
        public virtual bool Create(GLVersion openGLVersion, int width, int height, int bitDepth, object parameter)
        {
            //  Set the width, height and bit depth.
            Width = width;
            Height = height;
            BitDepth = bitDepth;

            //  For now, assume we're going to be able to create the requested OpenGL version.
            RequestedGLVersion = openGLVersion;
            CreatedGLVersion = openGLVersion;

            return true;
        }

        /// <summary>
        /// Destroys the render context provider instance.
        /// </summary>
        public virtual void Destroy()
        {
            //  If we have a render context, destroy it.
            if (RenderContextHandle != IntPtr.Zero)
            {
                Win32.wglDeleteContext(RenderContextHandle);
                RenderContextHandle = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Sets the dimensions of the render context provider.
        /// </summary>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        public virtual void SetDimensions(int width, int height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Makes the render context current.
        /// </summary>
        public abstract void MakeCurrent();

        /// <summary>
        /// Blit the rendered data to the supplied device context.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        public abstract void Blit(IntPtr hdc);

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            //  Destroy the context provider.
            Destroy();
        }

        /// <summary>
        /// Only valid to be called after the render context is created, this function attempts to
        /// move the render context to the OpenGL version originally requested. If this is &gt; 2.1, this
        /// means building a new context. If this fails, we'll have to make do with 2.1.
        /// </summary>
        /// <param name="gl">The OpenGL instance.</param>
        protected void UpdateContextVersion()
        {
            //  If the request version number is anything up to and including 2.1, standard render contexts
            //  will provide what we need (as long as the graphics card drivers are up to date).
            var requestedVersionNumber = VersionAttribute.GetVersionAttribute(RequestedGLVersion);
            if (requestedVersionNumber.IsAtLeastVersion(3, 0) == false)
            {
                CreatedGLVersion = RequestedGLVersion;
                return;
            }

            //  Now the none-trivial case. We must use the WGL_ARB_create_context extension to 
            //  attempt to create a 3.0+ context.
            try
            {
                int[] attributes = 
                {
                    GL.WGL_CONTEXT_MAJOR_VERSION_ARB, requestedVersionNumber.Major,  
                    GL.WGL_CONTEXT_MINOR_VERSION_ARB, requestedVersionNumber.Minor,
                    GL.WGL_CONTEXT_FLAGS_ARB, GL.WGL_CONTEXT_FORWARD_COMPATIBLE_BIT_ARB,// compatible profile
#if DEBUG
                    GL.WGL_CONTEXT_FLAGS_ARB, GL.WGL_CONTEXT_DEBUG_BIT_ARB,// this is a debug context
#endif
                    0
                };
                IntPtr hrc = GL.GetDelegateFor<GL.wglCreateContextAttribsARB>()(this.DeviceContextHandle, IntPtr.Zero, attributes);
                Win32.wglMakeCurrent(IntPtr.Zero, IntPtr.Zero);
                Win32.wglDeleteContext(RenderContextHandle);
                Win32.wglMakeCurrent(DeviceContextHandle, hrc);
                RenderContextHandle = hrc;
            }
            catch (Exception)
            {
                //  TODO: can we actually get the real version?
                CreatedGLVersion = GLVersion.OpenGL2_1;
            }
        }

        /// <summary>
        /// Gets the render context handle.
        /// </summary>
        public IntPtr RenderContextHandle { get; protected set; }

        /// <summary>
        /// Gets the device context handle.
        /// </summary>
        public IntPtr DeviceContextHandle { get; protected set; }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
        public int Width { get; protected set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        public int Height { get; protected set; }

        /// <summary>
        /// Gets or sets the bit depth.
        /// </summary>
        /// <value>The bit depth.</value>
        public int BitDepth { get; protected set; }

        /// <summary>
        /// Gets the OpenGL version that was requested when creating the render context.
        /// </summary>
        public GLVersion RequestedGLVersion { get; protected set; }

        /// <summary>
        /// Gets the OpenGL version that is supported by the render context, compare to <see cref="RequestedGLVersion"/>.
        /// </summary>
        public GLVersion CreatedGLVersion { get; protected set; }

    }
}
