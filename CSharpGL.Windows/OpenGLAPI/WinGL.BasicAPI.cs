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
    }
}