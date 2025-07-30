using System;
using System.Collections.Generic;

namespace CSharpGL {
    public unsafe partial class Framebuffer {
        // https://www.khronos.org/opengl/wiki/GLAPI/glFramebufferTexture
        // https://www.khronos.org/opengl/wiki/GLAPI/glFramebufferTextureLayer

        #region glFramebufferTexture

        /// <summary>
        /// Attach a level of the <paramref name="texture"/> as a logical buffer to the currently bound framebuffer object's color attachment point.
        /// If there are multiple images in one mipmap level of the <paramref name="texture"/>, then we will start 'layered rendering'.
        /// <para>Bind() this framebuffer before invoking this method.</para>
        /// </summary>
        /// <param name="target">GL_FRAMEBUFFER is equivalent to GL_DRAW_FRAMEBUFFER</param>
        /// <param name="texture">Specifies the texture object to attach to the framebuffer attachment point named by <paramref name="colorAtttachmentLocation"/>.</param>
        /// <param name="colorAtttachmentLocation">Specifies the attachment point of the framebuffer.</param>
        /// <param name="mipmapLevel">Specifies the mipmap level of <paramref name="texture"/>​ to attach.</param>
        public void Attach(Framebuffer.Target target, Texture? texture, GLenum colorAtttachmentLocation, int mipmapLevel = 0) {
            //if (colorAtttachmentLocation >= Framebuffer.maxColorAttachmentCount) { throw new IndexOutOfRangeException(string.Format("Invalid color attachment point[{0}]!", colorAtttachmentLocation)); }

            var gl = GL.current; if (gl == null) { return; }
            gl.glFramebufferTexture((GLenum)target, GL.GL_COLOR_ATTACHMENT0 + colorAtttachmentLocation, texture?.id ?? 0u, mipmapLevel);
        }

        /// <summary>
        /// Attach a level of the <paramref name="texture"/> as a logical buffer to the currently bound framebuffer object.
        /// If there are multiple images in one mipmap level of the <paramref name="texture"/>, then we will start 'layered rendering'.
        /// <para>Bind() this framebuffer before invoking this method.</para>
        /// </summary>
        /// <param name="target">GL_FRAMEBUFFER is equivalent to GL_DRAW_FRAMEBUFFER</param>
        /// <param name="texture">Specifies the texture object to attach to the framebuffer attachment point named by <paramref name="location"/>.</param>
        /// <param name="location">Specifies the attachment point of the framebuffer.</param>
        /// <param name="mipmapLevel">Specifies the mipmap level of <paramref name="texture"/>​ to attach.</param>
        public void Attach(Framebuffer.Target target, Texture? texture, AttachmentLocation location, int mipmapLevel = 0) {
            var gl = GL.current; if (gl == null) { return; }
            gl.glFramebufferTexture((GLenum)target, (GLenum)location, texture?.id ?? 0u, mipmapLevel);
        }

        #endregion glFramebufferTexture

        #region glFramebufferTextureLayer

        // TODO: attach a total layer or a single image?
        /// <summary>
        /// Attach a single layer of a <paramref name="cubemapArrayTexture"/> to the currently bound framebuffer object's color attachment point.
        /// <para>Bind() this framebuffer before invoking this method.</para>
        /// </summary>
        /// <param name="target">GL_FRAMEBUFFER is equivalent to GL_DRAW_FRAMEBUFFER</param>
        /// <param name="cubemapArrayTexture">texture​ must either be null or an existing cube map array texture.</param>
        /// <param name="colorAtttachmentLocation">attachment point.</param>
        /// <param name="index">Specifies the index of <paramref name="cubemapArrayTexture"/>​ to attach. It's the third parameter of texture coordinate in sampler2DArray.</param>
        /// <param name="face">Specifies the face of <paramref name="cubemapArrayTexture"/>​ to attach.</param>
        /// <param name="mipmapLevel">Specifies the mipmap level of <paramref name="cubemapArrayTexture"/>​ to attach.</param>
        public void Attach(Framebuffer.Target target, Texture? cubemapArrayTexture, GLenum colorAtttachmentLocation, int index, CubemapFace face, int mipmapLevel = 0) {
            this.Attach(target, cubemapArrayTexture, colorAtttachmentLocation, (index * 6 + (int)((uint)face - GL.GL_TEXTURE_CUBE_MAP_POSITIVE_X)), mipmapLevel);
        }

        /// <summary>
        /// Attach a single layer of a <paramref name="texture"/> to the currently bound framebuffer object's color attachment point.
        /// <para>Bind() this framebuffer before invoking this method.</para>
        /// </summary>
        /// <param name="target">GL_FRAMEBUFFER is equivalent to GL_DRAW_FRAMEBUFFER</param>
        /// <param name="texture">texture​ must either be null or an existing three-dimensional texture, one- or two-dimensional array texture, cube map array texture, or multisample array texture.</param>
        /// <param name="colorAtttachmentLocation">attachment point.</param>
        /// <param name="layer">Specifies the layer of <paramref name="texture"/>​ to attach.</param>
        /// <param name="mipmapLevel">Specifies the mipmap level of <paramref name="texture"/>​ to attach.</param>
        public void Attach(Framebuffer.Target target, Texture? texture, GLenum colorAtttachmentLocation, int layer, int mipmapLevel = 0) {
            //if (colorAtttachmentLocation >= Framebuffer.maxColorAttachmentCount) { throw new IndexOutOfRangeException(string.Format("Invalid color attachment point[{0}]!", colorAtttachmentLocation)); }

            var gl = GL.current; if (gl == null) { return; }
            gl.glFramebufferTextureLayer((GLenum)target,
                GL.GL_COLOR_ATTACHMENT0 + colorAtttachmentLocation,
                texture?.id ?? 0,
                mipmapLevel,
                layer);
        }


        /// <summary>
        /// Attach a single layer of a <paramref name="cubemapArrayTexture"/> to the currently bound framebuffer object.
        /// <para>Bind() this framebuffer before invoking this method.</para>
        /// </summary>
        /// <param name="target">GL_FRAMEBUFFER is equivalent to GL_DRAW_FRAMEBUFFER</param>
        /// <param name="cubemapArrayTexture">texture​ must either be null or an existing cube map array texture.</param>
        /// <param name="location">attachment point.</param>
        /// <param name="layer">Specifies the layer of <paramref name="cubemapArrayTexture"/>​ to attach.</param>
        /// <param name="face">Specifies the face of <paramref name="cubemapArrayTexture"/>​ to attach.</param>
        /// <param name="mipmapLevel">Specifies the mipmap level of <paramref name="cubemapArrayTexture"/>​ to attach.</param>
        public void Attach(Framebuffer.Target target, Texture? cubemapArrayTexture, AttachmentLocation location, int layer, CubemapFace face, int mipmapLevel = 0) {
            this.Attach(target, cubemapArrayTexture, location, (layer * 6 + (int)((uint)face - GL.GL_TEXTURE_CUBE_MAP_POSITIVE_X)), mipmapLevel);
        }

        /// <summary>
        /// Attach a single layer of a <paramref name="texture"/> to the currently bound framebuffer object.
        /// <para>Bind() this framebuffer before invoking this method.</para>
        /// </summary>
        /// <param name="target">GL_FRAMEBUFFER is equivalent to GL_DRAW_FRAMEBUFFER</param>
        /// <param name="texture">texture​ must either be null or an existing three-dimensional texture, one- or two-dimensional array texture, cube map array texture, or multisample array texture.</param>
        /// <param name="location">attachment point.</param>
        /// <param name="layer">Specifies the layer of <paramref name="texture"/>​ to attach.</param>
        /// <param name="mipmapLevel">Specifies the mipmap level of <paramref name="texture"/>​ to attach.</param>
        public void Attach(Framebuffer.Target target, Texture? texture, AttachmentLocation location, int layer, int mipmapLevel = 0) {
            var gl = GL.current; if (gl == null) { return; }
            gl.glFramebufferTextureLayer((GLenum)target, (GLenum)location, texture?.id ?? 0u, mipmapLevel, layer);
        }

        #endregion glFramebufferTextureLayer

        /// <summary>
        /// Attach a single image of a <paramref name="cubemapTexture"/> to the currently bound framebuffer object's color attachment point.
        /// <para>Bind() this framebuffer before invoking this method.</para>
        /// </summary>
        /// <param name="target">GL_FRAMEBUFFER is equivalent to GL_DRAW_FRAMEBUFFER</param>
        /// <param name="colorAtttachmentLocation">attachment point.(0, 1, 2, ..)</param>
        /// <param name="face">Specifies the face of <paramref name="cubemapTexture"/>​ to attach.</param>
        /// <param name="cubemapTexture">texture​ must either be null or an existing cube map texture.</param>
        /// <param name="mipmapLevel">Specifies the mipmap level of <paramref name="cubemapTexture"/>​ to attach.</param>
        public void Attach(Framebuffer.Target target, GLenum colorAtttachmentLocation, CubemapFace face, Texture? cubemapTexture, int mipmapLevel = 0) {
            var gl = GL.current; if (gl == null) { return; }
            gl.glFramebufferTexture2D((GLenum)target,
                GL.GL_COLOR_ATTACHMENT0 + colorAtttachmentLocation,
                (GLenum)face,
                cubemapTexture?.id ?? 0,
                mipmapLevel);
        }

    }
}
