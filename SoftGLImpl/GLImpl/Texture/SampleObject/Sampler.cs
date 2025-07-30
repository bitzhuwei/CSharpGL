using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGLImpl {
    // https://www.khronos.org/opengl/wiki/Sampler_Object
    /// <summary>
    /// Bind a <see cref="Sampler"/> object to a texture uint('s index), and it will affect all textures that bind to the same texture uint.
    /// </summary>
    partial class SoftGL {

        public static unsafe void glGenSamplers(GLsizei n, GLuint* names) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            if (n < 0) { context.ErrorCode = (uint)ErrorCode.InvalidValue; return; }

            var array = context.idSamplers;
            var generated = 0;
            // try to reuse freed ids
            for (var i = 0; i < array.Count && generated < n; i++) {
                if (array[i] == null) {
                    var id = (GLuint)(i + 1);
                    array[i] = new IdObject<GLSampler>(id);
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
                    array.Add(new IdObject<GLSampler>(id));
                    names[generated] = id;
                    generated++;
                }
            }
        }

        public static void glBindSampler(GLuint unit, GLuint name) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            if (unit >= context.maxCombinedTextureImageUnits) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }
            if (context.idSamplers.Count < name) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            if (name > 0) {
                var index = (int)(name - 1);
                var item = context.idSamplers[index];
                if (item == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
                if (item.obj == null) { // first time to bind
                    item.obj = new GLSampler(name);
                    //context.target2Buffers.Add(target,)
                }

                context.currentSamplers[unit] = item.obj;
            }
            else { // unbind
                context.currentSamplers[unit] = null;
            }
        }

        public static bool glIsSampler(GLuint name) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return false; }
            if (name == 0 || context.idSamplers.Count < name) { return false; }
            var item = context.idSamplers[(int)(name - 1)];
            if (item == null // no glGen or cancelled by glDelete
                || item.id == 0 // no glBind
                ) { return false; }

            return true;
        }

        public static unsafe void glDeleteSamplers(GLsizei n, GLuint* names) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            if (n < 0) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }

            var array = context.idSamplers;
            for (int i = 0; i < n; i++) {
                var name = names[i]; if (name == 0) { continue; }
                var index = (int)(name - 1);
                var item = array[index];
                if (item != null) {
                    var obj = item.obj;
                    if (obj != null) {
                        obj.deleteFlag = true;
                        //// If a buffer object that is currently bound is deleted, the binding reverts to 0 (the absence of any buffer object).
                        //if (context.target2CurrentBuffer[obj.Target] == obj) {
                        //    context.target2CurrentBuffer[obj.Target] = null;
                        //}
                    }
                    array[index] = null;
                }
            }
        }
    }
}
