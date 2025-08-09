
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

        public aiReturn GetTexture(int type,
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
            aiMaterial material, int type, int index, out string path,
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

        /** @brief Retrieve a single float property with a specific key from the material.
        *
        * Pass one of the AI_MATKEY_XXX constants for the last three parameters (the
        * example reads the #AI_MATKEY_SHININESS_STRENGTH property of the first diffuse texture)
        * @code
        * float specStrength = 1.f; // default value, remains unmodified if we fail.
        * aiGetMaterialFloat(mat, AI_MATKEY_SHININESS_STRENGTH,
        *    (float*)&specStrength);
        * @endcode
        *
        * @param pMat Pointer to the input material. May not be NULL
        * @param pKey Key to search for. One of the AI_MATKEY_XXX constants.
        * @param pOut Receives the output float.
        * @param type (see the code sample above)
        * @param index (see the code sample above)
        * @return Specifies whether the key has been found. If not, the output
        *   float remains unmodified.*/
        // ---------------------------------------------------------------------------
        static aiReturn aiGetMaterialFloat(aiMaterial pMat, string pKey, int type, int index, float* pOut) {
            return aiGetMaterialFloatArray(pMat, pKey, type, index, pOut, null);
        }

        // Get an array of floating-point values from the material.
        private static aiReturn aiGetMaterialFloatArray(aiMaterial pMat, string pKey, int type, int index, float* pOut, int* pMax) {
            Debug.Assert(pOut != null);
            Debug.Assert(pMat != null);

            aiMaterialProperty? prop;
            aiGetMaterialProperty(pMat, pKey, type, index, out prop);
            if (null == prop) {
                return aiReturn.aiReturn_FAILURE;
            }

            // data is given in floats, convert to ai_real
            int iWrite = 0;
            if (aiPropertyTypeInfo.aiPTI_Float == prop.mType || aiPropertyTypeInfo.aiPTI_Buffer == prop.mType) {
                iWrite = prop.mDataLength / sizeof(float);
                if (pMax != null) {
                    iWrite = Math.Min(*pMax, iWrite);
                    ;
                }

                for (var a = 0; a < iWrite; ++a) {
                    pOut[a] = (float)(prop.mData)[a];
                }

                if (pMax != null) {
                    *pMax = iWrite;
                }
            }
            // data is given in doubles, convert to float
            else if (aiPropertyTypeInfo.aiPTI_Double == prop.mType) {
                iWrite = prop.mDataLength / sizeof(double);
                if (pMax != null) {
                    iWrite = Math.Min(*pMax, iWrite);
                    ;
                }
                for (var a = 0; a < iWrite; ++a) {
                    pOut[a] = (float)(double)(prop.mData)[a];
                }
                if (pMax != null) {
                    *pMax = iWrite;
                }
            }
            // data is given in ints, convert to float
            else if (aiPropertyTypeInfo.aiPTI_Integer == prop.mType) {
                iWrite = prop.mDataLength / sizeof(Int32);
                if (pMax != null) {
                    iWrite = Math.Min(*pMax, iWrite);
                    ;
                }
                for (var a = 0; a < iWrite; ++a) {
                    pOut[a] = (float)(Int32)(prop.mData)[a];
                }
                if (pMax != null) {
                    *pMax = iWrite;
                }
            }
            // a string ... read floats separated by spaces
            else {
                if (pMax != null) {
                    iWrite = *pMax;
                }
                // strings are zero-terminated with a 32 bit length prefix, so this is safe
                var cur = prop.mData + 4;
                Debug.Assert(prop.mDataLength >= 5);
                Debug.Assert(prop.mData[prop.mDataLength - 1] == 0);
                for (var a = 0; ; ++a) {
                    cur = fast_atoreal_move(cur, pOut[a]);
                    if (a == iWrite - 1) {
                        break;
                    }
                    if (!IsSpace(*cur)) {
                        Import3D.Log.WriteLine("Material property pKey is a string; failed to parse a float array out of it.");
                        return aiReturn.aiReturn_FAILURE;
                    }
                }

                if (pMax != null) {
                    *pMax = iWrite;
                }
            }
            return aiReturn.aiReturn_SUCCESS;
        }
        private static byte* fast_atoreal_move(byte* cur, float outValue, bool check_comma = true) {
            float f = 0;

            bool inv = (*cur == '-');
            if (inv || *cur == '+') {
                ++cur;
            }

            if ((cur[0] == 'N' || cur[0] == 'n') && ASSIMP_strincmp(cur, "nan", 3) == 0) {
                outValue = float.NaN;
                cur += 3;
                return cur;
            }

            if ((cur[0] == 'I' || cur[0] == 'i') && ASSIMP_strincmp(cur, "inf", 3) == 0) {
                outValue = float.PositiveInfinity;// std::numeric_limits<float>::infinity();
                if (inv) {
                    outValue = -outValue;
                }
                cur += 3;
                if ((cur[0] == 'I' || cur[0] == 'i') && ASSIMP_strincmp(cur, "inity", 5) == 0) {
                    cur += 5;
                }
                return cur;
            }

            if (!(cur[0] >= '0' && cur[0] <= '9') &&
                    !((cur[0] == '.' || (check_comma && cur[0] == ',')) && cur[1] >= '0' && cur[1] <= '9')) {
                // The string is known to be bad, so don't risk printing the whole thing.
                throw new Exception($"Cannot parse string  as a real number: does not start with digit or decimal point followed by digit.");
            }

            if (*cur != '.' && (!check_comma || cur[0] != ',')) {
                f = strtoul10_64(cur, &cur);
            }

            if ((*cur == '.' || (check_comma && cur[0] == ',')) && cur[1] >= '0' && cur[1] <= '9') {
                ++cur;

                // NOTE: The original implementation is highly inaccurate here. The precision of a single
                // IEEE 754 float is not high enough, everything behind the 6th digit tends to be more
                // inaccurate than it would need to be. Casting to double seems to solve the problem.
                // strtol_64 is used to prevent integer overflow.

                // Another fix: this tends to become 0 for long numbers if we don't limit the maximum
                // number of digits to be read. AI_FAST_ATOF_RELAVANT_DECIMALS can be a value between
                // 1 and 15.
                int diff = /*AI_FAST_ATOF_RELAVANT_DECIMALS*/15;
                double pl = strtoul10_64(cur, &cur, &diff);

                pl *= fast_atof_table[diff];
                f += (float)pl;
            }
            // For backwards compatibility: eat trailing dots, but not trailing commas.
            else if (*cur == '.') {
                ++cur;
            }

            // A major 'E' must be allowed. Necessary for proper reading of some DXF files.
            // Thanks to Zhao Lei to point out that this if() must be outside the if (*c == '.' ..)
            if (*cur == 'e' || *cur == 'E') {
                ++cur;
                bool einv = (*cur == '-');
                if (einv || *cur == '+') {
                    ++cur;
                }

                // The reason float constants are used here is that we've seen cases where compilers
                // would perform such casts on compile-time constants at runtime, which would be
                // bad considering how frequently fast_atoreal_move<float> is called in Assimp.
                float exp = strtoul10_64(cur, &cur);
                if (einv) {
                    exp = -exp;
                }
                f *= (float)Math.Pow(10.0f, exp);
            }

            if (inv) {
                f = -f;
            }
            outValue = f;
            return cur;

        }
        // we write [16] here instead of [] to work around a swig bug
        static double[] fast_atof_table = new double[16] {
        0.0,
        0.1,
        0.01,
        0.001,
        0.0001,
        0.00001,
        0.000001,
        0.0000001,
        0.00000001,
        0.000000001,
        0.0000000001,
        0.00000000001,
        0.000000000001,
        0.0000000000001,
        0.00000000000001,
        0.000000000000001
        };

        // ------------------------------------------------------------------------------------
        // Special version of the function, providing higher accuracy and safety
        // It is mainly used by fast_atof to prevent ugly and unwanted integer overflows.
        // ------------------------------------------------------------------------------------
        static UInt64 strtoul10_64(byte* inValue, byte** outValue = null, int* max_inout = null) {
            int cur = 0;
            UInt64 value = 0;

            if (*inValue < '0' || *inValue > '9') {
                // The string is known to be bad, so don't risk printing the whole thing.
                throw new Exception("The string cannot be converted into a value.");
            }

            for (; ; ) {
                if (*inValue < '0' || *inValue > '9') {
                    break;
                }

                UInt64 new_value = (value * (UInt64)10) + ((UInt64)(*inValue - '0'));

                // numeric overflow, we rely on you
                if (new_value < value) {
                    Import3D.Log.WriteLine("Converting the string into a value resulted inValue overflow.");
                    return 0;
                }

                value = new_value;

                ++inValue;
                ++cur;

                if (max_inout != null && *max_inout == cur) {
                    if (outValue != null) { /* skip to end */
                        while (*inValue >= '0' && *inValue <= '9') {
                            ++inValue;
                        }
                        *outValue = inValue;
                    }

                    return value;
                }
            }
            if (outValue != null) {
                *outValue = inValue;
            }

            if (max_inout != null) {
                *max_inout = cur;
            }

            return value;

        }

        static int ASSIMP_strincmp(byte* s1, string s2, int n) {
            Debug.Assert(null != s1);
            Debug.Assert(null != s2);
            if (n == 0) {
                return 0;
            }

            char c1, c2; int c2Index = 0;
            int p = 0;
            do {
                if (p++ >= n) return 0;
                c1 = char.ToLower((char)*(s1++));
                c2 = char.ToLower(s2[c2Index++]);
            } while (c1 != 0 && (c1 == c2));

            return c1 - c2;
        }
        // -------------------------------------------------------------------------------
        /** @brief Helper function to do platform independent string comparison.
         *
         *  This is required since strincmp() is not consistently available on
         *  all platforms. Some platforms use the '_' prefix, others don't even
         *  have such a function.
         *
         *  @param s1 First input string
         *  @param s2 Second input string
         *  @param n Maximum number of characters to compare
         *  @return 0 if the given strings are identical
         */
        static int ASSIMP_strincmp(byte* s1, byte* s2, int n) {
            Debug.Assert(null != s1);
            Debug.Assert(null != s2);
            if (n == 0) {
                return 0;
            }

            char c1, c2;
            int p = 0;
            do {
                if (p++ >= n) return 0;
                c1 = char.ToLower((char)*(s1++));
                c2 = char.ToLower((char)*(s2++));
            } while (c1 != 0 && (c1 == c2));

            return c1 - c2;
        }

        private static aiReturn aiGetMaterialInteger(aiMaterial material, string pKey, int type, int index, int* pOut) {
            return aiGetMaterialIntegerArray(material, pKey, type, index, pOut, null);
        }

        private static aiReturn aiGetMaterialIntegerArray(aiMaterial material, string pKey, int type, int index, int* pOut, int* pMax) {
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

        // Get a specific property from a material
        private static aiReturn aiGetMaterialProperty(aiMaterial pMat, string pKey, int type, int index, out aiMaterialProperty? pPropOut) {
            Debug.Assert(pMat != null);
            Debug.Assert(pKey != null);

            /*  Just search for a property with exactly this name ..
             *  could be improved by hashing, but it's possibly
             *  no worth the effort (we're bound to C structures,
             *  thus std::map or derivates are not applicable. */
            for (var i = 0; i < pMat.mNumProperties; ++i) {
                var prop = pMat.mProperties[i];

                if (prop != null /* just for safety ... */
                 && prop.mKey.StartsWith(pKey)
                 && (int.MaxValue == type || prop.mSemantic == type) /* UINT_MAX is a wild-card, but this is undocumented :-) */
                        && (int.MaxValue == index || prop.mIndex == index)) {
                    pPropOut = pMat.mProperties[i];
                    return aiReturn.aiReturn_SUCCESS;
                }
            }
            pPropOut = null;
            return aiReturn.aiReturn_FAILURE;
        }

        // Get a string from the material
        private static aiReturn aiGetMaterialString(aiMaterial material, string pKey, int type, int index, out string? pOut) {
            pOut = null;
            aiMaterialProperty? prop;
            aiGetMaterialProperty(material, pKey, (int)type, index, out prop);
            if (prop == null) {
                return aiReturn.aiReturn_FAILURE;
            }

            if (aiPropertyTypeInfo.aiPTI_String == prop.mType) {
                Debug.Assert(prop.mDataLength >= 5);

                // The string is stored as 32 but length prefix followed by zero-terminated UTF8 data
                //pOut.length = static_cast < unsigned int> (*reinterpret_cast<uint32_t*>(prop.mData));

                //ai_assert(pOut.length + 1 + 4 == prop.mDataLength);
                //ai_assert(!prop.mData[prop.mDataLength - 1]);
                //memcpy(pOut.data, prop.mData + 4, pOut.length + 1);
                pOut = Marshal.PtrToStringAnsi((IntPtr)prop.mData);
            }
            else {
                // TODO - implement lexical cast as well
                Import3D.Log.WriteLine("Material property pKey was found, but is no string");
                return aiReturn.aiReturn_FAILURE;
            }
            return aiReturn.aiReturn_SUCCESS;
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