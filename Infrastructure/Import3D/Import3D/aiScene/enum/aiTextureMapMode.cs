namespace Import3D {
    /** @brief Defines how UV coordinates outside the [0...1] range are handled.
*
*  Commonly referred to as 'wrapping mode'.
*/
    public enum aiTextureMapMode {
        /** A texture coordinate u|v is translated to u%1|v%1
         */
        aiTextureMapMode_Wrap = 0x0,

        /** Texture coordinates outside [0...1]
         *  are clamped to the nearest valid value.
         */
        aiTextureMapMode_Clamp = 0x1,

        /** If the texture coordinates for a pixel are outside [0...1]
         *  the texture is not applied to that pixel
         */
        aiTextureMapMode_Decal = 0x3,

        /** A texture coordinate u|v becomes u%1|v%1 if (u-(u%1))%2 is zero and
         *  1-(u%1)|1-(v%1) otherwise
         */
        aiTextureMapMode_Mirror = 0x2,

        //# ifndef SWIG
        //        _aiTextureMapMode_Force32Bit = INT_MAX
        //#endif
    }

}