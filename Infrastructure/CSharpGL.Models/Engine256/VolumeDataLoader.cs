using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharpGL
{
    public class Engine256Loader
    {

        //dimensions of volume data
        public const int XDIM = 256;
        public const int YDIM = 256;
        public const int ZDIM = 256;
        private const string volume_file = @"Engine256\Engine256.raw";

        /// <summary>
        /// load a volume from the given raw data file and generates an OpenGL 3D texture from it
        /// </summary>
        /// <returns></returns>
        public static Texture Load()
        {
            var bytes = new byte[XDIM * YDIM * ZDIM];
            // read the volume data file
            using (var file = new System.IO.FileStream(volume_file, System.IO.FileMode.Open))
            {
                file.Read(bytes, 0, bytes.Length);
            }

            // generate OpenGL texture
            var dataProvider = new ArrayDataProvider<byte>(bytes);
            var storage = new TexImage3D(TexImage3D.Target.Texture3D, GL.GL_RED, XDIM, YDIM, ZDIM, GL.GL_RED, GL.GL_UNSIGNED_BYTE, dataProvider);
            var texture = new Texture(storage, new MipmapBuilder(),
              new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP),
              new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP),
              new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP),
              new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR_MIPMAP_LINEAR),
              new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR),
              new TexParameteri(TexParameter.PropertyName.TextrueBaseLevel, 0),
              new TexParameteri(TexParameter.PropertyName.TextureMaxLevel, 4));
            texture.Initialize();

            return texture;
        }

    }
}
