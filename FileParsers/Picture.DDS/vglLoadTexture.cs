using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picture.DDS
{
    public partial class vgl
    {
        uint vglLoadTexture(string filename, uint texture, ref vglImageData image)
        {
            //vglImageData local_image;
            int level;

            //if (image == 0)
            //image = &local_image;

            vglLoadImage(filename, ref image);

            if (texture == 0)
            {
                uint[] tmp = new uint[1];
                GL.GenTextures(1, tmp);
                texture = tmp[0];
            }

            GL.BindTexture(image.target, texture);

            IntPtr ptr = image.mip[0].data;

            switch (image.target)
            {
                case GL.GL_TEXTURE_1D:
                    GL.TexStorage1D(image.target,
                                   image.mipLevels,
                                   image.internalFormat,
                                   image.mip[0].width);
                    for (level = 0; level < image.mipLevels; ++level)
                    {
                        GL.TexSubImage1D(GL.GL_TEXTURE_1D,
                                        level,
                                        0,
                                        image.mip[level].width,
                                        image.format, image.type,
                                        image.mip[level].data);
                    }
                    break;
                case GL.GL_TEXTURE_1D_ARRAY:
                    GL.TexStorage2D(image.target,
                                   image.mipLevels,
                                   image.internalFormat,
                                   image.mip[0].width,
                                   image.slices);
                    for (level = 0; level < image.mipLevels; ++level)
                    {
                        GL.TexSubImage2D(GL.GL_TEXTURE_1D,
                                        level,
                                        0, 0,
                                        image.mip[level].width, image.slices,
                                        image.format, image.type,
                                        image.mip[level].data);
                    }
                    break;
                case GL.GL_TEXTURE_2D:
                    GL.TexStorage2D(image.target,
                                   image.mipLevels,
                                   image.internalFormat,
                                   image.mip[0].width,
                                   image.mip[0].height);
                    for (level = 0; level < image.mipLevels; ++level)
                    {
                        GL.TexSubImage2D(GL.GL_TEXTURE_2D,
                                        level,
                                        0, 0,
                                        image.mip[level].width, image.mip[level].height,
                                        image.format, image.type,
                                        image.mip[level].data);
                    }
                    break;
                case GL.GL_TEXTURE_CUBE_MAP:
                    for (level = 0; level < image.mipLevels; ++level)
                    {
                        ptr = image.mip[level].data;
                        for (int face = 0; face < 6; face++)
                        {
                            GL.TexImage2D((uint)(GL.GL_TEXTURE_CUBE_MAP_POSITIVE_X + face),
                                         level,
                                         image.internalFormat,
                                         image.mip[level].width, image.mip[level].height,
                                         0,
                                         image.format, image.type,
                                         ptr + image.sliceStride * face);
                        }
                    }
                    break;
                case GL.GL_TEXTURE_2D_ARRAY:
                    GL.TexStorage3D(image.target,
                                   image.mipLevels,
                                   image.internalFormat,
                                   image.mip[0].width,
                                   image.mip[0].height,
                                   image.slices);
                    for (level = 0; level < image.mipLevels; ++level)
                    {
                        GL.TexSubImage3D(GL.GL_TEXTURE_2D_ARRAY,
                                        level,
                                        0, 0, 0,
                                        image.mip[level].width, image.mip[level].height, image.slices,
                                        image.format, image.type,
                                        image.mip[level].data);
                    }
                    break;
                case GL.GL_TEXTURE_CUBE_MAP_ARRAY:
                    GL.TexStorage3D(image.target,
                                   image.mipLevels,
                                   image.internalFormat,
                                   image.mip[0].width,
                                   image.mip[0].height,
                                   image.slices);
                    break;
                case GL.GL_TEXTURE_3D:
                    GL.TexStorage3D(image.target,
                                   image.mipLevels,
                                   image.internalFormat,
                                   image.mip[0].width,
                                   image.mip[0].height,
                                   image.mip[0].depth);
                    for (level = 0; level < image.mipLevels; ++level)
                    {
                        GL.TexSubImage3D(GL.GL_TEXTURE_3D,
                                        level,
                                        0, 0, 0,
                                        image.mip[level].width, image.mip[level].height, image.mip[level].depth,
                                        image.format, image.type,
                                        image.mip[level].data);
                    }
                    break;
                default:
                    break;
            }

            int[] swizzle = new int[4];
            image.swizzle.CopyTo(swizzle, 0);
            GL.TexParameteriv(image.target, GL.GL_TEXTURE_SWIZZLE_RGBA, swizzle);

            //if (image == &local_image)
            //{
            //vglUnloadImage(image);
            //}

            return texture;
        }
    }
}
