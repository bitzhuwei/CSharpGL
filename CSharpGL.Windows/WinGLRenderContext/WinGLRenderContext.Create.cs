using CSharpGL.Windows;
using System;
using System.Diagnostics;
using System.Drawing;

namespace CSharpGL.Windows {
    unsafe partial class WinGLRenderContext {

        // TODO: never tested.
        /// <summary>
        /// create a render context who uses a shared <see cref="GL"/> object(<paramref name="glFunctions"/>)
        /// </summary>
        /// <param name="windowHandle">Control.Handle</param>
        /// <param name="width">Control.Width</param>
        /// <param name="height">Control.Height</param>
        /// <param name="genParams"></param>
        /// <param name="config">required opengl functions</param>
        /// <returns></returns>
        public static WinGLRenderContext? Create(IntPtr windowHandle, int width, int height, object genParams, GL glFunctions) {
            var parameters = genParams as ContextGenerationParams;
            if (parameters is null) { parameters = new ContextGenerationParams(); }
            var (hDC, hRC) = Create(windowHandle, width, height, parameters);

            ////  Make the context current.
            //Win32.wglMakeCurrent(hDC, hRC);
            //var glFunctions = new GL(WinGLRenderContext.GetProcAddress, config);// only valid when hDC and hRC are not 0.

            var dibSection = new DIBSection(width, height, hDC, parameters);

            return new WinGLRenderContext(windowHandle, width, height, /*parameters,*/ hDC, hRC, glFunctions, dibSection);
        }

        /// <summary>
        /// create a render context who creates a new <see cref="GL"/> object.
        /// </summary>
        /// <param name="windowHandle">Control.Handle</param>
        /// <param name="width">Control.Width</param>
        /// <param name="height">Control.Height</param>
        /// <param name="genParams"></param>
        /// <param name="config">required opengl functions</param>
        /// <returns></returns>
        public static WinGLRenderContext? Create(IntPtr windowHandle, int width, int height, object? genParams, HashSet<string>? config) {
            var parameters = genParams as ContextGenerationParams;
            if (parameters is null) { parameters = new ContextGenerationParams(); }
            var (hDC, hRC) = Create(windowHandle, width, height, parameters);

            if (hDC == IntPtr.Zero && hRC == IntPtr.Zero) { return null; }

            //  Make the context current.
            Win32.wglMakeCurrent(hDC, hRC);
            var glFunctions = new GL(WinGLRenderContext.GetProcAddress, config);// only valid when hDC and hRC are not 0.

            var dibSection = new DIBSection(width, height, hDC, parameters);

            return new WinGLRenderContext(windowHandle, width, height, /*parameters,*/ hDC, hRC, glFunctions, dibSection);
        }

        internal static (IntPtr hDC, IntPtr hRC) Create(IntPtr windowHandle, int width, int height, ContextGenerationParams parameters) {
            // create basic render context
            //	Get the window device context.
            var hDC = Win32.GetDC(windowHandle);
            //	Setup a pixel format.
            var pfd = new PixelFormatDescriptor() {
                nVersion = 1,
                dwFlags = 4/*PFD_DRAW_TO_WINDOW*/ | 32/*PFD_SUPPORT_OPENGL*/ | 1/*PFD_DOUBLEBUFFER*/,
                iPixelType = 0/*PFD_TYPE_RGBA*/,
                colorBits = parameters.colorBits,
                accumBits = parameters.accumBits,
                accumRedBits = parameters.accumRedBits,
                accumGreenBits = parameters.accumGreenBits,
                accumBlueBits = parameters.accumBlueBits,
                accumAlphaBits = parameters.accumAlphaBits,
                depthBits = parameters.depthBits,
                stencilBits = parameters.stencilBits,
                iLayerType = 0/*PFD_MAIN_PLANE*/,
            };
            //	Match an appropriate pixel format
            int iPixelformat = Win32.ChoosePixelFormat(hDC, pfd);
            if (iPixelformat == 0) { return (IntPtr.Zero, IntPtr.Zero); }
            //	Sets the pixel format
            if (false == Win32.SetPixelFormat(hDC, iPixelformat, pfd)) { return (IntPtr.Zero, IntPtr.Zero); }
            //	Create the render context.
            var hRC = Win32.wglCreateContext(hDC);

            var goon = parameters.updateContextVersion;
            var major = 2; var minor = 1;
            if (goon) {
                //  Update the context if required.
                // if I update context, something in legacy opengl will not work...
                //  If the request version number is anything up to and including 2.1, standard render contexts
                //  will provide what we need (as long as the graphics card drivers are up to date).

                //  Now the none-trivial case. We must use the WGL_create_context extension to
                //  attempt to create a 3.0+ context.
                /// Only valid to be called after the render context is created, this function attempts to
                /// move the render context to the OpenGL version originally requested. If this is &gt; 2.1, this
                /// means building a new context. If this fails, we'll have to make do with 2.1.

                //  Make the context current.
                Win32.wglMakeCurrent(hDC, hRC);

                var glGetString = (delegate* unmanaged<uint, string>)WinGLRenderContext.GetProcAddress("glGetString");
                if (glGetString != null) {
                    string version = glGetString(0x1F02/*GL.GL_VERSION*/);
                    string[] parts = version.Split('.');
                    major = int.Parse(parts[0]); minor = int.Parse(parts[1]);
                }
                goon = (major > 2) || (major == 2 && minor > 1);
            }
            var pixelFormat = stackalloc int[1];
            if (goon) {
                // Match an appropriate pixel format
                var attributes = new int[] {
                    0x2010/*WGL_SUPPORT_OPENGL_ARB*/,   1/*GL_TRUE*/,
                    0x2001/*WGL_DRAW_TO_WINDOW_ARB*/,   1/*GL_TRUE*/,
                    0x2011/*WGL_DOUBLE_BUFFER_ARB*/,    1/*GL_TRUE*/,
                    0x2003/*WGL_ACCELERATION_ARB*/,     0x2027/*WGL_FULL_ACCELERATION_ARB*/,
                    0x2013/*WGL_PIXEL_TYPE_ARB*/,       0x202B/*WGL_TYPE_RGBA_ARB*/,
                    0x2014/*WGL_COLOR_BITS_ARB*/,       parameters.colorBits,
                    0x201D/*WGL_ACCUM_BITS_ARB*/,       parameters.accumBits,
                    0x201E/*WGL_ACCUM_RED_BITS_ARB*/,   parameters.accumRedBits,
                    0x201F/*WGL_ACCUM_GREEN_BITS_ARB*/, parameters.accumGreenBits,
                    0x2020/*WGL_ACCUM_BLUE_BITS_ARB*/,  parameters.accumBlueBits,
                    0x2021/*WGL_ACCUM_ALPHA_BITS_ARB*/, parameters.accumAlphaBits,
                    0x2022/*WGL_DEPTH_BITS_ARB*/,       parameters.depthBits,
                    0x2023/*WGL_STENCIL_BITS_ARB*/,     parameters.stencilBits,
                         0,        //End
                };
                var numFormats = stackalloc uint[1];
                var wglChoosePixelFormatARB = (delegate* unmanaged<IntPtr, int[], IntPtr/*GLfloat[]*/, uint, int*, uint*, bool>)GetProcAddress("wglChoosePixelFormatARB");
                goon = wglChoosePixelFormatARB(hDC, attributes, IntPtr.Zero, 1, pixelFormat, numFormats);
            }
            if (goon) { // Sets the pixel format
                goon = Win32.SetPixelFormat(hDC, pixelFormat[0], new PixelFormatDescriptor());
            }
            if (goon) {
                var attributes = stackalloc int[] {
                        0x2091/*WGL_CONTEXT_MAJOR_VERSION_ARB*/, major,
                        0x2092/*WGL_CONTEXT_MINOR_VERSION_ARB*/, minor,
                        //0x9126/*WGL_CONTEXT_PROFILE_MASK_ARB*/,  0x00000001/*WGL_CONTEXT_CORE_PROFILE_BIT_ARB*/,
                        0x9126/*WGL_CONTEXT_PROFILE_MASK_ARB*/,  0x00000002/*WGL_CONTEXT_COMPATIBILITY_PROFILE_BIT_ARB*/,
#if DEBUG
                        // this is a debug context
                        0x2094/*WGL_CONTEXT_FLAGS_ARB*/, 0x0001/*WGL_CONTEXT_DEBUG_BIT_ARB*/,
#endif
                        0
                        };
                var wglCreateContextAttribsARB = (delegate* unmanaged<IntPtr, IntPtr, int*, IntPtr>)GetProcAddress("wglCreateContextAttribsARB");
                IntPtr hRC2 = wglCreateContextAttribsARB(hDC, IntPtr.Zero, attributes);
                Win32.wglMakeCurrent(IntPtr.Zero, IntPtr.Zero);
                Win32.wglDeleteContext(hRC);
                Win32.wglMakeCurrent(hDC, hRC2);
                hRC = hRC2;
            }

            return (hDC, hRC);
        }

        /*
         * https://www.khronos.org/opengl/wiki/Load_OpenGL_Functions
        wglGetProcAddress will not return function pointers from any OpenGL functions that are directly exported by the OpenGL32.DLL itself. This means the old ones from OpenGL version 1.1. Fortunately those functions can be obtained by the Win32's GetProcAddress. On the other hand GetProcAddress will not work for the functions for which wglGetProcAddress works. So in order to get the address of any GL function one can try with wglGetProcAddress and if it fails, try again with the Win32's GetProcAddress:
         */
        private static readonly Func<string, IntPtr> GetProcAddress = (procName) => {
            IntPtr addr = IntPtr.Zero;
            // check https://www.GL.org/wiki/Load_OpenGL_Functions
            addr = Win32.wglGetProcAddress(procName);// from opengl32.dll
            long pointer = addr.ToInt64();
            if (-1 <= pointer && pointer <= 3) {
                addr = Win32.GetProcAddress(procName);// from kernel32.dll
                pointer = addr.ToInt64();
                if (-1 <= pointer && pointer <= 3) {
                    //Debug.WriteLine($"openGL function [{funcName}] not supported!");
                    addr = IntPtr.Zero;
                }
            }

            return addr;
        };
    }
}