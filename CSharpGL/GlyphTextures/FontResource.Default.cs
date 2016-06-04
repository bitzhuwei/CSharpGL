using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Xml.Linq;

namespace CSharpGL
{
    /// <summary>
    /// 含有字形贴图及其配置信息的单例类型。
    /// </summary>
    public sealed partial class FontResource
    {
        private static FontResource defaultInstance = new FontResource();

        public static FontResource Default
        {
            get
            {
                return defaultInstance;
            }
        }

        private FontResource(Bitmap bitmap = null, XElement config = null)
        {
            if (bitmap == null && config == null)
            {
                InitDefault(
                    @"GlyphTextures\ANTQUAI.TTF.png",
                    @"GlyphTextures\ANTQUAI.TTF.xml");
            }
            else
            {
                InitTexture(bitmap);
            }
        }

        private void InitDefault(string filename, string config)
        {
            {
                var bitmap = ManifestResourceLoader.LoadBitmap(filename);
                InitTexture(bitmap);
                bitmap.Dispose();
            }
            {
                string xmlContent = ManifestResourceLoader.LoadTextFile(config);
                XElement xElement = XElement.Parse(xmlContent, LoadOptions.None);
                this.FontHeight = int.Parse(xElement.Attribute(strFontHeight).Value);
                this.FirstChar = (char)int.Parse(xElement.Attribute(strFirstChar).Value);
                this.LastChar = (char)int.Parse(xElement.Attribute(strLastChar).Value);
                this.CharInfoDict = CharacterInfoDictHelper.Parse(
                    xElement.Element(CharacterInfoDictHelper.strCharacterInfoDict));
            }
        }

        private void InitTexture(Bitmap bitmap)
        {
            // generate texture.
            //  Lock the image bits (so that we can pass them to OGL).
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            //GL.ActiveTexture(GL.GL_TEXTURE0);
            OpenGL.GetDelegateFor<OpenGL.glActiveTexture>()(OpenGL.GL_TEXTURE0);
            var ids = new uint[1];
            OpenGL.GenTextures(1, ids);
            OpenGL.BindTexture(OpenGL.GL_TEXTURE_2D, ids[0]);
            /* Clamping to edges is important to prevent artifacts when scaling */
            /* We require 1 byte alignment when uploading texture data */
            //GL.PixelStorei(GL.GL_UNPACK_ALIGNMENT, 1);
            OpenGL.TexParameteri(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MAG_FILTER, (int)OpenGL.GL_LINEAR);
            OpenGL.TexParameteri(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_WRAP_S, (int)OpenGL.GL_CLAMP_TO_EDGE);
            OpenGL.TexParameteri(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_WRAP_T, (int)OpenGL.GL_CLAMP_TO_EDGE);
            /* Linear filtering usually looks best for text */
            OpenGL.TexParameteri(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MIN_FILTER, (int)OpenGL.GL_LINEAR);
            OpenGL.TexImage2D(OpenGL.GL_TEXTURE_2D, 0, (int)OpenGL.GL_RGBA,
                bitmap.Width, bitmap.Height, 0, OpenGL.GL_BGRA, OpenGL.GL_UNSIGNED_BYTE,
                bitmapData.Scan0);
            //  Unlock the image.
            bitmap.UnlockBits(bitmapData);
            OpenGL.BindTexture(OpenGL.GL_TEXTURE_2D, 0);
            this.TextureSize = bitmap.Size;
            this.FontTextureId = ids[0];
        }

    }
}
