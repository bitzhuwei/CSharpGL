using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Provides a <see cref="Framebuffer"/> object.
    /// </summary>
    public interface IFramebufferProvider
    {
        /// <summary>
        /// Provides a framebuffer object with specified <paramref name="width"/> and <paramref name="height"/>.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        Framebuffer GetFramebuffer(int width, int height);

        /// <summary>
        /// 
        /// </summary>
        Texture BindingTexture { get; set; }

    }
}
