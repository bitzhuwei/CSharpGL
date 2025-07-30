using System;
using System.Diagnostics;
using System.Drawing;

namespace CSharpGL.SoftGL {
    unsafe partial class SoftGLRenderContext {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="windowHandle">Control.Handle</param>
        /// <param name="width">Control.Width</param>
        /// <param name="height">Control.Height</param>
        /// <param name="genParams"></param>
        /// <param name="config">required opengl functions</param>
        /// <returns></returns>
        public static SoftGLRenderContext? Create(IntPtr windowHandle, int width, int height, object genParams, HashSet<string>? config) {
            var hDC = SoftGLImpl.SoftGL.GetDC(windowHandle);
            var hRC = SoftGLImpl.SoftGL.CreateContext(windowHandle, width, height, genParams, config);
            //  Make the context current.
            SoftGLImpl.SoftGL.MakeCurrent(hDC, hRC);
            var glFunctions = new GL(GetProcAddress, config);

            //var dibSection = new DIBSection(width, height, hDC, genParams);

            //return new WinGLRenderContext(windowHandle, width, height, /*genParams,*/ hDC, hRC, glFunctions, dibSection);
            return new SoftGLRenderContext(windowHandle, width, height, /*genParams,*/ hDC, hRC, glFunctions);
        }

        private static readonly Func<string, IntPtr> GetProcAddress = (procName) => {
            IntPtr address = SoftGLImpl.SoftGL.GetProcAddress(procName);

            return address;
        };
    }
}