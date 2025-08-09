namespace Import3D {
    /** @brief Defines how the mapping coords for a texture are generated.
  *
  *  Real-time applications typically require full UV coordinates, so the use of
  *  the aiProcess_GenUVCoords step is highly recommended. It generates proper
  *  UV channels for non-UV mapped objects, as long as an accurate description
  *  how the mapping should look like (e.g spherical) is given.
  *  See the #AI_MATKEY_MAPPING property for more details.
  */
    public enum aiTextureMapping {
        /** The mapping coordinates are taken from an UV channel.
         *
         *  #AI_MATKEY_UVWSRC property specifies from which UV channel
         *  the texture coordinates are to be taken from (remember,
         *  meshes can have more than one UV channel).
        */
        aiTextureMapping_UV = 0x0,

        /** Spherical mapping */
        aiTextureMapping_SPHERE = 0x1,

        /** Cylindrical mapping */
        aiTextureMapping_CYLINDER = 0x2,

        /** Cubic mapping */
        aiTextureMapping_BOX = 0x3,

        /** Planar mapping */
        aiTextureMapping_PLANE = 0x4,

        /** Undefined mapping. Have fun. */
        aiTextureMapping_OTHER = 0x5,

        //# ifndef SWIG
        //        _aiTextureMapping_Force32Bit = INT_MAX
        //#endif
    }

}