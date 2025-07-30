using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace SoftGLImpl {
    unsafe partial class SoftGL {
        public static unsafe void glDrawBuffers(GLsizei n, GLenum* buffers) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            DrawBuffers(n, buffers, context);
        }

        internal static unsafe void DrawBuffers(GLsizei n, GLenum* buffers, RenderContext context) {
            var framebuffer = context.target2CurrentFramebuffer[(GLenum)BindFramebufferTarget.DrawFramebuffer];// context.currentFramebuffer;
            if (framebuffer == null) { throw new Exception("something is wrong with this implementation(no current framebuffer)!"); }

            if (n < 0) { context.ErrorCode = (uint)(ErrorCode.InvalidEnum); return; }
            if (buffers == null) { return; }
            for (int i = 0; i < n; i++) {
                var item = buffers[i];
                if (item == 0) { continue; }
                if (GL.GL_FRONT_LEFT <= item && item <= GL.GL_BACK_RIGHT) { continue; }
                if (GL.GL_COLOR_ATTACHMENT0 <= item && item < GL.GL_COLOR_ATTACHMENT0 + GLFramebuffer.maxColorAttachments) { continue; }

                { context.ErrorCode = (uint)(ErrorCode.InvalidEnum); return; }
            }
            // GL_INVALID_OPERATION is generated if a symbolic constant other than GL_NONE appears more than once in buffers.
            for (int i = 0; i < n; i++) {
                if (buffers[i] == GL.GL_NONE) { continue; }
                for (int j = i + 1; j < n; j++) {
                    if (buffers[j] == GL.GL_NONE) { continue; }
                    if (buffers[i] == buffers[j]) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
                }
            }

            if (framebuffer == context.defaultFramebuffer) {
                for (int i = 0; i < n; i++) {
                    var item = buffers[i];
                    if (!(GL.GL_FRONT_LEFT <= item && item <= GL.GL_BACK_RIGHT)) { context.ErrorCode = (uint)(ErrorCode.InvalidEnum); return; }
                }
            }
            else {
                for (int i = 0; i < n; i++) {
                    var item = buffers[i];
                    if (!(GL.GL_COLOR_ATTACHMENT0 <= item && item < GL.GL_COLOR_ATTACHMENT0 + GLFramebuffer.maxColorAttachments)) { context.ErrorCode = (uint)(ErrorCode.InvalidEnum); return; }
                }
            }

            framebuffer.DrawBuffers.Clear();
            for (int i = 0; i < n; i++) {
                var item = buffers[i];
                if (item != GL.GL_NONE) {
                    framebuffer.DrawBuffers.Add(item);
                }
            }
        }

        /*
        ‌glDrawBuffers函数用于指定绘制操作的目标缓冲区‌。在OpenGL中，帧缓冲对象（Framebuffer Object, FBO）是一个用于存储渲染结果的内存区域，包括颜色缓冲区、深度缓冲区和模板缓冲区等。通过使用glDrawBuffers，可以指定绘制操作的目标缓冲区，从而控制渲染结果的具体存储位置。

glDrawBuffers的基本用法
glDrawBuffers函数可以设置多个颜色缓冲区，其基本语法如下：

c
Copy Code
void glDrawBuffers(GLsizei n, const GLenum *bufs);
其中，n表示缓冲区的数量，bufs是一个指向枚举值的数组，指定了要绘制到的缓冲区。例如：

c
Copy Code
glDrawBuffers(1, &GL_COLOR_ATTACHMENT0);
这表示将绘制结果存储到第一个颜色缓冲区。

glDrawBuffers的应用场景
‌离屏渲染‌：通过glDrawBuffers，可以将渲染结果存储在内存中，而不是直接显示在屏幕上。这样可以进行离屏渲染、后期处理、多重渲染目标等操作。
‌后期处理‌：在后期处理阶段，可以通过glDrawBuffers指定多个缓冲区进行复杂的图像处理。
‌多重渲染目标‌：在需要同时渲染多个目标时，glDrawBuffers提供了灵活的控制。
通过使用glDrawBuffers，可以更灵活地控制OpenGL中的渲染过程，实现更复杂的图形效果和处理流程。 
         */
    }
}
