using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ArrayDataProvider<T> : LeveledDataProvider where T : struct
    {
        private T[] data;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public ArrayDataProvider(T[] data)
        {
            this.data = data;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IEnumerator<LeveledData> GetEnumerator()
        {
            yield return new ArrayData<T>(this.data);
        }
    }

    class ArrayData<T> : LeveledData
    {
        private T[] data;
        private GCHandle pinned;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public ArrayData(T[] data)
        {
            this.data = data;
        }

        public override IntPtr LockData()
        {
            this.pinned = GCHandle.Alloc(this.data, GCHandleType.Pinned);
            IntPtr header = pinned.AddrOfPinnedObject();
            // same result with: IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(this.data, 0);
            return header;
            //GL.Instance.PixelStorei(GL.GL_UNPACK_ALIGNMENT, 1);
            //GL.Instance.TexImage1D((uint)TextureTarget.Texture1D, 0, GL.GL_RGBA8, this.width, 0, GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, header);
        }

        public override void FreeData()
        {
            this.pinned.Free();
        }
    }
}
