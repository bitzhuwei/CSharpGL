using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace CSharpGL
{
    /// <summary>
    /// 字形贴图及其UV。
    /// </summary>
    public sealed partial class FontResource
    {
        private static readonly object synObj = new object();

        public static FontResource Default
        {
            get
            {
                IntPtr renderContext = Win32.wglGetCurrentContext();
                if (!dict.ContainsKey(renderContext))
                {
                    lock (synObj)
                    {
                        if (!dict.ContainsKey(renderContext))
                        {
                            FontResource resource = InitializeDefaultFontResource();
                            dict.Add(renderContext, resource);
                        }
                    }
                }

                return dict[renderContext];
            }
        }

        private static FontResource InitializeDefaultFontResource()
        {
            Bitmap glyphBitmap;
            FullDictionary<char, GlyphInfo> defaultGlyphDict;
            const int pixelSize = 64;
            GetDefaultGlyphInfo(out glyphBitmap, out defaultGlyphDict, pixelSize);

            var fontResource = new FontResource();
            fontResource.FontHeight = pixelSize + yInterval;
            fontResource.CharInfoDict = defaultGlyphDict;
            fontResource.InitTexture(glyphBitmap);

            return fontResource;
        }

        private static Dictionary<IntPtr, FontResource> dict = new Dictionary<IntPtr, FontResource>();
        private FontResource() { }

        //public FontResource Load(string filename, string config)
        //{
        //    var result = new FontResource();

        //    var bitmap = new Bitmap(filename);
        //    result.InitTexture(bitmap);
        //    bitmap.Dispose();

        //    XElement xElement = XElement.Load(config, LoadOptions.None);
        //    result.InitConfig(xElement);

        //    return result;
        //}

        //private void InitConfig(XElement config)
        //{
        //    this.FontHeight = int.Parse(config.Attribute(strFontHeight).Value);
        //    //this.FirstChar = (char)int.Parse(config.Attribute(strFirstChar).Value);
        //    //this.LastChar = (char)int.Parse(config.Attribute(strLastChar).Value);
        //    this.CharInfoDict = CharacterInfoDictHelper.Parse(
        //        config.Element(CharacterInfoDictHelper.strCharacterInfoDict));
        //}

        private void InitTexture(Bitmap bitmap)
        {
#if DEBUG
            var filename = string.Format("FontResource{0:yyyy-MM-dd_HH-mm-ss.ff}FontResource.log.bmp", DateTime.Now);
            bitmap.Save(filename);
#endif
            // generate texture.
            //  Lock the image bits (so that we can pass them to OGL).
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
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
            OpenGL.TexImage2D(OpenGL.GL_TEXTURE_2D, 0, (int)OpenGL.GL_RED,
                bitmap.Width, bitmap.Height, 0, OpenGL.GL_RGB, OpenGL.GL_UNSIGNED_BYTE,
                bitmapData.Scan0);
            //  Unlock the image.
            bitmap.UnlockBits(bitmapData);
            OpenGL.BindTexture(OpenGL.GL_TEXTURE_2D, 0);
            this.TextureSize = bitmap.Size;
            this.FontTextureId = ids[0];
        }

    }
}
