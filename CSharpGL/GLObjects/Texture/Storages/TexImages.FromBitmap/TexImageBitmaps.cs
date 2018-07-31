using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// setup 2D texture array's content with multiple Bitmap objects.
    /// </summary>
    public class TexImageBitmaps : TexStorageBase
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly Bitmap[] layers;
        /// <summary>
        /// 
        /// </summary>
        public readonly int width;
        /// <summary>
        /// 
        /// </summary>
        public readonly int height;
        /// <summary>
        /// /
        /// </summary>
        public readonly int layerCount;

        internal static readonly GLDelegates.void_uint_int_uint_int_int_int_int_uint_uint_IntPtr glTexImage3D;
        /// <summary>
        /// void glTexStorage3D( GLenum target​, GLint levels​, GLint internalformat​, GLsizei width​, GLsizei height​, GLsizei depth​ );
        /// </summary>
        internal static readonly GLDelegates.void_uint_int_uint_int_int_int glTexStorage3D;
        /// <summary>
        /// void glTexSubImage3D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, const GLvoid* pixels)
        /// </summary>
        internal static readonly GLDelegates.void_uint_int_int_int_int_int_int_int_uint_uint_IntPtr glTexSubImage3D;
        static TexImageBitmaps()
        {
            glTexImage3D = GL.Instance.GetDelegateFor("glTexImage3D", GLDelegates.typeof_void_uint_int_uint_int_int_int_int_uint_uint_IntPtr) as GLDelegates.void_uint_int_uint_int_int_int_int_uint_uint_IntPtr;
            glTexStorage3D = GL.Instance.GetDelegateFor("glTexStorage3D", GLDelegates.typeof_void_uint_int_uint_int_int_int) as GLDelegates.void_uint_int_uint_int_int_int;
            glTexSubImage3D = GL.Instance.GetDelegateFor("glTexSubImage3D", GLDelegates.typeof_void_uint_int_int_int_int_int_int_int_uint_uint_IntPtr) as GLDelegates.void_uint_int_int_int_int_int_int_int_uint_uint_IntPtr;
        }

        /// <summary>
        /// setup 2D texture array's content with multiple Bitmap objects.
        /// </summary>
        /// <param name="layers"></param>
        /// <param name="internalFormat"></param>
        /// <param name="mipmapLevelCount"></param>
        /// <param name="border"></param>
        public TexImageBitmaps(Bitmap[] layers, uint internalFormat = GL.GL_RGBA8, int mipmapLevelCount = 1, bool border = false)
            : base(TextureTarget.Texture2DArray, internalFormat, mipmapLevelCount, border)
        {
            if (layers == null || layers.Length < 1) { throw new ArgumentNullException("bitmap"); }
            if (mipmapLevelCount < 1) { throw new ArgumentException("mipmap level count must be greater than 0!"); }

            int width = layers[0].Width, height = layers[0].Height;
            for (int i = 1; i < layers.Length; i++)
            {
                if (layers[i].Width != width) { throw new ArgumentException("All layers must be in the same width!"); }
                if (layers[i].Height != height) { throw new ArgumentException("All layers must be in the same height!"); }
            }

            this.layers = layers;
            this.width = width;
            this.height = height;
            this.layerCount = layers.Length;
        }

        /// <summary>
        /// setup 2D texture array's content with multiple Bitmap objects.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="layerCount"></param>
        /// <param name="internalFormat"></param>
        /// <param name="mipmapLevelCount"></param>
        /// <param name="border"></param>
        public TexImageBitmaps(int width, int height, int layerCount, uint internalFormat = GL.GL_RGBA8, int mipmapLevelCount = 1, bool border = false)
            : base(TextureTarget.Texture2DArray, internalFormat, mipmapLevelCount, border)
        {
            if (width < 1) { throw new ArgumentException("width must be greater than 0!"); }
            if (height < 1) { throw new ArgumentException("height must be greater than 0!"); }
            if (layerCount < 1) { throw new ArgumentException("layerCount must be greater than 0!"); }
            if (mipmapLevelCount < 1) { throw new ArgumentException("mipmap level count must be greater than 0!"); }

            this.width = width;
            this.height = height;
            this.layerCount = layerCount;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Apply()
        {
            int mipmapLevelCount = this.mipmapLevelCount;

            // allocate space.
            if (glTexStorage3D != null)
            {
                glTexStorage3D((uint)this.target, mipmapLevelCount, this.internalFormat, this.width, this.height, this.layerCount);
            }
            else if (glTexImage3D != null)
            {
                int w = this.width, h = this.height;
                for (int i = 0; i < mipmapLevelCount; i++)
                {
                    glTexImage3D((uint)this.target, i, this.internalFormat, w, h, this.layerCount, this.border ? 1 : 0, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, IntPtr.Zero);
                    w = w / 2; h = h / 2;
                }
            }
            else
            {
                throw new Exception(string.Format("glTexImage3D and glTexStorage3D are not supported on this graphics card!"));
            }

            var layers = this.layers;
            if (layers != null)
            {
                // set up contents for each mipmap level of each layer.
                for (int layerIndex = 0; layerIndex < layers.Length; layerIndex++)
                {
                    Bitmap layer = layers[layerIndex]; // layers[i]
                    const int xoffset = 0, yoffset = 0;
                    const int depth = 1;
                    // first mipmap.
                    {
                        const int level = 0;
                        BitmapData data = layer.LockBits(new Rectangle(0, 0, this.width, this.height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                        IntPtr pixels = data.Scan0;
                        glTexSubImage3D((uint)this.target, level, xoffset, yoffset, layerIndex, this.width, this.height, depth, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, pixels);
                        layer.UnlockBits(data);
                    }
                    // other mipmaps.
                    Bitmap bmp = layer;
                    for (int level = 1; level < mipmapLevelCount; level++)
                    {
                        bmp = (Bitmap)bmp.GetThumbnailImage(bmp.Width / 2, bmp.Height / 2, new Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero);
                        BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                        IntPtr pixels = data.Scan0;
                        glTexSubImage3D((uint)this.target, level, xoffset, yoffset, layerIndex, bmp.Width, bmp.Height, depth, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, pixels);
                        bmp.UnlockBits(data);
                        bmp.Dispose();
                    }
                }
            }
        }

        private bool ThumbnailCallback()
        {
            return false;
        }
    }
}
