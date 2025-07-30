using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGLImpl {
    unsafe partial class SoftGL {

        public static unsafe void glGenTextures(GLsizei n, GLuint* names) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            if (n < 0) { context.ErrorCode = (uint)ErrorCode.InvalidValue; return; }

            var array = context.idTextures;
            var generated = 0;
            // try to reuse freed ids
            for (var i = 0; i < array.Count && generated < n; i++) {
                if (array[i] == null) {
                    var id = (GLuint)(i + 1);
                    array[i] = new IdObject<GLTexture>(id);
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
                    array.Add(new IdObject<GLTexture>(id));
                    names[generated] = id;
                    generated++;
                }
            }
        }

        public static void glActiveTexture(GLenum textureUnit) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            if (textureUnit < GL.GL_TEXTURE0
                || GL.GL_TEXTURE0 + context.maxTextureImageUnits <= textureUnit) { context.ErrorCode = (uint)(ErrorCode.InvalidEnum); return; }

            context.currentTextureUnitIndex = textureUnit - GL.GL_TEXTURE0;
        }

        public static void glBindTexture(GLenum target, GLuint name) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            if (!Enum.IsDefined(typeof(BindTextureTarget), target)) { context.ErrorCode = (uint)(ErrorCode.InvalidEnum); return; }
            if (context.idTextures.Count < name) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }
            GLTexture? texture = null;
            if (name > 0) {
                var index = (int)(name - 1);
                var item = context.idTextures[index];
                if (item == null) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }
                if (item.obj == null) { // first time to bind
                    item.obj = new GLTexture(target, name);
                    //context.target2Buffers.Add(target,)
                }
                else if (item.obj.Target != target) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }

                texture = item.obj;
            }

            SetCurrentTexture(context, target, texture);
        }

        public static bool glIsTexture(GLuint name) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return false; }
            if (name == 0 || context.idTextures.Count < name) { return false; }
            var item = context.idTextures[(int)(name - 1)];
            if (item == null // no glGen or cancelled by glDelete
                || item.id == 0 // no glBind
                ) { return false; }

            return true;
        }

        public static unsafe void glDeleteTextures(GLsizei n, GLuint* names) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            if (n < 0) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }

            var array = context.idTextures;
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
