using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace SoftGLImpl {
    partial class SoftGL {
        public static void glDrawArrays(GLenum mode, GLint first, GLsizei count) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            if (!Enum.IsDefined(typeof(DrawTarget), mode)) { context.ErrorCode = (uint)(ErrorCode.InvalidEnum); return; }
            if (count < 0) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }
            // TODO: GL_INVALID_OPERATION is generated if a non-zero buffer object name is bound to an enabled array and the buffer object's data store is currently mapped.
            // TODO: GL_INVALID_OPERATION is generated if a geometry shader is active and mode is incompatible with the input primitive type of the geometry shader in the currently installed program object.

            var vao = context.currentVertexArrayObject; // data structure.
            if (vao == null) { return; }
            var program = context.currentShaderProgram; // algorithm.
            if (program == null) { return; }

            // execute vertex shader for each vertex!
            // This is a low effetient implementation.
            Dictionary<uint, VertexCodeBase> vertexID2Shader = VertexShaderStage(count, vao, program);

            var framebuffer = context.target2CurrentFramebuffer[(GLenum)BindFramebufferTarget.Framebuffer];// context.currentFramebuffer;
            if (framebuffer == null) { throw new Exception("something is wrong with this implementation(no current framebuffer)!"); }

            ClipSpace2NormalDeviceSpace(vertexID2Shader);

            // linear interpolation.
            if (vertexID2Shader.Count == 0) { return; }
            var fs = program.FragmentShader; if (fs == null || fs.codeType == null) { return; }
            const BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;
            var inFieldInfos = (from item in fs.codeType.GetFields(flags)
                                where item.IsDefined(typeof(InAttribute), true)
                                select item).ToArray();
            var name2fielfInfo = new Dictionary<string, FieldInfo>();
            foreach (var item in vertexID2Shader.First().Value.GetType().GetFields(flags)) {
                name2fielfInfo.Add(item.Name, item);
            }
            ConcurrentBag<FragmentCodeBase[]> fragmentList = LinearInterpolationAndFragmentShaderStage(
                context, (DrawTarget)mode, count, vao, program, vertexID2Shader,
                inFieldInfos, name2fielfInfo);

            // Scissor test

            // Multisampel fragment operations

            // Stencil test

            // Depth test
            DepthTest(context, fragmentList);

            // Blending

            // Dithering

            // Logical operations

            // write fragments to framebuffer's colorbuffer attachment(s).
            WriteFragments2Framebuffer(context, framebuffer, fragmentList);
        }

        //private static void WriteFragments2Framebuffer(RenderContext context, GLFramebuffer framebuffer, ConcurrentBag<FragmentCodeBase[]> fragmentList) {
        //    if (framebuffer.ColorbufferAttachments == null) { return; }
        //    uint[] drawBufferIndexes = framebuffer.DrawBuffers.ToArray();
        //    Func<int, IntPtr, FragmentCodeBase, bool> hasValidDepth;
        //    var depthBuffer = framebuffer.DepthbufferAttachment;
        //    GCHandle pin = new GCHandle(); IntPtr pDepthBuffer = IntPtr.Zero;
        //    if (depthBuffer == null) { hasValidDepth = alwaysHasValidDepth; }
        //    else {
        //        switch (depthBuffer.Format) {
        //        case GL.GL_DEPTH_COMPONENT: hasValidDepth = hasValidDepth32float; break;
        //        case GL.GL_DEPTH_COMPONENT24: hasValidDepth = hasValidDepth24uint; break;
        //        case GL.GL_DEPTH_COMPONENT32: hasValidDepth = hasValidDepth32float; break;
        //        default: throw new Exception("bug, fix this!");
        //        }
        //        pin = GCHandle.Alloc(depthBuffer.DataStore, GCHandleType.Pinned);
        //        pDepthBuffer = pin.AddrOfPinnedObject();
        //    }
        //    int width = context.viewport.w;
        //    foreach (var fragment in fragmentList) {
        //        if (fragment.discard) { continue; }
        //        if (fragment.outVariables == null) { continue; }
        //        if (framebuffer.ColorbufferAttachments == null) { continue; }
        //        //if (fragment.depthTestFailed) { continue; }
        //        if (!hasValidDepth(width, pDepthBuffer, fragment)) { continue; }

        //        for (int i = 0; i < fragment.outVariables.Length && i < drawBufferIndexes.Length; i++) {
        //            PassBuffer outVar = fragment.outVariables[i];
        //            var attachment = framebuffer.ColorbufferAttachments[drawBufferIndexes[i].ToIndex()];
        //            if (attachment != null) {
        //                attachment.Set((int)fragment.gl_FragCoord.x, (int)fragment.gl_FragCoord.y, outVar);
        //            }
        //        }
        //    }
        //    if (depthBuffer != null) { pin.Free(); }
        //}
    }
}
