using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL {
    public unsafe partial class vgl {
        public static uint vglLoadTexture(string filename, uint texture, ref vglImageData image) {
            var gl = GL.Current; if (gl == null) return 0;
            //vglImageData local_image;
            int level;

            //if (image == 0)
            //image = &local_image;

            vglLoadImage(filename, ref image);

            if (texture == 0) {
                var tmp = stackalloc uint[1];
                gl.glGenTextures(1, tmp);
                texture = tmp[0];
            }

            gl.glBindTexture(image.target, texture);

            if (image.mip == null) { image.mip = new vglImageMipData[vermilion.MAX_TEXTURE_MIPS]; }
            IntPtr ptr = image.mip[0].data;

            switch (image.target) {
            case GL.GL_TEXTURE_1D:
            gl.glTexStorage1D(image.target,
                           image.mipLevels,
                           image.internalFormat,
                           image.mip[0].width);
            for (level = 0; level < image.mipLevels; ++level) {
                gl.glTexSubImage1D(GL.GL_TEXTURE_1D,
                                level,
                                0,
                                image.mip[level].width,
                                image.format, image.type,
                                image.mip[level].data);
            }
            break;
            case GL.GL_TEXTURE_1D_ARRAY:
            gl.glTexStorage2D(image.target,
                           image.mipLevels,
                           image.internalFormat,
                           image.mip[0].width,
                           image.slices);
            for (level = 0; level < image.mipLevels; ++level) {
                gl.glTexSubImage2D(GL.GL_TEXTURE_1D,
                                level,
                                0, 0,
                                image.mip[level].width, image.slices,
                                image.format, image.type,
                                image.mip[level].data);
            }
            break;
            case GL.GL_TEXTURE_2D:
            gl.glTexStorage2D(image.target,
                           image.mipLevels,
                           image.internalFormat,
                           image.mip[0].width,
                           image.mip[0].height);
            for (level = 0; level < image.mipLevels; ++level) {
                gl.glTexSubImage2D(GL.GL_TEXTURE_2D,
                                level,
                                0, 0,
                                image.mip[level].width, image.mip[level].height,
                                image.format, image.type,
                                image.mip[level].data);
            }
            break;
            case GL.GL_TEXTURE_CUBE_MAP:
            for (level = 0; level < image.mipLevels; ++level) {
                ptr = image.mip[level].data;
                for (int face = 0; face < 6; face++) {
                    gl.glTexImage2D((uint)(GL.GL_TEXTURE_CUBE_MAP_POSITIVE_X + face),
                                 level,
                                 (int)image.internalFormat,
                                 image.mip[level].width, image.mip[level].height,
                                 0,
                                 image.format, image.type,
                                 new IntPtr(ptr.ToInt32() + image.sliceStride * face));
                }
            }
            break;
            case GL.GL_TEXTURE_2D_ARRAY:
            gl.glTexStorage3D(image.target,
                           image.mipLevels,
                           image.internalFormat,
                           image.mip[0].width,
                           image.mip[0].height,
                           image.slices);
            for (level = 0; level < image.mipLevels; ++level) {
                gl.glTexSubImage3D(GL.GL_TEXTURE_2D_ARRAY,
                                level,
                                0, 0, 0,
                                image.mip[level].width, image.mip[level].height, image.slices,
                                image.format, image.type,
                                image.mip[level].data);
            }
            break;
            case GL.GL_TEXTURE_CUBE_MAP_ARRAY:
            gl.glTexStorage3D(image.target,
                           image.mipLevels,
                           image.internalFormat,
                           image.mip[0].width,
                           image.mip[0].height,
                           image.slices);
            break;
            case GL.GL_TEXTURE_3D:
            gl.glTexStorage3D(image.target,
                           image.mipLevels,
                           image.internalFormat,
                           image.mip[0].width,
                           image.mip[0].height,
                           image.mip[0].depth);
            for (level = 0; level < image.mipLevels; ++level) {
                gl.glTexSubImage3D(GL.GL_TEXTURE_3D,
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

            var swizzle = stackalloc int[4];
            for (int i = 0; i < 4; i++) { swizzle[i] = (int)image.swizzle[i]; }
            gl.glTexParameteriv(image.target, GL.GL_TEXTURE_SWIZZLE_RGBA, swizzle);

            //if (image == &local_image)
            //{
            //vglUnloadImage(image);
            //}

            return texture;
        }
    }
}
