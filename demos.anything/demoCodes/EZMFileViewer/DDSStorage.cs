using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {
    /// <summary>
    /// Storage of *.DDS file.
    /// </summary>
    public class DDSStorage : TexStorageBase {
        private vglImageData imageData;

        public DDSStorage(vglImageData imageData)
            : base((TextureTarget)imageData.target, imageData.internalFormat, imageData.mipLevels, false) {
            this.imageData = imageData;
        }

        public unsafe override void Apply() {
            var gl = GL.Current; System.Diagnostics.Debug.Assert(gl != null);

            vglImageData imageData = this.imageData;
            //IntPtr ptr = imageData.mip[0].data;
            int level;
            switch (imageData.target) {
            case GL.GL_TEXTURE_1D:
            gl.glTexStorage1D(imageData.target,
                           imageData.mipLevels,
                           imageData.internalFormat,
                           imageData.mip[0].width);
            for (level = 0; level < imageData.mipLevels; ++level) {
                gl.glTexSubImage1D(GL.GL_TEXTURE_1D,
                                level,
                                0,
                                imageData.mip[level].width,
                                imageData.format, imageData.type,
                                imageData.mip[level].data);
            }
            break;
            case GL.GL_TEXTURE_1D_ARRAY:
            gl.glTexStorage2D(imageData.target,
                           imageData.mipLevels,
                           imageData.internalFormat,
                           imageData.mip[0].width,
                           imageData.slices);
            for (level = 0; level < imageData.mipLevels; ++level) {
                gl.glTexSubImage2D(GL.GL_TEXTURE_1D,
                                level,
                                0, 0,
                                imageData.mip[level].width, imageData.slices,
                                imageData.format, imageData.type,
                                imageData.mip[level].data);
            }
            break;
            case GL.GL_TEXTURE_2D:
            gl.glTexStorage2D(imageData.target,
                           imageData.mipLevels,
                           imageData.internalFormat,
                           imageData.mip[0].width,
                           imageData.mip[0].height);
            for (level = 0; level < imageData.mipLevels; ++level) {
                gl.glTexSubImage2D(GL.GL_TEXTURE_2D,
                                level,
                                0, 0,
                                imageData.mip[level].width, imageData.mip[level].height,
                                imageData.format, imageData.type,
                                imageData.mip[level].data);
            }
            break;
            case GL.GL_TEXTURE_CUBE_MAP:
            for (level = 0; level < imageData.mipLevels; ++level) {
                var ptr = imageData.mip[level].data;
                for (int face = 0; face < 6; face++) {
                    gl.glTexImage2D((uint)(GL.GL_TEXTURE_CUBE_MAP_POSITIVE_X + face),
                                 level,
                                 (int)imageData.internalFormat,
                                 imageData.mip[level].width, imageData.mip[level].height,
                                 0,
                                 imageData.format, imageData.type,
                                 new IntPtr(ptr.ToInt32() + imageData.sliceStride * face));
                }
            }
            break;
            case GL.GL_TEXTURE_2D_ARRAY:
            gl.glTexStorage3D(imageData.target,
                           imageData.mipLevels,
                           imageData.internalFormat,
                           imageData.mip[0].width,
                           imageData.mip[0].height,
                           imageData.slices);
            for (level = 0; level < imageData.mipLevels; ++level) {
                gl.glTexSubImage3D(GL.GL_TEXTURE_2D_ARRAY,
                                level,
                                0, 0, 0,
                                imageData.mip[level].width, imageData.mip[level].height, imageData.slices,
                                imageData.format, imageData.type,
                                imageData.mip[level].data);
            }
            break;
            case GL.GL_TEXTURE_CUBE_MAP_ARRAY:
            gl.glTexStorage3D(imageData.target,
                           imageData.mipLevels,
                           imageData.internalFormat,
                           imageData.mip[0].width,
                           imageData.mip[0].height,
                           imageData.slices);
            break;
            case GL.GL_TEXTURE_3D:
            gl.glTexStorage3D(imageData.target,
                           imageData.mipLevels,
                           imageData.internalFormat,
                           imageData.mip[0].width,
                           imageData.mip[0].height,
                           imageData.mip[0].depth);
            for (level = 0; level < imageData.mipLevels; ++level) {
                gl.glTexSubImage3D(GL.GL_TEXTURE_3D,
                                level,
                                0, 0, 0,
                                imageData.mip[level].width, imageData.mip[level].height, imageData.mip[level].depth,
                                imageData.format, imageData.type,
                                imageData.mip[level].data);
            }
            break;
            default:
            throw new Exception(string.Format("Not deal with {0}!", imageData.target));
            }
        }

        //internal static readonly GLDelegates.void_uint_int_uint_int glTexStorage1D;
        //internal static readonly GLDelegates.void_uint_int_uint_int_int glTexStorage2D;
        //internal static readonly GLDelegates.void_uint_int_uint_int_int_int glTexStorage3D;
        //internal static readonly GLDelegates.void_uint_int_int_int_int_int_int_int_uint_uint_IntPtr glTexSubImage3D;
        //static DDSStorage() {
        //    glTexStorage1D = gl.glGetDelegateFor("glTexStorage1D", GLDelegates.typeof_void_uint_int_uint_int) as GLDelegates.void_uint_int_uint_int;
        //    glTexStorage2D = gl.glGetDelegateFor("glTexStorage2D", GLDelegates.typeof_void_uint_int_uint_int_int) as GLDelegates.void_uint_int_uint_int_int;
        //    glTexStorage3D = gl.glGetDelegateFor("glTexStorage3D", GLDelegates.typeof_void_uint_int_uint_int_int_int) as GLDelegates.void_uint_int_uint_int_int_int;
        //    glTexSubImage3D = gl.glGetDelegateFor("glTexSubImage3D", GLDelegates.typeof_void_uint_int_int_int_int_int_int_int_uint_uint_IntPtr) as GLDelegates.void_uint_int_int_int_int_int_int_int_uint_uint_IntPtr;
        //}

    }
}
