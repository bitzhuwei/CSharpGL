using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    public partial class WinGL
    {
        public override void Begin(uint mode)
        {
            WinGL.glBegin(mode);
        }

        public override void End()
        {
            WinGL.glEnd();
        }


        /// <summary>
        /// This function deletes a set of Texture objects.
        /// </summary>
        /// <param name="n">Number of textures to delete.</param>
        /// <param name="textures">The array containing the names of the textures to delete.</param>
        public override void DeleteTextures(int n, uint[] textures)
        {
            IntPtr ptr = Win32.wglGetCurrentContext();
            if (ptr != IntPtr.Zero)
            {
                glDeleteTextures(n, textures);
            }
        }


        /// <summary>
        /// bind a named sampler to a texturing target.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="texture"></param>
        private static GLDelegates.void_uint_uint glBindSampler;

        /// <summary>
        /// bind a named sampler to a texturing target.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="sampler"></param>
        public override void BindSampler(uint target, uint sampler)
        {
            if (glBindSampler == null)
            {
                glBindSampler = WinGL.Instance.GetDelegateFor("glBindSampler", GLDelegates.typeof_void_uint_uint) as GLDelegates.void_uint_uint;
            }
            glBindSampler(target, sampler);
        }

    }
}