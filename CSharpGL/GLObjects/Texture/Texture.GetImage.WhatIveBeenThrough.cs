//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Linq;
//using System.Runtime.InteropServices;
//using System.Text;

//namespace CSharpGL
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    public static partial class TextureHelper
//    {
//        /// <summary>
//        /// Get image from texture.
//        /// </summary>
//        /// <param name="texture"></param>
//        /// <param name="width"></param>
//        /// <param name="height"></param>
//        /// <returns></returns>
//        public static unsafe Bitmap GetImage(this Texture texture, int width, int height)
//        {
//            texture.Bind();
//            var array = new byte[width * height * 4];
//            GCHandle pinned = GCHandle.Alloc(array, GCHandleType.Pinned);
//            IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(array, 0);
//            var unmanagedArray = new TempUnmanagedArray<byte>(header, array.Length);
//            GL.Instance.GetTexImage((uint)texture.Target, 0, texture.Storage.internalFormat, GL.GL_UNSIGNED_BYTE, unmanagedArray.Header);
//            pinned.Free();

//            var bmp = new Bitmap(width, height);
//            {
//                var data = bmp.LockBits(new Rectangle(0, 0, width, height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
//                var byteArray = (byte*)data.Scan0;
//                float min = array[0], max = array[0];
//                for (int i = 0; i < array.Length / 4; i++)
//                {
//                    byteArray[i * 4 + 0] = array[i * 4 + 2];
//                    byteArray[i * 4 + 1] = array[i * 4 + 1];
//                    byteArray[i * 4 + 2] = array[i * 4 + 0];
//                    byteArray[i * 4 + 3] = array[i * 4 + 3];
//                }
//                bmp.UnlockBits(data);
//            }

//            texture.Unbind();

//            return bmp;
//        }
//    }

//    // memo: I used this to find the right order of array in GetImage(). It's <2,1,0,3>.
//    //public class Tuple4
//    //{
//    //    public int this[int index]
//    //    {
//    //        get { return this.list[index]; }
//    //    }

//    //    public readonly int[] list = new int[4];

//    //    public Tuple4(int v0, int v1, int v2, int v3)
//    //    {
//    //        this.list[0] = v0;
//    //        this.list[1] = v1;
//    //        this.list[2] = v2;
//    //        this.list[3] = v3;
//    //    }

//    //    public override string ToString()
//    //    {
//    //        return string.Format("{0}{1}{2}{3}", list[0], list[1], list[2], list[3]);
//    //    }
//    //}
//    //        var list = new List<Tuple4>();
//    //        list.Add(new Tuple4(0, 1, 2, 3));
//    //        list.Add(new Tuple4(0, 1, 3, 2));
//    //        list.Add(new Tuple4(0, 2, 1, 3));
//    //        list.Add(new Tuple4(0, 2, 3, 1));
//    //        list.Add(new Tuple4(0, 3, 1, 2));
//    //        list.Add(new Tuple4(0, 3, 2, 1));
//    //        list.Add(new Tuple4(1, 0, 2, 3));
//    //        list.Add(new Tuple4(1, 0, 3, 2));
//    //        list.Add(new Tuple4(1, 2, 0, 3));
//    //        list.Add(new Tuple4(1, 2, 3, 0));
//    //        list.Add(new Tuple4(1, 3, 0, 2));
//    //        list.Add(new Tuple4(1, 3, 2, 0));
//    //        list.Add(new Tuple4(2, 0, 1, 3));
//    //        list.Add(new Tuple4(2, 0, 3, 1));
//    //        list.Add(new Tuple4(2, 1, 0, 3));
//    //        list.Add(new Tuple4(2, 1, 3, 0));
//    //        list.Add(new Tuple4(2, 3, 0, 1));
//    //        list.Add(new Tuple4(2, 3, 1, 0));
//    //        list.Add(new Tuple4(3, 0, 1, 2));
//    //        list.Add(new Tuple4(3, 0, 2, 1));
//    //        list.Add(new Tuple4(3, 1, 0, 2));
//    //        list.Add(new Tuple4(3, 1, 2, 0));
//    //        list.Add(new Tuple4(3, 2, 0, 1));
//    //        list.Add(new Tuple4(3, 2, 1, 0));
//}
