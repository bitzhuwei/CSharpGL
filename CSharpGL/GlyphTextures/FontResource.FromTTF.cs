using SharpFont;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using System.Linq;

namespace CSharpGL
{
    /// <summary>
    /// 含有字形贴图及其配置信息的单例类型。
    /// </summary>
    public sealed partial class FontResource
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ttfFilename"></param>
        /// <param name="characters"></param>
        /// <param name="pixelSize">The desired size of the font, in pixels.</param>
        /// <returns></returns>
        private static FontResource Load(string ttfFilename, char[] characters, float pixelSize = 32)
        {
            Bitmap bitmap;
            XElement config;
            Load(ttfFilename, characters, pixelSize, out bitmap, out config);
            var result = new FontResource(bitmap, config);
            bitmap.Dispose();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ttfFilename"></param>
        /// <param name="characters"></param>
        /// <param name="pixelSize">The desired size of the font, in pixels.</param>
        /// <returns></returns>
        private static FontResource Load(string ttfFilename, string characters, float pixelSize = 32)
        {
            Bitmap bitmap;
            XElement config;
            Load(ttfFilename, characters, pixelSize, out bitmap, out config);
            var result = new FontResource(bitmap, config);
            bitmap.Dispose();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ttfFilename"></param>
        /// <param name="pixelSize">The desired size of the font, in pixels.</param>
        /// <returns></returns>
        public static FontResource Load(string ttfFilename,
            char firstChar, char lastChar, float pixelSize = 32)
        {
            Bitmap bitmap;
            XElement config;
            Load(ttfFilename, firstChar, lastChar, pixelSize, out bitmap, out config);
            var result = new FontResource(bitmap, config);
            bitmap.Dispose();
            return result;
        }

        private static void Load(string ttfFilename, char[] content, float pixelSize, out Bitmap bitmap, out XElement config)
        {
            using (var file = File.OpenRead(ttfFilename))
            {
                var typeface = new FontFace(file);

                var distincted = (from item in content select item).Distinct();
                foreach (var c in distincted)
                {
                    //Console.WriteLine("Dump {0}: {1}", (int)c, c);
                    //var comparisonFile = Path.Combine(ComparisonPath, (int)c + ".png");
                    Surface surface;
                    if (RenderGlyph(typeface, c, pixelSize, out surface))
                    {
                        //SaveSurface(surface, comparisonFile);
                        surface.Dispose();
                    }
                }
            }
            throw new NotImplementedException();
        }

        private static void Load(string ttfFilename, string characters, float pixelSize, out Bitmap bitmap, out XElement config)
        {
            using (var file = File.OpenRead(ttfFilename))
            {
                var typeface = new FontFace(file);

                var distincted = (from item in characters select item).Distinct();
                foreach (var c in distincted)
                {
                    //Console.WriteLine("Dump {0}: {1}", (int)c, c);
                    //var comparisonFile = Path.Combine(ComparisonPath, (int)c + ".png");
                    Surface surface;
                    if (RenderGlyph(typeface, c, pixelSize, out surface))
                    {
                        //SaveSurface(surface, comparisonFile);
                        surface.Dispose();
                    }
                }
            }
            throw new NotImplementedException();
        }

        private static void Load(string ttfFilename, char firstChar, char lastChar, float pixelSize, out Bitmap bitmap, out XElement config)
        {
            using (var file = File.OpenRead(ttfFilename))
            {
                var typeface = new FontFace(file);

                for (char c = firstChar; c <= lastChar; c++)
                {
                    //Console.WriteLine("Dump {0}: {1}", (int)c, c);
                    //var comparisonFile = Path.Combine(ComparisonPath, (int)c + ".png");
                    Surface surface;
                    if (RenderGlyph(typeface, c, pixelSize, out surface))
                    {
                        //SaveSurface(surface, comparisonFile);
                        surface.Dispose();
                    }
                }
            }
            throw new NotImplementedException();
        }


        private static unsafe bool RenderGlyph(FontFace typeface, char c, float pixelSize, out Surface surface)
        {
            bool result = false;

            Glyph glyph = typeface.GetGlyph(c, pixelSize);
            if (glyph != null)
            {
                surface = new Surface
                {
                    Bits = Marshal.AllocHGlobal(glyph.RenderWidth * glyph.RenderHeight),
                    Width = glyph.RenderWidth,
                    Height = glyph.RenderHeight,
                    Pitch = glyph.RenderWidth
                };

                var stuff = (byte*)surface.Bits;
                for (int i = 0; i < surface.Width * surface.Height; i++)
                    *stuff++ = 0;

                glyph.RenderTo(surface);

                result = true;
            }
            else
            {
                surface = new Surface();
            }

            return result;
        }

    }
}
