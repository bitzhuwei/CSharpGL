using System;

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
    public unsafe struct aiMaterialProperty {
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

    }
}