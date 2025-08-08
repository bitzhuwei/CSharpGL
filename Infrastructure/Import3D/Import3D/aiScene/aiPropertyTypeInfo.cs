namespace Import3D {
    /// <summary>
    ///  @brief A very primitive RTTI system for the contents of material properties.
    /// </summary>
    public enum aiPropertyTypeInfo {
        /// <summary> Array of single-precision (32 Bit) floats
        ///
        ///  It is possible to use aiGetMaterialInteger[Array]() (or the C++-API
        ///  aiMaterial::Get()) to query properties stored in floating-point format.
        ///  The material system performs the type conversion automatically.
        /// </summary>
        aiPTI_Float = 0x1,

        /// <summary> Array of double-precision (64 Bit) floats
        ///
        ///  It is possible to use aiGetMaterialInteger[Array]() (or the C++-API
        ///  aiMaterial::Get()) to query properties stored in floating-point format.
        ///  The material system performs the type conversion automatically.
        /// </summary>
        aiPTI_Double = 0x2,

        /// <summary> The material property is an aiString.
        ///
        ///  Arrays of strings aren't possible, aiGetMaterialString() (or the
        ///  C++-API aiMaterial::Get())///must* be used to query a string property.
        /// </summary>
        aiPTI_String = 0x3,

        /// <summary> Array of (32 Bit) integers
        ///
        ///  It is possible to use aiGetMaterialFloat[Array]() (or the C++-API
        ///  aiMaterial::Get()) to query properties stored in integer format.
        ///  The material system performs the type conversion automatically.
        /// </summary>
        aiPTI_Integer = 0x4,

        /// <summary> Simple binary buffer, content undefined. Not convertible to anything.
        /// </summary>
        aiPTI_Buffer = 0x5,

        ///// <summary> This value is not used. It is just there to force the
        //    ///  compiler to map this enum to a 32 Bit integer.
        //    /// </summary>
        //#ifndef SWIG
        //    _aiPTI_Force32Bit = INT_MAX
        //#endif
    }
}