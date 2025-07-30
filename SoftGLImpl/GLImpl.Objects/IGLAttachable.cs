using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGLImpl {
    /// <summary>
    /// Objects that can be attached to framebuffer's attachment point.
    /// </summary>
    interface IGLAttachable {
        uint Format { get; }

        int Width { get; }

        int Height { get; }

        //byte[]? DataStore { get; }
        /// <summary>
        /// byte*
        /// </summary>
        IntPtr DataStore { get; }

        /// <summary>
        /// how many bytes in <see cref="DataStore"/>
        /// </summary>
        int Size { get; }

    }

    static class IGLAttachableHelper {
        /// <summary>
        /// set <paramref name="attachable"/>'s data store to specified <paramref name="data"/>.
        /// </summary>
        /// <param name="attachable"></param>
        /// <param name="data"></param>
        public static unsafe void Clear(this IGLAttachable attachable, byte[] data) {
            if (attachable == null || data == null || data.Length < 1) { return; }

            var dataStore = attachable.DataStore;
            if (dataStore == IntPtr.Zero) { return; }

            int width = attachable.Width;
            int height = attachable.Height;
            int singleElementByteLength = attachable.Size / width / height;
            var dest = (byte*)dataStore;
            if (singleElementByteLength != data.Length) {
                for (int i = 0; i < width; i++) {
                    for (int j = 0; j < height; j++) {
                        for (int t = 0; t < singleElementByteLength && t < data.Length; t++) {
                            dest[(width * j + i) * singleElementByteLength + t] = data[t];
                        }
                    }
                }
            }
            else {
                for (int i = 0; i < attachable.Size; i++) {
                    dest[i] = data[i % data.Length];
                }
            }
        }

        public static unsafe void Set(this IGLAttachable attachable, int x, int y, IntPtr pointer, PassType passType) {
            if (attachable == null) { return; }

            byte[] data = PassTypeHelper.ConvertTo(pointer, passType, attachable.Format);
            var dataStore = attachable.DataStore;
            if (dataStore == IntPtr.Zero) { return; }

            int width = attachable.Width;
            int height = attachable.Height;
            int singleElementByteLength = attachable.Size / width / height;
            var dest = (byte*)dataStore;
            if (singleElementByteLength != data.Length) {
                for (int i = 0; i < singleElementByteLength && i < data.Length; i++) {
                    dest[(width * y + x) * singleElementByteLength + i] = data[i];
                }
            }
            else {
                for (int i = 0; i < singleElementByteLength; i++) {
                    dest[(width * y + x) * singleElementByteLength + i] = data[i];
                }
            }
        }
        //public static void Set(this IGLAttachable attachable, int x, int y, PassBuffer passbuffer) {
        //    if (attachable == null || passbuffer == null || passbuffer.array == null) { return; }

        //    byte[] data = passbuffer.ConvertTo(attachable.Format);
        //    var dataStore = attachable.DataStore;
        //    if (dataStore == null) { return; }

        //    int width = attachable.Width;
        //    int height = attachable.Height;
        //    int singleElementByteLength = dataStore.Length / width / height;
        //    if (singleElementByteLength != data.Length) {
        //        for (int i = 0; i < singleElementByteLength && i < data.Length; i++) {
        //            dataStore[(width * y + x) * singleElementByteLength + i] = data[i];
        //        }
        //    }
        //    else {
        //        for (int i = 0; i < singleElementByteLength; i++) {
        //            dataStore[(width * y + x) * singleElementByteLength + i] = data[i];
        //        }
        //    }
        //}

    }
}
