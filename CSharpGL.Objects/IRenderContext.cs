using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects
{
    /// <summary>
    /// Defines the contract for an OpenGL render context.
    /// </summary>
    public interface IRenderContext : IDisposable
    {
        /// <summary>
        /// Creates the render context. Must also create the OpenGL extensions.
        /// </summary>
        /// <param name="openGLVersion">The desired OpenGL version.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="bitDepth">The bit depth.</param>
        /// <param name="parameter">The extra parameter.</param>
        /// <returns></returns>
        bool Create(GLVersion openGLVersion, int width, int height, int bitDepth, object parameter);

        /// <summary>
        /// Destroys the render context instance.
        /// </summary>
        void Destroy();

        /// <summary>
        /// Sets the dimensions of the render context.
        /// </summary>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        void SetDimensions(int width, int height);

        /// <summary>
        /// Makes the render context current.
        /// </summary>
        void MakeCurrent();

        /// <summary>
        /// Blit the rendered data to the supplied device context.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        void Blit(IntPtr hdc);

        /// <summary>
        /// Gets the render context handle.
        /// </summary>
        IntPtr RenderContextHandle { get; }

        /// <summary>
        /// Gets the device context handle.
        /// </summary>
        IntPtr DeviceContextHandle { get; }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
        int Width { get; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        int Height { get; }

        /// <summary>
        /// Gets or sets the bit depth.
        /// </summary>
        /// <value>The bit depth.</value>
        int BitDepth { get; }

        /// <summary>
        /// Gets a value indicating whether GDI drawing is enabled for this type of render context.
        /// </summary>
        /// <value><c>true</c> if GDI drawing is enabled; otherwise, <c>false</c>.</value>
        bool GDIDrawingEnabled { get; }
    }
}