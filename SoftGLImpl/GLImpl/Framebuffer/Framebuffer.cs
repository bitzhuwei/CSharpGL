using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace SoftGLImpl {
    unsafe partial class SoftGL {

        public static unsafe void glGenFramebuffers(GLsizei n, GLuint* names) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            GenFramebuffers(n, names, context);
        }

        internal static unsafe void GenFramebuffers(GLsizei n, GLuint* names, RenderContext context) {
            if (n < 0) { context.ErrorCode = (uint)ErrorCode.InvalidValue; return; }

            var array = context.idFramebuffers;
            var generated = 0;
            // try to reuse freed ids
            for (var i = 0; i < array.Count && generated < n; i++) {
                if (array[i] == null) {
                    var id = (GLuint)(i + 1);
                    array[i] = new IdObject<GLFramebuffer>(id);
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
                    array.Add(new IdObject<GLFramebuffer>(id));
                    names[generated] = id;
                    generated++;
                }
            }
        }

        public static void glBindFramebuffer(GLenum target, GLuint name) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            BindFramebuffer(target, name, context);
        }

        internal static void BindFramebuffer(GLenum target, GLuint name, RenderContext context) {
            if (!Enum.IsDefined(typeof(BindFramebufferTarget), target)) { context.ErrorCode = (uint)(ErrorCode.InvalidEnum); return; }
            if (context.idFramebuffers.Count < name) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }

            if (name > 0) {
                var index = (int)(name - 1);
                var item = context.idFramebuffers[index];
                if (item == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
                if (item.obj == null) { // first time to bind
                    item.obj = new GLFramebuffer(name);
                    //context.target2Buffers.Add(target,)
                }
                //else if (item.obj.Target != target) { context.lastErrorCode = (uint)(ErrorCode.InvalidOperation); return; }

                context.target2CurrentFramebuffer[target] = item.obj;
            }
            else { // unbind
                context.target2CurrentFramebuffer[target] = context.defaultFramebuffer;
            }
        }

        public static bool glIsFramebuffer(uint name) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return false; }
            if (name == 0 || context.idFramebuffers.Count < name) { return false; }
            var item = context.idFramebuffers[(int)(name - 1)];
            if (item == null // no glGen or cancelled by glDelete
                || item.id == 0 // no glBind
                ) { return false; }

            return true;
        }

        public static void glDeleteFramebuffers(int n, GLuint* names) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            if (n < 0) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }

            var array = context.idGLBuffers;
            for (int i = 0; i < n; i++) {
                var name = names[i]; if (name == 0) { continue; }
                var index = (int)(name - 1);
                var item = array[index];
                if (item != null) {
                    var obj = item.obj;
                    if (obj != null) {
                        obj.deleteFlag = true;
                        // If a buffer object that is currently bound is deleted, the binding reverts to 0 (the absence of any buffer object).
                        if (context.target2CurrentBuffer[obj.target] == obj) {
                            context.target2CurrentBuffer[obj.target] = null;
                        }
                    }
                    array[index] = null;
                }
            }
        }
    }

}
