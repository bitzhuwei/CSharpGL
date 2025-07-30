using System.Runtime.InteropServices;

namespace SoftGLImpl {
    partial class SoftGL {

        internal static readonly Dictionary<IntPtr, RenderContext> hRC2RenderContext = new();
        internal static readonly Dictionary<Thread, RenderContext?> thread2RenderContext = new();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="windowHandle">Control.Handle</param>
        /// <param name="width">Control.Width</param>
        /// <param name="height">Control.Height</param>
        /// <param name="genParams"></param>
        /// <param name="config">required opengl functions</param>
        /// <returns></returns>
        public static IntPtr CreateContext(IntPtr windowHandle, int width, int height, object genParams, HashSet<string>? config) {
            // create basic render context
            //	Get the window device context.
            var hDC = SoftGL.GetDC(windowHandle);
            //	Create the render context.
            var renderContext = new RenderContext(windowHandle, width, height);

            SoftGL.hRC2RenderContext.Add(renderContext.hRC, renderContext);
            //  Make the context current.
            SoftGL.MakeCurrent(hDC, renderContext.hRC);

            return renderContext.hRC;
            //return new SoftGLRenderContext(windowHandle, width, height, parameters, hDC, hRC, glFunctions, dibSection);
        }

        //TODO: useless hDC ?
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hDC"></param>
        /// <param name="hRC"></param>
        public static void MakeCurrent(IntPtr hDC, IntPtr hRC) {
            var thread2RenderContext = SoftGL.thread2RenderContext;
            if (hRC == IntPtr.Zero) // cancel current render context to current thread.
            {
                Thread thread = Thread.CurrentThread;
                if (thread2RenderContext.TryGetValue(thread, out var context)) {
                    //thread2RenderContext[thread] = null;
                    thread2RenderContext.Remove(thread);
                }
                else {
                    // TODO: what should I do?
                }
            }
            else // change current render context to current thread.
            {
                if (hRC2RenderContext.TryGetValue(hRC, out var context)) {
                    Thread thread = Thread.CurrentThread;
                    if (thread2RenderContext.TryGetValue(thread, out var currentContext)) {
                        if (context != currentContext) {
                            thread2RenderContext[thread] = context;
                        }
                    }
                    else { thread2RenderContext.Add(thread, context); }
                }
                else {
                    // TODO: update last error.
                }
            }
        }


        /// <summary>
        /// Gets current render context's handle.
        /// </summary>
        /// <returns></returns>
        public static IntPtr GetCurrentContext() {
            var result = IntPtr.Zero;

            var thread2RenderContext = SoftGL.thread2RenderContext;
            Thread thread = Thread.CurrentThread;
            if (thread2RenderContext.TryGetValue(thread, out var context)) {
                if (context != null) {
                    result = context.hRC;
                }
            }

            return result;
        }

        /// <summary>
        /// Gets current render context's handle.
        /// </summary>
        /// <returns></returns>
        internal static RenderContext? GetCurrentContextObj() {
            var thread2RenderContext = SoftGL.thread2RenderContext;
            Thread thread = Thread.CurrentThread;
            if (thread2RenderContext.TryGetValue(thread, out var context)) {
            }

            return context;
        }

        public static void DeleteContext(IntPtr hRC) {
            if (SoftGL.hRC2RenderContext.TryGetValue(hRC, out var context)) {
                var current = SoftGL.GetCurrentContextObj();
                if (current != null && current == context) {
                    SoftGL.MakeCurrent(IntPtr.Zero, IntPtr.Zero);
                }

                SoftGL.hRC2RenderContext.Remove(hRC);

                Thread? thread = null;
                foreach (var item in SoftGL.thread2RenderContext) {
                    if (item.Value == context) { thread = item.Key; break; }
                }
                if (thread != null) { SoftGL.thread2RenderContext.Remove(thread); }

                if (context is IDisposable disposable) { disposable.Dispose(); }
            }
        }
    }
}
