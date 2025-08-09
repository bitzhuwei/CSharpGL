using System;
using System.ComponentModel;
using System.Text;

namespace Import3D {
    /// <summary> @brief Data structure for a single material property
    ///
    ///  As an user, you'll probably never need to deal with this data structure.
    ///  Just use the provided aiGetMaterialXXX() or aiMaterial::Get() family
    ///  of functions to query material properties easily. Processing them
    ///  manually is faster, but it is not the recommended way. It isn't worth
    ///  the effort. <br>
    ///  Material property names follow a simple scheme:
    ///  @code
    ///    $<name>
    ///    ?<name>
    ///       A public property, there must be corresponding AI_MATKEY_XXX define
    ///       2nd: Public, but ignored by the #aiProcess_RemoveRedundantMaterials
    ///       post-processing step.
    ///    ~<name>
    ///       A temporary property for internal use.
    ///  @endcode
    ///  @see aiMaterial
    /// </summary>
    public unsafe class aiMaterialProperty {
        /// <summary> Specifies the name of the property (key)
        ///  Keys are generally case insensitive.
        /// </summary>
        public string mKey;

        /// <summary> Textures: Specifies their exact usage semantic.
        /// For non-texture properties, this member is always 0
        /// (or, better-said, #aiTextureType_NONE).
        /// </summary>
        public int mSemantic;

        /// <summary> Textures: Specifies the index of the texture.
        ///  For non-texture properties, this member is always 0.
        /// </summary>
        public int mIndex;

        /// <summary> Size of the buffer mData is pointing to, in bytes.
        ///  This value may not be 0.
        /// </summary>
        public int mDataLength;

        /// <summary> Type information for the property.
        ///
        /// Defines the data layout inside the data buffer. This is used
        /// by the library internally to perform debug checks and to
        /// utilize proper type conversions.
        /// (It's probably a hacky solution, but it works.)
        /// </summary>
        public aiPropertyTypeInfo mType;

        /// <summary> Binary buffer to hold the property's value.
        /// The size of the buffer is always mDataLength.
        /// </summary>
        public byte* mData;

        public override string ToString() {
            var value = "";
            switch (this.mType) {
            case aiPropertyTypeInfo.aiPTI_Float: {
                var iWrite = this.mDataLength / sizeof(float);
                var builder = new StringBuilder();
                var array = (float*)(this.mData);
                for (var a = 0; a < iWrite; ++a) {
                    var element = array[a];
                    builder.Append(element); builder.Append(", ");
                }
                value = builder.ToString();
            }
            break;
            case aiPropertyTypeInfo.aiPTI_Double: {
                var iWrite = this.mDataLength / sizeof(double);
                var builder = new StringBuilder();
                var array = (double*)(this.mData);
                for (var a = 0; a < iWrite; ++a) {
                    var element = array[a];
                    builder.Append(element); builder.Append(", ");
                }
                value = builder.ToString();
            }
            break;
            case aiPropertyTypeInfo.aiPTI_String:
            value = System.Runtime.InteropServices.Marshal.PtrToStringAnsi((IntPtr)this.mData);
            break;
            case aiPropertyTypeInfo.aiPTI_Integer:
            if (1 == this.mDataLength) {
                // bool type, 1 byte
                value = $"{(int)(*this.mData) != 0}";
            }
            else {
                var iWrite = Math.Max((this.mDataLength / sizeof(Int32)), 1);
                var builder = new StringBuilder();
                var array = (int*)(this.mData);
                for (var a = 0; a < iWrite; ++a) {
                    var element = array[a];
                    builder.Append(element); builder.Append(", ");
                }
                value = builder.ToString();
            }
            break;
            case aiPropertyTypeInfo.aiPTI_Buffer: {
                var iWrite = Math.Max((this.mDataLength / sizeof(Int32)), 1);
                var builder = new StringBuilder();
                var array = (int*)(this.mData);
                for (var a = 0; a < iWrite; ++a) {
                    var element = array[a];
                    builder.Append(element); builder.Append(", ");
                }
                value = builder.ToString();
            }
            break;
            default: throw new NotImplementedException();
            }

            return $"{mKey} : {value}";
        }
    }
}