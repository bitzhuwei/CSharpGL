using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharpGL
{
    public class AmberLoader
    {

        //dimensions of volume data
        public const int length = 256;

        /// <summary>
        /// load a volume from the given raw data file and generates an OpenGL 3D texture from it
        /// </summary>
        /// <returns></returns>
        public static Texture Load(Bitmap image)
        {
            var bytes = new byte[length * length * length];
            if (image.Width != length || image.Height != length)
            {
                image = (Bitmap)image.GetThumbnailImage(length, length, null, IntPtr.Zero);
            }

            image.RotateFlip(RotateFlipType.Rotate180FlipX);
            FillByteArray(bytes, image);

            // generate OpenGL texture
            var dataProvider = new ArrayDataProvider<byte>(bytes);
            var storage = new TexImage3D(TexImage3D.Target.Texture3D, GL.GL_RED, length, length, length, GL.GL_RED, GL.GL_UNSIGNED_BYTE, dataProvider);
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

        private static void FillByteArray(byte[] bytes, Bitmap image)
        {
            for (int y = 20; y < image.Height - 20; y++)
            {
                for (int x = 20; x < image.Width - 20; x++)
                {
                    Color color = image.GetPixel(x, y);
                    if (color.A > 0)
                    {
                        for (int z = (int)(length * 4.5 / 10); z < (int)(length * 5.5 / 10); z++)
                        {
                            for (int deltaY = -1; deltaY < 2; deltaY++)
                            {
                                for (int deltaX = -1; deltaX < 2; deltaX++)
                                {
                                    for (int deltaZ = -1; deltaZ < 2; deltaZ++)
                                    {
                                        bytes[(z + deltaZ) * (image.Width * image.Height) + image.Width * (y + deltaY) + (x + deltaX)] += (byte)((double)color.A * (0.033) * (3 - Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ)));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            // boundary
            for (int y = 10; y < image.Height - 10; y++)
            {
                for (int x = 10; x < image.Width; x++)
                {
                    int xx = (x - image.Width / 2) * (x - image.Width / 2);
                    int yy = (y - image.Height / 2) * (y - image.Height / 2);
                    for (int delta = 0; delta < 10; delta++)
                    {
                        int z = (int)Math.Sqrt((length / 2 - delta) * (length / 2 - delta) - xx - yy);
                        int index0 = (length / 2 - delta + z) * (image.Width * image.Height) + image.Width * y + x;
                        if (index0 < bytes.Length)
                        {
                            bytes[index0] += (byte)(delta);
                        }
                        int index1 = (length / 2 - delta - z) * (image.Width * image.Height) + image.Width * y + x;
                        if (index1 < bytes.Length)
                        {
                            bytes[index1] += (byte)(delta);
                        }
                    }
                }
            }
        }

    }
}
