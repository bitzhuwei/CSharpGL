using System;
using System.Collections.Generic;

namespace CSharpGL
{
    public partial class Framebuffer
    {
        /// <summary>
        /// Attach texture's image\images in one mipmap level.
        /// If there are multiple images in one mipmap level of the specified <paramref name="texture"/>, then we will start 'layered rendering'.
        /// <para>Bind() this framebuffer before invoking this method.</para>
        /// </summary>
        /// <param name="texture">texture of which the image to be attached.</param>
        /// <param name="location">attachment point.</param>
        /// <param name="mipmapLevel">In which mipmap level should the image be attached?</param>
        public void Attach(Texture texture, AttachmentLocation location, int mipmapLevel = 0)
        {
            if (location == AttachmentLocation.Color)
            {
                if (this.nextColorAttachmentIndex >= Framebuffer.maxColorAttachmentCount)
                { throw new IndexOutOfRangeException("Not enough color attach points!"); }

                glFramebufferTexture(GL.GL_FRAMEBUFFER, GL.GL_COLOR_ATTACHMENT0 + this.nextColorAttachmentIndex, texture != null ? texture.Id : 0, mipmapLevel);
                this.nextColorAttachmentIndex++;
            }
            else
            {
                glFramebufferTexture(GL.GL_FRAMEBUFFER, (uint)location, texture != null ? texture.Id : 0, mipmapLevel);
            }
        }

        /// <summary>
        /// Attach texture's image in one mipmap level.
        /// <para>Bind() this framebuffer before invoking this method.</para>
        /// </summary>
        /// <param name="texture">texture of which the image to be attached.</param>
        /// <param name="location">attachment point.</param>
        /// <param name="layer">layer.</param>
        /// <param name="mipmapLevel">In which mipmap level should the image be attached?</param>
        public void Attach(Texture texture, AttachmentLocation location, int layer, int mipmapLevel = 0)
        {
            if (location == AttachmentLocation.Color)
            {
                if (this.nextColorAttachmentIndex >= Framebuffer.maxColorAttachmentCount)
                { throw new IndexOutOfRangeException("Not enough color attach points!"); }

                glFramebufferTextureLayer(GL.GL_FRAMEBUFFER, GL.GL_COLOR_ATTACHMENT0 + this.nextColorAttachmentIndex, texture != null ? texture.Id : 0, mipmapLevel, layer);
                this.nextColorAttachmentIndex++;
            }
            else
            {
                glFramebufferTextureLayer(GL.GL_FRAMEBUFFER, (uint)location, texture != null ? texture.Id : 0, mipmapLevel, layer);
            }
        }
    }
}
