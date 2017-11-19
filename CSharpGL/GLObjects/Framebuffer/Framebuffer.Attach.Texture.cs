using System;
using System.Collections.Generic;

namespace CSharpGL
{
    public partial class Framebuffer
    {
        // https://www.khronos.org/opengl/wiki/GLAPI/glFramebufferTexture
        /// <summary>
        /// Attach texture's image\images in one mipmap level.
        /// If there are multiple images in one mipmap level of the specified <paramref name="texture"/>, then we will start 'layered rendering'.
        /// <para>Bind() this framebuffer before invoking this method.</para>
        /// </summary>
        /// <param name="target"></param>
        /// <param name="texture">texture of which the image to be attached.</param>
        /// <param name="location">attachment point.</param>
        /// <param name="mipmapLevel">Specifies the mipmap level of <paramref name="texture"/>​ to attach.</param>
        public void Attach(FramebufferTarget target, Texture texture, AttachmentLocation location, int mipmapLevel = 0)
        {
            if (location == AttachmentLocation.Color)
            {
                if (this.nextColorAttachmentIndex >= Framebuffer.maxColorAttachmentCount)
                { throw new IndexOutOfRangeException("Not enough color attach points!"); }

                glFramebufferTexture((uint)target, GL.GL_COLOR_ATTACHMENT0 + this.nextColorAttachmentIndex, texture != null ? texture.Id : 0, mipmapLevel);
                this.nextColorAttachmentIndex++;
            }
            else
            {
                glFramebufferTexture((uint)target, (uint)location, texture != null ? texture.Id : 0, mipmapLevel);
            }
        }

        // https://www.khronos.org/opengl/wiki/GLAPI/glFramebufferTextureLayer
        /// <summary>
        /// Attach a single layer of a <paramref name="cubemapArrayTexture"/> to the framebuffer.
        /// <para>Bind() this framebuffer before invoking this method.</para>
        /// </summary>
        /// <param name="target"></param>
        /// <param name="cubemapArrayTexture">texture​ must either be null or an existing three-dimensional texture, one- or two-dimensional array texture, cube map array texture, or multisample array texture.</param>
        /// <param name="location">attachment point.</param>
        /// <param name="layer">Specifies the layer of <paramref name="cubemapArrayTexture"/>​ to attach.</param>
        /// <param name="face"></param>
        /// <param name="mipmapLevel">Specifies the mipmap level of <paramref name="cubemapArrayTexture"/>​ to attach.</param>
        public void Attach(FramebufferTarget target, Texture cubemapArrayTexture, AttachmentLocation location, int layer, CubemapFace face, int mipmapLevel = 0)
        {
            if (location == AttachmentLocation.Color)
            {
                if (this.nextColorAttachmentIndex >= Framebuffer.maxColorAttachmentCount)
                { throw new IndexOutOfRangeException("Not enough color attach points!"); }

                glFramebufferTextureLayer((uint)target, GL.GL_COLOR_ATTACHMENT0 + this.nextColorAttachmentIndex, cubemapArrayTexture != null ? cubemapArrayTexture.Id : 0, mipmapLevel, (layer * 6 + (int)((uint)face - GL.GL_TEXTURE_CUBE_MAP_POSITIVE_X)));
                this.nextColorAttachmentIndex++;
            }
            else
            {
                glFramebufferTextureLayer((uint)target, (uint)location, cubemapArrayTexture != null ? cubemapArrayTexture.Id : 0, mipmapLevel, (layer * 6 + (int)((uint)face - GL.GL_TEXTURE_CUBE_MAP_POSITIVE_X)));
            }
        }

        // https://www.khronos.org/opengl/wiki/GLAPI/glFramebufferTextureLayer
        /// <summary>
        /// Attach a single layer of a <paramref name="texture"/> to the framebuffer.
        /// <para>Bind() this framebuffer before invoking this method.</para>
        /// </summary>
        /// <param name="target"></param>
        /// <param name="texture">texture​ must either be null or an existing three-dimensional texture, one- or two-dimensional array texture, cube map array texture, or multisample array texture.</param>
        /// <param name="location">attachment point.</param>
        /// <param name="layer">Specifies the layer of <paramref name="texture"/>​ to attach.</param>
        /// <param name="mipmapLevel">Specifies the mipmap level of <paramref name="texture"/>​ to attach.</param>
        public void Attach(FramebufferTarget target, Texture texture, AttachmentLocation location, int layer, int mipmapLevel = 0)
        {
            if (location == AttachmentLocation.Color)
            {
                if (this.nextColorAttachmentIndex >= Framebuffer.maxColorAttachmentCount)
                { throw new IndexOutOfRangeException("Not enough color attach points!"); }

                glFramebufferTextureLayer((uint)target, GL.GL_COLOR_ATTACHMENT0 + this.nextColorAttachmentIndex, texture != null ? texture.Id : 0, mipmapLevel, layer);
                this.nextColorAttachmentIndex++;
            }
            else
            {
                glFramebufferTextureLayer((uint)target, (uint)location, texture != null ? texture.Id : 0, mipmapLevel, layer);
            }
        }
    }
}
