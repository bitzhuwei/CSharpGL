
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Import3D {
    public unsafe class aiMaterial {
        public const int DefaultNumAllocated = 5;

        /// <summary>List of all material properties loaded.</summary>
        public aiMaterialProperty[] mProperties = new aiMaterialProperty[DefaultNumAllocated];

        /// <summary>Number of properties in the data base</summary>
        public uint mNumProperties;

        /// <summary>Storage allocated</summary>
        public uint mNumAllocated = DefaultNumAllocated;

        public aiMaterial() {
        }

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

        public aiReturn GetTexture(aiTextureType type,
                                   int index,
                                   out string path,
                                   aiTextureMapping* mapping = null,
                                   int* uvindex = null,
                                   float* blend = null,
                                   aiTextureOp* op = null,
                                   aiTextureMapMode* mapmode = null) {
            return aiGetMaterialTexture(this, type, index, out path, mapping, uvindex, blend, op, mapmode);
        }

        private static aiReturn aiGetMaterialTexture(
            aiMaterial material, aiTextureType type, int index, out string path,
            aiTextureMapping* _mapping, int* uvindex, float* blend, aiTextureOp* op, aiTextureMapMode* mapmode, int* flags = null) {
            Debug.Assert(null != material);
            //Debug.Assert(null != path);

            // Get the path to the texture
            if (aiReturn.aiReturn_SUCCESS != aiGetMaterialString(material, /*AI_MATKEY_TEXTURE(type, index)*/"$tex.mapping", type, index, out path)) {
                return aiReturn.aiReturn_FAILURE;
            }

            // Determine mapping type
            int mapping_ = (int)aiTextureMapping.aiTextureMapping_UV;
            aiGetMaterialInteger(material, /*AI_MATKEY_MAPPING(type, index)*/"$tex.mapping", type, index, &mapping_);
            var mapping = (aiTextureMapping)(mapping_);
            if (_mapping != null)
                _mapping[0] = mapping;

            // Get UV index
            if (aiTextureMapping.aiTextureMapping_UV == mapping && uvindex != null) {
                aiGetMaterialInteger(material, /*AI_MATKEY_UVWSRC(type, index)*/"$tex.uvwsrc", type, index, uvindex);
            }
            // Get blend factor
            if (blend != null) {
                aiGetMaterialFloat(material, /*AI_MATKEY_TEXBLEND(type, index)*/"$tex.blend", type, index, blend);
            }
            // Get texture operation
            if (op != null) {
                aiGetMaterialInteger(material, /*AI_MATKEY_TEXOP(type, index)*/"$tex.op", type, index, (int*)op);
            }
            // Get texture mapping modes
            if (mapmode != null) {
                aiGetMaterialInteger(material, /*AI_MATKEY_MAPPINGMODE_U(type, index)*/"$tex.mapmodeu", type, index, (int*)&mapmode[0]);
                aiGetMaterialInteger(material, /*AI_MATKEY_MAPPINGMODE_V(type, index)*/"$tex.mapmodev", type, index, (int*)&mapmode[1]);
            }
            // Get texture flags
            if (flags != null) {
                aiGetMaterialInteger(material, /*AI_MATKEY_TEXFLAGS(type, index)*/"$tex.flags", type, index, (int*)flags);
            }

            return aiReturn.aiReturn_SUCCESS;

        }

        private static void aiGetMaterialFloat(aiMaterial material, string v, aiTextureType type, int index, float* blend) {
            throw new NotImplementedException();
        }

        private static aiReturn aiGetMaterialInteger(aiMaterial material, string pKey, aiTextureType type, int index, int* pOut) {
            return aiGetMaterialIntegerArray(material, pKey, type, index, pOut, null);
        }

        private static aiReturn aiGetMaterialIntegerArray(aiMaterial material, string pKey, aiTextureType type, int index, int* pOut, int* pMax) {
            Debug.Assert(pOut != null);
            Debug.Assert(material != null);

            aiMaterialProperty prop;
            aiGetMaterialProperty(material, pKey, type, index, out prop);
            //if (!prop) {
            //return AI_FAILURE;
            //}

            // data is given in ints, simply copy it
            int iWrite = 0;
            if (aiPropertyTypeInfo.aiPTI_Integer == prop.mType || aiPropertyTypeInfo.aiPTI_Buffer == prop.mType) {
                iWrite = Math.Max((prop.mDataLength / sizeof(Int32)), 1);
                if (pMax != null) {
                    iWrite = Math.Min(*pMax, iWrite);
                }
                if (1 == prop.mDataLength) {
                    // bool type, 1 byte
                    *pOut = (*prop.mData);
                }
                else {
                    for (var a = 0; a < iWrite; ++a) {
                        pOut[a] = ((prop.mData)[a]);
                    }
                }
                if (pMax != null) {
                    *pMax = iWrite;
                }
            }
            // data is given in floats convert to int
            else if (aiPropertyTypeInfo.aiPTI_Float == prop.mType) {
                iWrite = prop.mDataLength / sizeof(float);
                if (pMax != null) {
                    iWrite = Math.Min(*pMax, iWrite);
                    ;
                }
                for (var a = 0; a < iWrite; ++a) {
                    pOut[a] = (prop.mData)[a];
                }
                if (pMax != null) {
                    *pMax = iWrite;
                }
            }
            // it is a string ... no way to read something out of this
            else {
                if (pMax != null) {
                    iWrite = *pMax;
                }
                // strings are zero-terminated with a 32 bit length prefix, so this is safe
                var cur = prop.mData + 4;
                Debug.Assert(prop.mDataLength >= 5);
                Debug.Assert(0 != prop.mData[prop.mDataLength - 1]);
                for (var a = 0; ; ++a) {
                    pOut[a] = strtol10(cur, &cur);
                    if (a == iWrite - 1) {
                        break;
                    }
                    if (!IsSpace(*cur)) {
                        Log.WriteLine($"Material property {pKey} is a string; failed to parse an integer array out of it.");
                        return aiReturn.aiReturn_FAILURE;
                    }
                }

                if (pMax != null) {
                    *pMax = iWrite;
                }
            }
            return aiReturn.aiReturn_SUCCESS;

        }

        private static bool IsSpace(byte v) {
            return v == ' ' || v == '\t';
        }

        // ------------------------------------------------------------------------------------
        // signed variant of strtoul10
        // ------------------------------------------------------------------------------------
        static int strtol10(byte* inValue, byte** outValue = null) {
            bool inv = (*inValue == '-');
            if (inv || *inValue == '+') {
                ++inValue;
            }

            int value = strtoul10(inValue, outValue);
            if (inv) {
                if (value < int.MaxValue && value > int.MinValue) {
                    value = -value;
                }
                else {
                    //Log.WriteLine($"Converting the string \"{inValue}\" into an inverted value resulted in overflow.");
                    Log.WriteLine($"Converting the string [] into an inverted value resulted in overflow.");
                }
            }
            return value;
        }
        // ------------------------------------------------------------------------------------
        // Convert a string in decimal format to a number
        // ------------------------------------------------------------------------------------
        static int strtoul10(byte* inValue, byte** outValue = null) {
            int value = 0;

            for (; ; ) {
                if (*inValue < '0' || *inValue > '9') {
                    break;
                }

                value = (value * 10) + (*inValue - '0');
                ++inValue;
            }
            if (outValue != null) {
                *outValue = inValue;
            }
            return value;
        }

        private static void aiGetMaterialProperty(aiMaterial material, string pKey, aiTextureType type, int index, out aiMaterialProperty prop) {
            throw new NotImplementedException();
        }

        private static aiReturn aiGetMaterialString(aiMaterial material, string v, aiTextureType type, int index, out string path) {
            throw new NotImplementedException();
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