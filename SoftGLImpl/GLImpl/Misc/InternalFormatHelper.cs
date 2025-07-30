using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGLImpl {
    // https://www.khronos.org/opengl/wiki/Image_Format
    static class InternalFormatHelper {
        /// <summary>
        /// How many bits the specified internal format has?
        /// </summary>
        /// <param name="internalFormat"></param>
        /// <returns></returns>
        public static int BitSize(this uint internalFormat) {
            int result = 8;
            switch (internalFormat) {
            case GL.GL_RGBA: result = 4 * 8; break; // byte[4](r, g, b, a)
            case GL.GL_BGRA: result = 4 * 8; break; // byte[4](b, g, r, a)
            case GL.GL_DEPTH_COMPONENT: result = 32; break; // TODO: what should this be?
            case GL.GL_DEPTH_COMPONENT24: result = 24; break;
            case GL.GL_DEPTH_COMPONENT32: result = 32; break;
            // TODO: what should this be?
            case GL.GL_STENCIL_INDEX: result = 8; break;
            //case GL.GL_STENCIL_INDEX1: result = 1; break;
            //case GL.GL_STENCIL_INDEX4: result = 4; break;
            case GL.GL_STENCIL_INDEX8: result = 8; break;
            case GL.GL_STENCIL_INDEX16: result = 16; break;
            default:
            throw new NotImplementedException();
            }

            return result;
        }
    }
}
