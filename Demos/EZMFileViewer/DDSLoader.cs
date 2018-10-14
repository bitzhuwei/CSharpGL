using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EZMFileViewer
{
    public static class DDSLoader
    {
        public static Texture LoadDDS(string fullname)
        {
            vglImageData imageData = new vglImageData();
            vgl.vglLoadImage(fullname, ref imageData);
            if (imageData.mip == null)
            { imageData.mip = new vglImageMipData[vermilion.MAX_TEXTURE_MIPS]; }

            int[] swizzle = new int[4];
            for (int i = 0; i < 4; i++)
            { swizzle[i] = (int)imageData.swizzle[i]; }
            var texture = new Texture(new DDSStorage(imageData),
                new TexParameteriv(GL.GL_TEXTURE_SWIZZLE_RGBA, "SwizzleRGBA", swizzle));
            texture.Initialize();

            return texture;
        }
    }
}
