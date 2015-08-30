using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class StructHelper
    {
        /// <summary>
        /// 从当前位置读取一个struct并前移Stream的位置<code>Marshal.SizeOf(typeof(T))</code>的距离。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="br"></param>
        /// <param name="result"></param>
        public static T ReadStruct<T>(this BinaryReader br) where T : struct
        {
            T result;

            int size = Marshal.SizeOf(typeof(T));
            byte[] bytes = br.ReadBytes(size);
            bytes.GetStruct(out result);

            return result;
        }
    }
}
