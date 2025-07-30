using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;

namespace SoftGLImpl {
    public unsafe partial class SoftGL {

        //public static readonly delegate* managed<GLsizei, GLuint[], void> glGenBuffers = (n, bufferIds) => {
        //};
        //public static readonly delegate* managed<GLsizei, GLuint[], void> glGenBuffers = &glGenBuffers;
        static void glGenBuffers(GLsizei n, GLuint* names) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            if (n < 0) { context.ErrorCode = (uint)ErrorCode.InvalidValue; return; }

            var array = context.idGLBuffers;
            var generated = 0;
            // try to reuse freed ids
            for (var i = 0; i < array.Count && generated < n; i++) {
                if (array[i] == null) {
                    var id = (GLuint)(i + 1);
                    array[i] = new IdObject<GLBuffer>(id);
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
                    array.Add(new IdObject<GLBuffer>(id));
                    names[generated] = id;
                    generated++;
                }
            }
        }


        public static void glBindBuffer(GLenum target, GLuint name) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            if (!Enum.IsDefined(typeof(BindBufferTarget), target)) { context.ErrorCode = (uint)(ErrorCode.InvalidEnum); return; }
            if (context.idGLBuffers.Count < name) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }
            if (name > 0) {
                var index = (int)(name - 1);
                var item = context.idGLBuffers[index];
                if (item == null) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }
                if (item.obj == null) { // first time to bind
                    item.obj = new GLBuffer(target, name);
                    //context.target2Buffers.Add(target,)
                }
                else if (item.obj.target != target) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }

                context.target2CurrentBuffer[target] = item.obj;
            }
            else { // unbind
                context.target2CurrentBuffer[target] = null;
            }
        }

        public static bool glIsBuffer(GLuint name) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return false; }
            if (name == 0 || context.idGLBuffers.Count < name) { return false; }
            var item = context.idGLBuffers[(int)(name - 1)];
            if (item == null // no glGen or cancelled by glDelete
                || item.id == 0 // no glBind
                ) { return false; }

            return true;
        }

        public static void glDeleteBuffers(GLsizei n, GLuint* names) {
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

        public static void glBufferData(GLenum target, GLsizei size, IntPtr data, GLenum usage) {
            var context = SoftGL.GetCurrentContextObj();
            if (context == null) { return; }

            if ((!Enum.IsDefined(typeof(BindBufferTarget), target)) || (!Enum.IsDefined(typeof(Usage), usage))) { context.ErrorCode = (uint)(ErrorCode.InvalidEnum); return; }
            if (size < 0) { context.ErrorCode = (uint)(ErrorCode.InvalidValue); return; }
            var buffer = context.target2CurrentBuffer[target];
            if (buffer == null) { context.ErrorCode = (uint)(ErrorCode.InvalidOperation); return; }
            // TODO: GL_OUT_OF_MEMORY is generated if the GL is unable to create a data store with the specified size​.

            buffer.SetData(size, data, usage);
        }

        /*
                // 示例1：Action<int> 转换为 delegate* unmanaged<int, void>
        Action<int> action = (i) => Console.WriteLine($"Action called with {i}");
        GCHandle actionHandle = GCHandle.Alloc(action, GCHandleType.Normal);
        IntPtr actionPtr = Marshal.GetFunctionPointerForDelegate(action);
        delegate* unmanaged<int, void> unmanagedAction = (delegate* unmanaged<int, void>)actionPtr;

        // 调用非托管函数指针
        unsafe { unmanagedAction(42); }

        // 释放句柄
        actionHandle.Free();

        // 示例2：Func<int, int> 转换为 delegate* unmanaged<int, int>
        Func<int, int> func = (x) => x * 2;
        GCHandle funcHandle = GCHandle.Alloc(func, GCHandleType.Normal);
        IntPtr funcPtr = Marshal.GetFunctionPointerForDelegate(func);
        delegate* unmanaged<int, int> unmanagedFunc = (delegate* unmanaged<int, int>)funcPtr;

        // 调用非托管函数指针
        unsafe { Console.WriteLine($"Func result: {unmanagedFunc(21)}"); }

        // 释放句柄
        funcHandle.Free();
         */
    }
}
