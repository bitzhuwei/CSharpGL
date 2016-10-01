using System;

namespace CSharpGL
{
    /// <summary>
    /// All information for creating render context and device context.
    /// </summary>
    public abstract partial class RenderContext : IDisposable
    {
        /// <summary>
        /// Creates the render context provider. Must also create the OpenGL extensions.
        /// </summary>
        /// <param name="openGLVersion">The desired OpenGL version.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="bitDepth">The bit depth.</param>
        /// <param name="parameter">The extra parameter.</param>
        /// <returns></returns>
        public virtual bool Create(int width, int height, int bitDepth, object parameter)
        {
            //  Set the width, height and bit depth.
            this.Width = width;
            this.Height = height;
            this.BitDepth = bitDepth;

            return true;
        }

        /// <summary>
        /// Sets the dimensions of the render context provider.
        /// </summary>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        public virtual void SetDimensions(int width, int height)
        {
            this.Width = width;
            this.Height = height;
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
    }
}