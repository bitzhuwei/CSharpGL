using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace SoftGLImpl {
    unsafe partial class SoftGL {


        public static unsafe void glGenRenderbuffers(GLsizei n, GLuint* names) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            GenRenderbuffers(n, names, context);
        }

        internal static unsafe void GenRenderbuffers(GLsizei n, GLuint* names, RenderContext context) {
            if (n < 0) { context.ErrorCode = (uint)ErrorCode.InvalidValue; return; }

            var array = context.idRenderbuffers;
            var generated = 0;
            // try to reuse freed ids
            for (var i = 0; i < array.Count && generated < n; i++) {
                if (array[i] == null) {
                    var id = (GLuint)(i + 1);
                    array[i] = new IdObject<GLRenderbuffer>(id);
                    names[generated] = id;
                    generated++;
                }
            }
            if (generated < n) {
                // expand new ids
                var last = n - generated;
                var markCount = array.Count;
                for (var i = 0; i < last; i++) {
                    var id = (GLuint)(markCount + i + 1);
                    array.Add(new IdObject<GLRenderbuffer>(id));
                    names[generated] = id;
                    generated++;
                }
            }
        }

        public static void glBindRenderbuffer(GLenum target, GLuint name) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            BindRenderbuffer(target, name, context);
        }

        internal static void BindRenderbuffer(GLenum target, GLuint name, RenderContext context) {
            if (target != GL.GL_RENDERBUFFER) { context.ErrorCode = (uint)(ErrorCode.InvalidEnum); return; }
            if (context.idRenderbuffers.Count < name) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            if (name > 0) {
                var index = (int)(name - 1);
                var item = context.idRenderbuffers[index];
                if (item == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
                if (item.obj == null) { // first time to bind
                    item.obj = new GLRenderbuffer(target, name);
                    //context.target2Buffers.Add(target,)
                }
                //else if (item.obj.Target != target) { context.lastErrorCode = (uint)(ErrorCode.InvalidOperation); return; }

                context.target2CurrentRenderbuffer[target] = item.obj;
            }
            else { // unbind
                context.target2CurrentRenderbuffer[target] = null;
            }
        }

        //private void BindRenderbuffer(uint target, uint name) {
        //    if (target != GL.GL_RENDERBUFFER) { context.lastErrorCode = (uint)(ErrorCode.InvalidEnum); return; }
        //    if ((name != 0) && (!this.renderbufferNameList.Contains(name))) { context.lastErrorCode = (uint)(ErrorCode.InvalidOperation); return; }

        //    if (name == 0) { this.currentRenderbuffers[target - GL.GL_RENDERBUFFER] = null; }
        //    else {
        //        Dictionary<uint, Renderbuffer> dict = this.nameRenderbufferDict;
        //        if (!dict.ContainsKey(name)) // for the first time the name is binded, we create a renderbuffer object.
        //        {
        //            var obj = new Renderbuffer(name);
        //            dict.Add(name, obj);
        //        }

        //        this.currentRenderbuffers[target - GL.GL_RENDERBUFFER] = dict[name];
        //    }
        //}

        public static bool glIsRenderbuffer(GLuint name) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return false; }
            if (name == 0 || context.idRenderbuffers.Count < name) { return false; }
            var item = context.idRenderbuffers[(int)(name - 1)];
            if (item == null // no glGen or cancelled by glDelete
                || item.id == 0 // no glBind
                ) { return false; }

            return true;
        }

        public static void glRenderbufferStorage(GLenum target, GLenum internalformat, GLsizei width, GLsizei height) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            RenderbufferStorage(target, internalformat, width, height, context);
        }

        internal static void RenderbufferStorage(uint target, uint internalformat, int width, int height, RenderContext context) {
            if (target != GL.GL_RENDERBUFFER) { context.ErrorCode = (uint)(ErrorCode.InvalidEnum); return; }
            if (width < 0 || context.maxRenderbufferSize < width) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }
            if (height < 0 || context.maxRenderbufferSize < height) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }
            // TODO: GL_INVALID_ENUM is generated if internalformat​ is not a color-renderable, depth-renderable, or stencil-renderable format.
            // TODO: GL_OUT_OF_MEMORY is generated if the GL is unable to create a data store of the requested size.

            var obj = context.target2CurrentRenderbuffer[target];
            if (obj != null) {
                int bitSize = InternalFormatHelper.BitSize(internalformat);
                int bytes = (bitSize % 8 == 0) ? bitSize / 8 : bitSize / 8 + 1; // TODO: any better solution?
                var size = width * height * bytes;
                var dataStore = Marshal.AllocHGlobal(size);
                obj.Storage(internalformat, width, height, dataStore, size);
            }
        }

        public static unsafe void glDeleteRenderbuffers(GLsizei n, GLuint* names) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            if (n < 0) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }

            var array = context.idRenderbuffers;
            for (int i = 0; i < n; i++) {
                var name = names[i]; if (name == 0) { continue; }
                var index = (int)(name - 1);
                var item = array[index];
                if (item != null) {
                    var obj = item.obj;
                    if (obj != null) {
                        obj.deleteFlag = true;
                        // If a buffer object that is currently bound is deleted, the binding reverts to 0 (the absence of any buffer object).
                        if (context.target2CurrentRenderbuffer[obj.Target] == obj) {
                            context.target2CurrentRenderbuffer[obj.Target] = null;
                        }
                    }
                    array[index] = null;
                }
            }
        }
    }

    enum RenderbufferStorageInternalformat : uint {
        RGBA = GL.GL_RGBA,
        DepthComponent = GL.GL_DEPTH_COMPONENT
    }
}
