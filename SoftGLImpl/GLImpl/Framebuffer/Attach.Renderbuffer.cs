using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace SoftGLImpl {
    unsafe partial class SoftGL {
        public static void glFramebufferRenderbuffer(GLenum target, GLenum attachmentPoint, GLenum renderbufferTarget, GLuint renderbufferName) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            FramebufferRenderbuffer(target, attachmentPoint, renderbufferTarget, renderbufferName, context);
        }

        internal static void FramebufferRenderbuffer(GLenum target, GLenum attachmentPoint, GLenum renderbufferTarget, GLuint renderbufferName, RenderContext context) {
            if (!Enum.IsDefined(typeof(BindFramebufferTarget), target)) { context.ErrorCode = (uint)(ErrorCode.InvalidEnum); return; }
            if (renderbufferTarget != GL.GL_RENDERBUFFER) { context.ErrorCode = (uint)(ErrorCode.InvalidEnum); return; }
            // TODO: GL_INVALID_OPERATION is generated if zero is bound to target.
            var framebuffer = context.target2CurrentFramebuffer[target];
            if (framebuffer == null) { throw new Exception("something is wrong with this implementation(no current framebuffer)!"); }

            GLRenderbuffer? attachment = null;
            if (renderbufferName != 0) {
                //var index = (int)(renderbufferName - 1);
                var item = context.idRenderbuffers[(int)(renderbufferName - 1)];
                if (item == null || item.id == 0 || item.obj == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
                attachment = item.obj;
            }
            if (attachmentPoint == GL.GL_DEPTH_ATTACHMENT) {
                framebuffer.DepthbufferAttachment = attachment;
            }
            else if (attachmentPoint == GL.GL_STENCIL_ATTACHMENT) {
                framebuffer.StencilbufferAttachment = attachment;
            }
            else if (attachmentPoint == GL.GL_DEPTH_STENCIL_ATTACHMENT) {
                framebuffer.DepthbufferAttachment = attachment;
                framebuffer.StencilbufferAttachment = attachment;
            }
            else {// color attachment points.
                if (attachmentPoint < GL.GL_COLOR_ATTACHMENT0) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
                uint index = attachmentPoint - GL.GL_COLOR_ATTACHMENT0;
                if (framebuffer.ColorbufferAttachments.Length <= index) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }

                framebuffer.ColorbufferAttachments[index] = attachment;
            }
            //// old version
            //Dictionary<uint, Renderbuffer> dict = this.nameRenderbufferDict;
            //if ((renderbufferName != 0) && (!dict.ContainsKey(renderbufferName))) { context.lastErrorCode = (uint)(ErrorCode.InvalidOperation); return; }

            //Renderbuffer renderbuffer = null;
            //if (renderbufferName != 0) {
            //    if (!dict.TryGetValue(renderbufferName, out renderbuffer)) { context.lastErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            //}

            //Framebuffer framebuffer = this.currentFramebuffer;
            //if (framebuffer == null) { return; }
            //if (framebuffer.Target != target) {
            //    // TODO: what should I do? Or should multiple current framebufer object exist?
            //}

            //if (attachmentPoint == GL.GL_DEPTH_ATTACHMENT) {
            //    framebuffer.DepthbufferAttachment = renderbuffer;
            //}
            //else if (attachmentPoint == GL.GL_STENCIL_ATTACHMENT) {
            //    framebuffer.StencilbufferAttachment = renderbuffer;
            //}
            //else if (attachmentPoint == GL.GL_DEPTH_STENCIL_ATTACHMENT) {
            //    framebuffer.DepthbufferAttachment = renderbuffer;
            //    framebuffer.StencilbufferAttachment = renderbuffer;
            //}
            //else {// color attachment points.
            //    if (attachmentPoint < GL.GL_COLOR_ATTACHMENT0) { context.lastErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            //    uint index = attachmentPoint - GL.GL_COLOR_ATTACHMENT0;
            //    if (framebuffer.ColorbufferAttachments.Length <= index) { context.lastErrorCode = (uint)(ErrorCode.InvalidOperation); return; }

            //    framebuffer.ColorbufferAttachments[index] = renderbuffer;
            //}
        }
    }
}
