using CSharpGL;
using demos.anything;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace DistanceFieldFont {
    public class GlyphServer {
        private Dictionary<char, GlyphInfo> charGlyphDict;

        public Dictionary<char, GlyphInfo> CharGlyphDict {
            get { return charGlyphDict; }
        }

        private float maxHeight;
        public float MaxHeight { get { return this.maxHeight; } }

        private float maxDiff;
        public float MaxDiff { get { return this.maxDiff; } }

        private Texture glyphsTexture;
        public Texture GlyphsTexture { get { return glyphsTexture; } }

        private int textureWidth;
        public int TextureWidth {
            get { return textureWidth; }
        }

        private int textureHeight;
        public int TextureHeight {
            get { return textureHeight; }
        }

        public static GlyphServer Load(string dictFilename, string glyphsFilename) {
            Dictionary<char, GlyphInfo> dict = SDFDictParser.Parse(dictFilename);
            float maxHeight, maxDiff;
            GetHeight(dict, out maxHeight, out maxDiff);
            Texture texture = LoadTexture(glyphsFilename);
            int textureWidth, textureHeight;
            GetTextureSize(glyphsFilename, out textureWidth, out textureHeight);

            var result = new GlyphServer();
            result.charGlyphDict = dict;
            result.maxHeight = maxHeight;
            result.maxDiff = maxDiff;
            result.glyphsTexture = texture;
            result.textureWidth = textureWidth;
            result.textureHeight = textureHeight;

            return result;
        }

        private static void GetTextureSize(string glyphsFilename, out int textureWidth, out int textureHeight) {
            var bmp = new Bitmap(glyphsFilename);
            textureWidth = bmp.Width;
            textureHeight = bmp.Height;
            bmp.Dispose();
        }

        private static void GetHeight(Dictionary<char, GlyphInfo> dict,
            out float maxHeight, out float maxDiff) {
            maxHeight = 0;
            foreach (GlyphInfo item in dict.Values) {
                if (maxHeight < item.yOffset) { maxHeight = item.yOffset; }
            }

            maxDiff = 0;
            foreach (GlyphInfo item in dict.Values) {
                float diff = item.height - item.yOffset;
                if (maxDiff < diff) { maxDiff = diff; }
            }

            maxHeight += maxDiff;
        }

        private static Texture LoadTexture(string glyphsFilename) {
            var bmp = new Bitmap(glyphsFilename);
            var winGLBitmap = new WinGLBitmap(bmp);
            var storage = new TexImageBitmap(winGLBitmap);
            var texture = new Texture(storage,
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
            texture.Initialize();
            bmp.Dispose();

            return texture;
        }


    }
}
