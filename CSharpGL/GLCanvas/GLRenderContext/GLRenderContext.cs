using System;

namespace CSharpGL
{
    /// <summary>
    /// OpenGL render context.
    /// </summary>
    public abstract partial class GLRenderContext : IDisposable
    {
        /// <summary>
        ///  Set the width, height and parameters.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="parameters">parameters.</param>
        /// <returns></returns>
        public GLRenderContext(int width, int height, ContextGenerationParams parameters)
        {
            this.Width = width;
            this.Height = height;
            this.Parameters = parameters;
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
        /// <param name="deviceContext">The HDC.</param>
        public abstract void Blit(IntPtr deviceContext);

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
        public ContextGenerationParams Parameters { get; protected set; }
    }
}