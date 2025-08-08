namespace Import3D {

    /// <summary>
    /// Enumerates the methods of mesh morphing supported by Assimp.
    /// </summary>
    public enum aiMorphingMethod {
        /// <summary>Morphing method to be determined</summary>
        aiMorphingMethod_UNKNOWN = 0x0,

        /// <summary>Interpolation between morph targets</summary>
        aiMorphingMethod_VERTEX_BLEND = 0x1,

        /// <summary>Normalized morphing between morph targets</summary>
        aiMorphingMethod_MORPH_NORMALIZED = 0x2,

        /// <summary>Relative morphing between morph targets</summary>
        aiMorphingMethod_MORPH_RELATIVE = 0x3,

        /** This value is not used. It is just here to force the
             *  compiler to map this enum to a 32 Bit integer.
             */
        //# ifndef SWIG
        //        _aiMorphingMethod_Force32Bit = INT_MAX
        //#endif
    } //! enum aiMorphingMethod

}
