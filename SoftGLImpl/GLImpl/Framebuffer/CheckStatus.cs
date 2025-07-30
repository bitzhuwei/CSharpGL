using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace SoftGLImpl {
    unsafe partial class SoftGL {
        public static GLenum glCheckFramebufferStatus(GLenum target) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return 0; }

            return CheckFramebufferStatus(target, context);
        }

        internal static GLenum CheckFramebufferStatus(GLenum target, RenderContext context) {
            if (!Enum.IsDefined(typeof(BindFramebufferTarget), target)) { context.ErrorCode = (uint)(ErrorCode.InvalidEnum); return 0; }
            var framebuffer = context.target2CurrentFramebuffer[target];// context.currentFramebuffer;
            if (framebuffer == null) { throw new Exception("something is wrong with this implementation(no current framebuffer)!"); }

            // TODO: check this framebuffer.

            return GL.GL_FRAMEBUFFER_COMPLETE;
        }
        /*
‌glCheckFramebufferStatus函数用于检查OpenGL中的帧缓冲对象（FBO）的完整性状态‌。该函数返回一个枚举值，指示帧缓冲对象是否满足渲染操作的要求。

函数原型和参数
glCheckFramebufferStatus函数的原型如下：

c
Copy Code
GLenum glCheckFramebufferStatus(GLenum target);
参数target指定要检查的帧缓冲目标，可以是以下值之一：

GL_DRAW_FRAMEBUFFER：指定帧缓冲对象是用作绘制的帧缓冲目标。
GL_READ_FRAMEBUFFER：指定帧缓冲对象是用作读取的帧缓冲目标。
GL_FRAMEBUFFER：用于同时检查绘制和读取帧缓冲对象的完整性‌
1
2。
返回值
函数返回以下值之一：

GL_FRAMEBUFFER_COMPLETE：表示帧缓冲对象是完整的，可以用于绘制或读取操作。
其他可能的错误码，例如：
GL_FRAMEBUFFER_INCOMPLETE_ATTACHMENT：至少有一个附件不完整。
GL_FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT：缺少必要的附件。
GL_FRAMEBUFFER_INCOMPLETE_DRAW_BUFFER：绘制缓冲区无效。
GL_FRAMEBUFFER_INCOMPLETE_READ_BUFFER：读取缓冲区无效。
GL_FRAMEBUFFER_UNSUPPORTED：帧缓冲的配置不受支持‌
1
2。
使用场景和重要性
确保帧缓冲对象的完整性对于OpenGL编程至关重要。如果帧缓冲对象不满足完整性条件，可能会导致渲染操作失败或产生意外的结果。完整性条件包括：

所有附件都必须是完整的，包括颜色附件、深度附件和模板附件等。
所有附件的维度必须匹配，即宽度和高度必须相同。
所有附件的样本数量必须匹配，如果使用了多重采样，所有附件的样本数量必须一致。
所有附件的大小和格式必须匹配，所有附件的内部格式和数据类型必须相同。
如果使用了多重采样，必须同时包含颜色附件和深度/模板附件‌
1。
*/

    }
}
