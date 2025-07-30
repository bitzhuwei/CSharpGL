using System.Reflection.Emit;

namespace SoftGLImpl {
    public unsafe partial class SoftGL {
        static void glGenVertexArrays(GLsizei n, GLuint* names) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            if (n < 0) { context.ErrorCode = (uint)ErrorCode.InvalidValue; return; }

            var array = context.idVertexArrayObjects;
            var generated = 0;
            // try to reuse freed ids
            for (var i = 0; i < array.Count && generated < n; i++) {
                if (array[i] == null) {
                    var id = (GLuint)(i + 1);
                    array[i] = new IdObject<GLVertexArrayObject>(id);
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
                    array.Add(new IdObject<GLVertexArrayObject>(id));
                    names[generated] = id;
                    generated++;
                }
            }
        }


        public static void glBindVertexArray(GLuint name) {
            //var context = SoftGL.GetCurrentContextObj();
            //if (context == null) { return; }

            //if ((name == 0) || (context.vaos.Count < name)) { context.lastErrorCode = (uint)ErrorCode.InvalidOperation; return; }
            //var obj = context.vaos[(int)(name - 1)];
            //obj.Bind(context);
            //context.currentVertexArrayObject = obj;
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            if (context.idVertexArrayObjects.Count < name) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            if (name > 0) {
                var index = (int)(name - 1);
                var item = context.idVertexArrayObjects[index];
                if (item == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
                if (item.obj == null) { // first time to bind
                    item.obj = new GLVertexArrayObject(name);
                    //context.target2Buffers.Add(target,)
                }

                context.currentVertexArrayObject = item.obj;
            }
            else { // unbind
                context.currentVertexArrayObject = null;
            }
        }

        public static bool glIsVertexArray(GLuint name) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return false; }
            if (name == 0 || context.idVertexArrayObjects.Count < name) { return false; }
            var item = context.idVertexArrayObjects[(int)(name - 1)];
            if (item == null // no glGen or cancelled by glDelete
                || item.id == 0 // no glBind
                ) { return false; }

            return true;
        }

        public static void glDeleteVertexArrays(GLsizei n, GLuint* names) {
            //var context = SoftGL.GetCurrentContextObj();
            //if (context == null) { return; }

            //if (count < 0) { context.lastErrorCode = (uint)ErrorCode.InvalidValue; return; }

            //var array = context.idVertexArrayObjects;
            //for (int i = 0; i < count; i++) {
            //    uint name = names[i];
            //    if (0 < name && name <= array.Count) {
            //        var index = (int)(name - 1);
            //        var vao = array[index];
            //        if (vao is IDisposable disposable) { disposable.Dispose(); }
            //        array[index] = null;
            //    }
            //}
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            if (n < 0) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }

            var array = context.idVertexArrayObjects;
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

        public static void glEnableVertexAttribArray(GLuint index) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            // TODO: GL_INVALID_VALUE is generated if index​ is greater than or equal to GL_MAX_VERTEX_ATTRIBS.
            var vao = context.currentVertexArrayObject;
            if (vao == null) { context.ErrorCode = (uint)ErrorCode.InvalidOperation; return; }

            if (vao.LocVertexAttribDict.TryGetValue(index, out var desc)) {
                desc.enabled = true;
            }
        }

        public static void glDisableVertexAttribArray(GLuint index) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            // TODO: GL_INVALID_VALUE is generated if index​ is greater than or equal to GL_MAX_VERTEX_ATTRIBS.
            var vao = context.currentVertexArrayObject;
            if (vao == null) { context.ErrorCode = (uint)ErrorCode.InvalidOperation; return; }

            if (vao.LocVertexAttribDict.TryGetValue(index, out var desc)) {
                desc.enabled = false;
            }
        }

        public static void glVertexAttribPointer(GLuint index, GLint size, GLenum type, GLboolean normalized, GLsizei stride, IntPtr pointer) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            // TODO: GL_INVALID_VALUE is generated if index​ is greater than or equal to GL_MAX_VERTEX_ATTRIBS.
            if (size != 1 && size != 2 && size != 3 && size != 4 && size != GL.GL_BGRA) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }
            if (!Enum.IsDefined(typeof(VertexAttribType), type)) { context.ErrorCode = (uint)(ErrorCode.InvalidEnum); return; }
            if (stride < 0) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }
            if (size == GL.GL_BGRA) {
                if (type != (GLenum)VertexAttribType.UnsignedByte
                    && type != (GLenum)VertexAttribType.Int2101010Rev
                    && type != (GLenum)VertexAttribType.UnsignedInt2101010Rev) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
                if (normalized == false) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            }
            if (type == (GLenum)VertexAttribType.Int2101010Rev || type == (GLenum)VertexAttribType.UnsignedInt2101010Rev) {
                if (size != 4 && size != GL.GL_BGRA) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            }
            if (type == (GLenum)VertexAttribType.UnsignedInt10f11f11fRev) {
                if (size != 3) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            }
            var vao = context.currentVertexArrayObject;
            if (vao == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            var buffer = context.target2CurrentBuffer[(GLenum)BindBufferTarget.ArrayBuffer];
            // GL_INVALID_OPERATION is generated if zero is bound to the GL_ARRAY_BUFFER buffer object binding point and the pointer​ argument is not NULL.
            // TODO: why only when "pointer​ argument is not NULL"?
            if (buffer == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            if (!vao.LocVertexAttribDict.TryGetValue(index, out var desc)) {
                desc = new VertexAttribDesc(buffer, VertexAttribDesc.Kind.Default);
                vao.LocVertexAttribDict.Add(index, desc);
            }
            desc.inLocation = index;
            desc.vbo = buffer;
            desc.kind = VertexAttribDesc.Kind.Default;
            desc.dataSize = size;
            desc.dataType = (uint)type;
            desc.normalize = normalized;
            desc.startPos = (uint)pointer.ToInt32();
            desc.stride = (uint)stride;
        }

        public static void glVertexAttribIPointer(GLuint index, GLint size, GLenum type, GLsizei stride, IntPtr pointer) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            // TODO: GL_INVALID_VALUE is generated if index​ is greater than or equal to GL_MAX_VERTEX_ATTRIBS.
            if (size != 1 && size != 2 && size != 3 && size != 4) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }
            if (!Enum.IsDefined(typeof(VertexAttribIType), type)) { context.ErrorCode = (uint)(ErrorCode.InvalidEnum); return; }
            if (stride < 0) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }
            var vao = context.currentVertexArrayObject;
            if (vao == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            var buffer = context.target2CurrentBuffer[(GLenum)BindBufferTarget.ArrayBuffer];
            // GL_INVALID_OPERATION is generated if zero is bound to the GL_ARRAY_BUFFER buffer object binding point and the pointer​ argument is not NULL.
            // TODO: why only when "pointer​ argument is not NULL"?
            if (buffer == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            if (!vao.LocVertexAttribDict.TryGetValue(index, out var desc)) {
                desc = new VertexAttribDesc(buffer, VertexAttribDesc.Kind.I);
                vao.LocVertexAttribDict.Add(index, desc);
            }
            desc.inLocation = index;
            desc.vbo = buffer;
            desc.kind = VertexAttribDesc.Kind.I;
            desc.dataSize = size;
            desc.dataType = (uint)type;
            //desc.normalize = false; // not needed.
            desc.startPos = (uint)pointer.ToInt32();
            desc.stride = (uint)stride;
        }

        public static void glVertexAttribLPointer(GLuint index, GLint size, GLenum type, GLsizei stride, IntPtr pointer) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            // TODO: GL_INVALID_VALUE is generated if index​ is greater than or equal to GL_MAX_VERTEX_ATTRIBS.
            if (size != 1 && size != 2 && size != 3 && size != 4) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }
            if (!Enum.IsDefined(typeof(VertexAttribLType), type)) { context.ErrorCode = (uint)(ErrorCode.InvalidEnum); return; }
            if (stride < 0) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }
            var vao = context.currentVertexArrayObject;
            if (vao == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            var buffer = context.target2CurrentBuffer[(GLenum)BindBufferTarget.ArrayBuffer];
            // GL_INVALID_OPERATION is generated if zero is bound to the GL_ARRAY_BUFFER buffer object binding point and the pointer​ argument is not NULL.
            // TODO: why only when "pointer​ argument is not NULL"?
            if (buffer == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            if (!vao.LocVertexAttribDict.TryGetValue(index, out var desc)) {
                desc = new VertexAttribDesc(buffer, VertexAttribDesc.Kind.L);
                vao.LocVertexAttribDict.Add(index, desc);
            }
            desc.inLocation = index;
            desc.vbo = buffer;
            desc.kind = VertexAttribDesc.Kind.L;
            desc.dataSize = size;
            desc.dataType = (uint)type;
            //desc.normalize = false; // not needed.
            desc.startPos = (uint)pointer.ToInt32();
            desc.stride = (uint)stride;
        }

    }
}
