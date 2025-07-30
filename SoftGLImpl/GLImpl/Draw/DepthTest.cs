using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace SoftGLImpl {
    unsafe partial class SoftGL {
        private static void DepthTest(RenderContext context, ConcurrentBag<FragmentCodeBase[]> primitiveList) {
            // use Framebuffer or DrawFramebuffer ?
            var framebuffer = context.target2CurrentFramebuffer[(GLenum)BindFramebufferTarget.DrawFramebuffer];
            if (framebuffer == null) { throw new Exception("bug, fix this!"); }
            var depthBuffer = framebuffer.DepthbufferAttachment;
            if (depthBuffer == null) { return; } // TODO: return or what ?
            ivec4 viewport = context.viewport;
            switch (depthBuffer.Format) {
            case GL.GL_DEPTH_COMPONENT: {// 32 bit -> float
                DepthTest32float(viewport.w, depthBuffer, primitiveList);
            }
            break; // TODO: what should this be? ok, uint it is.
            case GL.GL_DEPTH_COMPONENT24: {// 24 bit -> uint
                DepthTest24uint(viewport.w, depthBuffer, primitiveList);
            }
            break;
            case GL.GL_DEPTH_COMPONENT32: {// 32 bit -> float
                DepthTest32float(viewport.w, depthBuffer, primitiveList);
            }
            break;
            default: {
                // invalid depth format
                throw new Exception("bug, fix this!");
                //return;
            }
            }

        }

        private static void DepthTest24uint(int width, IGLAttachable depthBuffer, ConcurrentBag<FragmentCodeBase[]> primitiveList) {
            var depthTestPlatform = (byte*)depthBuffer.DataStore;// [viewport.z, viewport.w];
            //var byte4 = stackalloc byte[4];
            foreach (var primitive in primitiveList) {
                foreach (var fsInstance in primitive) {
                    var x = (int)fsInstance.gl_FragCoord.x;
                    var y = (int)fsInstance.gl_FragCoord.y;
                    var coord = (y * width + x) * 3;
                    uint preDepth = 0;
                    for (int i = 0; i < 3; i++) { preDepth += (uint)(depthTestPlatform[coord + i] << i); }
                    var postDepth = (uint)fsInstance.gl_FragCoord.z * (1 << 24);
                    // TODO: switch (depthfunc(..)) { .. }
                    if (postDepth < preDepth) {// fragment is nearer.
                        for (int i = 0; i < 3; i++) {
                            depthTestPlatform[coord + i] = (byte)(postDepth >> i);
                        }
                        //pre.depthTestFailed = true;
                    }
                    //else {
                    //    post.depthTestFailed = true;
                    //}
                }
            }
        }

        private static void DepthTest32float(int width, IGLAttachable depthBuffer, ConcurrentBag<FragmentCodeBase[]> primitiveList) {
            var depthTestPlatform = (float*)depthBuffer.DataStore;// [viewport.z, viewport.w];
            foreach (var primitive in primitiveList) {
                foreach (var fsInstance in primitive) {
                    var x = (int)fsInstance.gl_FragCoord.x;
                    var y = (int)fsInstance.gl_FragCoord.y;
                    var coord = y * width + x;
                    var preDepth = depthTestPlatform[coord];
                    // TODO: switch (depthfunc(..)) { .. }
                    if (fsInstance.gl_FragCoord.z < preDepth) {// fragment is nearer.
                        depthTestPlatform[coord] = fsInstance.gl_FragCoord.z;
                        //pre.depthTestFailed = true;
                    }
                    //else {
                    //    post.depthTestFailed = true;
                    //}
                }
            }
        }

    }
}
