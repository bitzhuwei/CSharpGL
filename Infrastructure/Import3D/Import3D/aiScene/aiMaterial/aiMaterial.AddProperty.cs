
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Import3D {
    unsafe partial class aiMaterial {
        public aiReturn AddProperty(string input, string key, int type, int index) {
            Debug.Assert(sizeof(UInt32) == 4);
            var str = Marshal.StringToHGlobalAnsi(input);
            var result = AddBinaryProperty((byte*)str, (input.Length + 1 + 4),
                key, type, index, aiPropertyTypeInfo.aiPTI_String);
            Marshal.FreeHGlobal(str);
            return result;
        }
        public aiReturn AddProperty<T>(T input, int pNumValues, string key, int type, int index)
            where T : struct {
            var pin = GCHandle.Alloc(input, GCHandleType.Pinned);
            var addr = pin.AddrOfPinnedObject();
            var result = AddBinaryProperty((byte*)addr, pNumValues * Marshal.SizeOf<T>(),
                key, type, index, aiPropertyTypeInfo.aiPTI_Integer);
            pin.Free();
            return result;
        }
        private aiReturn AddBinaryProperty(byte* input, int pSizeInBytes,
            string key, int type, int index, aiPropertyTypeInfo typeInfo) {
            Debug.Assert(input != null);
            Debug.Assert(key != null);
            Debug.Assert(0 != pSizeInBytes);

            if (0 == pSizeInBytes) { return aiReturn.aiReturn_FAILURE; }

            // first search the list whether there is already an entry with this key
            var iOutIndex = uint.MaxValue;
            for (var i = 0; i < this.mNumProperties; ++i) {
                aiMaterialProperty prop = this.mProperties[i];

                if (//prop != null /* just for safety */ &&
                    prop.mKey == key && prop.mSemantic == type && prop.mIndex == index) {
                    //delete this.mProperties[i];
                    iOutIndex = (uint)i;
                }
            }

            // Allocate a new material property
            var pcNew = new aiMaterialProperty();

            // .. and fill it
            pcNew.mType = typeInfo;
            pcNew.mSemantic = type;
            pcNew.mIndex = index;

            pcNew.mDataLength = pSizeInBytes;
            //pcNew.mData = (byte*)Marshal.StringToHGlobalAnsi(input);// new byte[pSizeInBytes];
            pcNew.mData = (byte*)Marshal.AllocHGlobal(pSizeInBytes);
            for (int i = 0; i < pSizeInBytes; i++) {
                pcNew.mData[i] = input[i];
            }
            //memcpy(pcNew.mData, input, pSizeInBytes);

            //pcNew.mKey.length = static_cast<ai_uint32>(::strlen(key));
            //ai_assert(AI_MAXLEN > pcNew.mKey.length);
            //strcpy(pcNew.mKey.data, key);
            pcNew.mKey = key;

            if (uint.MaxValue != iOutIndex) {
                mProperties[iOutIndex] = pcNew;//.release();
                return aiReturn.aiReturn_SUCCESS;
            }

            // resize the array ... double the storage allocated
            if (mNumProperties == mNumAllocated) {
                uint iOld = mNumAllocated;
                mNumAllocated *= 2;

                aiMaterialProperty[] ppTemp;
                try {
                    ppTemp = new aiMaterialProperty[mNumAllocated];
                }
                catch (Exception e) {
                    return aiReturn.aiReturn_OUTOFMEMORY;
                }

                // just copy all items over; then replace the old array
                //memcpy(ppTemp, this.mProperties, iOld * sizeof(void*));
                for (int i = 0; i < this.mProperties.Length; i++) {
                    ppTemp[i] = this.mProperties[i];
                }

                //delete[] mProperties;
                this.mProperties = ppTemp;
            }
            // push back ...
            this.mProperties[mNumProperties++] = pcNew;//.release();

            return aiReturn.aiReturn_SUCCESS;

        }
    }
}