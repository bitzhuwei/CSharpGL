using System.Runtime.InteropServices;

namespace SoftGLImpl {
    static unsafe class PassTypeHelper {

        ///// <summary>
        ///// Convert data in bytes to data in specified <paramref name="internalFormat"/>.
        ///// </summary>
        ///// <param name="passbuffer">source data and its type.</param>
        ///// <param name="internalFormat">type of target result.</param>
        ///// <returns>target result.</returns>
        //public static byte[] ConvertTo(this PassBuffer passbuffer, uint internalFormat) {
        //    GCHandle pin = GCHandle.Alloc(passbuffer.array, GCHandleType.Pinned);
        //    IntPtr address = Marshal.UnsafeAddrOfPinnedArrayElement(passbuffer.array, 0);
        //    byte[] result = ConvertTo(address, passbuffer.elementType, internalFormat);
        //    pin.Free();

        //    return result;
        //}


        /// <summary>
        /// Convert data in bytes to data in specified <paramref name="internalFormat"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="dataType">type of source data(<paramref name="value"/>).</param>
        /// <param name="internalFormat">type of target result.</param>
        /// <returns>target result.</returns>
        public static byte[] ConvertTo<T>(this T value, PassType dataType, uint internalFormat) where T : struct {
            var array = new T[] { value };
            GCHandle pin = GCHandle.Alloc(array, GCHandleType.Pinned);
            IntPtr address = Marshal.UnsafeAddrOfPinnedArrayElement(array, 0);
            byte[] result = ConvertTo(address, dataType, internalFormat);
            pin.Free();

            return result;
        }

        /// <summary>
        /// Convert data in bytes to data in specified <paramref name="internalFormat"/>.
        /// </summary>
        /// <param name="address">unmanaged address of source data.</param>
        /// <param name="dataType">type of source data(<paramref name="address"/>).</param>
        /// <param name="internalFormat">type of target result.</param>
        /// <returns>target result.</returns>
        public static byte[] ConvertTo(this IntPtr address, PassType dataType, uint internalFormat) {
            byte[] result;
            switch (dataType) {
            case PassType.Float: result = ConvertFloatTo(address, internalFormat); break;
            case PassType.Vec2: result = ConvertVec2To(address, internalFormat); break;
            case PassType.Vec3: result = ConvertVec3To(address, internalFormat); break;
            case PassType.Vec4: result = ConvertVec4To(address, internalFormat); break;
            case PassType.Mat2: result = ConvertMat2To(address, internalFormat); break;
            case PassType.Mat3: result = ConvertMat3To(address, internalFormat); break;
            case PassType.Mat4: result = ConvertMat4To(address, internalFormat); break;
            default:
            throw new NotDealWithNewEnumItemException(typeof(PassType));
            }

            return result;
        }

        private static byte[] ConvertFloatTo(IntPtr address, uint internalFormat) {
            byte[] result;
            var array = (float*)address;
            float v = array[0];
            if (internalFormat == GL.GL_DEPTH_COMPONENT) {
                result = new byte[4];
                //GCHandle pin = GCHandle.Alloc(result, GCHandleType.Pinned);
                //IntPtr addr = Marshal.UnsafeAddrOfPinnedArrayElement(result, 0);
                //var dst = (float*)addr;
                //dst[0] = v;
                //pin.Free();
                fixed (byte* p = result) {
                    float* p2 = (float*)p;
                    p2[0] = v;
                }
            }
            else {
                throw new NotImplementedException();
            }

            return result;
        }

        private static byte[] ConvertVec2To(IntPtr address, uint internalFormat) {
            throw new NotImplementedException();
            //byte[] result;
            //if (internalFormat == GL.GL_RGBA) {

            //}
            //else if (internalFormat == GL.GL_BGRA) {

            //}
            //else {
            //    throw new NotImplementedException();
            //}

            //return result;
        }

        private static byte[] ConvertVec3To(IntPtr address, uint internalFormat) {
            throw new NotImplementedException();
            //byte[] result = null;
            //if (internalFormat == GL.GL_RGBA) {

            //}
            //else if (internalFormat == GL.GL_BGRA) {

            //}
            //else {
            //    throw new NotImplementedException();
            //}

            //return result;
        }

        /// <summary>
        /// Convert a vec4 data to data in specified <paramref name="internalFormat"/>.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="internalFormat"></param>
        /// <returns></returns>
        private static byte[] ConvertVec4To(IntPtr address, uint internalFormat) {
            byte[] result = new byte[4];
            var array = (vec4*)address;
            vec4 v = array[0];
            if (internalFormat == GL.GL_RGBA) // to byte[4]{r, g, b, a}
            {
                result[0] = (byte)(v.x * 255);
                result[1] = (byte)(v.y * 255);
                result[2] = (byte)(v.z * 255);
                result[3] = (byte)(v.w * 255);
            }
            else if (internalFormat == GL.GL_BGRA) // to byte[4]{b, g, r, a}
            {
                result[0] = (byte)(v.z * 255);
                result[1] = (byte)(v.y * 255);
                result[2] = (byte)(v.x * 255);
                result[3] = (byte)(v.w * 255);
            }
            else {
                throw new NotImplementedException();
            }

            return result;
        }

        private static byte[] ConvertMat2To(IntPtr address, uint internalFormat) {
            throw new NotImplementedException();
            //byte[] result = null;
            //if (internalFormat == GL.GL_RGBA) {

            //}
            //else if (internalFormat == GL.GL_BGRA) {

            //}
            //else {
            //    throw new NotImplementedException();
            //}

            //return result;
        }

        private static byte[] ConvertMat3To(IntPtr address, uint internalFormat) {
            throw new NotImplementedException();
            //byte[] result = null;
            //if (internalFormat == GL.GL_RGBA) {

            //}
            //else if (internalFormat == GL.GL_BGRA) {

            //}
            //else {
            //    throw new NotImplementedException();
            //}

            //return result;
        }

        private static byte[] ConvertMat4To(IntPtr address, uint internalFormat) {
            throw new NotImplementedException();
            //byte[] result = null;
            //if (internalFormat == GL.GL_RGBA) {

            //}
            //else if (internalFormat == GL.GL_BGRA) {

            //}
            //else {
            //    throw new NotImplementedException();
            //}

            //return result;
        }

        public static PassType GetPassType(this Type type) {
            if (type == null) { throw new ArgumentNullException(); }
            if (type == typeof(float)) { return PassType.Float; }
            if (type == typeof(vec2)) { return PassType.Vec2; }
            if (type == typeof(vec3)) { return PassType.Vec3; }
            if (type == typeof(vec4)) { return PassType.Vec4; }
            if (type == typeof(mat2)) { return PassType.Mat2; }
            if (type == typeof(mat3)) { return PassType.Mat3; }
            if (type == typeof(mat4)) { return PassType.Mat4; }

            throw new ArgumentException(string.Format("Unexpected type [{0}] in TryGetPassType()", type));
        }

        public static int ByteSize(this PassType passType) {
            int result = 0;
            switch (passType) {
            case PassType.Float: result = sizeof(float); break;
            case PassType.Vec2: result = sizeof(float) * 2; break;
            case PassType.Vec3: result = sizeof(float) * 3; break;
            case PassType.Vec4: result = sizeof(float) * 4; break;
            case PassType.Mat2: result = sizeof(float) * 4; break;
            case PassType.Mat3: result = sizeof(float) * 9; break;
            case PassType.Mat4: result = sizeof(float) * 16; break;
            default:
            throw new NotImplementedException();
            }

            return result;
        }
    }
}
