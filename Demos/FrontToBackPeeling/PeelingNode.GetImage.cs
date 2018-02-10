using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;
using System.Drawing;
using System.Runtime.InteropServices;

namespace FrontToBackPeeling
{
    partial class PeelingNode
    {
        // TODO: move this into CSharpGL.Texture.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="texture"></param>
        /// <returns></returns>
        private unsafe Bitmap GetImage(Texture texture)
        {
            texture.Bind();
            var array = new float[width * height * 4];
            GCHandle pinned = GCHandle.Alloc(array, GCHandleType.Pinned);
            IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(array, 0);
            var unmanagedArray = new TempUnmanagedArray<float>(header, array.Length);
            GL.Instance.GetTexImage((uint)texture.Target, 0, texture.Storage.internalFormat, GL.GL_FLOAT, unmanagedArray.Header);
            pinned.Free();

            var bmp = new Bitmap(this.width, this.height);
            {
                var data = bmp.LockBits(new Rectangle(0, 0, this.width, this.height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                var floatArray = (byte*)data.Scan0;
                int index = 0;
                float min = array[0], max = array[0];
                for (int w = 0; w < this.width; w++)
                {
                    for (int h = 0; h < this.height; h++)
                    {
                        var value = array[index++];
                        if (value < min) { min = value; }
                        if (max < value) { max = value; }

                        floatArray[index++] = (byte)(value * 255);
                    }
                }
                //System.Runtime.InteropServices.Marshal.Copy(array, 0, data.Scan0, array.Length);
                bmp.UnlockBits(data);
            }

            texture.Unbind();

            return bmp;
        }
    }
}
