using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SoftGLImpl {
    /// <summary>
    ///
    /// </summary>
    static class StructHelper {
        ///// <summary>
        ///// 从当前位置读取一个struct并前移Stream的位置<code>Marshal.SizeOf(typeof(T))</code>的距离。
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="br"></param>
        ///// <param name="result"></param>
        //public static T ReadStruct<T>(this BinaryReader br) where T : struct
        //{
        //    T result;

        //    int size = Marshal.SizeOf(typeof(T));
        //    byte[] bytes = br.ReadBytes(size);
        //    bytes.GetStruct(out result);

        //    return result;
        //}

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="structObj"></param>
        /// <returns></returns>
        public static unsafe byte[] ToBytes<T>(this T structObj) where T : struct {
            byte[] bytes1, bytes2;
            {
                Int32 size = Marshal.SizeOf(structObj);
                bytes1 = new Byte[size];
                fixed (byte* p = bytes1) {
                    var buffer = (IntPtr)p;
                    Marshal.StructureToPtr(structObj, buffer, false);
                }

                //return bytes1;
            }
            {// original way
                Int32 size = Marshal.SizeOf(structObj);
                bytes2 = new Byte[size];
                IntPtr buffer = IntPtr.Zero;
                try {
                    buffer = Marshal.AllocHGlobal(size);
                    Marshal.StructureToPtr(structObj, buffer, false);
                    Marshal.Copy(buffer, bytes2, 0, size);
                }
                finally {
                    Marshal.FreeHGlobal(buffer);
                }

                //return bytes2;
            }
            Debug.Assert(bytes1.Length == bytes2.Length);
            for (int i = 0; i < bytes1.Length; i++) {
                if (bytes1[i] != bytes2[i]) { Debug.Assert(false); }
            }

            return bytes2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="packet"></param>
        /// <param name="type"></param>
        /// <param name="startPos"></param>
        /// <returns></returns>
        public static unsafe object? ToStruct(this byte[] packet, Type type, int startPos = 0) {
            object? result1, result2;
            fixed (byte* p = packet) {
                var p2 = p + startPos;
                var addr = (IntPtr)p2;
                result1 = Marshal.PtrToStructure(addr, type);
                //return result1;
            }
            //{// original way
            //    GCHandle pin = GCHandle.Alloc(packet, GCHandleType.Pinned);
            //    IntPtr address = Marshal.UnsafeAddrOfPinnedArrayElement(packet, startPos);
            //    result2 = Marshal.PtrToStructure(address, type);
            //    pin.Free();
            //}

            return result1;
        }
    }
}