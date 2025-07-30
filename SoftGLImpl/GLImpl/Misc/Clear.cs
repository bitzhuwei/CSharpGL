using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGLImpl {
    unsafe partial class SoftGL {
        public static void glClearColor(GLfloat r, GLfloat g, GLfloat b, GLfloat a) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            context.clearColor = new vec4(r, g, b, a);
        }

        public static void glClearDepthf(GLfloat depth) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            context.clearDepthf = depth;
        }

        public static void glClearDepth(GLdouble depth) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            context.clearDepthf = (float)depth;// dummy code
        }

        public static void glClearStencil(GLint s) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            context.clearStencil = s;
        }

        public static void glClear(GLbitfield mask) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            const GLbitfield all = (~GL.GL_COLOR_BUFFER_BIT) & (~GL.GL_DEPTH_BUFFER_BIT) & (~GL.GL_STENCIL_BUFFER_BIT);
            if ((mask & all) != 0) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }

            bool colorBIT = (mask & GL.GL_COLOR_BUFFER_BIT) != 0;
            bool depthBIT = (mask & GL.GL_DEPTH_BUFFER_BIT) != 0;
            bool stencilBIT = (mask & GL.GL_STENCIL_BUFFER_BIT) != 0;
            if (!(colorBIT || depthBIT || stencilBIT)) { return; }

            var framebuffer = context.target2CurrentFramebuffer[(GLenum)BindFramebufferTarget.Framebuffer];
            if (framebuffer == null) { throw new Exception("something is wrong with this implementation(no current framebuffer)!"); }

            if (colorBIT) {// clear all colorbuffers.
                var list = framebuffer.GetCurrentColorBuffers();
                vec4 clearColor = context.clearColor;
                foreach (var item in list) {
                    // convert vec4 to byte[4]{r, g, b, a}
                    //byte[] data = clearColor.ConvertTo(PassType.Vec4, GL.GL_RGBA);
                    if (item != null) {
                        byte[] data = clearColor.ConvertTo(PassType.Vec4, item.Format);
                        item.Clear(data);
                    }
                }
            }

            if (depthBIT) {// clear depthbuffer.
                var depthBuffer = framebuffer.DepthbufferAttachment;
                if (depthBuffer != null) {
                    switch (depthBuffer.Format) {
                    case GL.GL_DEPTH_COMPONENT: {// 32 bit -> float
                        byte[] value = context.clearDepthf.ConvertTo(PassType.Float, depthBuffer.Format);
                        depthBuffer.Clear(value);
                    }
                    break; // TODO: what should this be?
                    case GL.GL_DEPTH_COMPONENT24: {// 24 bit -> uint
                        var clearDepth = (uint)(context.clearDepthf * (1 << 24));
                        var value = new byte[3];
                        for (int i = 0; i < 3; i++) { value[i] = (byte)(clearDepth >> i); }
                        depthBuffer.Clear(value);
                    }
                    break;
                    case GL.GL_DEPTH_COMPONENT32: {// 32 bit -> float
                        byte[] value = context.clearDepthf.ConvertTo(PassType.Float, depthBuffer.Format);
                        depthBuffer.Clear(value);
                    }
                    break;
                    default: {
                        // invalid depth format
                        throw new Exception("bug, fix this!");
                        //return;
                    }
                    }
                }
            }

            if (stencilBIT) {// clear stencilbuffer.
                var item = framebuffer.StencilbufferAttachment;
                if (item != null) {
                    byte[] value = context.clearStencil.ConvertTo(PassType.Float, item.Format);
                    item.Clear(value);
                    throw new NotImplementedException("clearStencil is an integer. But PassType not support int type.");
                }
            }
        }

    }
}
