using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.InteropServices;

namespace SoftGLImpl {
    partial class SoftGL {
        /// <summary>
        /// write fragments to framebuffer's colorbuffer attachment(s).
        /// </summary>
        /// <param name="context"></param>
        /// <param name="framebuffer"></param>
        /// <param name="primitiveList"></param>
        /// <exception cref="Exception"></exception>
        private static unsafe void WriteFragments2Framebuffer(RenderContext context, GLFramebuffer framebuffer, ConcurrentBag<FragmentCodeBase[]> primitiveList) {
            if (framebuffer.ColorbufferAttachments == null) { return; }
            uint[] drawBufferIndexes = framebuffer.DrawBuffers.ToArray();
            Func<int, IntPtr, FragmentCodeBase, bool> hasValidDepth;
            var depthBuffer = framebuffer.DepthbufferAttachment;
            IntPtr pDepthBuffer = IntPtr.Zero;
            if (depthBuffer == null || depthBuffer.DataStore == IntPtr.Zero) {
                hasValidDepth = alwaysHasValidDepth;
            }
            else {
                switch (depthBuffer.Format) {
                case GL.GL_DEPTH_COMPONENT: hasValidDepth = hasValidDepth32float; break;
                case GL.GL_DEPTH_COMPONENT24: hasValidDepth = hasValidDepth24uint; break;
                case GL.GL_DEPTH_COMPONENT32: hasValidDepth = hasValidDepth32float; break;
                default: throw new Exception("bug, fix this!");
                }
                pDepthBuffer = depthBuffer.DataStore;
            }
            int width = context.viewport.w;
            // way #1
            FieldInfo[]? outFieldInfos = null; PassType[]? passTypes = null;
            foreach (var primitive in primitiveList) {
                foreach (var fsInstance in primitive) {
                    if (fsInstance.discard) { continue; }
                    if (outFieldInfos == null || passTypes == null) {
                        const BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;
                        outFieldInfos = (from item in fsInstance.GetType().GetFields(flags)
                                         where item.IsDefined(typeof(OutAttribute), true)
                                         select item).ToArray();
                        passTypes = (from item in outFieldInfos select item.FieldType.GetPassType()).ToArray();
                        break;
                    }
                }

                if (outFieldInfos != null && passTypes != null) { break; }
            }
            if (outFieldInfos == null || passTypes == null) { return; }

            for (int i = 0; i < outFieldInfos.Length && i < drawBufferIndexes.Length; i++) {
                var index = i;//TODO: var index = outFieldInfos[i].GetCustomAttribute(typeof(Location))?.Index;
                var attachment = framebuffer.ColorbufferAttachments[drawBufferIndexes[i].ToIndex()];
                if (attachment == null) { continue; }
                var fieldInfo = outFieldInfos[index];
                foreach (var primitive in primitiveList) {
                    foreach (var fsInstance in primitive) {
                        if (fsInstance.discard) { continue; }
                        //if (fragment.depthTestFailed) { continue; }
                        if (!hasValidDepth(width, pDepthBuffer, fsInstance)) { continue; }
                        var value = fieldInfo.GetValue(fsInstance); Debug.Assert(value != null);
                        var objPin = GCHandle.Alloc(value, GCHandleType.Pinned);
                        IntPtr pointer = objPin.AddrOfPinnedObject();
                        var passType = passTypes[index];
                        switch (passType) {
                        case PassType.Float: {// make sure no negtive values
                            var p = (float*)pointer;
                            if (p[0] < 0) { p[0] = 0; } else if (p[0] > 1) { p[0] = 1; }
                        }
                        break;
                        case PassType.Vec2: {// make sure no negtive values
                            var p = (vec2*)pointer;
                            if (p[0].x < 0) { p[0].x = 0; } else if (p[0].x > 1) { p[0].x = 1; }
                            if (p[0].y < 0) { p[0].y = 0; } else if (p[0].y > 1) { p[0].y = 1; }
                        }
                        break;
                        case PassType.Vec3: {// make sure no negtive values
                            var p = (vec3*)pointer;
                            if (p[0].x < 0) { p[0].x = 0; } else if (p[0].x > 1) { p[0].x = 1; }
                            if (p[0].y < 0) { p[0].y = 0; } else if (p[0].y > 1) { p[0].y = 1; }
                            if (p[0].z < 0) { p[0].z = 0; } else if (p[0].z > 1) { p[0].z = 1; }
                        }
                        break;
                        case PassType.Vec4: {// make sure no negtive values
                            var p = (vec4*)pointer;
                            if (p[0].x < 0) { p[0].x = 0; } else if (p[0].x > 1) { p[0].x = 1; }
                            if (p[0].y < 0) { p[0].y = 0; } else if (p[0].y > 1) { p[0].y = 1; }
                            if (p[0].z < 0) { p[0].z = 0; } else if (p[0].z > 1) { p[0].z = 1; }
                            if (p[0].w < 0) { p[0].w = 0; } else if (p[0].w > 1) { p[0].w = 1; }
                        }
                        break;
                        case PassType.Mat2: break;
                        case PassType.Mat3: break;
                        case PassType.Mat4: break;
                        default: throw new NotDealWithNewEnumItemException(typeof(PassType));
                        }
                        attachment.Set((int)fsInstance.gl_FragCoord.x, (int)fsInstance.gl_FragCoord.y, pointer, passType);
                        objPin.Free();
                    }
                }
            }
            // way #3
            // this works bad because there would be to many fragments.
            //ThreadPool.SetMaxThreads(Environment.ProcessorCount, Environment.ProcessorCount);
            //var countdown = new CountdownEvent(primitiveList.Count);
            //foreach (var fragment in primitiveList) {
            //    var state = new InitParamWriteFragment2Framebuffer(fragment, hasValidDepth, width, pDepthBuffer, drawBufferIndexes, framebuffer, countdown);
            //    ThreadPool.QueueUserWorkItem(writeFragment2Framebuffer, state, true);
            //}
            //countdown.Wait(3000);//wait for 3 seconds at most
        }
        //TODO: rewrite this according to above implementation.
        //class InitParamWriteFragment2Framebuffer {
        //    public Fragment fragment;
        //    public Func<int, nint, Fragment, bool> hasValidDepth;
        //    public int width;
        //    public IntPtr pDepthBuffer;
        //    public uint[] drawBufferIndexes;
        //    public GLFramebuffer framebuffer;
        //    public CountdownEvent countdown;

        //    public InitParamWriteFragment2Framebuffer(Fragment fragment, Func<int, nint, Fragment, bool> hasValidDepth, int width, IntPtr pDepthBuffer, uint[] drawBufferIndexes, GLFramebuffer framebuffer, CountdownEvent countdown) {
        //        this.fragment = fragment;
        //        this.hasValidDepth = hasValidDepth;
        //        this.width = width;
        //        this.pDepthBuffer = pDepthBuffer;
        //        this.drawBufferIndexes = drawBufferIndexes;
        //        this.framebuffer = framebuffer;
        //        this.countdown = countdown;
        //    }
        //}
        //private static unsafe readonly Action<InitParamWriteFragment2Framebuffer> writeFragment2Framebuffer = (state) => {
        //    if (state.fragment.discard) { return; }
        //    if (state.fragment.outVariables == null) { return; }
        //    //if (fragment.depthTestFailed) { continue; }
        //    if (!state.hasValidDepth(state.width, state.pDepthBuffer, state.fragment)) { return; }

        //    for (int i = 0; i < state.fragment.outVariables.Length && i < state.drawBufferIndexes.Length; i++) {
        //        PassBuffer outVar = state.fragment.outVariables[i];
        //        var attachment = state.framebuffer.ColorbufferAttachments[state.drawBufferIndexes[i].ToIndex()];
        //        if (attachment != null) {
        //            attachment.Set((int)state.fragment.gl_FragCoord.x, (int)state.fragment.gl_FragCoord.y, outVar);
        //        }
        //    }
        //    state.countdown.Signal();
        //};
    }
}
